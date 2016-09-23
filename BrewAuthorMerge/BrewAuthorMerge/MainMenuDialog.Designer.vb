<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgMainMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgMainMenu))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.pnllMMMain = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCopyMergeClipboard = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCopyNewClipboard = New System.Windows.Forms.Button()
        Me.tvOld = New System.Windows.Forms.TreeView()
        Me.MenuImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.tvNew = New System.Windows.Forms.TreeView()
        Me.tvMerge = New System.Windows.Forms.TreeView()
        Me.tblOldCopy = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCopyOldClipboard = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnllMMMain.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.tblOldCopy.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(609, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(308, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.Location = New System.Drawing.Point(43, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        Me.OK_Button.Visible = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Location = New System.Drawing.Point(197, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'pnllMMMain
        '
        Me.pnllMMMain.Controls.Add(Me.TableLayoutPanel2)
        Me.pnllMMMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnllMMMain.Location = New System.Drawing.Point(0, 0)
        Me.pnllMMMain.Name = "pnllMMMain"
        Me.pnllMMMain.Size = New System.Drawing.Size(920, 399)
        Me.pnllMMMain.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel4, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel1, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.tvOld, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.tvNew, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.tvMerge, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.tblOldCopy, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(920, 399)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.btnCopyMergeClipboard, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(609, 38)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(308, 32)
        Me.TableLayoutPanel4.TabIndex = 9
        '
        'btnCopyMergeClipboard
        '
        Me.btnCopyMergeClipboard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopyMergeClipboard.Location = New System.Drawing.Point(157, 3)
        Me.btnCopyMergeClipboard.Name = "btnCopyMergeClipboard"
        Me.btnCopyMergeClipboard.Size = New System.Drawing.Size(148, 25)
        Me.btnCopyMergeClipboard.TabIndex = 7
        Me.btnCopyMergeClipboard.Text = "Copy to Clipboard"
        Me.btnCopyMergeClipboard.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Merged Result"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnCopyNewClipboard, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(306, 38)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(297, 32)
        Me.TableLayoutPanel3.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 3)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "New ACP"
        '
        'btnCopyNewClipboard
        '
        Me.btnCopyNewClipboard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopyNewClipboard.Location = New System.Drawing.Point(151, 3)
        Me.btnCopyNewClipboard.Name = "btnCopyNewClipboard"
        Me.btnCopyNewClipboard.Size = New System.Drawing.Size(142, 29)
        Me.btnCopyNewClipboard.TabIndex = 6
        Me.btnCopyNewClipboard.Text = "Copy to Clipboard"
        Me.btnCopyNewClipboard.UseVisualStyleBackColor = True
        '
        'tvOld
        '
        Me.tvOld.BackColor = System.Drawing.Color.PaleGreen
        Me.tvOld.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvOld.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvOld.ImageIndex = 0
        Me.tvOld.ImageList = Me.MenuImageList
        Me.tvOld.Location = New System.Drawing.Point(3, 76)
        Me.tvOld.Name = "tvOld"
        Me.tvOld.SelectedImageIndex = 0
        Me.tvOld.Size = New System.Drawing.Size(297, 339)
        Me.tvOld.TabIndex = 3
        '
        'MenuImageList
        '
        Me.MenuImageList.ImageStream = CType(resources.GetObject("MenuImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.MenuImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.MenuImageList.Images.SetKeyName(0, "MainMenu")
        Me.MenuImageList.Images.SetKeyName(1, "navbar")
        Me.MenuImageList.Images.SetKeyName(2, "mainDiv")
        Me.MenuImageList.Images.SetKeyName(3, "ASPIf")
        Me.MenuImageList.Images.SetKeyName(4, "ASPElse")
        Me.MenuImageList.Images.SetKeyName(5, "ASPEnd")
        Me.MenuImageList.Images.SetKeyName(6, "divComment")
        Me.MenuImageList.Images.SetKeyName(7, "dropItem")
        Me.MenuImageList.Images.SetKeyName(8, "dropMenu")
        Me.MenuImageList.Images.SetKeyName(9, "subMenu")
        Me.MenuImageList.Images.SetKeyName(10, "subItem")
        Me.MenuImageList.Images.SetKeyName(11, "subSubItem")
        Me.MenuImageList.Images.SetKeyName(12, "divTrailer")
        Me.MenuImageList.Images.SetKeyName(13, "ModMainMenu")
        Me.MenuImageList.Images.SetKeyName(14, "GreenNavbar")
        Me.MenuImageList.Images.SetKeyName(15, "ModMainDiv")
        Me.MenuImageList.Images.SetKeyName(16, "ModASPIf")
        Me.MenuImageList.Images.SetKeyName(17, "ModASPElse")
        Me.MenuImageList.Images.SetKeyName(18, "ModASPEnd")
        Me.MenuImageList.Images.SetKeyName(19, "ModDivComment")
        Me.MenuImageList.Images.SetKeyName(20, "ModDropItem")
        Me.MenuImageList.Images.SetKeyName(21, "ModDropMenu")
        Me.MenuImageList.Images.SetKeyName(22, "ModSubMenu")
        Me.MenuImageList.Images.SetKeyName(23, "ModSubItem")
        Me.MenuImageList.Images.SetKeyName(24, "ModSubSubItem")
        Me.MenuImageList.Images.SetKeyName(25, "ModDivTrailer")
        Me.MenuImageList.Images.SetKeyName(26, "WarnMainMenu")
        Me.MenuImageList.Images.SetKeyName(27, "WarnNavbar")
        Me.MenuImageList.Images.SetKeyName(28, "WarnMainDiv")
        Me.MenuImageList.Images.SetKeyName(29, "WarnASPIf")
        Me.MenuImageList.Images.SetKeyName(30, "WarnASPElse")
        Me.MenuImageList.Images.SetKeyName(31, "WarnASPEnd")
        Me.MenuImageList.Images.SetKeyName(32, "WarnDivComment")
        Me.MenuImageList.Images.SetKeyName(33, "WarnDropItem")
        Me.MenuImageList.Images.SetKeyName(34, "WarnDropMenu")
        Me.MenuImageList.Images.SetKeyName(35, "WarnSubMenu")
        Me.MenuImageList.Images.SetKeyName(36, "WarnSubItem")
        Me.MenuImageList.Images.SetKeyName(37, "WarnSubSubItem")
        Me.MenuImageList.Images.SetKeyName(38, "WarnDivTrailer")
        '
        'tvNew
        '
        Me.tvNew.BackColor = System.Drawing.Color.LightBlue
        Me.tvNew.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvNew.ImageIndex = 0
        Me.tvNew.ImageList = Me.MenuImageList
        Me.tvNew.Location = New System.Drawing.Point(306, 76)
        Me.tvNew.Name = "tvNew"
        Me.tvNew.SelectedImageIndex = 0
        Me.tvNew.Size = New System.Drawing.Size(297, 339)
        Me.tvNew.TabIndex = 4
        '
        'tvMerge
        '
        Me.tvMerge.BackColor = System.Drawing.Color.Pink
        Me.tvMerge.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvMerge.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvMerge.ImageIndex = 0
        Me.tvMerge.ImageList = Me.MenuImageList
        Me.tvMerge.Location = New System.Drawing.Point(609, 76)
        Me.tvMerge.Name = "tvMerge"
        Me.tvMerge.SelectedImageIndex = 0
        Me.tvMerge.ShowNodeToolTips = True
        Me.tvMerge.Size = New System.Drawing.Size(308, 339)
        Me.tvMerge.TabIndex = 5
        '
        'tblOldCopy
        '
        Me.tblOldCopy.ColumnCount = 2
        Me.tblOldCopy.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblOldCopy.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblOldCopy.Controls.Add(Me.btnCopyOldClipboard, 1, 0)
        Me.tblOldCopy.Controls.Add(Me.Label3, 0, 0)
        Me.tblOldCopy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblOldCopy.Location = New System.Drawing.Point(3, 38)
        Me.tblOldCopy.Name = "tblOldCopy"
        Me.tblOldCopy.RowCount = 1
        Me.tblOldCopy.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblOldCopy.Size = New System.Drawing.Size(297, 32)
        Me.tblOldCopy.TabIndex = 7
        '
        'btnCopyOldClipboard
        '
        Me.btnCopyOldClipboard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopyOldClipboard.Location = New System.Drawing.Point(151, 3)
        Me.btnCopyOldClipboard.Name = "btnCopyOldClipboard"
        Me.btnCopyOldClipboard.Size = New System.Drawing.Size(142, 25)
        Me.btnCopyOldClipboard.TabIndex = 7
        Me.btnCopyOldClipboard.Text = "Copy to Clipboard"
        Me.btnCopyOldClipboard.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 3)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Customized"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dlgMainMenu
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(920, 399)
        Me.Controls.Add(Me.pnllMMMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgMainMenu"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main Menu Trees"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.pnllMMMain.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.tblOldCopy.ResumeLayout(False)
        Me.tblOldCopy.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents pnllMMMain As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tvOld As TreeView
    Friend WithEvents tvNew As TreeView
    Friend WithEvents tvMerge As TreeView
    Friend WithEvents MenuImageList As ImageList
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents btnCopyMergeClipboard As Button
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents btnCopyNewClipboard As Button
    Friend WithEvents tblOldCopy As TableLayoutPanel
    Friend WithEvents btnCopyOldClipboard As Button
    Friend WithEvents ToolTip1 As ToolTip
End Class
