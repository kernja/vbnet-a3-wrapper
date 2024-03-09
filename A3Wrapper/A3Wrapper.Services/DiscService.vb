Imports System.IO

Public Class DiscService
    Public Function HasDisk(name As String) As Boolean
        If (String.IsNullOrWhiteSpace(name)) Then Return False

        For Each drive In DriveInfo.GetDrives()
            If drive.DriveType = DriveType.CDRom Then
                If String.Equals(drive.VolumeLabel, name) Then Return True
            End If
        Next

        Return False
    End Function
End Class
