Imports System
Imports System.IO
Imports System.Web
'Imports System.Runtime.InteropServices

Public Class BrewAuthorMerge

    ' Version History
    '    1.0.0.0      Original release
    '    1.1.0.0      Handle white space lines in mainMenu
    '                 Fix case where Old tiddler (not Bob) needed to replace New Tiddler (Bob)
    '                 Use proper Help file
    '    1.2.0.0      Handle case where Customized file exists, but Bob's tiddler has a newer date.
    '                 Change name ofOld to Customized

    Public gOLD As AuthorData
    Public gNEW As AuthorData
    Public gMerge As AuthorData

    Private mNeedFileSaved As Boolean = False           ' true after merge, before File is saved

    ' search pieces for parsing
    Private Const END_OF_HEADER = "<div id=""storeArea"">"
    Private Const START_OF_TRAILER = "<!--POST-BODY-START-->"
    Private Const START_OF_TIDDLER = "<div tiddler="
    Private Const END_OF_TIDDLER = "</div>"      ' tiddler goes to end of line

    Public Const SOURCE_NEW = "NEW"            ' ImageName constants into StatusImages used by ListView
    Public Const SOURCE_OLD = "OLD"
    Public Const SOURCE_WARNING = "Warning"

    Public Const BOB_DENNY = "BOB DENNY"
    Public Const YOUR_NAME = "YOURNAME"

    '<DllImport("uxtheme", CharSet:=CharSet.Unicode)>
    'Public Shared Function SetWindowTheme(ByVal hWnd As IntPtr, ByVal textSubAppName As String, ByVal textSubIdList As String) As Integer
    'End Function


    Private Sub ReadAuthorFile(auth As AuthorData, path As String, source As String)
        ' read the author file and parse it into the collection
        ' returns error string or empty string

        Dim fr As StreamReader = FileIO.FileSystem.OpenTextFileReader(path)
        Dim fileS As String = ""
        fileS = fr.ReadToEnd()

        fr.Close()

        ParseAuthorFile(auth, fileS, FileIO.FileSystem.GetName(path), source)
    End Sub

    Private Function ParseAuthorFile(auth As AuthorData, bigS As String, whichFile As String, source As String) As String
        ' bigS is the file contents. It has
        ' huge amount of header and javascript stuff
        '  <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
        '             ...
        '   	<div id="storeArea"><div tiddler="AARemoteContentTest"...  this is the first tiddler
        ' all the tiddlers, one per line. These are in alphabetical order by tiddler name
        '       <div tiddler="Acquire a Single Image" modifier="Bob Denny" modified="201401302305"  ... n&lt;/script&gt;\n</div>
        '             ...
        '       One of these tiddlers is MainMenu, which needs special processing.
        ' Trailer part
        '   		</div>
        '    <!--POST-BODY-START-->
        '
        '    <!--POST-BODY-END-->
        '	 </body>
        '    </html>

        Dim errS As String = ""
        Dim pos As Integer
        Dim posEnd As Integer
        Dim hdr As String = ""
        Dim trl As String = ""
        Dim tiddler As String = ""

        pos = bigS.IndexOf(END_OF_HEADER)
        If (pos > 0) Then
            ' found end of header. Move to end of header, cut out header
            pos = pos + Len(END_OF_HEADER)
            hdr = bigS.Substring(0, pos)
            auth.AddHeader(hdr)
            bigS = bigS.Remove(0, pos)
        Else
            errS = "Header not found in " & whichFile
            Return errS
        End If

        ' Cut out trailer
        pos = bigS.IndexOf(START_OF_TRAILER)
        If (pos > 0) Then
            pos = pos - 9   ' back up to 2 tabs and </div>
            trl = bigS.Substring(pos)
            auth.AddTrailer(trl)
            bigS = bigS.Remove(pos)     ' cut off trailer
        Else
            errS = "Trailer not found in " & whichFile
            Return errS
        End If

        pos = bigS.IndexOf(START_OF_TIDDLER)
        While (pos > -1)
            ' break out tiddlers
            posEnd = bigS.IndexOf(END_OF_TIDDLER, pos)
            If (posEnd > -1) Then
                tiddler = bigS.Substring(pos, posEnd - pos + Len(END_OF_TIDDLER))
                Try
                    auth.AddTiddler(tiddler, source, False)
                Catch ex As Exception
                    MsgBox("Failed to add tiddler. Error: " & ex.Message & vbCrLf & tiddler)
                End Try
            End If
            pos = bigS.IndexOf(START_OF_TIDDLER, posEnd)
        End While

        Return errS
    End Function

    Private Sub SaveAuthorFile(path As String)
        Dim errS As String = ""

        Dim fr As StreamWriter = New StreamWriter(path)
        Dim s As String = gMerge.GetHeader()
        Try
            fr.Write(s)
        Catch ex As Exception
            MsgBox("SaveAuthorFile: WriteLine Header failed. " & ex.Message)
        End Try

        s = gMerge.GetTiddlers()
        Try
            fr.WriteLine(s)
        Catch ex As Exception
            MsgBox("SaveAuthorFile: WriteLine Tiddlers failed. " & ex.Message)
        End Try

        s = gMerge.GetTrailer()
        Try
            fr.WriteLine(s)
        Catch ex As Exception
            MsgBox("SaveAuthorFile: WriteLine Trailer failed. " & ex.Message)
        End Try

        fr.Close()
        mNeedFileSaved = False
    End Sub

    Private Sub MergeFiles()
        ' several cases for comparing the tiddlers
        ' Case  OLD                NewNEW
        '   1  tidA Brewington       tidA Denny            Use OLD tidA  - update the date
        '   2  tidA Brewington                             Use OLD tidA 
        '   3  tidA Denny                                  ? drop the tiddler
        '   3a tidA YourName                               ? drop the tiddler
        '   4                        tidA Denny            Use NEW tidA 
        '   5  tidA Denny            tidA Denny            Use NEW tidA
        '   6  tidA Brewington       tidA YourName         Use OLD tidA Brewington - update the date
        '   7                        tidA YourName         Use NEW tidA 
        '   8  tidA YourName         tidA YourName         Use NEW tidA
        '   9  tidA Brewington       tidA Brewington       Use NEW tidA
        '  10                        tidA Brewington       Use NEW tidA
        '
        ' In all cases, watch for special tiddler MainMenu - special update process
        'txtLog.Text = ""

        ' build today's date in format usable to replace cutom tiddler dates, if needed   200612050344
        Dim todayString As String = DateTime.Now.ToString("yyyyMMddHHmm")

        Dim i As Integer
        Dim key As String
        Dim NEWAuthor As String
        Dim OLDAuthor As String

        ' Look for OLD tiddlers not in NEW
        For i = 0 To gOLD.Count - 1
            key = gOLD.GetKey(i)
            NEWAuthor = UCase(gNEW.GetAuthor(key))
            OLDAuthor = UCase(gOLD.GetAuthor(key))
            If (NEWAuthor = "") Then
                ' no corresponding NEW tiddler, use the OLD one if not Denny or YourName
                If ((OLDAuthor <> BOB_DENNY) And (OLDAuthor <> YOUR_NAME)) Then
                    gMerge.AddTiddler(gOLD.GetTiddler(key), SOURCE_OLD, False)       ' Case 2
                    LogMsg("Case 2  Cus  " & key)
                Else
                    ' drop this tiddler                              ' Case 3,3a
                    LogMsg("Case 3/3a Cus dropped " & key)
                End If
            ElseIf (key = "MainMenu") Then      ' MainMenu is special
                ' Special update for the MainMenu
                Try
                    gMerge.MergeMainMenu(gOLD, gNEW)
                Catch ex As Exception
                    MsgBox("Error merging Main Menus. " & ex.Message)
                End Try
            ElseIf (((NEWAuthor = BOB_DENNY) Or (NEWAuthor = YOUR_NAME)) And ((OLDAuthor <> BOB_DENNY) And (OLDAuthor <> YOUR_NAME))) Then
                ' Case 1 and 6 - need to replace the tiddler already in Merge list
                ' However - if Bob's date is newer than the tiddler date
                '   then we want to a) flag with warning icon and b) msgbox warning
                Dim oldDate As String = gOLD.GetDate(key)
                Dim newDate As String = gMerge.GetDate(key)
                Dim iOldDate As Long = CLng(oldDate)
                Dim iNewDate As Long = CLng(newDate)
                Dim src As String = ""
                If (iNewDate > iOldDate) Then
                    src = SOURCE_WARNING
                    MsgBox("Tiddler key: " & key & vbCrLf & vbCrLf & "This tiddler has been modified, but the ACP version has been modified more recently." & vbCrLf & "You need to manually review the tiddler in the ACP Authoring environment.", MsgBoxStyle.Exclamation, "Tiddler Warning")
                Else
                    src = SOURCE_OLD
                End If
                gMerge.ReplaceTiddler(key, gOLD.GetTiddler(key), src)
            End If
        Next
        mNeedFileSaved = True                    ' Or (NEWAuthor = BOB_DENNY) Or (NEWAuthor = YOUR_NAME))
    End Sub

    Private Sub LogMsg(s As String)
        'txtLog.Text = txtLog.Text & s & vbCrLf
    End Sub

    Private Function UpdateTheDate(tiddler As String, olddate As String, newdate As String) As String
        ' replace the modified date in tiddler with the newdate
        Dim newTiddler As String = tiddler.Replace(olddate, newdate)
        Return newTiddler
    End Function


    Private Sub SaveUpdatedFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveUpdatedFileToolStripMenuItem.Click
        ' Ready to write out the merged author file
        ' Have we done the merge?
        If (Not IsNothing(gMerge)) Then
            SaveFileDialog.FileName = "author.html"
            If (SaveFileDialog.ShowDialog() = DialogResult.OK) Then
                Dim path As String = SaveFileDialog.FileName
                SaveAuthorFile(path)
            End If
        Else
            MsgBox("Need to merge the files using the Go button",, "Save File Error")
        End If
    End Sub

    Private Sub btnOldSelect_Click(sender As Object, e As EventArgs) Handles btnOldSelect.Click
        OpenFileDialog.Title = "Select your last backed up Oldized author file"
        If (OpenFileDialog.ShowDialog() = DialogResult.OK) Then
            txtOldFile.Text = OpenFileDialog.FileName
            txtOldFile.SelectionStart = 9999
            ToolTip1.SetToolTip(txtOldFile, txtOldFile.Text)
        End If

    End Sub

    Private Sub btnNewSelect_Click(sender As Object, e As EventArgs) Handles btnNewSelect.Click
        OpenFileDialog.Title = "Select the New author file"
        If (OpenFileDialog.ShowDialog() = DialogResult.OK) Then
            txtNewFile.Text = OpenFileDialog.FileName
            txtNewFile.SelectionStart = 9999
            ToolTip1.SetToolTip(txtNewFile, txtNewFile.Text)
        End If

    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Dim errStr As String = ""
        Me.Cursor = Cursors.WaitCursor
        If ((txtOldFile.Text = "none") Or (txtOldFile.Text = "")) Then
            MsgBox("Missing OLD File selection",, "OLD File Error")
            Exit Sub
        End If
        If ((txtNewFile.Text = "none") Or (txtNewFile.Text = "")) Then
            MsgBox("Missing NEW File selection",, "NEW File Error")
            Exit Sub
        End If
        Dim tv As TreeView = dlgMainMenu.tvOld

        gOLD = New AuthorData(dlgMainMenu.tvOld)
        Try
            ReadAuthorFile(gOLD, txtOldFile.Text, SOURCE_OLD)
        Catch ex As Exception
            MsgBox("Error reading OLD file {" & txtOldFile.Text & "}" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error reading file")
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try

        gNEW = New AuthorData(dlgMainMenu.tvNew)
        Try
            ReadAuthorFile(gNEW, txtNewFile.Text, SOURCE_NEW)
        Catch ex As Exception
            MsgBox("Error reading NEW file {" & txtNewFile.Text & "}" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error reading file")
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try

        ' Preload the Merge with the NEW file
        gMerge = New AuthorData(dlgMainMenu.tvMerge)
        Try
            ReadAuthorFile(gMerge, txtNewFile.Text, SOURCE_NEW)
        Catch ex As Exception
            MsgBox("Error reading NEW file {" & txtNewFile.Text & "}" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error reading file")
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try

        ' Register the Author data in dlgMainMenu
        dlgMainMenu.RegisterAuthorData(gOLD, gNEW, gMerge)
        ' merge the files
        MergeFiles()

        ' Populate the list box
        gMerge.PopulateListView(lvUpdated)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub BrewAuthorMerge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtOldFile.SelectionStart = 9999
        ToolTip1.SetToolTip(txtOldFile, txtOldFile.Text)
        txtNewFile.SelectionStart = 9999
        ToolTip1.SetToolTip(txtNewFile, txtNewFile.Text)

        Me.Text = Me.Text & " " & String.Format("Version {0}", My.Application.Info.Version.ToString)

        ' Fixing list view column headers?
        'SetWindowTheme(lvUpdated.Handle, "Explorer", Nothing)

        ' set up help
        Dim strHelpPath As String = System.IO.Path.Combine(Application.StartupPath, "BrewAuthorMerge.chm")
        'MsgBox("Looking for help file at " & strHelpPath)
        HelpProvider1.HelpNamespace = strHelpPath

    End Sub

    Private Function CheckClosing() As Boolean
        ' If Go has been done and file not saved, ask if they want to save it
        ' return True to prevent exit, False to allow exit to continue
        Dim preventExit As Boolean = False
        Dim msgResult As Integer = 0
        If (Not IsNothing(gMerge) And (mNeedFileSaved = True)) Then
            msgResult = MsgBox("Merged File has not been saved. Do you wish to Exit?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Merged File Save")
            If (msgResult = MsgBoxResult.Yes) Then
                preventExit = False         ' yes, exit
            Else
                preventExit = True          ' dont exit
            End If
        End If
        Return preventExit
    End Function

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        If (Not CheckClosing()) Then
            Environment.Exit(0)
        End If
    End Sub

    Private Sub BrewAuthorMerge_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = CheckClosing()
    End Sub
    Private Sub lvUpdated_Click(sender As Object, e As EventArgs) Handles lvUpdated.Click
        Dim key As String = ""
        key = sender.selecteditems(0).text
        TiddlerDisplay(key)
    End Sub

    Private Sub lvUpdated_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvUpdated.SelectedIndexChanged
        Dim item As ListViewItem

        If (lvUpdated.SelectedItems.Count = 0) Then
            ' pop down the dialog if up
            dlgTiddlerCompare.Hide()
            Exit Sub
        End If

        item = lvUpdated.SelectedItems.Item(0)
        Dim key As String = item.Text
        TiddlerDisplay(key)

    End Sub

    Private Sub TiddlerDisplay(key As String)
        If (key = "MainMenu") Then
            dlgMainMenu.tvOld.ExpandAll()
            dlgMainMenu.tvNew.ExpandAll()
            dlgMainMenu.tvMerge.ExpandAll()
            dlgMainMenu.ShowDialog()      ' MainMenu uses special dialog box
            Exit Sub
        End If

        Dim newTxt As TextBox = dlgTiddlerCompare.txtNewTiddler
        Dim oldTxt As TextBox = dlgTiddlerCompare.txtOldTiddler
        Dim newKey As String = gNEW.GetTiddler(key)
        Dim oldKey As String = gOLD.GetTiddler(key)
        Dim source As String = gMerge.GetTiddlerSource(key)
        If (newKey <> "") Then
            newTxt.Text = Web.HttpUtility.HtmlDecode(newKey)
        Else
            newTxt.Text = ""
        End If
        If (oldKey <> "") Then
            oldTxt.Text = Web.HttpUtility.HtmlDecode(oldKey)
        Else
            oldTxt.Text = ""
        End If
        dlgTiddlerCompare.Text = "Tiddler Compare for {" & key & "}"
        If (source = SOURCE_NEW) Then
            oldTxt.BackColor = Color.Beige
            oldTxt.ForeColor = Color.Black
            newTxt.BackColor = Color.Gold
            newTxt.ForeColor = Color.Navy
            dlgTiddlerCompare.lblNewTiddler.Text = "New ACP Tiddler - Applied"
            dlgTiddlerCompare.lblOldTiddler.Text = "Customized Tiddler - Ignored"
        Else
            oldTxt.BackColor = Color.Gold
            oldTxt.ForeColor = Color.Navy
            newTxt.BackColor = Color.Beige
            newTxt.ForeColor = Color.Black
            dlgTiddlerCompare.lblNewTiddler.Text = "New ACP Tiddler - Ignored"
            dlgTiddlerCompare.lblOldTiddler.Text = "Customized Tiddler - Applied"
        End If
        dlgTiddlerCompare.ShowDialog()

    End Sub

    Private Sub lvUpdated_DrawColumnHeader(ByVal sender As Object, ByVal e As DrawListViewColumnHeaderEventArgs) Handles lvUpdated.DrawColumnHeader

        Dim strFormat As New StringFormat()
        Dim myBounds As Rectangle

        If e.Header.TextAlign = HorizontalAlignment.Center Then
            strFormat.Alignment = StringAlignment.Center
        ElseIf e.Header.TextAlign = HorizontalAlignment.Right Then
            strFormat.Alignment = StringAlignment.Far
        End If

        e.DrawBackground()
        e.Graphics.FillRectangle(Brushes.SteelBlue, e.Bounds)
        Dim headerFont As New Font("Arial", 10, FontStyle.Bold)

        ' adjust the bounds to move text down 3 px
        myBounds.X = e.Bounds.X
        myBounds.Y = e.Bounds.Y + 3
        myBounds.Width = e.Bounds.Width
        myBounds.Height = e.Bounds.Height - 3

        e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.White, myBounds, strFormat)


    End Sub

    Private Sub lvUpdated_DrawItem(ByVal sender As Object, ByVal e As DrawListViewItemEventArgs) Handles lvUpdated.DrawItem

        e.DrawDefault = True
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox.Show()
    End Sub

    Private Sub HelpToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem1.Click
        Help.ShowHelp(Me, HelpProvider1.HelpNamespace, HelpNavigator.TableOfContents)
    End Sub
End Class
