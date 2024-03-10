Public Class FormViewer
    Public Property clientService As ClientService

    Public Sub GetPhotoForDisplay(incrementValue As Integer)
        Dim photo = clientService.GetPhotoForDisplay(incrementValue)
        picView.Image = photo.Photo
        lblCaption.Text = photo.Caption
    End Sub

    Private Sub FormViewer_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        clientService.QuitProgram()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        GetPhotoForDisplay(1)
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        GetPhotoForDisplay(-1)
    End Sub
End Class
