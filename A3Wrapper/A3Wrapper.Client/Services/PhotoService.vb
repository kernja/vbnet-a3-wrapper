Imports System.IO
Imports System.Text.Json
Imports A3Wrapper.Client.My.ClientResources
Imports A3Wrapper.Models
Imports A3Wrapper.Services
Imports A3Wrapper.SharedResources.My.Resources

Public Class PhotoService
    Private encryptionService As EncryptionService
    Private zipService As ZipService
    Dim photoList As PhotoListModel

    Public Sub New()
        encryptionService = New EncryptionService()
        zipService = New ZipService()
        photoList = JsonSerializer.Deserialize(Of PhotoListModel)(encryptionService.DecryptFile(zipService.GetFileFromArchive(A3Resources.ZipManifestFile, ClientResources.encryptedPhotos)))
    End Sub

    Public Function GetPhotoForDisplay(incrementValue As Integer) As PhotoDisplayModel
        Dim photo = photoList.IncrementIndexAndGetPhoto(incrementValue)
        Using memoryStream = New MemoryStream(encryptionService.DecryptFile(zipService.GetFileFromArchive(photo.Filename, ClientResources.encryptedPhotos)))
            Return New PhotoDisplayModel() With {.Photo = Image.FromStream(memoryStream), .Caption = photo.Caption}
        End Using

    End Function
End Class
