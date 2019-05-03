Public Class Progress

    Dim donechecker As Boolean = False
    Private psi As ProcessStartInfo
    Private cmd As Process

    Private Delegate Sub InvokeWithString(ByVal text As String)
    Dim ImgSelected As Boolean = False
    Dim appPath As String = Application.StartupPath()
    Dim ResizedImage As Image
    Private IsFormBeingDragged As Boolean = False
    Private MouseDownX As Integer
    Private MouseDownY As Integer

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown

        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseUp

        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseMove

        If IsFormBeingDragged Then
            Dim temp As Point = New Point()

            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub
    Function GetNewestSubFolder(ByRef strPath As String) As String
        'Jim Cone - Portland, Oregon USA
        Dim oFSO As Object
        Dim oFolder As Object
        Dim oSubFldr As Object
        Dim strFolderPath As String = Nothing
        Dim dteDate As Date

        oFSO = CreateObject("Scripting.FileSystemObject")
        oFolder = oFSO.GetFolder(strPath)

        For Each oSubFldr In oFolder.Subfolders
            If oSubFldr.DateLastModified > dteDate Then
                dteDate = oSubFldr.DateLastModified
                strFolderPath = oSubFldr.Path
            End If
        Next
        GetNewestSubFolder = strFolderPath

        oSubFldr = Nothing
        oFolder = Nothing
        oFSO = Nothing
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GetItStarted()
        If Not IO.File.Exists(appPath & "\java.path") Then
            MsgBox("Java path Not found.")
        End If
        If TextBox2.Text = "debug.activate" Then
            TextBox1.Show()
            TextBox2.Text = "Debugging mode activated. Please be carefull, you may break something." & Environment.NewLine & "Just a heads up, This almost functions as a admin shell. You have been warned."
        Else
            Try
                cmd.Kill()
            Catch ex As Exception
            End Try
            TextBox2.Clear()
            If TextBox1.Text.Contains(" ") Then
                psi = New ProcessStartInfo(TextBox1.Text.Split(" ")(0), TextBox1.Text.Split(" ")(1))
            Else
                psi = New ProcessStartInfo(TextBox1.Text$)
            End If
            Dim systemencoding As System.Text.Encoding
            System.Text.Encoding.GetEncoding(Globalization.CultureInfo.CurrentUICulture.TextInfo.OEMCodePage)
            With psi
                .UseShellExecute = False
                .RedirectStandardError = True
                .RedirectStandardOutput = True
                .RedirectStandardInput = True
                .CreateNoWindow = True
                .StandardOutputEncoding = systemencoding
                .StandardErrorEncoding = systemencoding
            End With
            cmd = New Process With {.StartInfo = psi, .EnableRaisingEvents = True}
            AddHandler cmd.ErrorDataReceived, AddressOf Async_Data_Received
            AddHandler cmd.OutputDataReceived, AddressOf Async_Data_Received
            cmd.Start()
            cmd.BeginOutputReadLine()
            cmd.BeginErrorReadLine()
            Label1.Text = "Please Wait..."
            Timer1.Start()

        End If
    End Sub
    Private Sub Async_Data_Received(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        Me.Invoke(New InvokeWithString(AddressOf Sync_Output), e.Data)
    End Sub
    Private Sub Sync_Output(ByVal text As String)
        TextBox2.AppendText(text & Environment.NewLine)
        TextBox2.ScrollToCaret()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Progress_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = "gui.cmd"

    End Sub
    Sub GetItStarted()
        Dim answer As String
        Dim newjdk As String = InputBox("Is this : " & GetNewestSubFolder("C:\Program Files\Java\") & " your java JDK Folder? if not Please paste in your JDK path here.", "JDK Path Check", "Leave blank if the above path is ok")
        If newjdk = "" Then
            answer = MsgBox("Just to be sure, You mean your java jdk path is : " & GetNewestSubFolder("C:\Program Files\Java") & "?", MsgBoxStyle.YesNo)
            If answer = "6" Then 'Checks if user pressed "Yes" in the dialog box
                'Paste the "continue" code here
                IO.File.WriteAllText(appPath & "\java.path", GetNewestSubFolder("C:\Program Files\Java"))
            Else
                'Retry.
                Dim retryjdk As String = InputBox("Please paste in your jdk path eg C:\Program Files\Java\jdk1.8.0_192", "JDK Path Check", "Leave blank if the above path is ok")
                IO.File.WriteAllText(appPath & "\java.path", retryjdk)
            End If
        Else
            answer = MsgBox("Just to be sure, You mean your java jdk path is : " & newjdk & "?", MsgBoxStyle.YesNo)
            If answer = "6" Then 'Checks if user pressed "Yes" in the dialog box
                IO.File.WriteAllText(appPath & "\java.path", newjdk)
            Else
                'Retry.
                Dim retryjdk As String = InputBox("Please paste in your jdk path eg C:\Program Files\Java\jdk1.8.0_192", "JDK Path Check", "Leave blank if the above path is ok")
                IO.File.WriteAllText(appPath & "\java.path", retryjdk)
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not IO.File.Exists(appPath & "\done") Then
            Label1.Text = "Waiting for the jarsigner process to end..."
        Else
            Label1.Text = "Continueing..."
            TextBox1.Text = "continue.cmd"
            Try
                cmd.Kill()
            Catch ex As Exception
            End Try
            If TextBox1.Text.Contains(" ") Then
                psi = New ProcessStartInfo(TextBox1.Text.Split(" ")(0), TextBox1.Text.Split(" ")(1))
            Else
                psi = New ProcessStartInfo(TextBox1.Text$)
            End If
            Dim systemencoding As System.Text.Encoding
            System.Text.Encoding.GetEncoding(Globalization.CultureInfo.CurrentUICulture.TextInfo.OEMCodePage)
            With psi
                .UseShellExecute = False
                .RedirectStandardError = True
                .RedirectStandardOutput = True
                .RedirectStandardInput = True
                .CreateNoWindow = True
                .StandardOutputEncoding = systemencoding
                .StandardErrorEncoding = systemencoding
            End With
            cmd = New Process With {.StartInfo = psi, .EnableRaisingEvents = True}
            AddHandler cmd.ErrorDataReceived, AddressOf Async_Data_Received
            AddHandler cmd.OutputDataReceived, AddressOf Async_Data_Received
            cmd.Start()
            cmd.BeginOutputReadLine()
            cmd.BeginErrorReadLine()
            Timer1.Stop()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Start.Close()
        Me.Close()
    End Sub
End Class