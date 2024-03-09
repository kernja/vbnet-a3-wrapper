Imports System.IO
Imports System.IO.Compression
Imports A3Wrapper.Models

Public Class ZipService
    Public Function CreateZipArchive(files As IList(Of ZipEntryModel)) As Byte()

        Dim zipBytes As Byte()

        'Create memory stream to hold zip contents
        Using memoryStream As New MemoryStream
            'create the zip archive
            Using zipArchive = New ZipArchive(memoryStream, ZipArchiveMode.Create, False)
                'iterate through each file passed in through the list
                For Each fileEntry As ZipEntryModel In files
                    'create a zip entry for each file
                    Dim zipEntry = zipArchive.CreateEntry(fileEntry.Filename)

                    'write bytes
                    Using streamWriter As New StreamWriter(zipEntry.Open)
                        streamWriter.BaseStream.Write(fileEntry.Contents, 0, fileEntry.Contents.Length)
                    End Using

                Next


            End Using
            zipBytes = memoryStream.ToArray()
        End Using

        Return zipBytes
    End Function

    Public Function GetFileFromArchive(filename As String, archive As Byte()) As Byte()
        'Create memory stream to hold zip contents
        Using memoryStream As New MemoryStream(archive)
            'open the zip archive
            Using zipArchive = New ZipArchive(memoryStream, ZipArchiveMode.Read, False)
                'iterate through each file passed in through the list
                For Each zipEntry In zipArchive.Entries
                    If (String.Equals(zipEntry.Name, filename)) Then
                        'create a memory stream to read the entry
                        Using zipStream As DeflateStream = zipEntry.Open()
                            Using decompressedStream As New MemoryStream()
                                zipStream.CopyTo(decompressedStream)
                                Return decompressedStream.ToArray()
                            End Using
                        End Using
                    End If
                Next
            End Using
        End Using

        Throw New FileNotFoundException("Entry not found in ZIP file.", filename)
    End Function
End Class
