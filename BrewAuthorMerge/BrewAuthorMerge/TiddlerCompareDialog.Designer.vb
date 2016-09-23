<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTiddlerCompare
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgTiddlerCompare))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.tblTiddlerComp = New System.Windows.Forms.TableLayoutPanel()
        Me.txtOldTiddler = New System.Windows.Forms.TextBox()
        Me.lblOldTiddler = New System.Windows.Forms.Label()
        Me.txtNewTiddler = New System.Windows.Forms.TextBox()
        Me.lblNewTiddler = New System.Windows.Forms.Label()
        Me.pnlMainTiddlerComp = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.tblTiddlerComp.SuspendLayout()
        Me.pnlMainTiddlerComp.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(588, 357)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        Me.Cancel_Button.Visible = False
        '
        'tblTiddlerComp
        '
        Me.tblTiddlerComp.AutoSize = True
        Me.tblTiddlerComp.ColumnCount = 2
        Me.tblTiddlerComp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblTiddlerComp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblTiddlerComp.Controls.Add(Me.txtOldTiddler, 0, 1)
        Me.tblTiddlerComp.Controls.Add(Me.lblOldTiddler, 0, 0)
        Me.tblTiddlerComp.Controls.Add(Me.TableLayoutPanel1, 1, 2)
        Me.tblTiddlerComp.Controls.Add(Me.txtNewTiddler, 1, 1)
        Me.tblTiddlerComp.Controls.Add(Me.lblNewTiddler, 1, 0)
        Me.tblTiddlerComp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTiddlerComp.Location = New System.Drawing.Point(0, 0)
        Me.tblTiddlerComp.Name = "tblTiddlerComp"
        Me.tblTiddlerComp.RowCount = 3
        Me.tblTiddlerComp.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.71429!))
        Me.tblTiddlerComp.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.28571!))
        Me.tblTiddlerComp.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tblTiddlerComp.Size = New System.Drawing.Size(737, 389)
        Me.tblTiddlerComp.TabIndex = 0
        '
        'txtOldTiddler
        '
        Me.txtOldTiddler.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOldTiddler.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOldTiddler.Location = New System.Drawing.Point(3, 39)
        Me.txtOldTiddler.Multiline = True
        Me.txtOldTiddler.Name = "txtOldTiddler"
        Me.txtOldTiddler.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOldTiddler.Size = New System.Drawing.Size(362, 296)
        Me.txtOldTiddler.TabIndex = 3
        '
        'lblOldTiddler
        '
        Me.lblOldTiddler.AutoSize = True
        Me.lblOldTiddler.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOldTiddler.Location = New System.Drawing.Point(3, 3)
        Me.lblOldTiddler.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblOldTiddler.Name = "lblOldTiddler"
        Me.lblOldTiddler.Size = New System.Drawing.Size(162, 20)
        Me.lblOldTiddler.TabIndex = 1
        Me.lblOldTiddler.Text = "Customized Tiddler"
        '
        'txtNewTiddler
        '
        Me.txtNewTiddler.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNewTiddler.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewTiddler.Location = New System.Drawing.Point(371, 39)
        Me.txtNewTiddler.Multiline = True
        Me.txtNewTiddler.Name = "txtNewTiddler"
        Me.txtNewTiddler.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNewTiddler.Size = New System.Drawing.Size(363, 296)
        Me.txtNewTiddler.TabIndex = 2
        '
        'lblNewTiddler
        '
        Me.lblNewTiddler.AutoSize = True
        Me.lblNewTiddler.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewTiddler.Location = New System.Drawing.Point(371, 3)
        Me.lblNewTiddler.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblNewTiddler.Name = "lblNewTiddler"
        Me.lblNewTiddler.Size = New System.Drawing.Size(142, 20)
        Me.lblNewTiddler.TabIndex = 4
        Me.lblNewTiddler.Text = "New ACP Tiddler"
        '
        'pnlMainTiddlerComp
        '
        Me.pnlMainTiddlerComp.Controls.Add(Me.tblTiddlerComp)
        Me.pnlMainTiddlerComp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMainTiddlerComp.Location = New System.Drawing.Point(0, 0)
        Me.pnlMainTiddlerComp.Name = "pnlMainTiddlerComp"
        Me.pnlMainTiddlerComp.Size = New System.Drawing.Size(737, 389)
        Me.pnlMainTiddlerComp.TabIndex = 1
        '
        'dlgTiddlerCompare
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(737, 389)
        Me.Controls.Add(Me.pnlMainTiddlerComp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgTiddlerCompare"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tiddler Comparison"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.tblTiddlerComp.ResumeLayout(False)
        Me.tblTiddlerComp.PerformLayout()
        Me.pnlMainTiddlerComp.ResumeLayout(False)
        Me.pnlMainTiddlerComp.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents tblTiddlerComp As TableLayoutPanel
    Friend WithEvents txtOldTiddler As TextBox
    Friend WithEvents lblOldTiddler As Label
    Friend WithEvents txtNewTiddler As TextBox
    Friend WithEvents pnlMainTiddlerComp As Panel
    Friend WithEvents lblNewTiddler As Label
End Class
