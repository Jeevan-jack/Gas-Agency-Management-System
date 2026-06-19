
Imports System.Data.SqlClient
Imports System.Drawing

Public Class CustomerNotification

    ' SQL Server connection string
    Private connectionString As String = "Data Source=DESKTOP-JH6IF3M\SQLEXPRESS;Initial Catalog=Gas27;Integrated Security=True;Encrypt=False"

    ' Logged-in customer ID
    Private customerID As Integer

    ' Constructor to accept customer ID
    Public Sub New(custID As Integer)
        InitializeComponent()
        customerID = custID
    End Sub

    ' Form Load Event
    Private Sub CustomerNotification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupListView()
        LoadNotifications()
    End Sub

    ' Setup the ListView structure
    Private Sub SetupListView()
        With ListView1
            .View = View.Details
            .FullRowSelect = True
            .GridLines = True
            .Columns.Clear()

            .Columns.Add("Notification ID", 100)
            .Columns.Add("Message", 300)
            .Columns.Add("Sent Date", 180)
            .Columns.Add("Status", 100)
        End With
    End Sub

    ' Load notifications for the customer
    Private Sub LoadNotifications()
        ListView1.Items.Clear()

        Try
            Using conn As New SqlConnection(connectionString)
                Dim query As String = "
                    SELECT NotificationID, Message, SentDate, 
                           ISNULL(IsRead, 0) AS IsRead
                    FROM Notifications 
                    WHERE CustomerID = @CustomerID 
                    ORDER BY SentDate DESC"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
                    conn.Open()

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim item As New ListViewItem(reader("NotificationID").ToString())
                            item.SubItems.Add(reader("Message").ToString())
                            item.SubItems.Add(Convert.ToDateTime(reader("SentDate")).ToString("yyyy-MM-dd HH:mm:ss"))

                            Dim isRead As Boolean = Convert.ToBoolean(reader("IsRead"))
                            item.SubItems.Add(If(isRead, "Read", "Unread"))

                            ' Highlight unread notifications
                            If Not isRead Then
                                item.Font = New Font(ListView1.Font, FontStyle.Bold)
                            End If

                            ListView1.Items.Add(item)
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading notifications: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Mark selected notification as read
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListView1.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a notification to mark as read.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim notificationID As Integer = Integer.Parse(ListView1.SelectedItems(0).SubItems(0).Text)

        Try
            Using conn As New SqlConnection(connectionString)
                Dim query As String = "UPDATE Notifications SET IsRead = 1 WHERE NotificationID = @NotificationID"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@NotificationID", notificationID)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Notification marked as read!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadNotifications()

        Catch ex As Exception
            MessageBox.Show("Error updating notification: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Back to Customer Dashboard
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dashboard As New CustomerDashboard(customerID)
        dashboard.Show()
        Me.Close()
    End Sub

End Class
