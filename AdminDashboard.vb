
Public Class AdminDashboard

    Private AdminID As Integer

    ' Constructor to accept AdminID
    Public Sub New(adminID As Integer)
        InitializeComponent()
        Me.AdminID = adminID
    End Sub

    ' Manage Users Form
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim manageUsers As New ManageUsers(AdminID)
        manageUsers.Show()
        Me.Hide()
    End Sub

    ' Manage Inventory Form
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim inventoryForm As New ManageInventory(AdminID)
        inventoryForm.Show()
        Me.Hide()
    End Sub

    ' View Bookings Form
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim bookingsForm As New ViewBookings(AdminID)
        bookingsForm.Show()
        Me.Hide()
    End Sub

    ' Manage Feedback Form
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim feedbackForm As New ManageFeedback(AdminID)
        feedbackForm.Show()
        Me.Hide()
    End Sub

    ' Send Notifications Form
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim notificationsForm As New SendNotification(AdminID)
        notificationsForm.Show()
        Me.Hide()
    End Sub

    ' Admin Profile Form
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim adminProfile As New AdminProfile(AdminID)
        adminProfile.Show()
        Me.Hide()
    End Sub

    ' Assign Deliveries Form
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim assignDeliveriesForm As New AssignDeliveries(AdminID)
        assignDeliveriesForm.Show()
        Me.Hide()
    End Sub

    ' Logout Button
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim confirm As DialogResult = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm = DialogResult.Yes Then
            ' If you have a LogoutUser() function, call it here
            Login.Show()
            Me.Close()
        End If
    End Sub

End Class

