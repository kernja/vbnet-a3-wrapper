Imports System.IO
Imports System.Text.Json
Imports A3Wrapper.Client.My.ClientResources
Imports A3Wrapper.Models
Imports A3Wrapper.Services

Public Class PhotoService
    Private Const ARCHIVE_MANIFEST As String = "contents.txt"
    Private encryptionService As EncryptionService
    Private zipService As ZipService
    Dim photoList As PhotoListModel

    Public Sub New()
        encryptionService = New EncryptionService()
        zipService = New ZipService()
        photoList = JsonSerializer.Deserialize(Of PhotoListModel)(encryptionService.DecryptFile(zipService.GetFileFromArchive(ARCHIVE_MANIFEST, ClientResources.encryptedPhotos)))
    End Sub

    Public Function GetPhotoForDisplay(incrementValue As Integer) As (Image, String)
        Dim photo = photoList.IncrementIndexAndGetPhoto(incrementValue)
        Using memoryStream = New MemoryStream(encryptionService.DecryptFile(zipService.GetFileFromArchive(photo.Filename, ClientResources.encryptedPhotos)))
            Return (Image.FromStream(memoryStream), photo.Caption)
        End Using

    End Function
End Class
