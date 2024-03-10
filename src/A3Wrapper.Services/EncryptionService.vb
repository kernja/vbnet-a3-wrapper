Imports System.IO
Imports System.Security.Cryptography
Imports A3Wrapper.SharedResources.My.Resources

Public Class EncryptionService
    Private _desProvider As New TripleDESCryptoServiceProvider

    Public Sub New()
        Dim pwd As String = A3Resources.EncryptionPassword
        Dim salt As Byte() = A3Resources.EncryptionSalt.Split(",").Select(Of Byte)(Function(x) Byte.Parse(x)).ToArray()

        Me.ConfigureProvider(pwd, salt)
    End Sub
    Public Sub New(ByVal pwd As String, ByVal salt As Byte())
        Me.ConfigureProvider(pwd, salt)
    End Sub
    Private Sub ConfigureProvider(ByVal pwd As String, ByVal salt As Byte())
        Dim deriver As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(pwd, salt)

        _desProvider.Key = deriver.GetBytes(_desProvider.LegalKeySizes(0).MaxSize \ 8)
        _desProvider.IV = deriver.GetBytes(_desProvider.BlockSize \ 8)
        _desProvider.Padding = PaddingMode.PKCS7

    End Sub
    Public Function EncryptFile(rawAsset As Byte()) As Byte()
        'Create the encrypter
        Dim encryptor As ICryptoTransform
        encryptor = _desProvider.CreateEncryptor()

        'Perform the encrpytion
        'Use memory and crypto streams for large data blocks
        Return encryptor.TransformFinalBlock(rawAsset, 0, rawAsset.Length)
    End Function
    Public Function DecryptFile(rawAsset As Byte()) As Byte()
        Dim decryptor As ICryptoTransform
        decryptor = _desProvider.CreateDecryptor()

        'Perform the encrpytion
        'Use memory and crypto streams for large data blocks
        Return decryptor.TransformFinalBlock(rawAsset, 0, rawAsset.Length)
    End Function

End Class
