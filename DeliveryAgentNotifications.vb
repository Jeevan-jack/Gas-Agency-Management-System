
Imports System.Data.SqlClient

Public Class DeliveryAgentNotifications
    Dim connectionString As String = "Data Source=DESKTOP-JH6IF3M\SQLEXPRESS;Initial Catalog=Gas27;Integrated Security=True;Encrypt=False"
    Public Property DeliveryagentID As Integer

    ' Constructor to accept DeliveryAgentID
    Public Sub New(deliveryAgentID As Integer)
        InitializeComponent()
        Me.DeliveryagentID = deliveryAgentID
    End Sub

    ' Form Load Event
    Private Sub DeliveryAgentNotifications_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupListView()
        LoadNotifications()
    End Sub

    ' Configure ListView columns
    Private Sub SetupListView()
        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.GridLines = True
        ListView1.Columns.Clear()
        ListView1.Columns.Add("Notification ID", 100)
        ListView1.Columns.Add("Message", 300)
        ListView1.Columns.Add("Sent Date", 180)
        ListView1.Columns.Add("Status", 100)
    End Sub

    ' Load notifications ONLY for the logged-in Delivery Agent
    Private Sub LoadNotifications()
        ListView1.Items.Clear()
        Try
            Using conn As New SqlConnection(connectionString)
                Dim query As String = "SELECT NotificationID, Message, SentDate, IsRead 
                                       FROM Notifications 
                                       WHERE DeliveryAgentID = @DeliveryAgentID 
                                       ORDER BY SentDate DESC"
                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@DeliveryAgentID", DeliveryagentID)
                conn.Open()

                Dim reader As SqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim item As New ListViewItem(reader("NotificationID").ToString())
                    item.SubItems.Add(reader("Message").ToString())
                    item.SubItems.Add(Convert.ToDateTime(reader("SentDate")).ToString("yyyy-MM-dd HH:mm:ss"))

                    Dim isRead As Boolean = Convert.ToBoolean(reader("IsRead"))
                    If isRead Then
                        item.SubItems.Add("Read")
                    Else
                        item.SubItems.Add("Unread")
                        item.Font = New Font(ListView1.Font, FontStyle.Bold) ' Bold unread messages
                    End If

                    ListView1.Items.Add(item)
                End While
                reader.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading notifications: " & ex.Message)
        End Try
    End Sub

    ' Mark selected notification as Read
    Private Sub btnMarkAsRead_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListView1.SelectedItems.Count = 0 Then
            MessageBox.Show("Select a notification to mark as read.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim notificationID As Integer = Integer.Parse(ListView1.SelectedItems(0).SubItems(0).Text)

        Try
            Using conn As New SqlConnection(connectionString)
                Dim query As String = "UPDATE Notifications SET IsRead = 1 WHERE NotificationID = @NotificationID"
                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@NotificationID", notificationID)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Notification marked as read!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadNotifications() ' Refresh the list
        Catch ex As Exception
            MessageBox.Show("Error updating notification: " & ex.Message)
        End Try
    End Sub

    ' Back to Delivery Agent Dashboard
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim deliveryAgentDashboard As New DeliveryAgentDashboard(DeliveryagentID)
        deliveryAgentDashboard.Show()
        Me.Hide()
    End Sub
End Class








