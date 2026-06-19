
Public Class CustomerDashboard
    ' Store the current Customer ID
    Public Property customerID As Integer

    ' Constructor receiving the logged-in CustomerID
    Public Sub New(currentCustomerID As Integer)
        ' This call is required by the designer.
        InitializeComponent()

        ' Store the logged-in customer's ID
        customerID = currentCustomerID
    End Sub

    ' Parameterless constructor for the designer (not used in runtime)
    Public Sub New()
        InitializeComponent()
    End Sub

    ' Book Gas button
    Private Sub btnBookGas_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bookGasForm As New BookGas(customerID)
        bookGasForm.Show()
        Me.Hide()
    End Sub

    ' View Booking Status button
    Private Sub btnViewBookingStatus_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim viewBookingStatusForm As New ViewBookingStatus(customerID)
        viewBookingStatusForm.Show()
        Me.Hide()
    End Sub

    ' Your Orders button
    Private Sub btnYourOrders_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim yourOrdersForm As New YourOrders(customerID)
        yourOrdersForm.Show()
        Me.Hide()
    End Sub

    ' Feedback button
    Private Sub btnFeedback_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim feedbackForm As New CustomerFeedback(customerID)
        feedbackForm.Show()
        Me.Hide()
    End Sub

    ' Notifications button
    Private Sub btnNotifications_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim notificationForm As New CustomerNotification(customerID)
        notificationForm.Show()
        Me.Hide()
    End Sub

    ' Profile button
    Private Sub btnProfile_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim profileForm As New CustomerProfile(customerID)
        profileForm.Show()
        Me.Hide()
    End Sub

    ' Logout button
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim confirmLogout As DialogResult = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmLogout = DialogResult.Yes Then
            Login.Show()
            Me.Close()
        End If
    End Sub
End Class
