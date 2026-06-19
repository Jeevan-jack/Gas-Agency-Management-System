

Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class CustomerRegister
    Dim conn As New SqlConnection("Data Source=DESKTOP-JH6IF3M\SQLEXPRESS;Initial Catalog=Gas27;Integrated Security=True;Encrypt=False")

    ' Hash password function using SHA256
    Private Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
            Dim hash As Byte() = sha256.ComputeHash(bytes)
            Return Convert.ToBase64String(hash)
        End Using
    End Function

    ' Register Button Click
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Basic validation
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
            MessageBox.Show("Please fill all required fields!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            conn.Open()

            ' SQL Insert Query
            Dim query As String = "INSERT INTO Customers (FullName, Username, Password, Email, PhoneNumber, Address) 
                                   OUTPUT INSERTED.CustomerID 
                                   VALUES (@FullName, @Username, @Password, @Email, @PhoneNumber, @Address)"

            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@FullName", TextBox1.Text.Trim())
            cmd.Parameters.AddWithValue("@Username", TextBox2.Text.Trim())
            cmd.Parameters.AddWithValue("@Password", HashPassword(TextBox3.Text.Trim()))
            cmd.Parameters.AddWithValue("@Email", TextBox4.Text.Trim())
            cmd.Parameters.AddWithValue("@PhoneNumber", TextBox5.Text.Trim())
            cmd.Parameters.AddWithValue("@Address", TextBox6.Text.Trim())

            ' Get inserted ID
            Dim insertedID As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            MessageBox.Show("Customer registered successfully! Your Customer ID is: " & insertedID, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Redirect to Login (manually login)
            Dim loginForm As New Login()
            loginForm.Show()
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    ' Back Button Click
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RegisterForm.Show()
        Me.Hide()
    End Sub
End Class
