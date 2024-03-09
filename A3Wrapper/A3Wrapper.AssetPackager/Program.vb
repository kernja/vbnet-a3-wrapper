Imports System
Imports System.IO
Imports System.Resources
Imports System.Text
Imports System.Text.Json
Imports A3Wrapper.AssetPackager.My.Resources
Imports A3Wrapper.Models
Imports A3Wrapper.Services

Module Program
    Sub Main(args As String())
        'create services
        Dim encService As New EncryptionService()
        Dim zipService As New ZipService()

        'generate metadata
        Dim photoMetadata As PhotoListModel = GenerateAssetMetadata()
        Dim photoMetadataBytes As Byte() = JsonSerializer.SerializeToUtf8Bytes(Of PhotoListModel)(photoMetadata)

        'encrypt photo metadata
        Dim encMetadata As Byte() = encService.EncryptFile(photoMetadataBytes)

        'create zip file entries
        'contents
        Dim zipEntries As IList(Of ZipEntryModel) = New List(Of ZipEntryModel)
        zipEntries.Add(New ZipEntryModel() With {.Filename = "contents.txt", .Contents = encService.EncryptFile(photoMetadataBytes)})
        'photos
        For Each photo In photoMetadata.Photos
            zipEntries.Add(
                New ZipEntryModel() With {.Filename = photo.Filename,
                                          .Contents = encService.EncryptFile(UnencryptedAssets.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(photo.Filename)))})
        Next

        'write zip
        Dim zipBytes = zipService.CreateZipArchive(zipEntries)
        File.WriteAllBytes("./encryptedPhotos.zip", zipBytes)

        'output message
        Console.WriteLine("Written encrypted files to disk in a zip archive.")
    End Sub

    Function GenerateAssetMetadata() As PhotoListModel

        Dim pList As New PhotoListModel
        pList.Photos.Add(New PhotoCaptionModel() With {.Filename = "photo1.jpg", .Caption = "Maya the Corgi"})
        pList.Photos.Add(New PhotoCaptionModel() With {.Filename = "photo2.jpg", .Caption = "Giant waffle"})
        pList.Photos.Add(New PhotoCaptionModel() With {.Filename = "photo3.jpg", .Caption = "What student loan debt feels like"})
        pList.Photos.Add(New PhotoCaptionModel() With {.Filename = "photo4.jpg", .Caption = "Balloons!"})

        Return pList
        'Return JsonSerializer.SerializeToUtf8Bytes(Of PhotoListModel)(pList)
    End Function
End Module
