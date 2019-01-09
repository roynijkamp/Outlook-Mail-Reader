

Imports System.ComponentModel
Imports System.IO
Imports MsgReader
Imports MsgReader.Outlook

Public Class frmMain
    Dim sTempDirectory As List(Of String) = New List(Of String)
    Dim sTempDir As String
    Dim sMsgFile As String
    Dim sMsgTitle As String
    Dim bCancelNavigation As Boolean = False
    Dim sOpenAttachemnts As List(Of String) = New List(Of String)
    Dim sSelectedTab As String
    Private OpenedFiles As New List(Of WebBrowser)

    Private Sub cmdOpenMail_Click(sender As Object, e As EventArgs) Handles cmdOpenMail.Click
        Dim dlgFileOpen As OpenFileDialog = New OpenFileDialog()
        dlgFileOpen.Filter = "Email|*.msg"

        If dlgFileOpen.ShowDialog() = DialogResult.OK Then
            sMsgFile = dlgFileOpen.FileName
            If sMsgFile.Length = 0 Then
                Exit Sub
            End If
            readEmail(sMsgFile)
        End If

    End Sub

    Sub readEmail(sMsgFile As String)
        Try
            sTempDir = GetTemporaryFolder()
            sTempDirectory.Add(sTempDir)

            Dim sMessageTitle As String
            Dim sMessageBodyHTML As String
            Dim sHeaders As String

            Using msg As New MsgReader.Outlook.Storage.Message(sMsgFile)
                lblFrom.Text = "Van: " & msg.GetEmailSender(False, False)
                lblDateTime.Text = "Verzonden op: " & msg.SentOn
                lblTo.Text = "Aan: " & msg.GetEmailRecipients(RecipientType.To, False, False)
                lblCC.Text = "CC: " & msg.GetEmailRecipients(RecipientType.Cc, False, False)
                lblBCC.Text = "BCC: " & msg.GetEmailRecipients(RecipientType.Bcc, False, False)
                lblSubject.Text = "Onderwerp: " & msg.Subject

                sHeaders = String.Format("<div id = ""divRnHeader"" style=""direction: ltr;""><font face=""Tahoma"" size=""2"" color=""#000000""><b>Van:</b> {0}<br><b>Verzonden : </b> {1}<br><b>Aan : </b> {2}<br><b>CC : </b> {3}<br><b>BCC : </b> {4}<br><b>Onderwerp : </b> {5}<br></font><br></div>", msg.GetEmailSender(True, True),
                                                       msg.SentOn, msg.GetEmailRecipients(RecipientType.To, True, True), msg.GetEmailRecipients(RecipientType.Cc, True, True), msg.GetEmailRecipients(RecipientType.Bcc, True, True), msg.Subject)

                sMsgTitle = msg.Subject
                sMessageTitle = "<head><title>" & msg.Subject & "</title>"
                If msg.BodyHtml Is Nothing Then
                    sMessageBodyHTML = msg.BodyText
                Else
                    sMessageBodyHTML = msg.BodyHtml.Replace("<head>", sMessageTitle)
                End If
            End Using
            'get attachments
            Dim msgReader As New Reader()
            Dim filesAttached As String() = msgReader.ExtractToFolder(sMsgFile, sTempDir, True)
            Dim sError As String = msgReader.GetErrorMessage

            If Not String.IsNullOrEmpty(sError) Then
                msgViewer.DocumentText = sHeaders & sMessageBodyHTML
                Throw New Exception("ReaderError: " & sError)
            End If

            If Not String.IsNullOrEmpty(filesAttached(0)) Then
                msgViewer.Navigate(filesAttached(0))
            Else
                msgViewer.DocumentText = sHeaders & sMessageBodyHTML
            End If
            'show attachements
            Dim dirInfo As DirectoryInfo
            Dim fileInfo As FileInfo
            Dim exeIcon As System.Drawing.Icon
            lstAttachments.Clear()
            dirInfo = New DirectoryInfo(sTempDir)
            For Each fileInfo In dirInfo.GetFiles
                If (Not String.IsNullOrEmpty(fileInfo.Extension)) And (Not fileInfo.Extension.Contains(".htm")) Then

                    exeIcon = System.Drawing.Icon.ExtractAssociatedIcon(fileInfo.FullName)

                    If (ImageList1.Images.ContainsKey(fileInfo.FullName)) Then
                        lstAttachments.Items.Add(fileInfo.Name, fileInfo.FullName)
                    ElseIf (Not exeIcon Is Nothing) Then
                        ImageList1.Images.Add(fileInfo.FullName, exeIcon)
                        lstAttachments.Items.Add(fileInfo.Name, fileInfo.FullName)
                    Else
                        lstAttachments.Items.Add(fileInfo.Name)
                    End If

                End If
            Next

        Catch ex As Exception
            MsgBox("Fout bij het openen van de mail: " & ex.Message)
            If sTempDir IsNot Nothing And Directory.Exists(sTempDir) Then
                Directory.Delete(sTempDir)
            End If
        End Try
    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        msgViewer.ShowPrintPreviewDialog()
    End Sub




    Function GetTemporaryFolder()
        Dim sTempDir As String = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString())
        Directory.CreateDirectory(sTempDir)
        Return sTempDir
    End Function


    Private Sub cmdReload_Click(sender As Object, e As EventArgs) Handles cmdReload.Click
        readEmail(sMsgFile)
        cmdReload.Visible = False
    End Sub

    ''' <summary>
    ''' 'minimal code execution on load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblVersion.Text = "RN Outlook Mail Reader V" & Application.ProductVersion & " ©Roy Nijkamp"

        lblAbout.Text = "Over dit programma"
        'cmdReload.Visible = False

        ''tabAttachment.Visible = False
        'tabMessage.DrawMode = TabDrawMode.OwnerDrawFixed
        'tabMessage.SizeMode = TabSizeMode.Fixed
        'tabMessage.ItemSize = New Size(200, 30)
        ''handlers for tab close buttons
        'AddHandler tabMessage.DrawItem, AddressOf tabMessage_DrawItem
        'AddHandler tabMessage.MouseClick, AddressOf tabMessage_MouseClick

        ''laad commandline args
        'Dim iTeller As Integer
        'For Each s As String In My.Application.CommandLineArgs
        '    Select Case iTeller
        '        Case 0
        '            sMsgFile = s.ToString
        '            readEmail(sMsgFile)
        '    End Select
        '    iTeller = iTeller + 1
        'Next
        'Me.Text = sMsgTitle & " RN Outlook Mail Reader V" & Application.ProductVersion & " ©Roy Nijkamp"
    End Sub

    ''' <summary>
    ''' 'execute code after show
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        cmdReload.Visible = False

        'tabAttachment.Visible = False
        tabMessage.DrawMode = TabDrawMode.OwnerDrawFixed
        tabMessage.SizeMode = TabSizeMode.Fixed
        tabMessage.ItemSize = New Size(200, 30)
        'handlers for tab close buttons
        AddHandler tabMessage.DrawItem, AddressOf tabMessage_DrawItem
        AddHandler tabMessage.MouseClick, AddressOf tabMessage_MouseClick

        'laad commandline args
        Dim iTeller As Integer
        For Each s As String In My.Application.CommandLineArgs
            Select Case iTeller
                Case 0
                    sMsgFile = s.ToString
                    readEmail(sMsgFile)
            End Select
            iTeller = iTeller + 1
        Next
        Me.Text = sMsgTitle & " RN Outlook Mail Reader V" & Application.ProductVersion & " ©Roy Nijkamp"
    End Sub

    Private Sub frmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        msgViewer.Navigate("about:blankt")
        'dispose browsers
        For Each myBrowser As WebBrowser In OpenedFiles
            myBrowser.Dispose()
        Next
        'remove tabs back to front
        For i As Integer = tabMessage.TabCount - 1 To 0
            tabMessage.TabPages.RemoveAt(i)
        Next
        'clear temp if possible
        Try
            For Each tempFolder In sTempDirectory
                If Directory.Exists(tempFolder) Then
                    Directory.Delete(tempFolder, True)
                End If
            Next
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub


    Public Sub tabMessage_DrawItem(ByVal sender As System.Object, ByVal e As DrawItemEventArgs)

        Dim TC As TabControl = CType(sender, TabControl)
        'Dim TP As TabPage = TC.SelectedTab
        Dim TabRec As Rectangle = TC.GetTabRect(e.Index)

        Dim Clr As Color = If(e.State = DrawItemState.Selected, Color.White, Color.LightGray)

        e.Graphics.FillRectangle(New SolidBrush(Clr), TabRec)

        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        sf.FormatFlags = StringFormatFlags.NoWrap

        If e.State = DrawItemState.Selected And Not e.Index = 0 Then
            Dim BTNRec As New Rectangle(TabRec.X + TabRec.Width - 30, 8, 18, 18)
            e.Graphics.FillRectangle(Brushes.Red, BTNRec)
            e.Graphics.DrawRectangle(Pens.DarkRed, BTNRec)
            e.Graphics.DrawString("X", New Font(Me.Font.FontFamily, 8, FontStyle.Bold), Brushes.Black, BTNRec, sf)
        End If


        e.Graphics.DrawString(TC.TabPages(e.Index).Text, Me.Font, Brushes.Black, TabRec, sf)

        TabRec.Inflate(-3, -3)

        If Not e.Index = 0 Then
            Dim Pn As Pen = If(e.State = DrawItemState.Selected, New Pen(Color.Green, 2), New Pen(Color.Red, 1))

            e.Graphics.DrawRectangle(Pn, TabRec)
            e.DrawFocusRectangle()
        End If
    End Sub

    Private Sub tabMessage_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Dim TC As TabControl = CType(sender, TabControl)
        Dim Rec As Rectangle = tabMessage.GetTabRect(tabMessage.SelectedIndex)
        Dim HitTest As New Rectangle(Rec.X + Rec.Width - 30, 8, 18, 18)

        If HitTest.Contains(New Point(e.X, e.Y)) Then
            If Not TC.TabPages.Count = 1 Then
                Dim n As Integer = sOpenAttachemnts.RemoveAll(Function(x) x.Contains(TC.SelectedTab.Tag))
                TC.TabPages.Remove(TC.SelectedTab)
            End If
        End If

    End Sub



    Public Function ParseCommandLineArgs()
        Dim strArgs As String = ""
        For Each s As String In My.Application.CommandLineArgs
            strArgs = strArgs & s.ToString
        Next
        Return strArgs
    End Function

    Private Sub lblAbout_Click(sender As Object, e As EventArgs) Handles lblAbout.Click
        Dim fAbout As frmAbout = New frmAbout
        fAbout.ShowDialog()
    End Sub

    Private Sub lstAttachments_MouseDown(sender As Object, e As MouseEventArgs) Handles lstAttachments.MouseDown
        Dim selectedItemsList As New Collections.Specialized.StringCollection
        For Each file As ListViewItem In lstAttachments.Items
            If file.Selected = True Then
                selectedItemsList.Add(sTempDir & "/" & file.Text)
                If lstAttachments.SelectedItems.Count = 1 Then
                    'only open attachment in tab at single selected item
                    openNewTab(file.Text, sTempDir & "/" & file.Text)
                End If
            End If
        Next
        Dim dataObj As New DataObject
        dataObj.SetFileDropList(selectedItemsList)
        lstAttachments.DoDragDrop(dataObj, DragDropEffects.Copy)
    End Sub

    Private Sub lstAttachments_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstAttachments.MouseDoubleClick
        For Each file As ListViewItem In lstAttachments.Items
            If file.Selected = True Then
                Process.Start(sTempDir & "/" & file.Text)
            End If
        Next
    End Sub

    Public Sub openNewTab(ByVal sTitel As String, ByVal sUrl As String)
        bCancelNavigation = True
        If Not sOpenAttachemnts.Contains(sTitel) Then
            sOpenAttachemnts.Add(sTitel)
            Dim tabOpenAttachment As TabPage = New TabPage(sTitel)
            tabOpenAttachment.Tag = sTitel  'use tag to store title for later use
            Dim w As New WebBrowser()
            tabOpenAttachment.Controls.Add(w)
            w.Dock = DockStyle.Fill
            w.Navigate(sUrl)
            tabMessage.TabPages.Add(tabOpenAttachment)
            tabMessage.SelectedIndex = tabMessage.TabCount - 1
            'add browser to list for disposing to prevent file locks
            OpenedFiles.Add(w)
        Else
            'attachement al open, tab weergeven
            Dim index As Integer = sOpenAttachemnts.IndexOf(sTitel)
            'set tab active based on list index + 1 (tab index 0 based but first tab does not count for active tab list)
            tabMessage.SelectedIndex = index + 1
        End If
    End Sub

    Private Sub LinkClicked(ByVal sender As Object, ByVal e As EventArgs)
        Dim link As HtmlElement = msgViewer.Document.ActiveElement
        Dim url As String = link.GetAttribute("href")
        If Not url.Contains("mailto") Then
            'open link / bijlage in volgende TAB
            openNewTab(link.InnerText, url)
        End If
    End Sub

    Private Sub msgViewer_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles msgViewer.Navigating
        If bCancelNavigation = True Then
            e.Cancel = True
            bCancelNavigation = False
        End If
    End Sub

    Private Sub msgViewer_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles msgViewer.DocumentCompleted
        Try
            Dim link As HtmlElement
            Dim links As HtmlElementCollection = msgViewer.Document.Links
            For Each link In links
                link.AttachEventHandler("onclick", AddressOf LinkClicked)
            Next
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub


End Class
