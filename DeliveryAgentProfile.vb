
Imports System.Data.SqlClient

Public Class DeliveryAgentProfile
    Private connectionString As String = "Data Source=DESKTOP-JH6IF3M\SQLEXPRESS;Initial Catalog=Gas27;Integrated Security=True;Encrypt=False"
    Private LoggedInDeliveryAgentID As Integer

    ' Constructor
    Public Sub New(agentID As Integer)
        InitializeComponent()
        Me.LoggedInDeliveryAgentID = agentID
    End Sub

    ' On Load
    Private Sub DeliveryAgentProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAgentProfile()
        SetTextBoxesEditable(False)
    End Sub

    ' Toggle TextBox Editability
    Private Sub SetTextBoxesEditable(editable As Boolean)
        TextBox1.ReadOnly = Not editable  ' Full Name
        TextBox2.ReadOnly = True          ' Username (always read-only)
        TextBox3.ReadOnly = Not editable  ' Email
        TextBox4.ReadOnly = Not editable  ' Phone
        TextBox5.ReadOnly = Not editable  ' Address
        Button2.Enabled = editable
    End Sub

    ' Load Delivery Agent Details
    Private Sub LoadAgentProfile()
        Try
            Using conn As New SqlConnection(connectionString)
                Dim query As String = "SELECT FullName, Username, Email, PhoneNumber, Address FROM DeliveryAgents WHERE DeliveryAgentID = @DeliveryAgentID"
                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@DeliveryAgentID", LoggedInDeliveryAgentID)

                conn.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    TextBox1.Text = reader("FullName").ToString()
                    TextBox2.Text = reader("Username").ToString()
                    TextBox3.Text = reader("Email").ToString()
                    TextBox4.Text = reader("PhoneNumber").ToString()
                    TextBox5.Text = reader("Address").ToString()
                Else
                    MessageBox.Show("No delivery agent data found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                reader.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading profile: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Edit Button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SetTextBoxesEditable(True)
    End Sub

    ' Update Button
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Using conn As New SqlConnection(connectionString)
                Dim query As String = "UPDATE DeliveryAgents SET FullName=@FullName, Email=@Email, PhoneNumber=@PhoneNumber, Address=@Address WHERE DeliveryAgentID=@DeliveryAgentID"
                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@FullName", TextBox1.Text.Trim())
                cmd.Parameters.AddWithValue("@Email", TextBox3.Text.Trim())
                cmd.Parameters.AddWithValue("@PhoneNumber", TextBox4.Text.Trim())
                cmd.Parameters.AddWithValue("@Address", TextBox5.Text.Trim())
                cmd.Parameters.AddWithValue("@DeliveryAgentID", LoggedInDeliveryAgentID)

                conn.Open()
                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    MessageBox.Show("Profile updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
            SetTextBoxesEditable(False)
        Catch ex As Exception
            MessageBox.Show("Error updating profile: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Back Button
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dashboard As New DeliveryAgentDashboard(LoggedInDeliveryAgentID)
        dashboard.Show()
        Me.Hide()
    End Sub
End Class
