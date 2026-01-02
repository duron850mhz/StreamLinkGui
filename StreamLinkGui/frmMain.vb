Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports Newtonsoft.Json.Linq
Imports System.Text
Imports System.IO

Public Class frmMain

    Private ini As New IniFile(Path.Combine(Application.StartupPath, "config.ini"))
    Dim strTempPath As String = Path.Combine(Path.GetTempPath, Application.ProductName)

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' デフォルトだとShift-JISが有効じゃないらしい
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)

        txtStreamLinkPath.Text = ini.Read("Settings", txtStreamLinkPath.Name, "streamlink.exe")
        txtPattern.Text = ini.Read("Settings", txtPattern.Name, "{id}-{author}-{title}.ts")
        txtGetName.Text = ini.Read("Settings", txtGetName.Name, "--niconico-user-session user_session_xxxxxxxxxx --json")
        txtDownload.Text = ini.Read("Settings", txtDownload.Name, "--niconico-user-session user_session_xxxxxxxxxx [url] --output ""[filename]"" best")
        txtFfmpegPath.Text = ini.Read("Settings", txtFfmpegPath.Name, "ffmpeg.exe")
        txtEncode.Text = ini.Read("Settings", txtEncode.Name, "-i ""[input]"" -ss 600 -c:v copy -c:a copy ""[output]""")
        txtOutputFolder.Text = ini.Read("Settings", txtOutputFolder.Name, Application.StartupPath)

        If Path.Exists(strTempPath) = True Then
            Try
                Directory.Delete(strTempPath, True)
            Catch ex As Exception
                MessageBox.Show("一時ファイルを削除できませんでした: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        Directory.CreateDirectory(strTempPath)
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ini.Write("Settings", txtStreamLinkPath.Name, txtStreamLinkPath.Text)
        ini.Write("Settings", txtPattern.Name, txtPattern.Text)
        ini.Write("Settings", txtGetName.Name, txtGetName.Text)
        ini.Write("Settings", txtDownload.Name, txtDownload.Text)
        ini.Write("Settings", txtFfmpegPath.Name, txtFfmpegPath.Text)
        ini.Write("Settings", txtEncode.Name, txtEncode.Text)
        ini.Write("Settings", txtOutputFolder.Name, txtOutputFolder.Text)
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If txtURL.Text <> "" Then
            If txtStreamLinkPath.Text <> "" Then
                If txtGetName.Text <> "" Then
                    If txtFfmpegPath.Text <> "" Then
                        If txtDownload.Text <> "" Then
                            If txtEncode.Text <> "" Then
                                Dim strURL As String = txtURL.Text.Trim()
                                Dim strName As String = I_GetName(strURL)
                                If I_Download(strURL, strName) = True Then
                                    If I_Encode(strName, Path.ChangeExtension(strName, "mp4")) = True Then
                                        'MessageBox.Show("ダウンロードとエンコードが正常に完了しました。", "成功しました", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                        ' Clean up temporary files
                                        Try
                                            Directory.Delete(strTempPath, True)
                                            ' Close the form
                                            Me.Close()
                                        Catch ex As Exception
                                            MessageBox.Show("一時ファイルを削除できませんでした: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        End Try
                                    Else
                                        MessageBox.Show("「エンコードに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If
                                End If
                            Else
                                MessageBox.Show("エンコードするコマンドを入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show("ダウンロードするコマンドを入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("ffmpeg.exeへのパスを入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("名前を取得するコマンドを入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("streamlink.exeへのパスを入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("URLを入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    ''' <summary>
    ''' ファイル名取得
    ''' </summary>
    ''' <param name="strURL"></param>
    ''' <returns></returns>
    Private Function I_GetName(strURL As String) As String
        ' プロセス実行情報の設定
        Dim startInfo As New ProcessStartInfo()
        startInfo.FileName = txtStreamLinkPath.Text.Trim() ' Streamlinkのパス
        startInfo.Arguments = txtGetName.Text.Trim() & " """ & strURL & """" ' 引数にURLを追加
        startInfo.RedirectStandardOutput = True ' 標準出力をリダイレクト
        startInfo.UseShellExecute = False
        startInfo.CreateNoWindow = True ' 新しいウィンドウを作成しない

        Dim output As String = ""
        Using process As Process = Process.Start(startInfo)
            ' プロセスの出力をすべて読み取る
            output = process.StandardOutput.ReadToEnd()
            process.WaitForExit()
        End Using

        ' JSONとして解析
        Dim json As JObject = JObject.Parse(output)
        ' metadataオブジェクトを取得
        Dim metadata As JObject = TryCast(json("metadata"), JObject)

        ' 必要な項目を取得
        Dim title As String = metadata.Value(Of String)("title")
        Dim author As String = metadata.Value(Of String)("author")
        Dim id As String = metadata.Value(Of String)("id")

        '置換
        Dim strName As String = txtPattern.Text.Trim()
        strName = strName.Replace("{id}", id)
        strName = strName.Replace("{author}", author)
        strName = strName.Replace("{title}", title)

        ' ファイル名に使用できない文字を全角に置換
        Dim invalidChars As Char() = Path.GetInvalidFileNameChars()
        For Each c As Char In invalidChars
            strName = strName.Replace(c, Strings.StrConv(c, VbStrConv.Wide))
        Next

        Return strName
    End Function

    ''' <summary>
    ''' ダウンロード
    ''' </summary>
    ''' <param name="strURL"></param>
    ''' <param name="strName"></param
    ''' <returns></returns>
    Private Function I_Download(strURL As String, strName As String) As Boolean
        ' ダウンロードコマンドの実行
        Dim psi As New ProcessStartInfo()
        psi.FileName = txtStreamLinkPath.Text.Trim() ' Streamlinkのパス
        Dim strArgs As String = txtDownload.Text.Trim()
        strArgs = strArgs.Replace("[url]", strURL)
        strArgs = strArgs.Replace("[filename]", Path.Combine(strTempPath, strName))
        psi.Arguments = strArgs
        psi.RedirectStandardOutput = False  ' 標準出力をリダイレクトしない
        psi.UseShellExecute = True  ' UseShellExecuteをTrueに設定
        psi.CreateNoWindow = False
        Using process As Process = Process.Start(psi)
            process.WaitForExit()
            Return process.ExitCode = 0 ' 成功したかどうかを確認
        End Using
    End Function

    ''' <summary>
    ''' エンコード
    ''' </summary>
    ''' <param name="strName"></param>
    ''' <param name="strInput"></param>
    ''' <param name="strOutput"></param>
    ''' <returns></returns>
    Private Function I_Encode(strInput As String, strOutput As String) As Boolean
        ' エンコードコマンドの実行
        Dim psi As New ProcessStartInfo()
        psi.FileName = txtFfmpegPath.Text.Trim() ' ffmpegのパス
        psi.Arguments = txtEncode.Text.Trim().Replace("[input]", Path.Combine(strTempPath, strInput)).Replace("[output]", Path.Combine(txtOutputFolder.Text, strOutput))
        psi.RedirectStandardOutput = True ' 標準出力をリダイレクト
        psi.UseShellExecute = False
        psi.CreateNoWindow = False
        Using process As Process = Process.Start(psi)
            process.WaitForExit()
            Return process.ExitCode = 0 ' 成功したかどうかを確認
        End Using
    End Function

    ''' <summary>
    ''' ファイル参照
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnStreamLinkPathRef_Click(sender As Object, e As EventArgs) Handles btnStreamLinkPathRef.Click, btnFfmpegPathRef.Click
        Using ofd As New OpenFileDialog
            ofd.Filter = "実行ファイル|*.exe|すべてのファイル|*.*"
            ofd.Title = "実行ファイルを選択してください。"
            If ofd.ShowDialog = DialogResult.OK Then
                Dim txtBox = If(sender Is btnStreamLinkPathRef, txtStreamLinkPath, txtFfmpegPath)
                txtBox.Text = ofd.FileName
            End If
        End Using
    End Sub

    ''' <summary>
    ''' 出力先フォルダ参照
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOutputFolderRef_Click(sender As Object, e As EventArgs) Handles btnOutputFolderRef.Click
        Using fbd As New FolderBrowserDialog
            fbd.Description = "出力フォルダを選択してください。"
            If fbd.ShowDialog() = DialogResult.OK Then
                txtOutputFolder.Text = fbd.SelectedPath
            End If
        End Using
    End Sub
End Class
