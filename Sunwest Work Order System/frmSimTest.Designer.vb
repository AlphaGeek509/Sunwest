<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSimTest
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblWO = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboRunTime = New System.Windows.Forms.ComboBox
        Me.cboLoad = New System.Windows.Forms.ComboBox
        Me.cboOilPressure = New System.Windows.Forms.ComboBox
        Me.cboCompression = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Test being applied to Work Order:"
        '
        'lblWO
        '
        Me.lblWO.AutoSize = True
        Me.lblWO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWO.ForeColor = System.Drawing.Color.Black
        Me.lblWO.Location = New System.Drawing.Point(186, 13)
        Me.lblWO.Name = "lblWO"
        Me.lblWO.Size = New System.Drawing.Size(40, 13)
        Me.lblWO.TabIndex = 1
        Me.lblWO.Text = "WO #"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(24, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Run Time:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(24, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Load:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(24, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Oil Pressure:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(24, 131)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Compression"
        '
        'cboRunTime
        '
        Me.cboRunTime.ForeColor = System.Drawing.Color.Black
        Me.cboRunTime.FormattingEnabled = True
        Me.cboRunTime.Items.AddRange(New Object() {"Please Select", "2", "4", "6", "8", "10"})
        Me.cboRunTime.Location = New System.Drawing.Point(96, 47)
        Me.cboRunTime.Name = "cboRunTime"
        Me.cboRunTime.Size = New System.Drawing.Size(95, 21)
        Me.cboRunTime.TabIndex = 6
        '
        'cboLoad
        '
        Me.cboLoad.ForeColor = System.Drawing.Color.Black
        Me.cboLoad.FormattingEnabled = True
        Me.cboLoad.Items.AddRange(New Object() {"Please Select", "2", "4", "6", "8", "10", "12", "14", "16", "18", "20"})
        Me.cboLoad.Location = New System.Drawing.Point(95, 74)
        Me.cboLoad.Name = "cboLoad"
        Me.cboLoad.Size = New System.Drawing.Size(95, 21)
        Me.cboLoad.TabIndex = 7
        '
        'cboOilPressure
        '
        Me.cboOilPressure.ForeColor = System.Drawing.Color.Black
        Me.cboOilPressure.FormattingEnabled = True
        Me.cboOilPressure.Items.AddRange(New Object() {"Please Select", "5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55", "60", "65", "70", "75", "80", "85", "90", "95", "100"})
        Me.cboOilPressure.Location = New System.Drawing.Point(96, 101)
        Me.cboOilPressure.Name = "cboOilPressure"
        Me.cboOilPressure.Size = New System.Drawing.Size(95, 21)
        Me.cboOilPressure.TabIndex = 8
        '
        'cboCompression
        '
        Me.cboCompression.ForeColor = System.Drawing.Color.Black
        Me.cboCompression.FormattingEnabled = True
        Me.cboCompression.Items.AddRange(New Object() {"Please Select", "100", "105", "110", "115", "120", "125", "130", "135", "140", "145", "150", "155", "160", "165", "170", "175", "180", "185", "190", "195", "200"})
        Me.cboCompression.Location = New System.Drawing.Point(96, 128)
        Me.cboCompression.Name = "cboCompression"
        Me.cboCompression.Size = New System.Drawing.Size(95, 21)
        Me.cboCompression.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(196, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "mins."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(196, 77)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "amps."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(197, 104)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(23, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "psi."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(197, 131)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(23, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "psi."
        '
        'btnSave
        '
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Location = New System.Drawing.Point(58, 176)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(122, 23)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Tag = "INSERT"
        Me.btnSave.Text = "Save Sim Test"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'frmSimTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(250, 211)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboCompression)
        Me.Controls.Add(Me.cboOilPressure)
        Me.Controls.Add(Me.cboLoad)
        Me.Controls.Add(Me.cboRunTime)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblWO)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "frmSimTest"
        Me.ShowIcon = False
        Me.Text = "Engine Simulation Test"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblWO As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboRunTime As System.Windows.Forms.ComboBox
    Friend WithEvents cboLoad As System.Windows.Forms.ComboBox
    Friend WithEvents cboOilPressure As System.Windows.Forms.ComboBox
    Friend WithEvents cboCompression As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
End Class
