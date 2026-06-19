

Imports System.Data.SqlClient

Public Class CustomerFeedback

    ' SQL Server connection string
    Private connectionString As String = "Data Source=DESKTOP-JH6IF3M\SQLEXPRESS;Initial Catalog=Gas27;Integrated Security=True;Encrypt=False"

    ' Logged-in Customer ID
    Private customerID As Integer

    ' Constructor accepting customer ID
    Public Sub New(custID As Integer)
        InitializeComponent()
        customerID = custID
    End Sub

    ' Form Load: Populate rating dropdown
    Private Sub CustomerFeedback_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Clear()
        For i As Integer = 1 To 5
            ComboBox1.Items.Add(i)
        Next
        ComboBox1.SelectedIndex = 0
    End Sub

    ' Submit Feedback
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Please enter your feedback comments.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using conn As New SqlConnection(connectionString)
                Dim query As String = "
                    INSERT INTO Feedback (CustomerID, Rating, Comments, FeedbackDate) 
                    VALUES (@CustomerID, @Rating, @Comments, GETDATE())"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
                    cmd.Parameters.AddWithValue("@Rating", Convert.ToInt32(ComboBox1.SelectedItem))
                    cmd.Parameters.AddWithValue("@Comments", TextBox1.Text.Trim())

                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Thank you for your feedback!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Reset the form
                    ComboBox1.SelectedIndex = 0
                    TextBox1.Clear()
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error submitting feedback: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Back to Customer Dashboard
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dashboard As New CustomerDashboard(customerID)
        dashboard.Show()
        Me.Close()
    End Sub

End Class
