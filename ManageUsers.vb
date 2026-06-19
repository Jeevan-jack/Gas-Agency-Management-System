

Imports System.Data.SqlClient

Public Class ManageUsers

    ' Database Connection
    Dim conn As New SqlConnection("Data Source=DESKTOP-JH6IF3M\SQLEXPRESS;Initial Catalog=Gas27;Integrated Security=True;Encrypt=False")

    ' Store AdminID for navigation back
    Private AdminID As Integer

    ' Constructor to accept AdminID from AdminDashboard
    Public Sub New(adminID As Integer)
        InitializeComponent()
        Me.AdminID = adminID
    End Sub

    ' Load Data when the form opens
    Private Sub ManageUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCustomers()
        LoadDeliveryAgents()
    End Sub

    ' Load Customers into DataGridView
    Private Sub LoadCustomers()
        Try
            conn.Open()
            Dim query As String = "SELECT CustomerID, FullName, Email, PhoneNumber, Address FROM Customers"
            Dim adapter As New SqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView2.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error loading customers: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' Load Delivery Agents into DataGridView
    Private Sub LoadDeliveryAgents()
        Try
            conn.Open()
            Dim query As String = "SELECT DeliveryAgentID, FullName, Email, PhoneNumber, Address FROM DeliveryAgents"
            Dim adapter As New SqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView3.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error loading delivery agents: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' Delete Customer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Trim() = "" Then
            MessageBox.Show("Please enter a Customer ID to delete.")
            Return
        End If

        Try
            conn.Open()
            Dim query As String = "DELETE FROM Customers WHERE CustomerID = @CustomerID"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@CustomerID", TextBox1.Text.Trim())
            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MessageBox.Show("Customer deleted successfully.")
                LoadCustomers()
            Else
                MessageBox.Show("Customer ID not found.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error deleting customer: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' Delete Delivery Agent
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox2.Text.Trim() = "" Then
            MessageBox.Show("Please enter a Delivery Agent ID to delete.")
            Return
        End If

        Try
            conn.Open()
            Dim query As String = "DELETE FROM DeliveryAgents WHERE DeliveryAgentID = @DeliveryAgentID"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@DeliveryAgentID", TextBox2.Text.Trim())
            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MessageBox.Show("Delivery Agent deleted successfully.")
                LoadDeliveryAgents()
            Else
                MessageBox.Show("Delivery Agent ID not found.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error deleting delivery agent: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' Back Button - Navigate to Admin Dashboard
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim adminDashboard As New AdminDashboard(AdminID)
        adminDashboard.Show()
        Me.Hide()
    End Sub

End Class
