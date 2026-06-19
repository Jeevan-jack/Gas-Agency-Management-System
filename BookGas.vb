

Imports System.Data.SqlClient

Public Class BookGas
    Private ReadOnly connString As String = "Data Source=DESKTOP-JH6IF3M\SQLEXPRESS;Initial Catalog=Gas27;Integrated Security=True;Encrypt=False"
    Private CurrentBookingID As Integer
    Private customerID As Integer

    Public Sub New(custID As Integer)
        InitializeComponent()
        customerID = custID
    End Sub

    Private Sub BookGas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If customerID <= 0 Then
            MessageBox.Show("Customer not logged in. Redirecting to login.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Login.Show()
            Exit Sub
        End If

        LoadGasTypes()
    End Sub

    Private Sub LoadGasTypes()
        Try
            Using conn As New SqlConnection(connString)
                conn.Open()
                Dim query As String = "SELECT GasType FROM Inventory"
                Using cmd As New SqlCommand(query, conn)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        ComboBox1.Items.Clear()
                        While reader.Read()
                            ComboBox1.Items.Add(reader("GasType").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load gas types: " & ex.Message)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            Using conn As New SqlConnection(connString)
                conn.Open()
                Dim query As String = "SELECT PricePerUnit FROM Inventory WHERE GasType = @GasType"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@GasType", ComboBox1.SelectedItem.ToString())
                    Dim price As Object = cmd.ExecuteScalar()

                    If price IsNot Nothing AndAlso IsNumeric(price) Then
                        TextBox2.Text = Convert.ToDecimal(price).ToString("F2")
                    Else
                        TextBox2.Text = ""
                        MessageBox.Show("Price not found for selected gas type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error getting price: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedIndex = -1 OrElse String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Please select a gas type and enter quantity.")
            Return
        End If

        Dim qty As Integer
        If Not Integer.TryParse(TextBox1.Text, qty) OrElse qty <= 0 Then
            MessageBox.Show("Please enter a valid quantity.")
            Return
        End If

        Dim price As Decimal
        If Not Decimal.TryParse(TextBox2.Text, price) OrElse price <= 0 Then
            MessageBox.Show("Invalid price per unit.")
            Return
        End If

        Dim amount As Decimal = qty * price
        TextBox3.Text = amount.ToString("F2")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox1.SelectedIndex = -1 OrElse String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) Then
            MessageBox.Show("Please fill in all booking fields.")
            Return
        End If

        Try
            Using conn As New SqlConnection(connString)
                conn.Open()
                Dim query As String = "INSERT INTO Bookings (CustomerID, GasType, Quantity, BookingDate, Status) 
                                   OUTPUT INSERTED.BookingID 
                                   VALUES (@CustomerID, @GasType, @Quantity, GETDATE(), 'Pending')"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
                    cmd.Parameters.AddWithValue("@GasType", ComboBox1.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(TextBox1.Text))

                    Dim newBookingID As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    CurrentBookingID = newBookingID

                    MessageBox.Show("Booking placed! Redirecting to payment...")

                    ' Redirect to Payments form and pass BookingID, CustomerID and TotalAmount
                    Dim payForm As New Payments()
                    payForm.BookingID = CurrentBookingID
                    payForm.CustomerID = customerID
                    payForm.TotalAmount = Convert.ToDecimal(TextBox3.Text)

                    payForm.Show()
                    Me.Hide()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Booking error: " & ex.Message)
        End Try
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dash As New CustomerDashboard(customerID)
        dash.Show()
        Me.Hide()
    End Sub
End Class

