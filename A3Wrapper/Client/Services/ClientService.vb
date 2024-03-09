Imports A3Wrapper.Services

Public Class ClientService
    Dim frmKey As FormKey
    Dim frmLicense As FormLicense
    Dim frmViewer As FormViewer

    Dim licenseService As LicenseService

    Sub New(programName As String, keySeed As String, keyForm As FormKey, licenseForm As FormLicense, viewerForm As FormViewer)
        'generate license service
        licenseService = New LicenseService(programName, keySeed)
        'output a license key to the console
        Debug.Print(licenseService.GenerateKey("ABCD"))

        'create forms
        frmKey = keyForm
        frmLicense = licenseForm
        frmViewer = viewerForm
        frmKey.clientService = Me
        frmLicense.clientService = Me
        frmViewer.clientService = Me
    End Sub
    Public Sub LaunchProgram()
        Dim discCheck As (Boolean, String)
        discCheck = licenseService.DiscCheck()

        'do disc check
        While (discCheck.Item1 = False)
            If (MsgBox(discCheck.Item2, MsgBoxStyle.Critical + MsgBoxStyle.OkCancel, "Error") = MsgBoxResult.Cancel) Then
                QuitProgram()
            End If
        End While

        'do license check
        If (licenseService.VerifyLicenseFile() = False) Then
            ShowLicenseScreen()
        Else
            ShowViewerScreen()
        End If
    End Sub
    Public Sub VerifyKey(key As String)
        Dim keyCheck As (Boolean, String)
        keyCheck = licenseService.VerifyKey(key)

        If (keyCheck.Item1 = False) Then
            If (MsgBox(keyCheck.Item2, MsgBoxStyle.Critical, "Error") = MsgBoxResult.Cancel) Then
                QuitProgram()
            End If
        Else
            MsgBox("The program will now start.", MsgBoxStyle.Information, "Information")
            ShowViewerScreen()
        End If
    End Sub
    Public Sub ShowLicenseScreen()
        frmKey.Hide()
        frmViewer.Hide()
        frmLicense.ShowDialog()
    End Sub
    Public Sub ShowKeyScreen()
        frmViewer.Hide()
        frmLicense.Hide()
        frmKey.ShowDialog()
    End Sub
    Public Sub ShowViewerScreen()
        frmLicense.Hide()
        frmKey.Hide()
        frmViewer.ShowDialog()
    End Sub

    Public Sub QuitProgram()
        frmLicense.Hide()
        frmKey.Hide()
        frmViewer.Hide()
        End
    End Sub
End Class
