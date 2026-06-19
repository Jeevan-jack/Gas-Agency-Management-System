
Imports System.Data.SqlClient

Public Class CustomerProfile

    ' SQL Server connection string
    Private connectionString As String = "Data Source=DESKTOP-JH6IF3M\SQLEXPRESS;Initial Catalog=Gas27;Integrated Security=True;Encrypt=False"

    ' Store logged-in CustomerID
    Private customerID As Integer

    ' Constructor to accept CustomerID
    Public Sub New(custID As Integer)
        InitializeComponent()
        customerID = custID
    End Sub

    ' Form Load: Load profile and set textboxes as read-only
    Private Sub CustomerProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCustomerProfile()
        SetTextBoxesEditable(False)
    End Sub

    ' Make textboxes editable or read-only
    Private Sub SetTextBoxesEditable(editable As Boolean)
        TextBox1.ReadOnly = Not editable ' Full Name
        TextBox2.ReadOnly = True         ' Username is always read-only
        TextBox3.ReadOnly = Not editable ' Email
        TextBox4.ReadOnly = Not editable ' Phone Number
        TextBox5.ReadOnly = Not editable ' Address
        Button2.Enabled = editable       ' Enable "Update" button only in edit mode
    End Sub

    ' Load customer profile details from database
    Private Sub LoadCustomerProfile()
        Try
            Using conn As New SqlConnection(connectionString)
                Dim query As String = "SELECT FullName, Username, Email, PhoneNumber, Address FROM Customers WHERE CustomerID = @CustomerID"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
                    conn.Open()

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            TextBox1.Text = reader("FullName").ToString()
                            TextBox2.Text = reader("Username").ToString()
                            TextBox3.Text = reader("Email").ToString()
                            TextBox4.Text = reader("PhoneNumber").ToString()
                            TextBox5.Text = reader("Address").ToString()
                        Else
                            MessageBox.Show("Customer profile not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading profile: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Edit button clicked → Enable textboxes for editing
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SetTextBoxesEditable(True)
    End Sub

    ' Update button clicked → Save changes to database
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Using conn As New SqlConnection(connectionString)
                Dim query As String = "UPDATE Customers SET FullName = @FullName, Email = @Email, PhoneNumber = @PhoneNumber, Address = @Address WHERE CustomerID = @CustomerID"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@FullName", TextBox1.Text.Trim())
                    cmd.Parameters.AddWithValue("@Email", TextBox3.Text.Trim())
                    cmd.Parameters.AddWithValue("@PhoneNumber", TextBox4.Text.Trim())
                    cmd.Parameters.AddWithValue("@Address", TextBox5.Text.Trim())
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)

                    conn.Open()
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Profile updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        SetTextBoxesEditable(False)
                    Else
                        MessageBox.Show("No changes were made.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating profile: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Back button clicked → Return to dashboard
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dashboard As New CustomerDashboard(customerID)
        dashboard.Show()
        Me.Close()
    End Sub
End Class
