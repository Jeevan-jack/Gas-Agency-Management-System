
Module GlobalVariables

    ' Global variables to store logged-in user IDs
    Public CustomerID As Integer = -1
    Public AdminID As Integer = -1
    Public DeliveryAgentID As Integer = -1

    ' Logged-in user role
    Public LoggedInUserRole As String = ""

    ' Logout function to clear session
    Public Sub LogoutUser()
        CustomerID = -1
        AdminID = -1
        DeliveryAgentID = -1
        LoggedInUserRole = ""
    End Sub

End Module

