
Imports System.Data.SqlClient

Public Class ManageInventory

    ' ✅ Declare AdminID variable to accept from AdminDashboard
    Private AdminID As Integer

    ' ✅ Constructor to accept AdminID from AdminDashboard
    Public Sub New(adminID As Integer)
        InitializeComponent()
        Me.AdminID = adminID
    End Sub

    ' ✅ SQL Server Connection
    Dim conn As New SqlConnection("Data Source=DESKTOP-JH6IF3M\SQLEXPRESS;Initial Catalog=Gas27;Integrated Security=True;Encrypt=False")

    ' ✅ Load Inventory on Form Load
    Private Sub ManageInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadInventory()
    End Sub

    ' ✅ Load Inventory Data into DataGridView
    Private Sub LoadInventory()
        Try
            conn.Open()
            Dim query As String = "SELECT * FROM Inventory"
            Dim adapter As New SqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error loading inventory: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' ✅ Insert New Gas Type
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Or TextBox1.Text = "" Or TextBox2.Text = "" Then
            MessageBox.Show("Please fill all fields before adding.")
            Return
        End If

        Try
            conn.Open()
            Dim query As String = "INSERT INTO Inventory (GasType, StockAvailable, PricePerUnit, AdminID) VALUES (@GasType, @Stock, @Price, @AdminID)"
            Dim cmd As New SqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@GasType", ComboBox1.Text)
            cmd.Parameters.AddWithValue("@Stock", Convert.ToInt32(TextBox1.Text))
            cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(TextBox2.Text))
            cmd.Parameters.AddWithValue("@AdminID", AdminID)

            cmd.ExecuteNonQuery()
            MessageBox.Show("Gas type added successfully!")
        Catch ex As Exception
            MessageBox.Show("Error inserting gas type: " & ex.Message)
        Finally
            conn.Close()
            LoadInventory()
        End Try
    End Sub

    ' ✅ Update Existing Gas Type
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox1.Text = "" Or TextBox1.Text = "" Or TextBox2.Text = "" Then
            MessageBox.Show("Please fill all fields before updating.")
            Return
        End If

        Try
            conn.Open()
            Dim query As String = "UPDATE Inventory SET StockAvailable = @Stock, PricePerUnit = @Price WHERE GasType = @GasType"
            Dim cmd As New SqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@Stock", Convert.ToInt32(TextBox1.Text))
            cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(TextBox2.Text))
            cmd.Parameters.AddWithValue("@GasType", ComboBox1.Text)

            Dim rowsAffected = cmd.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MessageBox.Show("Inventory updated successfully!")
            Else
                MessageBox.Show("Gas type not found.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error updating gas type: " & ex.Message)
        Finally
            conn.Close()
            LoadInventory()
        End Try
    End Sub

    ' ✅ Delete Selected Gas Type
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ComboBox1.Text = "" Then
            MessageBox.Show("Please select a gas type to delete.")
            Return
        End If

        Try
            conn.Open()
            Dim query As String = "DELETE FROM Inventory WHERE GasType = @GasType"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@GasType", ComboBox1.Text)

            Dim rowsAffected = cmd.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MessageBox.Show("Gas type deleted successfully!")
            Else
                MessageBox.Show("Gas type not found.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error deleting gas type: " & ex.Message)
        Finally
            conn.Close()
            LoadInventory()
        End Try
    End Sub

    ' ✅ Clear Input Fields
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ComboBox1.SelectedIndex = -1
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

    ' ✅ Go Back to Admin Dashboard
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim adminDashboard As New AdminDashboard(AdminID)
        adminDashboard.Show()
        Me.Hide()
    End Sub

End Class
