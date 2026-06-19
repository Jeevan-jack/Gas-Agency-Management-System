
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class Login
    ' SQL Connection String
    Dim conn As New SqlConnection("Data Source=DESKTOP-JH6IF3M\SQLEXPRESS;Initial Catalog=Gas27;Integrated Security=True;Encrypt=False")

    ' Global Shared Variables for role-based redirection
    Public Shared AdminID As Integer
    Public Shared CustomerID As Integer
    Public Shared DeliveryAgentID As Integer

    ' Password hashing function using SHA256
    Private Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
            Dim hash As Byte() = sha256.ComputeHash(bytes)
            Return Convert.ToBase64String(hash)
        End Using
    End Function

    ' Form Load
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetPlaceholder(TextBox1, "Username", False)
        SetPlaceholder(TextBox2, "Password", True)

        ComboBox1.Items.Clear()
        ComboBox1.Items.AddRange({"Select Role", "Admin", "Customer", "DeliveryAgent"})
        ComboBox1.SelectedIndex = 0
    End Sub

    ' Placeholder Handling
    Private Sub SetPlaceholder(txt As TextBox, placeholder As String, isPassword As Boolean)
        txt.Text = placeholder
        txt.ForeColor = Color.Black
        txt.UseSystemPasswordChar = False
    End Sub

    Private Sub RemovePlaceholder(txt As TextBox, isPassword As Boolean)
        If txt.Text = "Username" Or txt.Text = "Password" Then
            txt.Text = ""
            txt.ForeColor = Color.Black
            txt.UseSystemPasswordChar = isPassword
        End If
    End Sub

    Private Sub RestorePlaceholder(txt As TextBox, placeholder As String, isPassword As Boolean)
        If String.IsNullOrWhiteSpace(txt.Text) Then
            txt.Text = placeholder
            txt.ForeColor = Color.Black
            txt.UseSystemPasswordChar = False
        End If
    End Sub

    ' TextBox Events
    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        RemovePlaceholder(TextBox1, False)
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        RestorePlaceholder(TextBox1, "Username", False)
    End Sub

    Private Sub TextBox2_Enter(sender As Object, e As EventArgs) Handles TextBox2.Enter
        RemovePlaceholder(TextBox2, True)
    End Sub

    Private Sub TextBox2_Leave(sender As Object, e As EventArgs) Handles TextBox2.Leave
        RestorePlaceholder(TextBox2, "Password", True)
    End Sub

    ' Login Button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = TextBox1.Text.Trim()
        Dim password As String = TextBox2.Text.Trim()
        Dim role As String = ComboBox1.SelectedItem?.ToString()

        If username = "Username" OrElse password = "Password" OrElse role = "Select Role" Then
            MessageBox.Show("Please fill in all fields!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim hashedPassword As String = HashPassword(password)

        Try
            conn.Open()
            Dim query As String = ""
            Dim idColumn As String = ""

            Select Case role
                Case "Admin"
                    query = "SELECT AdminID FROM Admins WHERE Username=@Username AND Password=@Password"
                    idColumn = "AdminID"
                Case "Customer"
                    query = "SELECT CustomerID FROM Customers WHERE Username=@Username AND Password=@Password"
                    idColumn = "CustomerID"
                Case "DeliveryAgent"
                    query = "SELECT DeliveryAgentID FROM DeliveryAgents WHERE Username=@Username AND Password=@Password"
                    idColumn = "DeliveryAgentID"
                Case Else
                    MessageBox.Show("Please select a valid role!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
            End Select

            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@Username", username)
            cmd.Parameters.AddWithValue("@Password", hashedPassword)

            Dim reader As SqlDataReader = cmd.ExecuteReader()

            If reader.HasRows Then
                reader.Read()
                Dim userID As Integer = Convert.ToInt32(reader(idColumn))
                MessageBox.Show("Login Successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Select Case role
                    Case "Admin"
                        AdminID = userID
                        Dim adminDash As New AdminDashboard(AdminID)
                        adminDash.Show()
                    Case "Customer"
                        CustomerID = userID
                        Dim custDash As New CustomerDashboard(CustomerID)
                        custDash.Show()
                    Case "DeliveryAgent"
                        DeliveryAgentID = userID
                        Dim deliveryDash As New DeliveryAgentDashboard(DeliveryAgentID)
                        deliveryDash.Show()
                End Select

                reader.Close()
                Me.Hide()
            Else
                MessageBox.Show("Invalid username or password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    ' Exit Button
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub
End Class
