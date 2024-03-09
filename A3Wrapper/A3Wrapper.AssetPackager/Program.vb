Imports System
Imports System.IO
Imports System.Reflection
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

        'serialize metadata into bytes
        Dim photoMetadataBytes As Byte() = JsonSerializer.SerializeToUtf8Bytes(Of PhotoListModel)(photoMetadata)

        'create zip file entries, consisting of filename and encrypted byte data
        'contents.xml
        Dim zipEntries As IList(Of ZipEntryModel) = New List(Of ZipEntryModel)
        zipEntries.Add(New ZipEntryModel() With {.Filename = "contents.txt", .Contents = encService.EncryptFile(photoMetadataBytes)})
        'photo entries
        For Each photo In photoMetadata.Photos
            zipEntries.Add(
                New ZipEntryModel() With {.Filename = photo.Filename,
                                          .Contents = encService.EncryptFile(UnencryptedAssets.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(photo.Filename)))})
        Next

        'create and write zip file
        Dim zipBytes = zipService.CreateZipArchive(zipEntries)
        File.WriteAllBytes("./encryptedPhotos.zip", zipBytes)

        'output message
        Console.WriteLine("Written encrypted files to disk in a zip archive.")
    End Sub

    Function GenerateAssetMetadata() As PhotoListModel

        Dim model As New PhotoListModel
        model.Photos.Add(New PhotoCaptionModel() With {.Filename = "photo1.jpg", .Caption = "Maya the Corgi"})
        model.Photos.Add(New PhotoCaptionModel() With {.Filename = "photo2.jpg", .Caption = "Giant waffle"})
        model.Photos.Add(New PhotoCaptionModel() With {.Filename = "photo3.jpg", .Caption = "What student loan debt feels like"})
        model.Photos.Add(New PhotoCaptionModel() With {.Filename = "photo4.jpg", .Caption = "Balloons!"})

        Return model
    End Function
End Module
