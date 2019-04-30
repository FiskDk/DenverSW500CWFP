Imports System.IO
Public Class form1
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Label2.Text = OpenFileDialog.FileName
            RectangleShape1.BackgroundImage = Image.FromFile(Label2.Text)

            Dim NewSize As New Size(150, 150)
            ResizedImage = New Bitmap(RectangleShape1.BackgroundImage, NewSize)
            RectangleShape1.BackgroundImage = ResizedImage
            RectangleShape1.BackgroundImageLayout = ImageLayout.Stretch
            ImgSelected = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ImgSelected = True Then
            If IO.File.Exists(appPath & "\Workspace\clockrendering0.png") Then
                IO.File.Delete(appPath & "\Workspace\clockrendering0.png")
            End If
            RectangleShape1.BackgroundImage.Save(appPath & "\Workspace\clockrendering0.png")
            Step2.Show()
            Me.Close()
        Else
            MsgBox("Please select your image first :)")
        End If
    End Sub

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RectangleShape1.BringToFront()
    End Sub

    Private Sub RectangleShape1_Click(sender As Object, e As EventArgs) Handles RectangleShape1.Click

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