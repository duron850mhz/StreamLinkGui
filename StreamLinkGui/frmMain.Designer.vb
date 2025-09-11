<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        lblGetName = New Label()
        lblDownload = New Label()
        lblEncode = New Label()
        txtGetName = New TextBox()
        txtDownload = New TextBox()
        txtEncode = New TextBox()
        btnOK = New Button()
        txtURL = New TextBox()
        lblURL = New Label()
        txtStreamLinkPath = New TextBox()
        lblStreamLinkPath = New Label()
        txtFfmpegPath = New TextBox()
        lblFfmpegPath = New Label()
        btnStreamLinkPathRef = New Button()
        btnFfmpegPathRef = New Button()
        txtPattern = New TextBox()
        lblPattern = New Label()
        txtOutputFolder = New TextBox()
        lblOutputFolder = New Label()
        btnOutputFolderRef = New Button()
        SuspendLayout()
        ' 
        ' lblGetName
        ' 
        lblGetName.AutoSize = True
        lblGetName.Location = New Point(12, 102)
        lblGetName.Name = "lblGetName"
        lblGetName.Size = New Size(77, 15)
        lblGetName.TabIndex = 7
        lblGetName.Text = "ファイル名取得"
        ' 
        ' lblDownload
        ' 
        lblDownload.AutoSize = True
        lblDownload.Location = New Point(12, 131)
        lblDownload.Name = "lblDownload"
        lblDownload.Size = New Size(59, 15)
        lblDownload.TabIndex = 9
        lblDownload.Text = "ダウンロード"
        ' 
        ' lblEncode
        ' 
        lblEncode.AutoSize = True
        lblEncode.Location = New Point(12, 189)
        lblEncode.Name = "lblEncode"
        lblEncode.Size = New Size(49, 15)
        lblEncode.TabIndex = 14
        lblEncode.Text = "エンコード"
        ' 
        ' txtGetName
        ' 
        txtGetName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtGetName.Location = New Point(97, 99)
        txtGetName.Name = "txtGetName"
        txtGetName.Size = New Size(691, 23)
        txtGetName.TabIndex = 8
        ' 
        ' txtDownload
        ' 
        txtDownload.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtDownload.Location = New Point(97, 128)
        txtDownload.Name = "txtDownload"
        txtDownload.Size = New Size(691, 23)
        txtDownload.TabIndex = 10
        ' 
        ' txtEncode
        ' 
        txtEncode.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtEncode.Location = New Point(97, 186)
        txtEncode.Name = "txtEncode"
        txtEncode.Size = New Size(691, 23)
        txtEncode.TabIndex = 15
        ' 
        ' btnOK
        ' 
        btnOK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnOK.Location = New Point(713, 251)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(75, 23)
        btnOK.TabIndex = 19
        btnOK.Text = "実行"
        btnOK.UseVisualStyleBackColor = True
        ' 
        ' txtURL
        ' 
        txtURL.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtURL.Location = New Point(97, 12)
        txtURL.Name = "txtURL"
        txtURL.Size = New Size(691, 23)
        txtURL.TabIndex = 1
        ' 
        ' lblURL
        ' 
        lblURL.AutoSize = True
        lblURL.Location = New Point(12, 15)
        lblURL.Name = "lblURL"
        lblURL.Size = New Size(28, 15)
        lblURL.TabIndex = 0
        lblURL.Text = "URL"
        ' 
        ' txtStreamLinkPath
        ' 
        txtStreamLinkPath.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtStreamLinkPath.Location = New Point(97, 41)
        txtStreamLinkPath.Name = "txtStreamLinkPath"
        txtStreamLinkPath.Size = New Size(662, 23)
        txtStreamLinkPath.TabIndex = 3
        ' 
        ' lblStreamLinkPath
        ' 
        lblStreamLinkPath.AutoSize = True
        lblStreamLinkPath.Location = New Point(12, 44)
        lblStreamLinkPath.Name = "lblStreamLinkPath"
        lblStreamLinkPath.Size = New Size(82, 15)
        lblStreamLinkPath.TabIndex = 2
        lblStreamLinkPath.Text = "streamlink.exe"
        ' 
        ' txtFfmpegPath
        ' 
        txtFfmpegPath.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtFfmpegPath.Location = New Point(97, 157)
        txtFfmpegPath.Name = "txtFfmpegPath"
        txtFfmpegPath.Size = New Size(662, 23)
        txtFfmpegPath.TabIndex = 12
        ' 
        ' lblFfmpegPath
        ' 
        lblFfmpegPath.AutoSize = True
        lblFfmpegPath.Location = New Point(12, 160)
        lblFfmpegPath.Name = "lblFfmpegPath"
        lblFfmpegPath.Size = New Size(65, 15)
        lblFfmpegPath.TabIndex = 11
        lblFfmpegPath.Text = "ffmpeg.exe"
        ' 
        ' btnStreamLinkPathRef
        ' 
        btnStreamLinkPathRef.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnStreamLinkPathRef.Location = New Point(765, 41)
        btnStreamLinkPathRef.Name = "btnStreamLinkPathRef"
        btnStreamLinkPathRef.Size = New Size(23, 23)
        btnStreamLinkPathRef.TabIndex = 4
        btnStreamLinkPathRef.Text = "..."
        btnStreamLinkPathRef.UseVisualStyleBackColor = True
        ' 
        ' btnFfmpegPathRef
        ' 
        btnFfmpegPathRef.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnFfmpegPathRef.Location = New Point(765, 157)
        btnFfmpegPathRef.Name = "btnFfmpegPathRef"
        btnFfmpegPathRef.Size = New Size(23, 23)
        btnFfmpegPathRef.TabIndex = 13
        btnFfmpegPathRef.Text = "..."
        btnFfmpegPathRef.UseVisualStyleBackColor = True
        ' 
        ' txtPattern
        ' 
        txtPattern.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtPattern.Location = New Point(97, 70)
        txtPattern.Name = "txtPattern"
        txtPattern.Size = New Size(691, 23)
        txtPattern.TabIndex = 6
        ' 
        ' lblPattern
        ' 
        lblPattern.AutoSize = True
        lblPattern.Location = New Point(12, 73)
        lblPattern.Name = "lblPattern"
        lblPattern.Size = New Size(43, 15)
        lblPattern.TabIndex = 5
        lblPattern.Text = "パターン"
        ' 
        ' txtOutputFolder
        ' 
        txtOutputFolder.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtOutputFolder.Location = New Point(97, 215)
        txtOutputFolder.Name = "txtOutputFolder"
        txtOutputFolder.Size = New Size(662, 23)
        txtOutputFolder.TabIndex = 17
        ' 
        ' lblOutputFolder
        ' 
        lblOutputFolder.AutoSize = True
        lblOutputFolder.Location = New Point(12, 218)
        lblOutputFolder.Name = "lblOutputFolder"
        lblOutputFolder.Size = New Size(43, 15)
        lblOutputFolder.TabIndex = 16
        lblOutputFolder.Text = "出力先"
        ' 
        ' btnOutputFolderRef
        ' 
        btnOutputFolderRef.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnOutputFolderRef.Location = New Point(765, 218)
        btnOutputFolderRef.Name = "btnOutputFolderRef"
        btnOutputFolderRef.Size = New Size(23, 23)
        btnOutputFolderRef.TabIndex = 18
        btnOutputFolderRef.Text = "..."
        btnOutputFolderRef.UseVisualStyleBackColor = True
        ' 
        ' frmMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 286)
        Controls.Add(btnOutputFolderRef)
        Controls.Add(txtOutputFolder)
        Controls.Add(lblOutputFolder)
        Controls.Add(txtPattern)
        Controls.Add(lblPattern)
        Controls.Add(btnFfmpegPathRef)
        Controls.Add(btnStreamLinkPathRef)
        Controls.Add(txtFfmpegPath)
        Controls.Add(lblFfmpegPath)
        Controls.Add(txtStreamLinkPath)
        Controls.Add(lblStreamLinkPath)
        Controls.Add(txtURL)
        Controls.Add(lblURL)
        Controls.Add(btnOK)
        Controls.Add(txtEncode)
        Controls.Add(txtDownload)
        Controls.Add(txtGetName)
        Controls.Add(lblEncode)
        Controls.Add(lblDownload)
        Controls.Add(lblGetName)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmMain"
        Text = "StreamLinkGUI"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblGetName As Label
    Friend WithEvents lblDownload As Label
    Friend WithEvents lblEncode As Label
    Friend WithEvents txtGetName As TextBox
    Friend WithEvents txtDownload As TextBox
    Friend WithEvents txtEncode As TextBox
    Friend WithEvents btnOK As Button
    Friend WithEvents txtURL As TextBox
    Friend WithEvents lblURL As Label
    Friend WithEvents txtStreamLinkPath As TextBox
    Friend WithEvents lblStreamLinkPath As Label
    Friend WithEvents txtFfmpegPath As TextBox
    Friend WithEvents lblFfmpegPath As Label
    Friend WithEvents btnStreamLinkPathRef As Button
    Friend WithEvents btnFfmpegPathRef As Button
    Friend WithEvents txtPattern As TextBox
    Friend WithEvents lblPattern As Label
    Friend WithEvents txtOutputFolder As TextBox
    Friend WithEvents lblOutputFolder As Label
    Friend WithEvents btnOutputFolderRef As Button

End Class
