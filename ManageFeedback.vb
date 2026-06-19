

Imports System.Data.SqlClient

Public Class ManageFeedback
    Private AdminID As Integer
    Private connectionString As String = "Data Source=DESKTOP-JH6IF3M\SQLEXPRESS;Initial Catalog=Gas27;Integrated Security=True;Encrypt=False"

    ' Constructor
    Public Sub New(adminID As Integer)
        InitializeComponent()
        Me.AdminID = adminID
    End Sub

    ' Form Load
    Private Sub ManageFeedback_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadFeedbacks()
    End Sub

    ' Load feedbacks into DataGridView
    Private Sub LoadFeedbacks()
        Try
            Using conn As New SqlConnection(connectionString)
                Dim query As String = "
                    SELECT F.FeedbackID, C.FullName AS CustomerName, F.Rating, F.Comments, F.FeedbackDate
                    FROM Feedback F
                    INNER JOIN Customers C ON F.CustomerID = C.CustomerID
                    ORDER BY F.FeedbackDate DESC"
                Dim adapter As New SqlDataAdapter(query, conn)
                Dim table As New DataTable()
                adapter.Fill(table)

                DataGridView1.DataSource = table
                DataGridView1.Columns("FeedbackID").Visible = False ' Hide ID column
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading feedback: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Refresh Button
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadFeedbacks()
    End Sub

    ' Delete Selected Feedback
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim feedbackID As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("FeedbackID").Value)
            Dim confirm As DialogResult = MessageBox.Show("Are you sure you want to delete this feedback?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If confirm = DialogResult.Yes Then
                Try
                    Using conn As New SqlConnection(connectionString)
                        Dim query As String = "DELETE FROM Feedback WHERE FeedbackID = @FeedbackID"
                        Dim cmd As New SqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@FeedbackID", feedbackID)
                        conn.Open()
                        cmd.ExecuteNonQuery()
                    End Using
                    MessageBox.Show("Feedback deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadFeedbacks()
                Catch ex As Exception
                    MessageBox.Show("Error deleting feedback: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Please select a feedback entry to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Back to Admin Dashboard
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dashboard As New AdminDashboard(AdminID)
        dashboard.Show()
        Me.Close()
    End Sub
End Class
