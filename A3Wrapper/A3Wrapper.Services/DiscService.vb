Imports System.IO

Public Class DiscService
    Public Function HasDiscInDrive(name As String) As Boolean
        'parameter check
        If String.IsNullOrWhiteSpace(name) Then Return False

        'query all drives
        For Each drive In DriveInfo.GetDrives()
            'check if disc inserted in drive name matches passed in parameter
            If drive.DriveType = DriveType.CDRom Then
                If String.Equals(drive.VolumeLabel, name) Then Return True
            End If
        Next

        Return False
    End Function
End Class
