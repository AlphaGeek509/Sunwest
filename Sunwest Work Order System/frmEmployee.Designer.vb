<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmployee
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployee))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFirst = New System.Windows.Forms.TextBox
        Me.txtLast = New System.Windows.Forms.TextBox
        Me.btnDone = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkEmployeeEdit = New System.Windows.Forms.CheckBox
        Me.chkEmployeeAdd = New System.Windows.Forms.CheckBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.chkImagesEdit = New System.Windows.Forms.CheckBox
        Me.chkImagesAdd = New System.Windows.Forms.CheckBox
        Me.chkWOEdit = New System.Windows.Forms.CheckBox
        Me.chkWOAdd = New System.Windows.Forms.CheckBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.chkCreditCardEdit = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.chkCreditCardAdd = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkCustomerAdd = New System.Windows.Forms.CheckBox
        Me.chkCustomerEdit = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.chkImagesDelete = New System.Windows.Forms.CheckBox
        Me.chkWODelete = New System.Windows.Forms.CheckBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.chkAdminDelete = New System.Windows.Forms.CheckBox
        Me.chkCustomerDelete = New System.Windows.Forms.CheckBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtJobDesc = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtConPassword = New System.Windows.Forms.TextBox
        Me.btnDelete = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "First Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Last Name:"
        '
        'txtFirst
        '
        Me.txtFirst.Location = New System.Drawing.Point(109, 6)
        Me.txtFirst.Name = "txtFirst"
        Me.txtFirst.Size = New System.Drawing.Size(120, 20)
        Me.txtFirst.TabIndex = 0
        '
        'txtLast
        '
        Me.txtLast.Location = New System.Drawing.Point(109, 32)
        Me.txtLast.Name = "txtLast"
        Me.txtLast.Size = New System.Drawing.Size(120, 20)
        Me.txtLast.TabIndex = 1
        '
        'btnDone
        '
        Me.btnDone.Location = New System.Drawing.Point(174, 305)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(55, 23)
        Me.btnDone.TabIndex = 5
        Me.btnDone.Text = "Done"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkEmployeeEdit)
        Me.GroupBox1.Controls.Add(Me.chkEmployeeAdd)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.chkImagesEdit)
        Me.GroupBox1.Controls.Add(Me.chkImagesAdd)
        Me.GroupBox1.Controls.Add(Me.chkWOEdit)
        Me.GroupBox1.Controls.Add(Me.chkWOAdd)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.chkCreditCardEdit)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.chkCreditCardAdd)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.chkCustomerAdd)
        Me.GroupBox1.Controls.Add(Me.chkCustomerEdit)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 155)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(217, 144)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Security Levels"
        '
        'chkEmployeeEdit
        '
        Me.chkEmployeeEdit.AutoSize = True
        Me.chkEmployeeEdit.Location = New System.Drawing.Point(171, 117)
        Me.chkEmployeeEdit.Name = "chkEmployeeEdit"
        Me.chkEmployeeEdit.Size = New System.Drawing.Size(15, 14)
        Me.chkEmployeeEdit.TabIndex = 16
        Me.chkEmployeeEdit.Tag = "75"
        Me.chkEmployeeEdit.UseVisualStyleBackColor = True
        '
        'chkEmployeeAdd
        '
        Me.chkEmployeeAdd.AutoSize = True
        Me.chkEmployeeAdd.Location = New System.Drawing.Point(126, 117)
        Me.chkEmployeeAdd.Name = "chkEmployeeAdd"
        Me.chkEmployeeAdd.Size = New System.Drawing.Size(15, 14)
        Me.chkEmployeeAdd.TabIndex = 15
        Me.chkEmployeeAdd.Tag = "100"
        Me.chkEmployeeAdd.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 117)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Employees:"
        '
        'chkImagesEdit
        '
        Me.chkImagesEdit.AutoSize = True
        Me.chkImagesEdit.Location = New System.Drawing.Point(171, 57)
        Me.chkImagesEdit.Name = "chkImagesEdit"
        Me.chkImagesEdit.Size = New System.Drawing.Size(15, 14)
        Me.chkImagesEdit.TabIndex = 13
        Me.chkImagesEdit.Tag = "75"
        Me.chkImagesEdit.UseVisualStyleBackColor = True
        Me.chkImagesEdit.Visible = False
        '
        'chkImagesAdd
        '
        Me.chkImagesAdd.AutoSize = True
        Me.chkImagesAdd.Location = New System.Drawing.Point(126, 57)
        Me.chkImagesAdd.Name = "chkImagesAdd"
        Me.chkImagesAdd.Size = New System.Drawing.Size(15, 14)
        Me.chkImagesAdd.TabIndex = 12
        Me.chkImagesAdd.Tag = "100"
        Me.chkImagesAdd.UseVisualStyleBackColor = True
        '
        'chkWOEdit
        '
        Me.chkWOEdit.AutoSize = True
        Me.chkWOEdit.Location = New System.Drawing.Point(171, 37)
        Me.chkWOEdit.Name = "chkWOEdit"
        Me.chkWOEdit.Size = New System.Drawing.Size(15, 14)
        Me.chkWOEdit.TabIndex = 10
        Me.chkWOEdit.Tag = "75"
        Me.chkWOEdit.UseVisualStyleBackColor = True
        '
        'chkWOAdd
        '
        Me.chkWOAdd.AutoSize = True
        Me.chkWOAdd.Location = New System.Drawing.Point(126, 37)
        Me.chkWOAdd.Name = "chkWOAdd"
        Me.chkWOAdd.Size = New System.Drawing.Size(15, 14)
        Me.chkWOAdd.TabIndex = 9
        Me.chkWOAdd.Tag = "100"
        Me.chkWOAdd.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(165, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(25, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Edit"
        '
        'chkCreditCardEdit
        '
        Me.chkCreditCardEdit.AutoSize = True
        Me.chkCreditCardEdit.Location = New System.Drawing.Point(171, 97)
        Me.chkCreditCardEdit.Name = "chkCreditCardEdit"
        Me.chkCreditCardEdit.Size = New System.Drawing.Size(15, 14)
        Me.chkCreditCardEdit.TabIndex = 7
        Me.chkCreditCardEdit.Tag = "75"
        Me.chkCreditCardEdit.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(121, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Add"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Images:"
        '
        'chkCreditCardAdd
        '
        Me.chkCreditCardAdd.AutoSize = True
        Me.chkCreditCardAdd.Location = New System.Drawing.Point(126, 97)
        Me.chkCreditCardAdd.Name = "chkCreditCardAdd"
        Me.chkCreditCardAdd.Size = New System.Drawing.Size(15, 14)
        Me.chkCreditCardAdd.TabIndex = 6
        Me.chkCreditCardAdd.Tag = "100"
        Me.chkCreditCardAdd.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Work Orders:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Customers:"
        '
        'chkCustomerAdd
        '
        Me.chkCustomerAdd.AutoSize = True
        Me.chkCustomerAdd.Location = New System.Drawing.Point(126, 77)
        Me.chkCustomerAdd.Name = "chkCustomerAdd"
        Me.chkCustomerAdd.Size = New System.Drawing.Size(15, 14)
        Me.chkCustomerAdd.TabIndex = 3
        Me.chkCustomerAdd.Tag = "100"
        Me.chkCustomerAdd.UseVisualStyleBackColor = True
        '
        'chkCustomerEdit
        '
        Me.chkCustomerEdit.AutoSize = True
        Me.chkCustomerEdit.Location = New System.Drawing.Point(171, 77)
        Me.chkCustomerEdit.Name = "chkCustomerEdit"
        Me.chkCustomerEdit.Size = New System.Drawing.Size(15, 14)
        Me.chkCustomerEdit.TabIndex = 4
        Me.chkCustomerEdit.Tag = "75"
        Me.chkCustomerEdit.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Customer Credit Cards:"
        '
        'chkImagesDelete
        '
        Me.chkImagesDelete.AutoSize = True
        Me.chkImagesDelete.Location = New System.Drawing.Point(284, 193)
        Me.chkImagesDelete.Name = "chkImagesDelete"
        Me.chkImagesDelete.Size = New System.Drawing.Size(15, 14)
        Me.chkImagesDelete.TabIndex = 14
        Me.chkImagesDelete.Tag = "50"
        Me.chkImagesDelete.UseVisualStyleBackColor = True
        Me.chkImagesDelete.Visible = False
        '
        'chkWODelete
        '
        Me.chkWODelete.AutoSize = True
        Me.chkWODelete.Location = New System.Drawing.Point(284, 173)
        Me.chkWODelete.Name = "chkWODelete"
        Me.chkWODelete.Size = New System.Drawing.Size(15, 14)
        Me.chkWODelete.TabIndex = 11
        Me.chkWODelete.Tag = "50"
        Me.chkWODelete.UseVisualStyleBackColor = True
        Me.chkWODelete.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(274, 152)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Delete"
        Me.Label9.Visible = False
        '
        'chkAdminDelete
        '
        Me.chkAdminDelete.AutoSize = True
        Me.chkAdminDelete.Location = New System.Drawing.Point(284, 233)
        Me.chkAdminDelete.Name = "chkAdminDelete"
        Me.chkAdminDelete.Size = New System.Drawing.Size(15, 14)
        Me.chkAdminDelete.TabIndex = 8
        Me.chkAdminDelete.Tag = "50"
        Me.chkAdminDelete.UseVisualStyleBackColor = True
        Me.chkAdminDelete.Visible = False
        '
        'chkCustomerDelete
        '
        Me.chkCustomerDelete.AutoSize = True
        Me.chkCustomerDelete.Location = New System.Drawing.Point(284, 213)
        Me.chkCustomerDelete.Name = "chkCustomerDelete"
        Me.chkCustomerDelete.Size = New System.Drawing.Size(15, 14)
        Me.chkCustomerDelete.TabIndex = 5
        Me.chkCustomerDelete.Tag = "50"
        Me.chkCustomerDelete.UseVisualStyleBackColor = True
        Me.chkCustomerDelete.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 113)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 13)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Job Description:"
        '
        'txtJobDesc
        '
        Me.txtJobDesc.Location = New System.Drawing.Point(109, 110)
        Me.txtJobDesc.Name = "txtJobDesc"
        Me.txtJobDesc.Size = New System.Drawing.Size(120, 20)
        Me.txtJobDesc.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 61)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 13)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Password:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 87)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(94, 13)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Confirm Password:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(109, 58)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(120, 20)
        Me.txtPassword.TabIndex = 2
        '
        'txtConPassword
        '
        Me.txtConPassword.Location = New System.Drawing.Point(109, 84)
        Me.txtConPassword.Name = "txtConPassword"
        Me.txtConPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConPassword.Size = New System.Drawing.Size(120, 20)
        Me.txtConPassword.TabIndex = 3
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(12, 305)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(47, 23)
        Me.btnDelete.TabIndex = 17
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'frmEmployee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(239, 352)
        Me.Controls.Add(Me.chkImagesDelete)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.txtConPassword)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.chkWODelete)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtJobDesc)
        Me.Controls.Add(Me.chkAdminDelete)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.txtLast)
        Me.Controls.Add(Me.txtFirst)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkCustomerDelete)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmEmployee"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add/Edit Employee"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFirst As System.Windows.Forms.TextBox
    Friend WithEvents txtLast As System.Windows.Forms.TextBox
    Friend WithEvents btnDone As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkCustomerAdd As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkCustomerDelete As System.Windows.Forms.CheckBox
    Friend WithEvents chkCustomerEdit As System.Windows.Forms.CheckBox
    Friend WithEvents chkImagesDelete As System.Windows.Forms.CheckBox
    Friend WithEvents chkImagesEdit As System.Windows.Forms.CheckBox
    Friend WithEvents chkImagesAdd As System.Windows.Forms.CheckBox
    Friend WithEvents chkWODelete As System.Windows.Forms.CheckBox
    Friend WithEvents chkWOEdit As System.Windows.Forms.CheckBox
    Friend WithEvents chkWOAdd As System.Windows.Forms.CheckBox
    Friend WithEvents chkAdminDelete As System.Windows.Forms.CheckBox
    Friend WithEvents chkCreditCardEdit As System.Windows.Forms.CheckBox
    Friend WithEvents chkCreditCardAdd As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtJobDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtConPassword As System.Windows.Forms.TextBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents chkEmployeeEdit As System.Windows.Forms.CheckBox
    Friend WithEvents chkEmployeeAdd As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
