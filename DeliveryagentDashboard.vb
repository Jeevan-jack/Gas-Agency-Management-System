
Public Class DeliveryAgentDashboard
    Private loggedInDeliveryAgentID As Integer ' Store the logged-in Delivery Agent's ID

    ' Default Constructor (Required for Designer)
    Public Sub New()
        InitializeComponent()
    End Sub

    ' Constructor to Set Logged-in ID
    Public Sub New(deliveryAgentID As Integer)
        InitializeComponent()
        loggedInDeliveryAgentID = deliveryAgentID
    End Sub

    ' View Assigned Deliveries Button
    Private Sub btnViewAssignedDeliveries_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Pass the logged-in Delivery Agent ID to ViewAssignedDeliveries form
        Dim assignedDeliveries As New ViewAssignDeliveries(loggedInDeliveryAgentID)
        assignedDeliveries.Show()
        Me.Hide()
    End Sub

    ' Delivery Agent Notifications Button
    Private Sub btnNotifications_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Pass the logged-in Delivery Agent ID to DeliveryAgentNotifications form
        Dim deliveryagentnotifications As New DeliveryAgentNotifications(loggedInDeliveryAgentID)
        deliveryagentnotifications.Show()
        Me.Hide()
    End Sub

    Private Sub button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Pass the logged-in Delivery Agent ID to DeliveryAgentNotifications form
        Dim deliveryagentprofile As New DeliveryAgentProfile(loggedInDeliveryAgentID)
        deliveryagentprofile.Show()
        Me.Hide()
    End Sub

    ' Logout Button
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim confirm As DialogResult
        confirm = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm = DialogResult.Yes Then
            Login.Show()
            Me.Close()
        End If

    End Sub
End Class



