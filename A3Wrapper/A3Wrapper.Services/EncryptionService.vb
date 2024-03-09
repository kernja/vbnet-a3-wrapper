Imports System.IO
Imports System.Security.Cryptography

Public Class EncryptionService
    Private _desProvider As New TripleDESCryptoServiceProvider

    Public Sub EncryptionService()
        Dim pwd As String = ChrW(86) & ChrW(55) & ChrW(89) & ChrW(76) & ChrW(79) & ChrW(51) & ChrW(50) & ChrW(81) & ChrW(90) & ChrW(75) & ChrW(84) & ChrW(74) & ChrW(65) & ChrW(76) & ChrW(51) & ChrW(76) & ChrW(76) & ChrW(71) & ChrW(51) & ChrW(88) & ChrW(90) & ChrW(74) & ChrW(87) & ChrW(81) & ChrW(70) & ChrW(80) & ChrW(72) & ChrW(71) & ChrW(79) & ChrW(80) & ChrW(50) & ChrW(67) & ChrW(73) & ChrW(77) & ChrW(77) & ChrW(66) & ChrW(76) & ChrW(57) & ChrW(73) & ChrW(52) & ChrW(50) & ChrW(76) & ChrW(77) & ChrW(54) & ChrW(74) & ChrW(54) & ChrW(83) & ChrW(85) & ChrW(53) & ChrW(66) & ChrW(73) & ChrW(90) & ChrW(49) & ChrW(77) & ChrW(81) & ChrW(76) & ChrW(75) & ChrW(73) & ChrW(71) & ChrW(56) & ChrW(86) & ChrW(85) & ChrW(67) & ChrW(75) & ChrW(83) & ChrW(81) & ChrW(65) & ChrW(88) & ChrW(57) & ChrW(49) & ChrW(57) & ChrW(76) & ChrW(56) & ChrW(56) & ChrW(53) & ChrW(79) & ChrW(55) & ChrW(90) & ChrW(71) & ChrW(73) & ChrW(55) & ChrW(86) & ChrW(76) & ChrW(77) & ChrW(71) & ChrW(66) & ChrW(76) & ChrW(54) & ChrW(53) & ChrW(65) & ChrW(49) & ChrW(68) & ChrW(51) & ChrW(74) & ChrW(73) & ChrW(72) & ChrW(73) & ChrW(66) & ChrW(78) & ChrW(50) & ChrW(53) & ChrW(53) & ChrW(85) & ChrW(69) & ChrW(66) & ChrW(55) & ChrW(50) & ChrW(50) & ChrW(81) & ChrW(67) & ChrW(79) & ChrW(84) & ChrW(66) & ChrW(55) & ChrW(66) & ChrW(57) & ChrW(74) & ChrW(89) & ChrW(69) & ChrW(82) & ChrW(70) & ChrW(69) & ChrW(50) & ChrW(57) & ChrW(57) & ChrW(53) & ChrW(82) & ChrW(89) & ChrW(90) & ChrW(88) & ChrW(70) & ChrW(53) & ChrW(77) & ChrW(78) & ChrW(77) & ChrW(66) & ChrW(66) & ChrW(71) & ChrW(75) & ChrW(74) & ChrW(73) & ChrW(83) & ChrW(79) & ChrW(51) & ChrW(85) & ChrW(72) & ChrW(67) & ChrW(54) & ChrW(72) & ChrW(74) & ChrW(55) & ChrW(84) & ChrW(55) & ChrW(54) & ChrW(87) & ChrW(49) & ChrW(68) & ChrW(86) & ChrW(69) & ChrW(71) & ChrW(79) & ChrW(68) & ChrW(66) & ChrW(51) & ChrW(54) & ChrW(83) & ChrW(71) & ChrW(87) & ChrW(84) & ChrW(65) & ChrW(55) & ChrW(67) & ChrW(78) & ChrW(53) & ChrW(73) & ChrW(86) & ChrW(89) & ChrW(56) & ChrW(78) & ChrW(50) & ChrW(51) & ChrW(86) & ChrW(81) & ChrW(81) & ChrW(90) & ChrW(85) & ChrW(56) & ChrW(81) & ChrW(49) & ChrW(85) & ChrW(56) & ChrW(79) & ChrW(67) & ChrW(69) & ChrW(52) & ChrW(70) & ChrW(81) & ChrW(86) & ChrW(54) & ChrW(67) & ChrW(66) & ChrW(79) & ChrW(76) & ChrW(72) & ChrW(76) & ChrW(53) & ChrW(70) & ChrW(66) & ChrW(87) & ChrW(66) & ChrW(67) & ChrW(69) & ChrW(73) & ChrW(77) & ChrW(77) & ChrW(51) & ChrW(86) & ChrW(85) & ChrW(67) & ChrW(76) & ChrW(84) & ChrW(89) & ChrW(54) & ChrW(56) & ChrW(66) & ChrW(83) & ChrW(65) & ChrW(74) & ChrW(66) & ChrW(68) & ChrW(69) & ChrW(67) & ChrW(66) & ChrW(75) & ChrW(90) & ChrW(79) & ChrW(74) & ChrW(74) & ChrW(70) & ChrW(53) & ChrW(80) & ChrW(55) & ChrW(52) & ChrW(90) & ChrW(83) & ChrW(51) & ChrW(71) & ChrW(90) & ChrW(50) & ChrW(66) & ChrW(84) & ChrW(54) & ChrW(83) & ChrW(85) & ChrW(83) & ChrW(76)
        Dim salt As Byte() = New Byte() {3, 4, 9, 1, 5, 7, 4, 2}

        Me.ConfigureProvider(pwd, salt)
    End Sub
    Public Sub EncryptionService(ByVal pwd As String, ByVal salt As Byte())
        Me.ConfigureProvider(pwd, salt)
    End Sub
    Private Sub ConfigureProvider(ByVal pwd As String, ByVal salt As Byte())
        Dim deriver As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(pwd, salt)

        _desProvider.Key = deriver.GetBytes(_desProvider.LegalKeySizes(0).MaxSize \ 8)
        _desProvider.IV = deriver.GetBytes(_desProvider.BlockSize \ 8)
    End Sub
    Public Function EncryptFile(rawAsset As Byte()) As Byte()
        Return PerformEncryptionAction(rawAsset, True)
    End Function
    Public Function DecryptFile(rawAsset As Byte()) As Byte()
        Return PerformEncryptionAction(rawAsset, False)
    End Function

    Private Function PerformEncryptionAction(rawAsset As Byte(), isEncrypting As Boolean)
        Dim incomingStream As New MemoryStream(rawAsset)

        'Create the encrypter
        Dim encryptor As ICryptoTransform
        encryptor = If(isEncrypting, _desProvider.CreateEncryptor(), _desProvider.CreateDecryptor())

        'Create the cryptostream
        Dim cryptoStream As CryptoStream
        cryptoStream = New CryptoStream(incomingStream, encryptor, CryptoStreamMode.Read)

        'Perform the encrpytion
        Dim outputBytes As Byte()
        Using destinationStream As New MemoryStream()
            cryptoStream.CopyTo(destinationStream)
            outputBytes = destinationStream.ToArray()
        End Using

        'Return result
        Return outputBytes
    End Function
End Class
