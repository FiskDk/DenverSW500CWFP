Public Class splashscreen
    Dim loader As Integer = 0
    Dim appPath As String = Environment.CurrentDirectory
    Private Sub splashscreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Starts to check for folders,
        If Environment.CurrentDirectory.Contains(" ") Then
            MsgBox("Error: The program have been installed in a location where the directory path contains one or more spaces!, To fix this error please move all the files to a directory without any spaces.")
            Start.Close()
        End If
        If Not IO.File.Exists(Environment.CurrentDirectory & "\Workspace\fresh.apk") Then
            MsgBox("Error: Fresh.apk not found!")
            Start.Close()
        End If
        If Not IO.File.Exists(Environment.CurrentDirectory & "\Workspace\signmeup.keystore") Then
            MsgBox("Error: Keystore not found!")
            Start.Close()
        End If
        If Not IO.Directory.Exists(appPath & "\Workspace") Then
            MsgBox("Error: Workspace not found!")
            Start.Close()

        End If
        If Not IO.Directory.Exists(appPath & "\android sdk") Then
            MsgBox("Android SDK not found!")
            Start.Close()
        End If

        If Not IO.File.Exists(appPath & "\7za.exe") Then
            MsgBox("Error: Files corupt or missing(7za)")
            Start.Close()
        End If
        If Not IO.File.Exists(appPath & "\keytool.exe") Then
            MsgBox("Error: Java files corrupt or missing")
            Start.Close()
        End If
        If Not IO.File.Exists(appPath & "\signer.cmd") Then
            MsgBox("Fatal Error: Main program files corrupt!")
            Start.Close()
        End If
        If Not IO.File.Exists(appPath & "\guiScript.cmd") Then
            MsgBox("Fatal Error: Main program files corrupt!")
            Start.Close()
        End If
        If Not IO.File.Exists(appPath & "\gui.cmd") Then
            MsgBox("Fatal Error: Main program files corrupt!")
            Start.Close()
        End If
        If Not IO.File.Exists(appPath & "\continue.cmd") Then
            MsgBox("Fatal Error: Main program files corrupt!")
            Start.Close()
        End If
        Timer1.Start()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        loader = loader + 1
        If loader = 5 Then
            Label2.Text = "Starting up."
        End If
        If loader = 10 Then
            Label2.Text = "Starting up.."
        End If
        If loader = 15 Then
            Label2.Text = "Starting up..."
        End If
        If loader = 20 Then
            Label2.Text = "Starting up."
        End If
        If loader = 25 Then
            Label2.Text = "Starting up.."
        End If
        If loader = 30 Then
            Label2.Text = "Starting up..."
        End If
        If loader = 35 Then
            Label2.Text = "Starting up."
        End If
        If loader = 40 Then
            Label2.Text = "Starting up.."
        End If
        If loader = 45 Then
            Label2.Text = "Starting up..."
        End If
        If loader = 50 Then
            Label2.Text = "Starting up."
        End If
        If loader = 55 Then
            Label2.Text = "Starting up.."
        End If
        If loader = 60 Then
            Label2.Text = "Starting up..."
        End If
        If loader = 65 Then
            Label2.Text = "Starting up."
        End If
        If loader = 70 Then
            Label2.Text = "Starting up.."
        End If
        If loader = 75 Then
            Label2.Text = "Starting up..."
        End If
        If loader = 80 Then
            Label2.Text = "Starting up."
        End If
        If loader = 85 Then
            Label2.Text = "Starting up.."
        End If
        If loader = 90 Then
            Label2.Text = "Starting up..."
        End If
        If loader = 95 Then
            Label2.Text = "Starting up."
        End If
        If loader = 96 Then
            Label2.Text = "Cleaning workspace..."
        End If
        If loader = 100 Then
            form1.Show()
            Me.Hide()
            Timer1.Stop()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label2.Text = "Starting up."

    End Sub
End Class