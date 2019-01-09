<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.cmdOpenMail = New System.Windows.Forms.Button()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.lblCC = New System.Windows.Forms.Label()
        Me.lblSubject = New System.Windows.Forms.Label()
        Me.gprAttachtments = New System.Windows.Forms.GroupBox()
        Me.lstAttachments = New System.Windows.Forms.ListView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblBCC = New System.Windows.Forms.Label()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.cmdReload = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblAbout = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tabMessage = New System.Windows.Forms.TabControl()
        Me.tabMessageBody = New System.Windows.Forms.TabPage()
        Me.msgViewer = New System.Windows.Forms.WebBrowser()
        Me.gprAttachtments.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.tabMessage.SuspendLayout()
        Me.tabMessageBody.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOpenMail
        '
        Me.cmdOpenMail.Location = New System.Drawing.Point(12, 12)
        Me.cmdOpenMail.Name = "cmdOpenMail"
        Me.cmdOpenMail.Size = New System.Drawing.Size(109, 23)
        Me.cmdOpenMail.TabIndex = 0
        Me.cmdOpenMail.Text = "Open MSG file"
        Me.cmdOpenMail.UseVisualStyleBackColor = True
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Location = New System.Drawing.Point(146, 7)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(26, 13)
        Me.lblFrom.TabIndex = 4
        Me.lblFrom.Text = "Van"
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(146, 37)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(26, 13)
        Me.lblTo.TabIndex = 5
        Me.lblTo.Text = "Aan"
        '
        'lblCC
        '
        Me.lblCC.AutoSize = True
        Me.lblCC.Location = New System.Drawing.Point(146, 53)
        Me.lblCC.Name = "lblCC"
        Me.lblCC.Size = New System.Drawing.Size(21, 13)
        Me.lblCC.TabIndex = 6
        Me.lblCC.Text = "CC"
        '
        'lblSubject
        '
        Me.lblSubject.AutoSize = True
        Me.lblSubject.Location = New System.Drawing.Point(146, 87)
        Me.lblSubject.Name = "lblSubject"
        Me.lblSubject.Size = New System.Drawing.Size(59, 13)
        Me.lblSubject.TabIndex = 7
        Me.lblSubject.Text = "Onderwerp"
        '
        'gprAttachtments
        '
        Me.gprAttachtments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gprAttachtments.Controls.Add(Me.lstAttachments)
        Me.gprAttachtments.Location = New System.Drawing.Point(15, 769)
        Me.gprAttachtments.Name = "gprAttachtments"
        Me.gprAttachtments.Size = New System.Drawing.Size(1249, 123)
        Me.gprAttachtments.TabIndex = 9
        Me.gprAttachtments.TabStop = False
        Me.gprAttachtments.Text = "Bijlagen"
        '
        'lstAttachments
        '
        Me.lstAttachments.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lstAttachments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstAttachments.LargeImageList = Me.ImageList1
        Me.lstAttachments.Location = New System.Drawing.Point(3, 16)
        Me.lstAttachments.Name = "lstAttachments"
        Me.lstAttachments.Size = New System.Drawing.Size(1243, 104)
        Me.lstAttachments.SmallImageList = Me.ImageList1
        Me.lstAttachments.TabIndex = 0
        Me.lstAttachments.UseCompatibleStateImageBehavior = False
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'lblBCC
        '
        Me.lblBCC.AutoSize = True
        Me.lblBCC.Location = New System.Drawing.Point(146, 70)
        Me.lblBCC.Name = "lblBCC"
        Me.lblBCC.Size = New System.Drawing.Size(28, 13)
        Me.lblBCC.TabIndex = 10
        Me.lblBCC.Text = "BCC"
        '
        'lblDateTime
        '
        Me.lblDateTime.AutoSize = True
        Me.lblDateTime.Location = New System.Drawing.Point(146, 23)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(38, 13)
        Me.lblDateTime.TabIndex = 11
        Me.lblDateTime.Text = "Datum"
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(1155, 7)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(107, 23)
        Me.cmdPrint.TabIndex = 12
        Me.cmdPrint.Text = "Afdrukken"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdReload
        '
        Me.cmdReload.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmdReload.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReload.ForeColor = System.Drawing.Color.White
        Me.cmdReload.Location = New System.Drawing.Point(12, 81)
        Me.cmdReload.Name = "cmdReload"
        Me.cmdReload.Size = New System.Drawing.Size(109, 23)
        Me.cmdReload.TabIndex = 13
        Me.cmdReload.Text = "Bericht"
        Me.cmdReload.UseVisualStyleBackColor = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblVersion, Me.lblAbout})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 895)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1274, 22)
        Me.StatusStrip1.TabIndex = 14
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblVersion
        '
        Me.lblVersion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(61, 17)
        Me.lblVersion.Text = "lblVersion"
        '
        'lblAbout
        '
        Me.lblAbout.IsLink = True
        Me.lblAbout.Margin = New System.Windows.Forms.Padding(150, 3, 0, 2)
        Me.lblAbout.Name = "lblAbout"
        Me.lblAbout.Size = New System.Drawing.Size(53, 17)
        Me.lblAbout.Text = "lblAbout"
        '
        'tabMessage
        '
        Me.tabMessage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabMessage.Controls.Add(Me.tabMessageBody)
        Me.tabMessage.Location = New System.Drawing.Point(12, 110)
        Me.tabMessage.Name = "tabMessage"
        Me.tabMessage.SelectedIndex = 0
        Me.tabMessage.Size = New System.Drawing.Size(1262, 653)
        Me.tabMessage.TabIndex = 15
        '
        'tabMessageBody
        '
        Me.tabMessageBody.Controls.Add(Me.msgViewer)
        Me.tabMessageBody.Location = New System.Drawing.Point(4, 22)
        Me.tabMessageBody.Name = "tabMessageBody"
        Me.tabMessageBody.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMessageBody.Size = New System.Drawing.Size(1254, 627)
        Me.tabMessageBody.TabIndex = 0
        Me.tabMessageBody.Text = "Bericht"
        Me.tabMessageBody.UseVisualStyleBackColor = True
        '
        'msgViewer
        '
        Me.msgViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.msgViewer.Location = New System.Drawing.Point(3, 3)
        Me.msgViewer.MinimumSize = New System.Drawing.Size(20, 20)
        Me.msgViewer.Name = "msgViewer"
        Me.msgViewer.Size = New System.Drawing.Size(1248, 621)
        Me.msgViewer.TabIndex = 4
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1274, 917)
        Me.Controls.Add(Me.tabMessage)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.cmdReload)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.lblDateTime)
        Me.Controls.Add(Me.lblBCC)
        Me.Controls.Add(Me.gprAttachtments)
        Me.Controls.Add(Me.lblSubject)
        Me.Controls.Add(Me.lblCC)
        Me.Controls.Add(Me.lblTo)
        Me.Controls.Add(Me.lblFrom)
        Me.Controls.Add(Me.cmdOpenMail)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "RN - MSG Reader - ©Roy Nijkamp"
        Me.gprAttachtments.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.tabMessage.ResumeLayout(False)
        Me.tabMessageBody.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdOpenMail As Button
    Friend WithEvents lblFrom As Label
    Friend WithEvents lblTo As Label
    Friend WithEvents lblCC As Label
    Friend WithEvents lblSubject As Label
    Friend WithEvents gprAttachtments As GroupBox
    Friend WithEvents lblBCC As Label
    Friend WithEvents lblDateTime As Label
    Friend WithEvents cmdPrint As Button
    Friend WithEvents lstAttachments As ListView
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents cmdReload As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblVersion As ToolStripStatusLabel
    Friend WithEvents lblAbout As ToolStripStatusLabel
    Friend WithEvents tabMessage As TabControl
    Friend WithEvents tabMessageBody As TabPage
    Friend WithEvents msgViewer As WebBrowser
End Class
