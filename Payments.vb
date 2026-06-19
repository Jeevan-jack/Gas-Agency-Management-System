
Imports System.Data.SqlClient
Imports System.Reflection.Emit
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button

Public Class Payments
    Dim connectionString As String = "Data Source=DESKTOP-JH6IF3M\SQLEXPRESS;Initial Catalog=Gas27;Integrated Security=True;Encrypt=False"

    Public Property BookingID As Integer
    Public Property CustomerID As Integer

    Public Property TotalAmount As Decimal


    Private Sub Payments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If BookingID <= 0 Or CustomerID <= 0 Then
            MessageBox.Show("Invalid booking or customer ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Exit Sub
        End If

        TextBox1.Text = BookingID.ToString()

        Dim totalAmount As Decimal = GetTotalAmount(BookingID)
        If totalAmount > 0 Then
            TextBox2.Text = totalAmount.ToString("F2")
        Else
            MessageBox.Show("Error retrieving total amount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Exit Sub
        End If

        Label4.Visible = False
        TextBox3.Visible = False
    End Sub

    Private Function GetTotalAmount(bookingID As Integer) As Decimal
        Dim totalAmount As Decimal = 0
        Try
            Using conn As New SqlConnection(connectionString)
                Dim query As String = "SELECT (b.Quantity * i.PricePerUnit) AS TotalPrice 
                                       FROM Bookings b 
                                       INNER JOIN Inventory i ON b.GasType = i.GasType 
                                       WHERE b.BookingID = @BookingID"
                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@BookingID", bookingID)
                conn.Open()
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    totalAmount = Convert.ToDecimal(result)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching total amount: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return totalAmount
    End Function

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Label4.Visible = True
        TextBox3.Visible = True
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Label4.Visible = False
        TextBox3.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim amount As Decimal
        If Not Decimal.TryParse(TextBox2.Text, amount) Then
            MessageBox.Show("Invalid amount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not CheckBookingExists(BookingID) Then
            MessageBox.Show("Booking ID does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If IsPaymentAlreadyMade(BookingID) Then
            MessageBox.Show("Payment for this booking has already been made!", "Duplicate Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim paymentMethod As String = ""
        If RadioButton2.Checked Then
            paymentMethod = "Cash"
        ElseIf RadioButton1.Checked Then
            paymentMethod = "Card"
            If TextBox3.Text.Trim().Length <> 16 OrElse Not IsNumeric(TextBox3.Text) Then
                MessageBox.Show("Please enter a valid 16-digit card number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            MessageBox.Show("Please select a payment method!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()

                ' Insert Payment
                Dim insertQuery As String = "INSERT INTO Payments (BookingID, Amount, PaymentMethod, PaymentDate, PaymentStatus) 
                                             VALUES (@BookingID, @Amount, @PaymentMethod, GETDATE(), 'Paid')"
                Dim insertCmd As New SqlCommand(insertQuery, conn)
                insertCmd.Parameters.AddWithValue("@BookingID", BookingID)
                insertCmd.Parameters.AddWithValue("@Amount", amount)
                insertCmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                insertCmd.ExecuteNonQuery()

                ' Update Booking Status
                Dim updateQuery As String = "UPDATE Bookings SET Status = 'Confirmed' WHERE BookingID = @BookingID"
                Dim updateCmd As New SqlCommand(updateQuery, conn)
                updateCmd.Parameters.AddWithValue("@BookingID", BookingID)
                updateCmd.ExecuteNonQuery()

                MessageBox.Show("Payment Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using

            ' Redirect to Customer Dashboard
            Dim dashboard As New CustomerDashboard()
            dashboard.customerID = Me.CustomerID
            dashboard.Show()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Payment failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function CheckBookingExists(bookingID As Integer) As Boolean
        Dim exists As Boolean = False
        Try
            Using conn As New SqlConnection(connectionString)
                Dim query As String = "SELECT COUNT(*) FROM Bookings WHERE BookingID = @BookingID"
                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@BookingID", bookingID)
                conn.Open()
                exists = Convert.ToInt32(cmd.ExecuteScalar()) > 0
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking booking: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return exists
    End Function

    Private Function IsPaymentAlreadyMade(bookingID As Integer) As Boolean
        Dim alreadyPaid As Boolean = False
        Try
            Using conn As New SqlConnection(connectionString)
                Dim query As String = "SELECT COUNT(*) FROM Payments WHERE BookingID = @BookingID"
                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@BookingID", bookingID)
                conn.Open()
                alreadyPaid = Convert.ToInt32(cmd.ExecuteScalar()) > 0
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking existing payment: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return alreadyPaid
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim bookGasForm As New BookGas(CustomerID)
            bookGasForm.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error opening BookGas form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class





