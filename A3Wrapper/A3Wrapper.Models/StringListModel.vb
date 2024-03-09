<Serializable>
Module StringListModel
    Public Property Items As IList(Of String) = New List(Of String)

    Public Function Contains(value As String) As Boolean
        If (Items Is Nothing) Then
            Return False
        End If
        If (String.IsNullOrWhiteSpace(value)) Then
            Return False
        End If

        value = value.Trim()

        Return Items.Any(Function(x) x.Equals(value))
    End Function
End Module
