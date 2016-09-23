Imports System.Windows.Forms

Public Class dlgMainMenu

    Private mOld As AuthorData
    Private mNew As AuthorData
    Private mMerge As AuthorData

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub tvOld_MouseClick(sender As Object, ByVal e As System.EventArgs) Handles tvOld.MouseClick
        '    ' click on a node. For some types, pop up the dialog to show the piece
        Dim clickNode As TreeNode = sender.selectednode
        If (Not IsNothing(clickNode)) Then
            SetupMenuItemFields(clickNode, Color.PaleGreen)
        End If
    End Sub

    Private Sub tvNew_MouseClick(sender As Object, ByVal e As System.EventArgs) Handles tvNew.MouseClick
        '    ' click on a node. For some types, pop up the dialog to show the piece
        Dim clickNode As TreeNode = sender.selectednode
        If (Not IsNothing(clickNode)) Then
            SetupMenuItemFields(clickNode, Color.LightBlue)
        End If
    End Sub

    Private Sub tvOldMrg_MouseClick(sender As Object, ByVal e As System.EventArgs) Handles tvMerge.MouseClick
        '    ' click on a node. For some types, pop up the dialog to show the piece
        Dim clickNode As TreeNode = sender.selectednode
        If (Not IsNothing(clickNode)) Then
            SetupMenuItemFields(clickNode, Color.Pink)
        End If
    End Sub

    Private Sub tvOld_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvOld.AfterSelect
        ' click on a node. For some types, pop up the dialog to show the piece
        SetupMenuItemFields(e.Node, Color.PaleGreen)
    End Sub

    Private Sub tvNew_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvNew.AfterSelect
        ' click on a node. For some types, pop up the dialog to show the piece
        SetupMenuItemFields(e.Node, Color.LightBlue)
    End Sub

    Private Sub tvMerge_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvMerge.AfterSelect
        ' click on a node. For some types, pop up the dialog to show the piece
        SetupMenuItemFields(e.Node, Color.Pink)
    End Sub

    Private Sub SetupMenuItemFields(node As TreeNode, bgcolor As Color)
        Dim theText As String = ""

        theText = GetNodeText(node)

        dlgMenuItem.Text = "Menu Component Contents for {" & node.Name & "}"
        dlgMenuItem.txtMenuItem.Text = theText
        dlgMenuItem.txtMenuItem.BackColor = bgcolor
        dlgMenuItem.Show()
    End Sub

    Private Function GetNodeText(node As TreeNode) As String
        ' recursive obtaining all the text for this node and its children
        Dim s As String = ""
        Dim info As InfoMenuNode = node.Tag

        s = info.TextPart1(False)
        For Each n As TreeNode In node.Nodes
            s = s & GetNodeText(n)
        Next
        s = s & info.TextPart2(False)
        Return s
    End Function

    Public Sub RegisterAuthorData(theOld As AuthorData, theNew As AuthorData, theMerge As AuthorData)
        ' saving references to Author data for the Copy buttons
        mOld = theOld
        mNew = theNew
        mMerge = theMerge
    End Sub

    Private Sub btnCopyOldClipboard_Click(sender As Object, e As EventArgs) Handles btnCopyOldClipboard.Click
        CopyToClipboard(mOld.GetTiddler("MainMenu"))
    End Sub
    Private Sub btnCopyNewClipboard_Click(sender As Object, e As EventArgs) Handles btnCopyNewClipboard.Click
        CopyToClipboard(mNew.GetTiddler("MainMenu"))
    End Sub
    Private Sub btnCopyMergeClipboard_Click(sender As Object, e As EventArgs) Handles btnCopyMergeClipboard.Click
        CopyToClipboard(mMerge.GetTiddler("MainMenu"))
    End Sub

    Private Sub CopyToClipboard(s As String)
        ' shift click does not decode the text. Regular click decodes
        If (Not ModifierKeys.HasFlag(Keys.Shift)) Then
            s = System.Web.HttpUtility.HtmlDecode(s)
            s = s.Replace("\n", vbCrLf)
        End If

        Clipboard.SetText(s)
    End Sub

    Private Sub dlgMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolTip1.SetToolTip(btnCopyOldClipboard, "Click to get decoded text. " & vbCrLf & "Shift-Click to get encoded text")
        ToolTip1.SetToolTip(btnCopyNewClipboard, "Click to get decoded text. " & vbCrLf & "Shift-Click to get encoded text")
        ToolTip1.SetToolTip(btnCopyMergeClipboard, "Click to get decoded text. " & vbCrLf & "Shift-Click to get encoded text")

    End Sub
End Class
