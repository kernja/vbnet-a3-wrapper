Imports A3Wrapper.Client.My.ClientResources


Public Class frmLicense
    Private Sub frmLicense_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load license file, embedded in application as unencrypted RTF
        rtbLicense.SelectedRtf = ClientResources.License
    End Sub
End Class