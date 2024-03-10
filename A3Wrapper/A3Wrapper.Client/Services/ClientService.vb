Imports A3Wrapper.Services
Imports A3Wrapper.SharedResources.My.Resources

Public Class ClientService
    Dim frmKey As FormKey
    Dim frmLicense As FormLicense
    Dim frmViewer As FormViewer

    Dim licenseService As LicenseService
    Dim photoService As PhotoService

    Sub New(programName As String, keySeed As String, keyForm As FormKey, licenseForm As FormLicense, viewerForm As FormViewer)
        'generate license service
        licenseService = New LicenseService(programName, keySeed)
        photoService = New PhotoService()

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
        'make sure that the disc is in the drive before doing anything else
        While (discCheck.Item1 = False)
            If (MsgBox(discCheck.Item2, MsgBoxStyle.Critical + MsgBoxStyle.OkCancel, A3Strings.MSGBOX_TITLE_ERROR) = MsgBoxResult.Cancel) Then
                QuitProgram()
            End If
            'reperform test
            discCheck = licenseService.DiscCheck()
        End While

        'do license check
        'if no license is found, or if it is invalid, show the license promot
        If (licenseService.VerifyLicenseFile() = False) Then
            ShowLicenseScreen()
        Else
            'license is valid, show the viewer screen
            ShowViewerScreen()
        End If
    End Sub

    'This sub is called by frmKey.btnNext, with the value passed in from the form's text box
    Public Sub VerifyKey(key As String)
        Dim keyCheck As (Boolean, String)
        keyCheck = licenseService.VerifyKey(key)

        If (keyCheck.Item1 = False) Then
            If (MsgBox(keyCheck.Item2, MsgBoxStyle.Critical, A3Strings.MSGBOX_TITLE_ERROR) = MsgBoxResult.Cancel) Then
                QuitProgram()
            End If
        Else
            'the key is valid, start the program
            MsgBox(A3Strings.INFO_PROGRAM_START, MsgBoxStyle.Information, A3Strings.MSGBOX_TITLE_INFORMATION)
            ShowViewerScreen()
        End If
    End Sub

    'this sub is called by frmViewer on inital photo load and when the user changes images

    Public Function GetPhotoForDisplay(incrementValue As Integer) As PhotoDisplayModel
        Dim continuousCheck As (Boolean, String)

        'force a continuous (license and disc) check
        continuousCheck = licenseService.ContinuousLicenseCheck()

        While (continuousCheck.Item1 = False)
            If (MsgBox(continuousCheck.Item2, MsgBoxStyle.Critical + MsgBoxStyle.OkCancel, A3Strings.MSGBOX_TITLE_ERROR) = MsgBoxResult.Cancel) Then
                QuitProgram()
            End If
            'reperform check
            continuousCheck = licenseService.ContinuousLicenseCheck()
        End While

        'check passed, load the image
        Return photoService.GetPhotoForDisplay(incrementValue)
    End Function

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
        frmViewer.GetPhotoForDisplay(0)
        frmViewer.ShowDialog()
    End Sub

    Public Sub QuitProgram()
        frmLicense.Hide()
        frmKey.Hide()
        frmViewer.Hide()
        End
    End Sub
End Class
