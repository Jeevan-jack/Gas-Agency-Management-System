
Imports System.Data.SqlClient

Public Class AssignDeliveries

    ' ✅ Store Logged-in AdminID
    Private AdminID As Integer

    ' ✅ Constructor to accept AdminID
    Public Sub New(adminID As Integer)
        InitializeComponent()
        Me.AdminID = adminID
    End Sub

    ' ✅ Database Connection
    Private ReadOnly conn As New SqlConnection("Data Source=DESKTOP-JH6IF3M\SQLEXPRESS;Initial Catalog=Gas27;Integrated Security=True;Encrypt=False")

    ' ✅ Load Data when the form opens
    Private Sub AssignDeliveries_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPendingBookings()
        LoadDeliveryAgents()
    End Sub

    ' ✅ Load Pending Bookings (Not Yet Assigned)
    Private Sub LoadPendingBookings()
        Try
            Dim query As String = "SELECT BookingID, CustomerID, GasType, Quantity, BookingDate, Status FROM Bookings WHERE Status = 'Pending'"
            Using cmd As New SqlCommand(query, conn)
                Using adapter As New SqlDataAdapter(cmd)
                    Dim table As New DataTable()
                    adapter.Fill(table)
                    DataGridView1.DataSource = table
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading pending bookings: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ✅ Load Available Delivery Agents
    Private Sub LoadDeliveryAgents()
        Try
            Dim query As String = "SELECT DeliveryAgentID, FullName, Email FROM DeliveryAgents"
            Using cmd As New SqlCommand(query, conn)
                Using adapter As New SqlDataAdapter(cmd)
                    Dim table As New DataTable()
                    adapter.Fill(table)
                    DataGridView2.DataSource = table
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading delivery agents: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ✅ Assign Delivery to an Agent
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("Please select a Booking and a Delivery Agent.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            conn.Open()
            Dim transaction As SqlTransaction = conn.BeginTransaction()

            Try
                ' ➕ Insert into Delivery Table
                Dim insertQuery As String = "INSERT INTO Delivery (BookingID, DeliveryAgentID, Status) VALUES (@BookingID, @DeliveryAgentID, 'Out for Delivery')"
                Using insertCmd As New SqlCommand(insertQuery, conn, transaction)
                    insertCmd.Parameters.AddWithValue("@BookingID", Convert.ToInt32(TextBox1.Text))
                    insertCmd.Parameters.AddWithValue("@DeliveryAgentID", Convert.ToInt32(TextBox2.Text))
                    insertCmd.ExecuteNonQuery()
                End Using

                ' ✏️ Update Booking Status
                Dim updateQuery As String = "UPDATE Bookings SET Status = 'Confirmed' WHERE BookingID = @BookingID"
                Using updateCmd As New SqlCommand(updateQuery, conn, transaction)
                    updateCmd.Parameters.AddWithValue("@BookingID", Convert.ToInt32(TextBox1.Text))
                    updateCmd.ExecuteNonQuery()
                End Using

                transaction.Commit()
                MessageBox.Show("Delivery Assigned Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' 🔄 Refresh Tables
                LoadPendingBookings()
                LoadDeliveryAgents()
                TextBox1.Clear()
                TextBox2.Clear()
            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Error assigning delivery: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            MessageBox.Show("Database connection error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    ' ✅ Selecting a Booking from Grid
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
        End If
    End Sub

    ' ✅ Selecting a Delivery Agent from Grid
    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If e.RowIndex >= 0 Then
            TextBox2.Text = DataGridView2.Rows(e.RowIndex).Cells(0).Value.ToString()
        End If
    End Sub

    ' 🔙 Back Button to Admin Dashboard
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dashboard As New AdminDashboard(AdminID)
        dashboard.Show()
        Me.Hide()
    End Sub

End Class
