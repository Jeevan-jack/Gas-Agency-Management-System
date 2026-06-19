
Public Class Mainmenu
    Private Sub button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RegisterForm.Show()  ' Open the Registration Form
        Me.Hide()        ' Hide Main Menu
    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Login.Show()  ' Open the Login Form
        Me.Hide()     ' Hide Main Menu
    End Sub

    Private Sub button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Application.Exit()  ' Close the application
    End Sub
End Class
