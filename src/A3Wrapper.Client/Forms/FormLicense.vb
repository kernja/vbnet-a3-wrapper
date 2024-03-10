Imports A3Wrapper.Client.My.ClientResources
Imports A3Wrapper.Services

Public Class FormLicense
    Public Property clientService As ClientService

    Private Sub frmLicense_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rtbLicense.SelectedRtf = ClientResources.License
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        clientService.QuitProgram()
    End Sub

    Private Sub FormLicense_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        clientService.QuitProgram()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        clientService.ShowKeyScreen()
    End Sub
End Class