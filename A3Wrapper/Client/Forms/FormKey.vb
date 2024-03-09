Public Class FormKey
    Public Property clientService As ClientService

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        clientService.QuitProgram()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        clientService.VerifyKey(txtKey.Text)
    End Sub
End Class