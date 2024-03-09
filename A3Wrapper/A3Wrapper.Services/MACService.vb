Imports System.Net.NetworkInformation

Public Class MACService
    Public Function GetAddresses() As String
        Return String.Join(";", NetworkInterface.GetAllNetworkInterfaces().Select(Of String)(Function(x) x.GetPhysicalAddress().ToString()))
    End Function

    Public Function HasAddress(mac As String) As Boolean
        If (String.IsNullOrWhiteSpace(mac)) Then Return False

        Dim addresses = GetAddresses()
        If (String.IsNullOrWhiteSpace(addresses)) Then Return False

        Return (addresses.Contains(mac))
    End Function
End Class
