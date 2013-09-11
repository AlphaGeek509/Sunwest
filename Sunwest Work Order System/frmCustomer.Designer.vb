<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomer
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnSave = New System.Windows.Forms.Button
        Me.txtBillCompany = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtBillLast = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtBillDayPhone = New System.Windows.Forms.TextBox
        Me.txtBillZipcode = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtBillCity = New System.Windows.Forms.TextBox
        Me.cboBillState = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtBillAddr3 = New System.Windows.Forms.TextBox
        Me.txtBillAddr2 = New System.Windows.Forms.TextBox
        Me.txtBillAddr1 = New System.Windows.Forms.TextBox
        Me.txtBillFirst = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtBillEmail = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.txtBillEveningPhone = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtShipEmail = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.txtShipEveningPhone = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtShipCompany = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtShipLast = New System.Windows.Forms.TextBox
        Me.txtShipFirst = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtShipAddr1 = New System.Windows.Forms.TextBox
        Me.txtShipDayPhone = New System.Windows.Forms.TextBox
        Me.txtShipAddr2 = New System.Windows.Forms.TextBox
        Me.txtShipZipcode = New System.Windows.Forms.TextBox
        Me.txtShipAddr3 = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.cboShipState = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtShipCity = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.radCopyBilling = New System.Windows.Forms.RadioButton
        Me.radClearShipping = New System.Windows.Forms.RadioButton
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtCCNumber = New System.Windows.Forms.TextBox
        Me.txtCardHolderName = New System.Windows.Forms.TextBox
        Me.cboMonth = New System.Windows.Forms.ComboBox
        Me.cboYear = New System.Windows.Forms.ComboBox
        Me.txtBankTelephone = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.txtCVV = New System.Windows.Forms.TextBox
        Me.lblCustomerID = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtSearchComp = New System.Windows.Forms.TextBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.dgvFindCustomer = New System.Windows.Forms.DataGridView
        Me.btnFindCustomer = New System.Windows.Forms.Button
        Me.txtSearchLast = New System.Windows.Forms.TextBox
        Me.txtSearchCustID = New System.Windows.Forms.TextBox
        Me.txtSearchFirst = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.radioMasterCard = New System.Windows.Forms.RadioButton
        Me.radioVisa = New System.Windows.Forms.RadioButton
        Me.gboxCreditCard = New System.Windows.Forms.GroupBox
        Me.cboPaymentType = New System.Windows.Forms.ComboBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvFindCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxCreditCard.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSave.Location = New System.Drawing.Point(268, 660)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(165, 58)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "Save Customer Information"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtBillCompany
        '
        Me.txtBillCompany.Location = New System.Drawing.Point(109, 75)
        Me.txtBillCompany.Name = "txtBillCompany"
        Me.txtBillCompany.Size = New System.Drawing.Size(188, 20)
        Me.txtBillCompany.TabIndex = 2
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(48, 78)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(54, 13)
        Me.Label23.TabIndex = 51
        Me.Label23.Text = "Company:"
        '
        'txtBillLast
        '
        Me.txtBillLast.Location = New System.Drawing.Point(109, 49)
        Me.txtBillLast.Name = "txtBillLast"
        Me.txtBillLast.Size = New System.Drawing.Size(188, 20)
        Me.txtBillLast.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(35, 52)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(68, 13)
        Me.Label18.TabIndex = 50
        Me.Label18.Text = "* Last Name:"
        '
        'txtBillDayPhone
        '
        Me.txtBillDayPhone.Location = New System.Drawing.Point(109, 258)
        Me.txtBillDayPhone.Name = "txtBillDayPhone"
        Me.txtBillDayPhone.Size = New System.Drawing.Size(188, 20)
        Me.txtBillDayPhone.TabIndex = 9
        '
        'txtBillZipcode
        '
        Me.txtBillZipcode.Location = New System.Drawing.Point(109, 232)
        Me.txtBillZipcode.Name = "txtBillZipcode"
        Me.txtBillZipcode.Size = New System.Drawing.Size(188, 20)
        Me.txtBillZipcode.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 261)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "* Daytime Phone:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(54, 235)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 49
        Me.Label12.Text = "Zipcode:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(33, 208)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 13)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "* State/Prov:"
        '
        'txtBillCity
        '
        Me.txtBillCity.Location = New System.Drawing.Point(109, 179)
        Me.txtBillCity.Name = "txtBillCity"
        Me.txtBillCity.Size = New System.Drawing.Size(188, 20)
        Me.txtBillCity.TabIndex = 6
        '
        'cboBillState
        '
        Me.cboBillState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboBillState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBillState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillState.DropDownWidth = 115
        Me.cboBillState.FormattingEnabled = True
        Me.cboBillState.Location = New System.Drawing.Point(109, 205)
        Me.cboBillState.Name = "cboBillState"
        Me.cboBillState.Size = New System.Drawing.Size(188, 21)
        Me.cboBillState.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(68, 182)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 13)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "* City:"
        '
        'txtBillAddr3
        '
        Me.txtBillAddr3.Location = New System.Drawing.Point(109, 153)
        Me.txtBillAddr3.Name = "txtBillAddr3"
        Me.txtBillAddr3.Size = New System.Drawing.Size(188, 20)
        Me.txtBillAddr3.TabIndex = 5
        '
        'txtBillAddr2
        '
        Me.txtBillAddr2.Location = New System.Drawing.Point(109, 127)
        Me.txtBillAddr2.Name = "txtBillAddr2"
        Me.txtBillAddr2.Size = New System.Drawing.Size(188, 20)
        Me.txtBillAddr2.TabIndex = 4
        '
        'txtBillAddr1
        '
        Me.txtBillAddr1.Location = New System.Drawing.Point(109, 101)
        Me.txtBillAddr1.Name = "txtBillAddr1"
        Me.txtBillAddr1.Size = New System.Drawing.Size(188, 20)
        Me.txtBillAddr1.TabIndex = 3
        '
        'txtBillFirst
        '
        Me.txtBillFirst.Location = New System.Drawing.Point(109, 23)
        Me.txtBillFirst.Name = "txtBillFirst"
        Me.txtBillFirst.Size = New System.Drawing.Size(188, 20)
        Me.txtBillFirst.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 130)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 13)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "Rm/Flr/Address 2:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 156)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Dept/Address 3:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(35, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "* First Name:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(21, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "Attn/Address 1:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtBillEmail)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.txtBillEveningPhone)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtBillCompany)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtBillLast)
        Me.GroupBox1.Controls.Add(Me.txtBillFirst)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtBillAddr1)
        Me.GroupBox1.Controls.Add(Me.txtBillDayPhone)
        Me.GroupBox1.Controls.Add(Me.txtBillAddr2)
        Me.GroupBox1.Controls.Add(Me.txtBillZipcode)
        Me.GroupBox1.Controls.Add(Me.txtBillAddr3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.cboBillState)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtBillCity)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 270)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(313, 339)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Billing Information"
        '
        'txtBillEmail
        '
        Me.txtBillEmail.Location = New System.Drawing.Point(109, 309)
        Me.txtBillEmail.Name = "txtBillEmail"
        Me.txtBillEmail.Size = New System.Drawing.Size(188, 20)
        Me.txtBillEmail.TabIndex = 11
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(59, 312)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(42, 13)
        Me.Label30.TabIndex = 54
        Me.Label30.Text = "* Email:"
        '
        'txtBillEveningPhone
        '
        Me.txtBillEveningPhone.Location = New System.Drawing.Point(109, 284)
        Me.txtBillEveningPhone.Name = "txtBillEveningPhone"
        Me.txtBillEveningPhone.Size = New System.Drawing.Size(188, 20)
        Me.txtBillEveningPhone.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 287)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Evening Phone:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtShipEmail)
        Me.GroupBox2.Controls.Add(Me.Label31)
        Me.GroupBox2.Controls.Add(Me.txtShipEveningPhone)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtShipCompany)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtShipLast)
        Me.GroupBox2.Controls.Add(Me.txtShipFirst)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtShipAddr1)
        Me.GroupBox2.Controls.Add(Me.txtShipDayPhone)
        Me.GroupBox2.Controls.Add(Me.txtShipAddr2)
        Me.GroupBox2.Controls.Add(Me.txtShipZipcode)
        Me.GroupBox2.Controls.Add(Me.txtShipAddr3)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.cboShipState)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.txtShipCity)
        Me.GroupBox2.Location = New System.Drawing.Point(361, 270)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(313, 339)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Shipping Information"
        '
        'txtShipEmail
        '
        Me.txtShipEmail.Enabled = False
        Me.txtShipEmail.Location = New System.Drawing.Point(109, 309)
        Me.txtShipEmail.Name = "txtShipEmail"
        Me.txtShipEmail.Size = New System.Drawing.Size(188, 20)
        Me.txtShipEmail.TabIndex = 11
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(67, 312)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(35, 13)
        Me.Label31.TabIndex = 56
        Me.Label31.Text = "Email:"
        '
        'txtShipEveningPhone
        '
        Me.txtShipEveningPhone.Enabled = False
        Me.txtShipEveningPhone.Location = New System.Drawing.Point(109, 284)
        Me.txtShipEveningPhone.Name = "txtShipEveningPhone"
        Me.txtShipEveningPhone.Size = New System.Drawing.Size(188, 20)
        Me.txtShipEveningPhone.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 287)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Evening Phone:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(42, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "First Name:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Attn/Address 1:"
        '
        'txtShipCompany
        '
        Me.txtShipCompany.Enabled = False
        Me.txtShipCompany.Location = New System.Drawing.Point(109, 75)
        Me.txtShipCompany.Name = "txtShipCompany"
        Me.txtShipCompany.Size = New System.Drawing.Size(188, 20)
        Me.txtShipCompany.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(17, 156)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 13)
        Me.Label13.TabIndex = 43
        Me.Label13.Text = "Dept/Address 3:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(48, 78)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 13)
        Me.Label14.TabIndex = 51
        Me.Label14.Text = "Company:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 130)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(94, 13)
        Me.Label15.TabIndex = 46
        Me.Label15.Text = "Rm/Flr/Address 2:"
        '
        'txtShipLast
        '
        Me.txtShipLast.Enabled = False
        Me.txtShipLast.Location = New System.Drawing.Point(109, 49)
        Me.txtShipLast.Name = "txtShipLast"
        Me.txtShipLast.Size = New System.Drawing.Size(188, 20)
        Me.txtShipLast.TabIndex = 1
        '
        'txtShipFirst
        '
        Me.txtShipFirst.Enabled = False
        Me.txtShipFirst.Location = New System.Drawing.Point(109, 23)
        Me.txtShipFirst.Name = "txtShipFirst"
        Me.txtShipFirst.Size = New System.Drawing.Size(188, 20)
        Me.txtShipFirst.TabIndex = 0
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(42, 52)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 13)
        Me.Label16.TabIndex = 50
        Me.Label16.Text = "Last Name:"
        '
        'txtShipAddr1
        '
        Me.txtShipAddr1.Enabled = False
        Me.txtShipAddr1.Location = New System.Drawing.Point(109, 101)
        Me.txtShipAddr1.Name = "txtShipAddr1"
        Me.txtShipAddr1.Size = New System.Drawing.Size(188, 20)
        Me.txtShipAddr1.TabIndex = 3
        '
        'txtShipDayPhone
        '
        Me.txtShipDayPhone.Enabled = False
        Me.txtShipDayPhone.Location = New System.Drawing.Point(109, 258)
        Me.txtShipDayPhone.Name = "txtShipDayPhone"
        Me.txtShipDayPhone.Size = New System.Drawing.Size(188, 20)
        Me.txtShipDayPhone.TabIndex = 9
        '
        'txtShipAddr2
        '
        Me.txtShipAddr2.Enabled = False
        Me.txtShipAddr2.Location = New System.Drawing.Point(109, 127)
        Me.txtShipAddr2.Name = "txtShipAddr2"
        Me.txtShipAddr2.Size = New System.Drawing.Size(188, 20)
        Me.txtShipAddr2.TabIndex = 4
        '
        'txtShipZipcode
        '
        Me.txtShipZipcode.Enabled = False
        Me.txtShipZipcode.Location = New System.Drawing.Point(109, 232)
        Me.txtShipZipcode.Name = "txtShipZipcode"
        Me.txtShipZipcode.Size = New System.Drawing.Size(188, 20)
        Me.txtShipZipcode.TabIndex = 8
        '
        'txtShipAddr3
        '
        Me.txtShipAddr3.Enabled = False
        Me.txtShipAddr3.Location = New System.Drawing.Point(109, 153)
        Me.txtShipAddr3.Name = "txtShipAddr3"
        Me.txtShipAddr3.Size = New System.Drawing.Size(188, 20)
        Me.txtShipAddr3.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(21, 261)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(82, 13)
        Me.Label17.TabIndex = 41
        Me.Label17.Text = "Daytime Phone:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(75, 182)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(27, 13)
        Me.Label19.TabIndex = 47
        Me.Label19.Text = "City:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(54, 235)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(49, 13)
        Me.Label20.TabIndex = 49
        Me.Label20.Text = "Zipcode:"
        '
        'cboShipState
        '
        Me.cboShipState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboShipState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboShipState.DropDownWidth = 115
        Me.cboShipState.Enabled = False
        Me.cboShipState.FormattingEnabled = True
        Me.cboShipState.Location = New System.Drawing.Point(109, 205)
        Me.cboShipState.Name = "cboShipState"
        Me.cboShipState.Size = New System.Drawing.Size(188, 21)
        Me.cboShipState.TabIndex = 7
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(41, 208)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(62, 13)
        Me.Label21.TabIndex = 48
        Me.Label21.Text = "State/Prov:"
        '
        'txtShipCity
        '
        Me.txtShipCity.Enabled = False
        Me.txtShipCity.Location = New System.Drawing.Point(109, 179)
        Me.txtShipCity.Name = "txtShipCity"
        Me.txtShipCity.Size = New System.Drawing.Size(188, 20)
        Me.txtShipCity.TabIndex = 6
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(361, 251)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(209, 13)
        Me.Label22.TabIndex = 56
        Me.Label22.Text = "* Shipping address same as billing address:"
        '
        'radCopyBilling
        '
        Me.radCopyBilling.AutoSize = True
        Me.radCopyBilling.Location = New System.Drawing.Point(586, 249)
        Me.radCopyBilling.Name = "radCopyBilling"
        Me.radCopyBilling.Size = New System.Drawing.Size(43, 17)
        Me.radCopyBilling.TabIndex = 2
        Me.radCopyBilling.Text = "Yes"
        Me.radCopyBilling.UseVisualStyleBackColor = True
        '
        'radClearShipping
        '
        Me.radClearShipping.AutoSize = True
        Me.radClearShipping.Location = New System.Drawing.Point(635, 249)
        Me.radClearShipping.Name = "radClearShipping"
        Me.radClearShipping.Size = New System.Drawing.Size(39, 17)
        Me.radClearShipping.TabIndex = 3
        Me.radClearShipping.Text = "No"
        Me.radClearShipping.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 21)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(59, 13)
        Me.Label24.TabIndex = 59
        Me.Label24.Text = "Card Type:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(6, 50)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(72, 13)
        Me.Label25.TabIndex = 60
        Me.Label25.Text = "Card Number:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(341, 50)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(99, 13)
        Me.Label26.TabIndex = 61
        Me.Label26.Text = "Cardholder's Name:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(341, 76)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(57, 13)
        Me.Label27.TabIndex = 62
        Me.Label27.Text = "Exp. Date:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(6, 102)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(117, 13)
        Me.Label28.TabIndex = 63
        Me.Label28.Text = "Card Issuer Telephone:"
        '
        'txtCCNumber
        '
        Me.txtCCNumber.Location = New System.Drawing.Point(127, 47)
        Me.txtCCNumber.Name = "txtCCNumber"
        Me.txtCCNumber.Size = New System.Drawing.Size(184, 20)
        Me.txtCCNumber.TabIndex = 6
        '
        'txtCardHolderName
        '
        Me.txtCardHolderName.Location = New System.Drawing.Point(462, 47)
        Me.txtCardHolderName.Name = "txtCardHolderName"
        Me.txtCardHolderName.Size = New System.Drawing.Size(184, 20)
        Me.txtCardHolderName.TabIndex = 7
        '
        'cboMonth
        '
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"Month", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cboMonth.Location = New System.Drawing.Point(462, 73)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(89, 21)
        Me.cboMonth.TabIndex = 9
        '
        'cboYear
        '
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Items.AddRange(New Object() {"Year", "2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015"})
        Me.cboYear.Location = New System.Drawing.Point(568, 72)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(78, 21)
        Me.cboYear.TabIndex = 10
        '
        'txtBankTelephone
        '
        Me.txtBankTelephone.Location = New System.Drawing.Point(127, 99)
        Me.txtBankTelephone.Name = "txtBankTelephone"
        Me.txtBankTelephone.Size = New System.Drawing.Size(184, 20)
        Me.txtBankTelephone.TabIndex = 11
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(7, 76)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(31, 13)
        Me.Label29.TabIndex = 70
        Me.Label29.Text = "CVV:"
        '
        'txtCVV
        '
        Me.txtCVV.Location = New System.Drawing.Point(127, 73)
        Me.txtCVV.Name = "txtCVV"
        Me.txtCVV.Size = New System.Drawing.Size(65, 20)
        Me.txtCVV.TabIndex = 8
        '
        'lblCustomerID
        '
        Me.lblCustomerID.AutoSize = True
        Me.lblCustomerID.Location = New System.Drawing.Point(642, 776)
        Me.lblCustomerID.Name = "lblCustomerID"
        Me.lblCustomerID.Size = New System.Drawing.Size(72, 13)
        Me.lblCustomerID.TabIndex = 74
        Me.lblCustomerID.Text = "lblCustomerID"
        Me.lblCustomerID.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtSearchComp)
        Me.GroupBox3.Controls.Add(Me.Label36)
        Me.GroupBox3.Controls.Add(Me.dgvFindCustomer)
        Me.GroupBox3.Controls.Add(Me.btnFindCustomer)
        Me.GroupBox3.Controls.Add(Me.txtSearchLast)
        Me.GroupBox3.Controls.Add(Me.txtSearchCustID)
        Me.GroupBox3.Controls.Add(Me.txtSearchFirst)
        Me.GroupBox3.Controls.Add(Me.Label32)
        Me.GroupBox3.Controls.Add(Me.Label34)
        Me.GroupBox3.Controls.Add(Me.Label33)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(662, 241)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'txtSearchComp
        '
        Me.txtSearchComp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearchComp.Location = New System.Drawing.Point(100, 44)
        Me.txtSearchComp.Name = "txtSearchComp"
        Me.txtSearchComp.Size = New System.Drawing.Size(171, 20)
        Me.txtSearchComp.TabIndex = 84
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(9, 47)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(85, 13)
        Me.Label36.TabIndex = 85
        Me.Label36.Text = "Company Name:"
        '
        'dgvFindCustomer
        '
        Me.dgvFindCustomer.AllowUserToAddRows = False
        Me.dgvFindCustomer.AllowUserToDeleteRows = False
        Me.dgvFindCustomer.AllowUserToOrderColumns = True
        Me.dgvFindCustomer.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvFindCustomer.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFindCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFindCustomer.Location = New System.Drawing.Point(15, 70)
        Me.dgvFindCustomer.Name = "dgvFindCustomer"
        Me.dgvFindCustomer.ReadOnly = True
        Me.dgvFindCustomer.RowHeadersVisible = False
        Me.dgvFindCustomer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvFindCustomer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvFindCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFindCustomer.Size = New System.Drawing.Size(631, 165)
        Me.dgvFindCustomer.TabIndex = 83
        '
        'btnFindCustomer
        '
        Me.btnFindCustomer.Location = New System.Drawing.Point(544, 19)
        Me.btnFindCustomer.Name = "btnFindCustomer"
        Me.btnFindCustomer.Size = New System.Drawing.Size(102, 45)
        Me.btnFindCustomer.TabIndex = 3
        Me.btnFindCustomer.Text = "Find Customer"
        Me.btnFindCustomer.UseVisualStyleBackColor = True
        '
        'txtSearchLast
        '
        Me.txtSearchLast.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearchLast.Location = New System.Drawing.Point(344, 44)
        Me.txtSearchLast.Name = "txtSearchLast"
        Me.txtSearchLast.Size = New System.Drawing.Size(187, 20)
        Me.txtSearchLast.TabIndex = 2
        '
        'txtSearchCustID
        '
        Me.txtSearchCustID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearchCustID.Location = New System.Drawing.Point(100, 18)
        Me.txtSearchCustID.Name = "txtSearchCustID"
        Me.txtSearchCustID.Size = New System.Drawing.Size(171, 20)
        Me.txtSearchCustID.TabIndex = 0
        '
        'txtSearchFirst
        '
        Me.txtSearchFirst.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearchFirst.Location = New System.Drawing.Point(344, 18)
        Me.txtSearchFirst.Name = "txtSearchFirst"
        Me.txtSearchFirst.Size = New System.Drawing.Size(187, 20)
        Me.txtSearchFirst.TabIndex = 1
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(9, 21)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(68, 13)
        Me.Label32.TabIndex = 77
        Me.Label32.Text = "Customer ID:"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(277, 47)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(61, 13)
        Me.Label34.TabIndex = 79
        Me.Label34.Text = "Last Name:"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(278, 21)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(60, 13)
        Me.Label33.TabIndex = 78
        Me.Label33.Text = "First Name:"
        '
        'radioMasterCard
        '
        Me.radioMasterCard.AutoSize = True
        Me.radioMasterCard.Location = New System.Drawing.Point(127, 22)
        Me.radioMasterCard.Name = "radioMasterCard"
        Me.radioMasterCard.Size = New System.Drawing.Size(82, 17)
        Me.radioMasterCard.TabIndex = 75
        Me.radioMasterCard.TabStop = True
        Me.radioMasterCard.Text = "Master Card"
        Me.radioMasterCard.UseVisualStyleBackColor = True
        '
        'radioVisa
        '
        Me.radioVisa.AutoSize = True
        Me.radioVisa.Location = New System.Drawing.Point(257, 21)
        Me.radioVisa.Name = "radioVisa"
        Me.radioVisa.Size = New System.Drawing.Size(49, 17)
        Me.radioVisa.TabIndex = 76
        Me.radioVisa.TabStop = True
        Me.radioVisa.Text = "VISA"
        Me.radioVisa.UseVisualStyleBackColor = True
        '
        'gboxCreditCard
        '
        Me.gboxCreditCard.Controls.Add(Me.Label24)
        Me.gboxCreditCard.Controls.Add(Me.radioVisa)
        Me.gboxCreditCard.Controls.Add(Me.Label25)
        Me.gboxCreditCard.Controls.Add(Me.radioMasterCard)
        Me.gboxCreditCard.Controls.Add(Me.Label26)
        Me.gboxCreditCard.Controls.Add(Me.Label27)
        Me.gboxCreditCard.Controls.Add(Me.Label28)
        Me.gboxCreditCard.Controls.Add(Me.txtCVV)
        Me.gboxCreditCard.Controls.Add(Me.txtCCNumber)
        Me.gboxCreditCard.Controls.Add(Me.Label29)
        Me.gboxCreditCard.Controls.Add(Me.txtCardHolderName)
        Me.gboxCreditCard.Controls.Add(Me.txtBankTelephone)
        Me.gboxCreditCard.Controls.Add(Me.cboMonth)
        Me.gboxCreditCard.Controls.Add(Me.cboYear)
        Me.gboxCreditCard.Location = New System.Drawing.Point(12, 655)
        Me.gboxCreditCard.Name = "gboxCreditCard"
        Me.gboxCreditCard.Size = New System.Drawing.Size(662, 128)
        Me.gboxCreditCard.TabIndex = 77
        Me.gboxCreditCard.TabStop = False
        Me.gboxCreditCard.Text = "Credit Card Information"
        '
        'cboPaymentType
        '
        Me.cboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaymentType.FormattingEnabled = True
        Me.cboPaymentType.Items.AddRange(New Object() {"- Please Select -", "Cash", "Check", "Credit Card", "On Account"})
        Me.cboPaymentType.Location = New System.Drawing.Point(120, 628)
        Me.cboPaymentType.Name = "cboPaymentType"
        Me.cboPaymentType.Size = New System.Drawing.Size(188, 21)
        Me.cboPaymentType.TabIndex = 78
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(35, 631)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(78, 13)
        Me.Label35.TabIndex = 79
        Me.Label35.Text = "Payment Type:"
        '
        'frmCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 730)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.cboPaymentType)
        Me.Controls.Add(Me.gboxCreditCard)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.lblCustomerID)
        Me.Controls.Add(Me.radClearShipping)
        Me.Controls.Add(Me.radCopyBilling)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.Name = "frmCustomer"
        Me.ShowIcon = False
        Me.Tag = "SAVE"
        Me.Text = "Add/Edit Customer"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvFindCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxCreditCard.ResumeLayout(False)
        Me.gboxCreditCard.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtBillCompany As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtBillLast As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtBillDayPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtBillZipcode As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtBillCity As System.Windows.Forms.TextBox
    Friend WithEvents cboBillState As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtBillAddr3 As System.Windows.Forms.TextBox
    Friend WithEvents txtBillAddr2 As System.Windows.Forms.TextBox
    Friend WithEvents txtBillAddr1 As System.Windows.Forms.TextBox
    Friend WithEvents txtBillFirst As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtBillEveningPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtShipEveningPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtShipCompany As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtShipLast As System.Windows.Forms.TextBox
    Friend WithEvents txtShipFirst As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtShipAddr1 As System.Windows.Forms.TextBox
    Friend WithEvents txtShipDayPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtShipAddr2 As System.Windows.Forms.TextBox
    Friend WithEvents txtShipZipcode As System.Windows.Forms.TextBox
    Friend WithEvents txtShipAddr3 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboShipState As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtShipCity As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents radCopyBilling As System.Windows.Forms.RadioButton
    Friend WithEvents radClearShipping As System.Windows.Forms.RadioButton
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtCCNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtCardHolderName As System.Windows.Forms.TextBox
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cboYear As System.Windows.Forms.ComboBox
    Friend WithEvents txtBankTelephone As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtCVV As System.Windows.Forms.TextBox
    Friend WithEvents txtBillEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtShipEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lblCustomerID As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtSearchFirst As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchLast As System.Windows.Forms.TextBox
    Friend WithEvents btnFindCustomer As System.Windows.Forms.Button
    Public WithEvents txtSearchCustID As System.Windows.Forms.TextBox
    Friend WithEvents dgvFindCustomer As System.Windows.Forms.DataGridView
    Friend WithEvents radioMasterCard As System.Windows.Forms.RadioButton
    Friend WithEvents radioVisa As System.Windows.Forms.RadioButton
    Friend WithEvents gboxCreditCard As System.Windows.Forms.GroupBox
    Friend WithEvents cboPaymentType As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Public WithEvents txtSearchComp As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
End Class
