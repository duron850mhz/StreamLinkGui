Imports System.Runtime.InteropServices

Public Class IniFile
    Private iniPath As String

    Public Sub New(path As String)
        iniPath = path
    End Sub

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function GetPrivateProfileString(
        ByVal section As String,
        ByVal key As String,
        ByVal defaultValue As String,
        ByVal retVal As System.Text.StringBuilder,
        ByVal size As Integer,
        ByVal filePath As String) As Integer
    End Function

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function WritePrivateProfileString(
        ByVal section As String,
        ByVal key As String,
        ByVal value As String,
        ByVal filePath As String) As Boolean
    End Function

    Public Function Read(section As String, key As String, defaultValue As String) As String
        Dim sb As New System.Text.StringBuilder(256)
        GetPrivateProfileString(section, key, defaultValue, sb, sb.Capacity, iniPath)
        Return sb.ToString()
    End Function

    Public Sub Write(section As String, key As String, value As String)
        WritePrivateProfileString(section, key, value, iniPath)
    End Sub
End Class