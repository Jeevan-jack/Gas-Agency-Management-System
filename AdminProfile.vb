

Imports System.Data.SqlClient

Public Class AdminProfile
    Private AdminID As Integer
    Private ReadOnly connectionString As String = "Data Source=DESKTOP-JH6IF3M\SQLEXPRESS;Initial Catalog=Gas27;Integrated Security=True;Encrypt=False"

    ' Constructor to accept AdminID from AdminDashboard
    Public Sub New(adminID As Integer)
        InitializeComponent()
        Me.AdminID = adminID
    End Sub

    ' Form Load
    Private Sub AdminProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAdminProfile()
        SetTextBoxesEditable(False)
    End Sub

    ' Set TextBoxes editable or read-only
    Private Sub SetTextBoxesEditable(editable As Boolean)
        TextBox1.ReadOnly = Not editable ' Full Name
        TextBox2.ReadOnly = True         ' Username stays read-only
        TextBox3.ReadOnly = Not editable ' Email
        TextBox4.ReadOnly = Not editable ' Phone Number
        Button2.Enabled = editable       ' Update button enabled only in edit mode
    End Sub

    ' Load admin details
    Private Sub LoadAdminProfile()
        Try
            Using conn As New SqlConnection(connectionString)
                Dim query As String = "SELECT FullName, Username, Email, PhoneNumber FROM Admins WHERE AdminID = @AdminID"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@AdminID", AdminID)

                    conn.Open()
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            TextBox1.Text = reader("FullName").ToString()
                            TextBox2.Text = reader("Username").ToString()
                            TextBox3.Text = reader("Email").ToString()
                            TextBox4.Text = reader("PhoneNumber").ToString()
                        Else
                            MessageBox.Show("Admin details not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading admin profile: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Edit Button Click
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SetTextBoxesEditable(True)
    End Sub

    ' Update Button Click
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Using conn As New SqlConnection(connectionString)
                Dim query As String = "UPDATE Admins SET FullName = @FullName, Email = @Email, PhoneNumber = @PhoneNumber WHERE AdminID = @AdminID"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@FullName", TextBox1.Text.Trim())
                    cmd.Parameters.AddWithValue("@Email", TextBox3.Text.Trim())
                    cmd.Parameters.AddWithValue("@PhoneNumber", TextBox4.Text.Trim())
                    cmd.Parameters.AddWithValue("@AdminID", AdminID)

                    conn.Open()
                    Dim result As Integer = cmd.ExecuteNonQuery()
                    If result > 0 Then
                        MessageBox.Show("Profile updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("No changes were made.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using

            SetTextBoxesEditable(False)

        Catch ex As Exception
            MessageBox.Show("Error updating profile: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Back Button Click
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim adminDashboard As New AdminDashboard(AdminID)
        adminDashboard.Show()
        Me.Close()
    End Sub
End Class



