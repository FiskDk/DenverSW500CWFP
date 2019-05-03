Public Class Start
    Dim appPath As String = Application.StartupPath()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        form1.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Debug.Show()
        Me.Hide()
    End Sub

    Private Sub Start_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IO.File.Exists(appPath & "\done") Then
            IO.File.Delete(appPath & "\done")
        End If
        If IO.File.Exists(appPath & "\java.path") Then
            IO.File.Delete(appPath & "\java.path")
        End If
        Me.WindowState = FormWindowState.Minimized
        splashscreen.Show()

    End Sub
End Class