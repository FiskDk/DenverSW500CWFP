Public Class Step4
    Dim ResizedImage As Image
    Dim appPath As String = Application.StartupPath()
    Dim ImgSelected As Boolean
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Label2.Text = OpenFileDialog.FileName
            RectangleShape3.BackgroundImage = Image.FromFile(Label2.Text)

            Dim NewSize As New Size(250, 250)
            ResizedImage = New Bitmap(RectangleShape3.BackgroundImage, NewSize)
            RectangleShape3.BackgroundImage = ResizedImage
            RectangleShape3.BackgroundImageLayout = ImageLayout.Stretch
            ImgSelected = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ImgSelected = True Then
            If IO.File.Exists(appPath & "\Workspace\clockminute0.png") Then
                IO.File.Delete(appPath & "\Workspace\clockminute0.png")
            End If
            RectangleShape3.BackgroundImage.Save(appPath & "\Workspace\clockminute0.png")
            Me.Close()
            Step5.Show()
        Else
            MsgBox("Please select your image first!")
        End If
    End Sub
    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        If ImgSelected = False Then
            Button2.Text = "Please choose your image first."
        Else
            Button2.Text = "Next"
        End If
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.Text = "Next"
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Start.Close()
        Me.Close()
    End Sub
End Class