Imports System.Net.NetworkInformation

Public Class MACService
    Public Function GetAddresses() As String
        'query all network interfaces physical addresses
        'join them into a semi-colon separated string
        Return String.Join(";", NetworkInterface.GetAllNetworkInterfaces().Select(Of String)(Function(x) x.GetPhysicalAddress().ToString()))
    End Function

    Public Function HasAddress(mac As String) As Boolean
        'parameter checks
        If (String.IsNullOrWhiteSpace(mac)) Then Return False

        'get addresses and boundary check
        Dim addresses = GetAddresses()
        If String.IsNullOrWhiteSpace(addresses) Then Return False

        'return test result
        Return addresses.Contains(mac)
    End Function
End Class
