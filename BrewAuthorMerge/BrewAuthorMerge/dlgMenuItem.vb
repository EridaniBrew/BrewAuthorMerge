Imports System.Windows.Forms
Imports System.Runtime.InteropServices


Public Class dlgMenuItem

    ' This stuff is here to set the tab width to 4 characters
    Private Const EM_SETTABSTOPS = &HCB
    <DllImport("User32.dll", CharSet:=CharSet.Auto)>
    Private Shared Sub SendMessage(ByVal hWnd As IntPtr, msg As Integer, wParam As Integer, lParam() As Integer)
    End Sub


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgMenuItem_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim tabWidth = 4     ' want 4 character wide tabs
        Dim vals() As Integer = {tabWidth * 4}
        SendMessage(txtMenuItem.Handle, EM_SETTABSTOPS, 1, vals)
    End Sub

End Class
