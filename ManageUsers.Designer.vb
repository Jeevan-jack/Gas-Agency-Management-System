<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManageUsers
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ManageUsers))
        Me.UsersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GasB27DataSet1 = New Gas27.GasB27DataSet1()
        Me.UsersTableAdapter = New Gas27.GasB27DataSet1TableAdapters.UsersTableAdapter()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.CustomerIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FullNameDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmailDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PhoneNumberDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AddressDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Gas27DataSet = New Gas27.Gas27DataSet()
        Me.CustomersTableAdapter = New Gas27.Gas27DataSetTableAdapters.CustomersTableAdapter()
        Me.Gas27DataSet1 = New Gas27.Gas27DataSet1()
        Me.DeliveryAgentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DeliveryAgentsTableAdapter = New Gas27.Gas27DataSet1TableAdapters.DeliveryAgentsTableAdapter()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.DeliveryAgentIDDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FullNameDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmailDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PhoneNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AddressDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeliveryAgentsBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Gas27DataSet2 = New Gas27.Gas27DataSet2()
        Me.DeliveryAgentsTableAdapter1 = New Gas27.Gas27DataSet2TableAdapters.DeliveryAgentsTableAdapter()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.UsersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasB27DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gas27DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gas27DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeliveryAgentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeliveryAgentsBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gas27DataSet2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UsersBindingSource
        '
        Me.UsersBindingSource.DataMember = "Users"
        Me.UsersBindingSource.DataSource = Me.GasB27DataSet1
        '
        'GasB27DataSet1
        '
        Me.GasB27DataSet1.DataSetName = "GasB27DataSet1"
        Me.GasB27DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UsersTableAdapter
        '
        Me.UsersTableAdapter.ClearBeforeFill = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.BorderSize = 5
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Elephant", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(524, 236)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(116, 42)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Delete User"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.BorderSize = 5
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Elephant", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(714, 488)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(111, 41)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Back"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Elephant", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(318, 243)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(134, 29)
        Me.TextBox1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Elephant", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(170, 246)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 26)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "CustomerID"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Elephant", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(318, 491)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(134, 29)
        Me.TextBox2.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Elephant", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(120, 491)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(190, 26)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "DeliveryAgent ID"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.BorderSize = 5
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Elephant", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(524, 488)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(116, 41)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "Delete"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'DataGridView2
        '
        Me.DataGridView2.AutoGenerateColumns = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerIDDataGridViewTextBoxColumn, Me.FullNameDataGridViewTextBoxColumn1, Me.EmailDataGridViewTextBoxColumn1, Me.PhoneNumberDataGridViewTextBoxColumn1, Me.AddressDataGridViewTextBoxColumn1})
        Me.DataGridView2.DataSource = Me.CustomersBindingSource
        Me.DataGridView2.Location = New System.Drawing.Point(65, 64)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersWidth = 51
        Me.DataGridView2.RowTemplate.Height = 24
        Me.DataGridView2.Size = New System.Drawing.Size(839, 150)
        Me.DataGridView2.TabIndex = 8
        '
        'CustomerIDDataGridViewTextBoxColumn
        '
        Me.CustomerIDDataGridViewTextBoxColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDDataGridViewTextBoxColumn.HeaderText = "CustomerID"
        Me.CustomerIDDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.CustomerIDDataGridViewTextBoxColumn.Name = "CustomerIDDataGridViewTextBoxColumn"
        Me.CustomerIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.CustomerIDDataGridViewTextBoxColumn.Width = 125
        '
        'FullNameDataGridViewTextBoxColumn1
        '
        Me.FullNameDataGridViewTextBoxColumn1.DataPropertyName = "FullName"
        Me.FullNameDataGridViewTextBoxColumn1.HeaderText = "FullName"
        Me.FullNameDataGridViewTextBoxColumn1.MinimumWidth = 6
        Me.FullNameDataGridViewTextBoxColumn1.Name = "FullNameDataGridViewTextBoxColumn1"
        Me.FullNameDataGridViewTextBoxColumn1.Width = 125
        '
        'EmailDataGridViewTextBoxColumn1
        '
        Me.EmailDataGridViewTextBoxColumn1.DataPropertyName = "Email"
        Me.EmailDataGridViewTextBoxColumn1.HeaderText = "Email"
        Me.EmailDataGridViewTextBoxColumn1.MinimumWidth = 6
        Me.EmailDataGridViewTextBoxColumn1.Name = "EmailDataGridViewTextBoxColumn1"
        Me.EmailDataGridViewTextBoxColumn1.Width = 125
        '
        'PhoneNumberDataGridViewTextBoxColumn1
        '
        Me.PhoneNumberDataGridViewTextBoxColumn1.DataPropertyName = "PhoneNumber"
        Me.PhoneNumberDataGridViewTextBoxColumn1.HeaderText = "PhoneNumber"
        Me.PhoneNumberDataGridViewTextBoxColumn1.MinimumWidth = 6
        Me.PhoneNumberDataGridViewTextBoxColumn1.Name = "PhoneNumberDataGridViewTextBoxColumn1"
        Me.PhoneNumberDataGridViewTextBoxColumn1.Width = 125
        '
        'AddressDataGridViewTextBoxColumn1
        '
        Me.AddressDataGridViewTextBoxColumn1.DataPropertyName = "Address"
        Me.AddressDataGridViewTextBoxColumn1.HeaderText = "Address"
        Me.AddressDataGridViewTextBoxColumn1.MinimumWidth = 6
        Me.AddressDataGridViewTextBoxColumn1.Name = "AddressDataGridViewTextBoxColumn1"
        Me.AddressDataGridViewTextBoxColumn1.Width = 125
        '
        'CustomersBindingSource
        '
        Me.CustomersBindingSource.DataMember = "Customers"
        Me.CustomersBindingSource.DataSource = Me.Gas27DataSet
        '
        'Gas27DataSet
        '
        Me.Gas27DataSet.DataSetName = "Gas27DataSet"
        Me.Gas27DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CustomersTableAdapter
        '
        Me.CustomersTableAdapter.ClearBeforeFill = True
        '
        'Gas27DataSet1
        '
        Me.Gas27DataSet1.DataSetName = "Gas27DataSet1"
        Me.Gas27DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DeliveryAgentsBindingSource
        '
        Me.DeliveryAgentsBindingSource.DataMember = "DeliveryAgents"
        Me.DeliveryAgentsBindingSource.DataSource = Me.Gas27DataSet1
        '
        'DeliveryAgentsTableAdapter
        '
        Me.DeliveryAgentsTableAdapter.ClearBeforeFill = True
        '
        'DataGridView3
        '
        Me.DataGridView3.AutoGenerateColumns = False
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DeliveryAgentIDDataGridViewTextBoxColumn1, Me.FullNameDataGridViewTextBoxColumn2, Me.EmailDataGridViewTextBoxColumn, Me.PhoneNumberDataGridViewTextBoxColumn, Me.AddressDataGridViewTextBoxColumn2})
        Me.DataGridView3.DataSource = Me.DeliveryAgentsBindingSource1
        Me.DataGridView3.Location = New System.Drawing.Point(65, 303)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.RowHeadersWidth = 51
        Me.DataGridView3.RowTemplate.Height = 24
        Me.DataGridView3.Size = New System.Drawing.Size(839, 150)
        Me.DataGridView3.TabIndex = 10
        '
        'DeliveryAgentIDDataGridViewTextBoxColumn1
        '
        Me.DeliveryAgentIDDataGridViewTextBoxColumn1.DataPropertyName = "DeliveryAgentID"
        Me.DeliveryAgentIDDataGridViewTextBoxColumn1.HeaderText = "DeliveryAgentID"
        Me.DeliveryAgentIDDataGridViewTextBoxColumn1.MinimumWidth = 6
        Me.DeliveryAgentIDDataGridViewTextBoxColumn1.Name = "DeliveryAgentIDDataGridViewTextBoxColumn1"
        Me.DeliveryAgentIDDataGridViewTextBoxColumn1.ReadOnly = True
        Me.DeliveryAgentIDDataGridViewTextBoxColumn1.Width = 125
        '
        'FullNameDataGridViewTextBoxColumn2
        '
        Me.FullNameDataGridViewTextBoxColumn2.DataPropertyName = "FullName"
        Me.FullNameDataGridViewTextBoxColumn2.HeaderText = "FullName"
        Me.FullNameDataGridViewTextBoxColumn2.MinimumWidth = 6
        Me.FullNameDataGridViewTextBoxColumn2.Name = "FullNameDataGridViewTextBoxColumn2"
        Me.FullNameDataGridViewTextBoxColumn2.Width = 125
        '
        'EmailDataGridViewTextBoxColumn
        '
        Me.EmailDataGridViewTextBoxColumn.DataPropertyName = "Email"
        Me.EmailDataGridViewTextBoxColumn.HeaderText = "Email"
        Me.EmailDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.EmailDataGridViewTextBoxColumn.Name = "EmailDataGridViewTextBoxColumn"
        Me.EmailDataGridViewTextBoxColumn.Width = 125
        '
        'PhoneNumberDataGridViewTextBoxColumn
        '
        Me.PhoneNumberDataGridViewTextBoxColumn.DataPropertyName = "PhoneNumber"
        Me.PhoneNumberDataGridViewTextBoxColumn.HeaderText = "PhoneNumber"
        Me.PhoneNumberDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.PhoneNumberDataGridViewTextBoxColumn.Name = "PhoneNumberDataGridViewTextBoxColumn"
        Me.PhoneNumberDataGridViewTextBoxColumn.Width = 125
        '
        'AddressDataGridViewTextBoxColumn2
        '
        Me.AddressDataGridViewTextBoxColumn2.DataPropertyName = "Address"
        Me.AddressDataGridViewTextBoxColumn2.HeaderText = "Address"
        Me.AddressDataGridViewTextBoxColumn2.MinimumWidth = 6
        Me.AddressDataGridViewTextBoxColumn2.Name = "AddressDataGridViewTextBoxColumn2"
        Me.AddressDataGridViewTextBoxColumn2.Width = 125
        '
        'DeliveryAgentsBindingSource1
        '
        Me.DeliveryAgentsBindingSource1.DataMember = "DeliveryAgents"
        Me.DeliveryAgentsBindingSource1.DataSource = Me.Gas27DataSet2
        '
        'Gas27DataSet2
        '
        Me.Gas27DataSet2.DataSetName = "Gas27DataSet2"
        Me.Gas27DataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DeliveryAgentsTableAdapter1
        '
        Me.DeliveryAgentsTableAdapter1.ClearBeforeFill = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Elephant", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(363, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(229, 38)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Manage Users"
        '
        'ManageUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DodgerBlue
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(982, 553)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DataGridView3)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "ManageUsers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ManageUsers"
        CType(Me.UsersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasB27DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gas27DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gas27DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeliveryAgentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeliveryAgentsBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gas27DataSet2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GasB27DataSet1 As GasB27DataSet1
    Friend WithEvents UsersBindingSource As BindingSource
    Friend WithEvents UsersTableAdapter As GasB27DataSet1TableAdapters.UsersTableAdapter
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Gas27DataSet As Gas27DataSet
    Friend WithEvents CustomersBindingSource As BindingSource
    Friend WithEvents CustomersTableAdapter As Gas27DataSetTableAdapters.CustomersTableAdapter
    Friend WithEvents CustomerIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FullNameDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents EmailDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents PhoneNumberDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents AddressDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents Gas27DataSet1 As Gas27DataSet1
    Friend WithEvents DeliveryAgentsBindingSource As BindingSource
    Friend WithEvents DeliveryAgentsTableAdapter As Gas27DataSet1TableAdapters.DeliveryAgentsTableAdapter
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents Gas27DataSet2 As Gas27DataSet2
    Friend WithEvents DeliveryAgentsBindingSource1 As BindingSource
    Friend WithEvents DeliveryAgentsTableAdapter1 As Gas27DataSet2TableAdapters.DeliveryAgentsTableAdapter
    Friend WithEvents DeliveryAgentIDDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents FullNameDataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents EmailDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PhoneNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AddressDataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents Label3 As Label
End Class
