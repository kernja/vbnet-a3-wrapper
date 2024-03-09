Imports System.Runtime.Serialization
Imports System.Text.Json.Serialization

<Serializable>
Public Class PhotoListModel
    Public Property Photos As IList(Of PhotoCaptionModel) = New List(Of PhotoCaptionModel)

    <JsonIgnore>
    Public Property Index As Integer

End Class
