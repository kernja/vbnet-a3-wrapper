Imports System.Runtime.Serialization
Imports System.Text.Json.Serialization

<Serializable>
Public Class PhotoListModel
    Public Property Photos As IList(Of PhotoCaptionModel) = New List(Of PhotoCaptionModel)

    <JsonIgnore>
    Public Property Index As Integer = 0

    Public Function IncrementIndexAndGetPhoto(incrementValue As Integer) As PhotoCaptionModel
        Index = Index + incrementValue

        If (Index < 0) Then Index = Photos.Count - 1
        If (Index >= Photos.Count) Then Index = 0

        Return Photos(Index)
    End Function
End Class
