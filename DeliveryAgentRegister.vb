Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class DeliveryAgentRegister
    Dim conn As New SqlConnection("Data Source=DESKTOP-JH6IF3M\SQLEXPRESS;Initial Catalog=Gas27;Integrated Security=True;Encrypt=False")

    ' Hash password function
    Private Function HashPassword(password As String) As String
        Dim sha256 As SHA256 = sha256.Create()
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
        Dim hash As Byte() = sha256.ComputeHash(bytes)
        Return Convert.ToBase64String(hash)
    End Function

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            conn.Open()
            Dim query As String = "INSERT INTO DeliveryAgents (FullName, Username, Password, Email, PhoneNumber, Address) VALUES (@FullName, @Username, @Password, @Email, @PhoneNumber, @Address)"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@FullName", TextBox12.Text)
            cmd.Parameters.AddWithValue("@Username", TextBox11.Text)
            cmd.Parameters.AddWithValue("@Password", HashPassword(TextBox10.Text)) ' Encrypt password
            cmd.Parameters.AddWithValue("@Email", TextBox9.Text)
            cmd.Parameters.AddWithValue("@PhoneNumber", TextBox8.Text)
            cmd.Parameters.AddWithValue("@Address", TextBox7.Text)

            cmd.ExecuteNonQuery()
            MessageBox.Show("Delivery Agent registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Redirect to Login Page
            Login.Show()
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RegisterForm.Show()
        Me.Hide()
    End Sub


End Class
