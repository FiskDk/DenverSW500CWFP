Public Class Debug
    Dim appPath As String = Application.StartupPath()
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        form1.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Step2.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Step3.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Step4.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Step5.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Progress.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Start.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        GetItStarted()

    End Sub
    Sub GetItStarted()
        Dim answer As String
        MsgBox(GetNewestSubFolder("C:\Program Files\Java\"))
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
                'Paste the "continue" code here
                IO.File.WriteAllText(appPath & "\java.path", newjdk)
            Else
                'Retry.
                Dim retryjdk As String = InputBox("Please paste in your jdk path eg C:\Program Files\Java\jdk1.8.0_192", "JDK Path Check", "Leave blank if the above path is ok")
                IO.File.WriteAllText(appPath & "\java.path", retryjdk)
            End If
        End If
    End Sub
End Class