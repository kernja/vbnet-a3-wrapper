Imports System.IO
Imports System.Text
Imports System.Text.Json
Imports A3Wrapper.Models
Imports A3Wrapper.SharedResources.My.Resources

Public Class LicenseService
    Dim discService As DiscService
    Dim keyService As KeyService
    Dim macService As MACService
    Dim encryptionService As EncryptionService

    Dim name As String
    Dim seed As Integer

    Public Sub New(productName As String, keySeed As String)
        If (String.IsNullOrWhiteSpace(productName)) Then Throw New ArgumentException(NameOf(productName))
        If (String.IsNullOrWhiteSpace(keySeed)) Then Throw New ArgumentException(NameOf(keySeed))
        If (Integer.TryParse(keySeed, seed) = False) Then
            Throw New ArgumentException(NameOf(keySeed))
        End If

        name = productName
        discService = New DiscService()
        macService = New MACService()
        encryptionService = New EncryptionService()
        keyService = New KeyService(seed)
    End Sub
    Public Function GenerateKey(seed As String) As String
        Return keyService.GenerateKey(seed)
    End Function
    Public Function VerifyKey(key As String) As (result As Boolean, message As String)
        Try
            If keyService.VerifyKey(key) = False Then Return (False, A3Strings.ERROR_INVALID_KEY)
        Catch ex As Exception
            Return (False, A3Strings.ERROR_INVALID_KEY)
        End Try

        Try
            If (WriteLicenseFile() = False) Then Return (False, A3Strings.ERROR_WRITE_LICENSE_ERROR)
        Catch ex As Exception
            Return (False, A3Strings.ERROR_WRITE_LICENSE_ERROR)
        End Try

        Return (True, String.Empty)
    End Function
    Public Function DiscCheck() As (result As Boolean, message As String)
        If (discService.HasDiscInDrive(name) = False) Then Return (False, A3Strings.ERROR_INSERT_DISC)

        Return (True, String.Empty)
    End Function

    Public Function ContinuousLicenseCheck() As (result As Boolean, message As String)
        If (discService.HasDiscInDrive(name) = False) Then Return (False, A3Strings.ERROR_INSERT_DISC)
        If (VerifyLicenseFile() = False) Then Return (False, A3Strings.ERROR_READ_LICENSE_ERROR)

        Return (True, String.Empty)
    End Function
    Public Function VerifyLicenseFile() As Boolean
        If (File.Exists(A3Resources.LicenseFile) = False) Then Return False

        Try
            Dim encryptedBytes = File.ReadAllBytes(A3Resources.LicenseFile)
            Dim decryptedBytes = encryptionService.DecryptFile(encryptedBytes)
            Dim license = JsonSerializer.Deserialize(Of LicenseModel)(Encoding.UTF8.GetString(decryptedBytes))

            If (Not (license Is Nothing) And (String.Equals(license.ProductName, name) And (macService.HasAddress(license.NetworkAdapters)))) Then
                Return True
            End If

            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function WriteLicenseFile() As Boolean
        If (VerifyLicenseFile() = True) Then Return True

        Try
            File.Delete(A3Resources.LicenseFile)
            Dim license = New LicenseModel() With {.NetworkAdapters = macService.GetAddresses(), .ProductName = name}
            Dim rawBytes = JsonSerializer.SerializeToUtf8Bytes(Of LicenseModel)(license)
            Dim encryptedBytes = encryptionService.EncryptFile(rawBytes)
            File.WriteAllBytes(A3Resources.LicenseFile, encryptedBytes)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
