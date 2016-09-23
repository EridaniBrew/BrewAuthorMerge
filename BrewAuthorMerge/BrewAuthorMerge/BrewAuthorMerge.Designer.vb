<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BrewAuthorMerge
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BrewAuthorMerge))
        Me.ControlPanel = New System.Windows.Forms.Panel()
        Me.tblButtons = New System.Windows.Forms.TableLayoutPanel()
        Me.txtOldFile = New System.Windows.Forms.TextBox()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.btnNewSelect = New System.Windows.Forms.Button()
        Me.btnOldSelect = New System.Windows.Forms.Button()
        Me.txtNewFile = New System.Windows.Forms.TextBox()
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.ViewPanel = New System.Windows.Forms.Panel()
        Me.lvUpdated = New System.Windows.Forms.ListView()
        Me.Key = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Author = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.EditDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StatusImages = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveUpdatedFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.ControlPanel.SuspendLayout()
        Me.tblButtons.SuspendLayout()
        Me.MainPanel.SuspendLayout()
        Me.ViewPanel.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ControlPanel
        '
        Me.ControlPanel.Controls.Add(Me.tblButtons)
        Me.ControlPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.ControlPanel.Location = New System.Drawing.Point(0, 0)
        Me.ControlPanel.Name = "ControlPanel"
        Me.ControlPanel.Size = New System.Drawing.Size(514, 57)
        Me.ControlPanel.TabIndex = 0
        '
        'tblButtons
        '
        Me.tblButtons.AutoSize = True
        Me.tblButtons.ColumnCount = 3
        Me.tblButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblButtons.Controls.Add(Me.txtOldFile, 0, 1)
        Me.tblButtons.Controls.Add(Me.btnGo, 2, 0)
        Me.tblButtons.Controls.Add(Me.btnNewSelect, 1, 0)
        Me.tblButtons.Controls.Add(Me.btnOldSelect, 0, 0)
        Me.tblButtons.Controls.Add(Me.txtNewFile, 1, 1)
        Me.tblButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.tblButtons.Location = New System.Drawing.Point(0, 0)
        Me.tblButtons.Name = "tblButtons"
        Me.tblButtons.RowCount = 2
        Me.tblButtons.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblButtons.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblButtons.Size = New System.Drawing.Size(514, 77)
        Me.tblButtons.TabIndex = 0
        '
        'txtOldFile
        '
        Me.txtOldFile.BackColor = System.Drawing.SystemColors.Control
        Me.txtOldFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOldFile.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtOldFile.Location = New System.Drawing.Point(3, 37)
        Me.txtOldFile.Margin = New System.Windows.Forms.Padding(3, 3, 3, 20)
        Me.txtOldFile.Name = "txtOldFile"
        Me.txtOldFile.Size = New System.Drawing.Size(221, 20)
        Me.txtOldFile.TabIndex = 5
        '
        'btnGo
        '
        Me.btnGo.BackColor = System.Drawing.Color.LimeGreen
        Me.btnGo.Location = New System.Drawing.Point(457, 3)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(53, 28)
        Me.btnGo.TabIndex = 3
        Me.btnGo.Text = "Go"
        Me.btnGo.UseVisualStyleBackColor = False
        '
        'btnNewSelect
        '
        Me.btnNewSelect.Location = New System.Drawing.Point(230, 3)
        Me.btnNewSelect.Name = "btnNewSelect"
        Me.btnNewSelect.Size = New System.Drawing.Size(114, 28)
        Me.btnNewSelect.TabIndex = 1
        Me.btnNewSelect.Text = "New (ACP) File..."
        Me.ToolTip1.SetToolTip(Me.btnNewSelect, "Select the recently updated ACP" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "file, should be something like " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DocRoot/author." &
        "html")
        Me.btnNewSelect.UseVisualStyleBackColor = True
        '
        'btnOldSelect
        '
        Me.btnOldSelect.Location = New System.Drawing.Point(3, 3)
        Me.btnOldSelect.Name = "btnOldSelect"
        Me.btnOldSelect.Size = New System.Drawing.Size(130, 28)
        Me.btnOldSelect.TabIndex = 0
        Me.btnOldSelect.Text = "Customized File..."
        Me.ToolTip1.SetToolTip(Me.btnOldSelect, "Select your backed up author file" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "containing your customizations." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This should b" &
        "e something like" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DocRoot/author-backup/author.bk-20160517_190644.html")
        Me.btnOldSelect.UseVisualStyleBackColor = True
        '
        'txtNewFile
        '
        Me.txtNewFile.BackColor = System.Drawing.SystemColors.Control
        Me.txtNewFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNewFile.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtNewFile.Location = New System.Drawing.Point(230, 37)
        Me.txtNewFile.Name = "txtNewFile"
        Me.txtNewFile.Size = New System.Drawing.Size(221, 20)
        Me.txtNewFile.TabIndex = 4
        '
        'MainPanel
        '
        Me.MainPanel.Controls.Add(Me.ViewPanel)
        Me.MainPanel.Controls.Add(Me.ControlPanel)
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanel.Location = New System.Drawing.Point(0, 24)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(514, 429)
        Me.MainPanel.TabIndex = 1
        '
        'ViewPanel
        '
        Me.ViewPanel.Controls.Add(Me.lvUpdated)
        Me.ViewPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewPanel.Location = New System.Drawing.Point(0, 57)
        Me.ViewPanel.Name = "ViewPanel"
        Me.ViewPanel.Size = New System.Drawing.Size(514, 372)
        Me.ViewPanel.TabIndex = 1
        '
        'lvUpdated
        '
        Me.lvUpdated.AllowColumnReorder = True
        Me.lvUpdated.BackColor = System.Drawing.SystemColors.Window
        Me.lvUpdated.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Key, Me.Author, Me.EditDate})
        Me.lvUpdated.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvUpdated.FullRowSelect = True
        Me.lvUpdated.Location = New System.Drawing.Point(0, 0)
        Me.lvUpdated.MultiSelect = False
        Me.lvUpdated.Name = "lvUpdated"
        Me.lvUpdated.OwnerDraw = True
        Me.lvUpdated.ShowItemToolTips = True
        Me.lvUpdated.Size = New System.Drawing.Size(514, 372)
        Me.lvUpdated.SmallImageList = Me.StatusImages
        Me.lvUpdated.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvUpdated.TabIndex = 1
        Me.lvUpdated.UseCompatibleStateImageBehavior = False
        Me.lvUpdated.View = System.Windows.Forms.View.Details
        '
        'Key
        '
        Me.Key.Text = "Key"
        Me.Key.Width = 213
        '
        'Author
        '
        Me.Author.Text = "Author"
        Me.Author.Width = 113
        '
        'EditDate
        '
        Me.EditDate.Text = "Edit Date"
        Me.EditDate.Width = 77
        '
        'StatusImages
        '
        Me.StatusImages.ImageStream = CType(resources.GetObject("StatusImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.StatusImages.TransparentColor = System.Drawing.Color.Transparent
        Me.StatusImages.Images.SetKeyName(0, "Old")
        Me.StatusImages.Images.SetKeyName(1, "New")
        Me.StatusImages.Images.SetKeyName(2, "Warning")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(514, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveUpdatedFileToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveUpdatedFileToolStripMenuItem
        '
        Me.SaveUpdatedFileToolStripMenuItem.Name = "SaveUpdatedFileToolStripMenuItem"
        Me.SaveUpdatedFileToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.SaveUpdatedFileToolStripMenuItem.Text = "Save Updated File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem1, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'HelpToolStripMenuItem1
        '
        Me.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(119, 22)
        Me.HelpToolStripMenuItem1.Text = "Help ..."
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.AboutToolStripMenuItem.Text = "About ..."
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.DefaultExt = "*.html"
        Me.OpenFileDialog.Filter = "HTML Files|*.html|All Files|*.*"
        '
        'SaveFileDialog
        '
        Me.SaveFileDialog.DefaultExt = "html"
        Me.SaveFileDialog.Filter = "HTML files|*.html|All Files|*.*"
        Me.SaveFileDialog.Title = "Save Merged File"
        '
        'BrewAuthorMerge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 453)
        Me.Controls.Add(Me.MainPanel)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "BrewAuthorMerge"
        Me.Text = "BrewAuthorMerge"
        Me.ControlPanel.ResumeLayout(False)
        Me.ControlPanel.PerformLayout()
        Me.tblButtons.ResumeLayout(False)
        Me.tblButtons.PerformLayout()
        Me.MainPanel.ResumeLayout(False)
        Me.ViewPanel.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ControlPanel As Panel
    Friend WithEvents btnNewSelect As Button
    Friend WithEvents btnOldSelect As Button
    Friend WithEvents MainPanel As Panel
    Friend WithEvents lvUpdated As ListView
    Friend WithEvents Key As ColumnHeader
    Friend WithEvents Author As ColumnHeader
    Friend WithEvents EditDate As ColumnHeader
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusImages As ImageList
    Friend WithEvents tblButtons As TableLayoutPanel
    Friend WithEvents ViewPanel As Panel
    Friend WithEvents SaveUpdatedFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents btnGo As Button
    Friend WithEvents txtNewFile As TextBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents txtOldFile As TextBox
    Friend WithEvents HelpToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpProvider1 As HelpProvider
End Class
