<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditYears
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
        Me.dgvYears = New System.Windows.Forms.DataGridView
        Me.btnSave = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNewYear = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboOrder = New System.Windows.Forms.ComboBox
        Me.chkHide = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colVisible = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvYears, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvYears
        '
        Me.dgvYears.AllowUserToAddRows = False
        Me.dgvYears.AllowUserToDeleteRows = False
        Me.dgvYears.AllowUserToResizeColumns = False
        Me.dgvYears.AllowUserToResizeRows = False
        Me.dgvYears.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvYears.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chkHide, Me.colVisible})
        Me.dgvYears.Location = New System.Drawing.Point(12, 182)
        Me.dgvYears.Name = "dgvYears"
        Me.dgvYears.RowHeadersVisible = False
        Me.dgvYears.Size = New System.Drawing.Size(234, 328)
        Me.dgvYears.TabIndex = 0
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(198, 131)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(48, 23)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(234, 42)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Due to years being used in the WO, dates can not be deleted but only hidden."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Add a new year:"
        '
        'txtNewYear
        '
        Me.txtNewYear.Location = New System.Drawing.Point(99, 96)
        Me.txtNewYear.MaxLength = 10
        Me.txtNewYear.Name = "txtNewYear"
        Me.txtNewYear.Size = New System.Drawing.Size(85, 20)
        Me.txtNewYear.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(62, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Display order:"
        '
        'cboOrder
        '
        Me.cboOrder.FormattingEnabled = True
        Me.cboOrder.Location = New System.Drawing.Point(139, 133)
        Me.cboOrder.Name = "cboOrder"
        Me.cboOrder.Size = New System.Drawing.Size(45, 21)
        Me.cboOrder.TabIndex = 6
        '
        'chkHide
        '
        Me.chkHide.HeaderText = "Hide Year"
        Me.chkHide.Name = "chkHide"
        '
        'colVisible
        '
        Me.colVisible.HeaderText = "Visible"
        Me.colVisible.Name = "colVisible"
        Me.colVisible.Visible = False
        '
        'frmEditYears
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(259, 522)
        Me.Controls.Add(Me.cboOrder)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNewYear)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.dgvYears)
        Me.Name = "frmEditYears"
        Me.Text = "frmEditYears"
        CType(Me.dgvYears, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvYears As System.Windows.Forms.DataGridView
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNewYear As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboOrder As System.Windows.Forms.ComboBox
    Friend WithEvents chkHide As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colVisible As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
