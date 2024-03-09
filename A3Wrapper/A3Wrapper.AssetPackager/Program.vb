Imports System
Imports System.IO
Imports System.Text.Json
Imports A3Wrapper.Models
Imports A3Wrapper.Services

Module Program
    Sub Main(args As String())
        'generate metadata
        Dim photoMetadata As PhotoListModel = GenerateAssetMetadata()
        Dim photoMetadataBytes As Byte() = JsonSerializer.SerializeToUtf8Bytes(Of PhotoListModel)(photoMetadata)

        'create encryption service
        Dim encService As New EncryptionService()

        'encrypt photo metadata and save

        Dim encMetadata As Byte() = encService.EncryptFile(photoMetadataBytes)
        File.WriteAllBytes("./rawMetadata.txt", photoMetadataBytes)
        File.WriteAllBytes("./encryptedMetadata.txt", encMetadata)
        File.WriteAllBytes("./decryptedMetadata.txt", encService.DecryptFile(encMetadata))

        Console.WriteLine("Hello World!")
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
