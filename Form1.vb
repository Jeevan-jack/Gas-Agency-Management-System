Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Start the Timer when Splash Screen loads
        Timer1.Start()
        End Sub

        Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Increase progress bar value
        ProgressBar1.Increment(5)
        Label1.Text = "Loading... " & ProgressBar1.Value & "%"

            ' Once progress bar reaches 100%, open Main Menu and close Splash Screen
            If ProgressBar1.Value = 100 Then
                Timer1.Stop()
                MainMenu.Show()  ' Open MainMenu form
                Me.Hide()        ' Hide Splash Screen
            End If
        End Sub
    End Class

