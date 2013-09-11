<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchOrAddTemplate
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgv1 = New System.Windows.Forms.DataGridView
        Me.colCheckBox = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.dgv2 = New System.Windows.Forms.DataGridView
        Me.colCheckBox2 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.lblLoad = New System.Windows.Forms.Label
        Me.cboCylinderHead = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnLoad = New System.Windows.Forms.Button
        Me.lblSave = New System.Windows.Forms.Label
        Me.txtSave = New System.Windows.Forms.TextBox
        Me.btnDelete = New System.Windows.Forms.Button
        Me.lblTemplateID = New System.Windows.Forms.Label
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rtxtNotes = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtVinCode = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtModel = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.radPieceWork = New System.Windows.Forms.RadioButton
        Me.radLongBlock = New System.Windows.Forms.RadioButton
        Me.radCylinderHead = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboFreightCarriers = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtHeadCore = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.cboCore = New System.Windows.Forms.ComboBox
        Me.txtBlockCore = New System.Windows.Forms.TextBox
        Me.txtCrankCore = New System.Windows.Forms.TextBox
        Me.txtCamCore = New System.Windows.Forms.TextBox
        Me.txtRodCore = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.txtHead = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtBlock = New System.Windows.Forms.TextBox
        Me.txtCrank = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtCubic = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtPO = New System.Windows.Forms.TextBox
        Me.cboYear = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.cboMake = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkFreightOwn = New System.Windows.Forms.CheckBox
        Me.chkFreightReturn = New System.Windows.Forms.CheckBox
        Me.chkFreightOutgoing = New System.Windows.Forms.CheckBox
        Me.chkFreightCorePur = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblPieceWork = New System.Windows.Forms.Label
        Me.lblTemplateType = New System.Windows.Forms.Label
        Me.lblCylinderHead = New System.Windows.Forms.Label
        Me.lblLongBlock = New System.Windows.Forms.Label
        Me.cboLongBlock = New System.Windows.Forms.ComboBox
        Me.cboPieceWork = New System.Windows.Forms.ComboBox
        Me.lblItemDesc = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ToolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddImagesToTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.RemoveImagesFromTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblImageCount = New System.Windows.Forms.Label
        Me.btnViewImages = New System.Windows.Forms.Button
        Me.ilCurrentImages = New System.Windows.Forms.ImageList(Me.components)
        Me.btnCopyTemplate = New System.Windows.Forms.Button
        Me.lblID = New System.Windows.Forms.Label
        Me.txtCylinderHead = New System.Windows.Forms.TextBox
        Me.txtLongBlock = New System.Windows.Forms.TextBox
        Me.txtPieceWork = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtSearchTemplateID = New System.Windows.Forms.TextBox
        Me.btnSearchTemplateID = New System.Windows.Forms.Button
        Me.txtFreightCost = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtJobber = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.AllowUserToOrderColumns = True
        Me.dgv1.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro
        Me.dgv1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCheckBox})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv1.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgv1.Location = New System.Drawing.Point(6, 19)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.RowHeadersVisible = False
        Me.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv1.Size = New System.Drawing.Size(375, 544)
        Me.dgv1.TabIndex = 0
        '
        'colCheckBox
        '
        Me.colCheckBox.HeaderText = ""
        Me.colCheckBox.Name = "colCheckBox"
        Me.colCheckBox.Width = 241
        '
        'dgv2
        '
        Me.dgv2.AllowUserToAddRows = False
        Me.dgv2.AllowUserToDeleteRows = False
        Me.dgv2.AllowUserToOrderColumns = True
        Me.dgv2.AllowUserToResizeRows = False
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.Gainsboro
        Me.dgv2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCheckBox2})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv2.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgv2.Location = New System.Drawing.Point(394, 19)
        Me.dgv2.Name = "dgv2"
        Me.dgv2.RowHeadersVisible = False
        Me.dgv2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgv2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv2.Size = New System.Drawing.Size(833, 544)
        Me.dgv2.TabIndex = 1
        '
        'colCheckBox2
        '
        Me.colCheckBox2.HeaderText = ""
        Me.colCheckBox2.Name = "colCheckBox2"
        Me.colCheckBox2.Width = 241
        '
        'lblLoad
        '
        Me.lblLoad.AutoSize = True
        Me.lblLoad.Location = New System.Drawing.Point(6, 29)
        Me.lblLoad.Name = "lblLoad"
        Me.lblLoad.Size = New System.Drawing.Size(212, 13)
        Me.lblLoad.TabIndex = 39
        Me.lblLoad.Text = "Please select the template you want to use:"
        Me.lblLoad.Visible = False
        '
        'cboCylinderHead
        '
        Me.cboCylinderHead.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCylinderHead.FormattingEnabled = True
        Me.cboCylinderHead.Location = New System.Drawing.Point(154, 45)
        Me.cboCylinderHead.Name = "cboCylinderHead"
        Me.cboCylinderHead.Size = New System.Drawing.Size(160, 21)
        Me.cboCylinderHead.TabIndex = 1
        Me.cboCylinderHead.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgv1)
        Me.GroupBox1.Controls.Add(Me.dgv2)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 210)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1233, 604)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Previewed Results"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(1048, 821)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(91, 23)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save Template"
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.Visible = False
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(1145, 820)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(91, 23)
        Me.btnLoad.TabIndex = 6
        Me.btnLoad.Text = "Load Template"
        Me.btnLoad.UseVisualStyleBackColor = True
        Me.btnLoad.Visible = False
        '
        'lblSave
        '
        Me.lblSave.AutoSize = True
        Me.lblSave.Location = New System.Drawing.Point(6, 29)
        Me.lblSave.Name = "lblSave"
        Me.lblSave.Size = New System.Drawing.Size(281, 13)
        Me.lblSave.TabIndex = 45
        Me.lblSave.Text = "Give a descriptive name to the template you want to save:"
        Me.lblSave.Visible = False
        '
        'txtSave
        '
        Me.txtSave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSave.Location = New System.Drawing.Point(9, 45)
        Me.txtSave.MaxLength = 150
        Me.txtSave.Name = "txtSave"
        Me.txtSave.Size = New System.Drawing.Size(305, 20)
        Me.txtSave.TabIndex = 0
        Me.txtSave.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Red
        Me.btnDelete.Location = New System.Drawing.Point(120, 821)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(103, 23)
        Me.btnDelete.TabIndex = 9
        Me.btnDelete.Text = "Delete Template"
        Me.btnDelete.UseVisualStyleBackColor = False
        Me.btnDelete.Visible = False
        '
        'lblTemplateID
        '
        Me.lblTemplateID.AutoSize = True
        Me.lblTemplateID.Location = New System.Drawing.Point(12, 139)
        Me.lblTemplateID.Name = "lblTemplateID"
        Me.lblTemplateID.Size = New System.Drawing.Size(72, 13)
        Me.lblTemplateID.TabIndex = 48
        Me.lblTemplateID.Text = "lblTemplateID"
        Me.lblTemplateID.Visible = False
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.LawnGreen
        Me.btnUpdate.Location = New System.Drawing.Point(8, 821)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(106, 23)
        Me.btnUpdate.TabIndex = 8
        Me.btnUpdate.Text = "Update Template"
        Me.btnUpdate.UseVisualStyleBackColor = False
        Me.btnUpdate.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtJobber)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtFreightCost)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.rtxtNotes)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtVinCode)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtModel)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.radPieceWork)
        Me.GroupBox2.Controls.Add(Me.radLongBlock)
        Me.GroupBox2.Controls.Add(Me.radCylinderHead)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cboFreightCarriers)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtHeadCore)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.cboCore)
        Me.GroupBox2.Controls.Add(Me.txtBlockCore)
        Me.GroupBox2.Controls.Add(Me.txtCrankCore)
        Me.GroupBox2.Controls.Add(Me.txtCamCore)
        Me.GroupBox2.Controls.Add(Me.txtRodCore)
        Me.GroupBox2.Controls.Add(Me.Label33)
        Me.GroupBox2.Controls.Add(Me.Label32)
        Me.GroupBox2.Controls.Add(Me.Label31)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.txtHead)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.txtBlock)
        Me.GroupBox2.Controls.Add(Me.txtCrank)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.txtCubic)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.txtPO)
        Me.GroupBox2.Controls.Add(Me.cboYear)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.cboMake)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(320, 29)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(922, 181)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Administration"
        '
        'rtxtNotes
        '
        Me.rtxtNotes.Location = New System.Drawing.Point(695, 37)
        Me.rtxtNotes.Multiline = True
        Me.rtxtNotes.Name = "rtxtNotes"
        Me.rtxtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.rtxtNotes.Size = New System.Drawing.Size(221, 126)
        Me.rtxtNotes.TabIndex = 79
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(692, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "General Notes:"
        '
        'txtVinCode
        '
        Me.txtVinCode.Location = New System.Drawing.Point(263, 127)
        Me.txtVinCode.Name = "txtVinCode"
        Me.txtVinCode.Size = New System.Drawing.Size(101, 20)
        Me.txtVinCode.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(198, 130)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 13)
        Me.Label11.TabIndex = 77
        Me.Label11.Text = "VIN Code:"
        '
        'txtModel
        '
        Me.txtModel.Location = New System.Drawing.Point(263, 101)
        Me.txtModel.Name = "txtModel"
        Me.txtModel.Size = New System.Drawing.Size(101, 20)
        Me.txtModel.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(187, 104)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 13)
        Me.Label10.TabIndex = 75
        Me.Label10.Text = "Model of Car:"
        '
        'radPieceWork
        '
        Me.radPieceWork.AutoSize = True
        Me.radPieceWork.Location = New System.Drawing.Point(287, 64)
        Me.radPieceWork.Name = "radPieceWork"
        Me.radPieceWork.Size = New System.Drawing.Size(81, 17)
        Me.radPieceWork.TabIndex = 9
        Me.radPieceWork.TabStop = True
        Me.radPieceWork.Tag = "PieceWork"
        Me.radPieceWork.Text = "Piece Work"
        Me.radPieceWork.UseVisualStyleBackColor = True
        '
        'radLongBlock
        '
        Me.radLongBlock.AutoSize = True
        Me.radLongBlock.Location = New System.Drawing.Point(287, 41)
        Me.radLongBlock.Name = "radLongBlock"
        Me.radLongBlock.Size = New System.Drawing.Size(79, 17)
        Me.radLongBlock.TabIndex = 8
        Me.radLongBlock.TabStop = True
        Me.radLongBlock.Tag = "LongBlock"
        Me.radLongBlock.Text = "Long Block"
        Me.radLongBlock.UseVisualStyleBackColor = True
        '
        'radCylinderHead
        '
        Me.radCylinderHead.AutoSize = True
        Me.radCylinderHead.Location = New System.Drawing.Point(287, 18)
        Me.radCylinderHead.Name = "radCylinderHead"
        Me.radCylinderHead.Size = New System.Drawing.Size(91, 17)
        Me.radCylinderHead.TabIndex = 7
        Me.radCylinderHead.TabStop = True
        Me.radCylinderHead.Tag = "CylinderHead"
        Me.radCylinderHead.Text = "Cylinder Head"
        Me.radCylinderHead.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(200, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Template Type:"
        '
        'cboFreightCarriers
        '
        Me.cboFreightCarriers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFreightCarriers.FormattingEnabled = True
        Me.cboFreightCarriers.Location = New System.Drawing.Point(447, 127)
        Me.cboFreightCarriers.Name = "cboFreightCarriers"
        Me.cboFreightCarriers.Size = New System.Drawing.Size(109, 21)
        Me.cboFreightCarriers.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(396, 130)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "Carriers:"
        '
        'txtHeadCore
        '
        Me.txtHeadCore.Location = New System.Drawing.Point(447, 100)
        Me.txtHeadCore.Name = "txtHeadCore"
        Me.txtHeadCore.Size = New System.Drawing.Size(64, 20)
        Me.txtHeadCore.TabIndex = 18
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(380, 103)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(61, 13)
        Me.Label27.TabIndex = 58
        Me.Label27.Text = "Head Core:"
        '
        'cboCore
        '
        Me.cboCore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCore.FormattingEnabled = True
        Me.cboCore.Items.AddRange(New Object() {"Customer", "Sunwest"})
        Me.cboCore.Location = New System.Drawing.Point(83, 17)
        Me.cboCore.Name = "cboCore"
        Me.cboCore.Size = New System.Drawing.Size(98, 21)
        Me.cboCore.TabIndex = 0
        '
        'txtBlockCore
        '
        Me.txtBlockCore.Location = New System.Drawing.Point(622, 100)
        Me.txtBlockCore.Name = "txtBlockCore"
        Me.txtBlockCore.Size = New System.Drawing.Size(64, 20)
        Me.txtBlockCore.TabIndex = 22
        '
        'txtCrankCore
        '
        Me.txtCrankCore.Location = New System.Drawing.Point(622, 74)
        Me.txtCrankCore.Name = "txtCrankCore"
        Me.txtCrankCore.Size = New System.Drawing.Size(64, 20)
        Me.txtCrankCore.TabIndex = 21
        '
        'txtCamCore
        '
        Me.txtCamCore.Location = New System.Drawing.Point(622, 47)
        Me.txtCamCore.Name = "txtCamCore"
        Me.txtCamCore.Size = New System.Drawing.Size(64, 20)
        Me.txtCamCore.TabIndex = 20
        '
        'txtRodCore
        '
        Me.txtRodCore.Location = New System.Drawing.Point(622, 18)
        Me.txtRodCore.Name = "txtRodCore"
        Me.txtRodCore.Size = New System.Drawing.Size(64, 20)
        Me.txtRodCore.TabIndex = 19
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(517, 103)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(99, 13)
        Me.Label33.TabIndex = 49
        Me.Label33.Text = "Block Core Charge:"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(553, 77)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(63, 13)
        Me.Label32.TabIndex = 48
        Me.Label32.Text = "Crank Core:"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(560, 50)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(56, 13)
        Me.Label31.TabIndex = 47
        Me.Label31.Text = "Cam Core:"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(539, 21)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(77, 13)
        Me.Label30.TabIndex = 46
        Me.Label30.Text = "Con Rod Core:"
        '
        'txtHead
        '
        Me.txtHead.Location = New System.Drawing.Point(447, 74)
        Me.txtHead.Name = "txtHead"
        Me.txtHead.Size = New System.Drawing.Size(64, 20)
        Me.txtHead.TabIndex = 17
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(385, 77)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(56, 13)
        Me.Label21.TabIndex = 20
        Me.Label21.Text = "Head No.:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(383, 50)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(58, 13)
        Me.Label20.TabIndex = 19
        Me.Label20.Text = "Crank No.:"
        '
        'txtBlock
        '
        Me.txtBlock.Location = New System.Drawing.Point(447, 18)
        Me.txtBlock.Name = "txtBlock"
        Me.txtBlock.Size = New System.Drawing.Size(64, 20)
        Me.txtBlock.TabIndex = 15
        '
        'txtCrank
        '
        Me.txtCrank.Location = New System.Drawing.Point(447, 47)
        Me.txtCrank.Name = "txtCrank"
        Me.txtCrank.Size = New System.Drawing.Size(64, 20)
        Me.txtCrank.TabIndex = 16
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(384, 20)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(57, 13)
        Me.Label19.TabIndex = 16
        Me.Label19.Text = "Block No.:"
        '
        'txtCubic
        '
        Me.txtCubic.Location = New System.Drawing.Point(83, 71)
        Me.txtCubic.Name = "txtCubic"
        Me.txtCubic.Size = New System.Drawing.Size(98, 20)
        Me.txtCubic.TabIndex = 2
        Me.txtCubic.Tag = "1"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(25, 74)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(52, 13)
        Me.Label17.TabIndex = 14
        Me.Label17.Text = "Cubic In.:"
        '
        'txtPO
        '
        Me.txtPO.Location = New System.Drawing.Point(83, 44)
        Me.txtPO.Name = "txtPO"
        Me.txtPO.Size = New System.Drawing.Size(98, 20)
        Me.txtPO.TabIndex = 1
        Me.txtPO.Tag = "1"
        '
        'cboYear
        '
        Me.cboYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Location = New System.Drawing.Point(83, 127)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(98, 21)
        Me.cboYear.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Year of Car:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(32, 47)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 13)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "PO No.:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(25, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 13)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "Core No.:"
        '
        'cboMake
        '
        Me.cboMake.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboMake.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMake.DropDownHeight = 200
        Me.cboMake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMake.FormattingEnabled = True
        Me.cboMake.IntegralHeight = False
        Me.cboMake.Location = New System.Drawing.Point(83, 101)
        Me.cboMake.Name = "cboMake"
        Me.cboMake.Size = New System.Drawing.Size(98, 21)
        Me.cboMake.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Make of Car:"
        '
        'chkFreightOwn
        '
        Me.chkFreightOwn.AutoSize = True
        Me.chkFreightOwn.Location = New System.Drawing.Point(1296, 820)
        Me.chkFreightOwn.Name = "chkFreightOwn"
        Me.chkFreightOwn.Size = New System.Drawing.Size(48, 17)
        Me.chkFreightOwn.TabIndex = 13
        Me.chkFreightOwn.Text = "Own"
        Me.chkFreightOwn.UseVisualStyleBackColor = True
        Me.chkFreightOwn.Visible = False
        '
        'chkFreightReturn
        '
        Me.chkFreightReturn.AutoSize = True
        Me.chkFreightReturn.Location = New System.Drawing.Point(1296, 797)
        Me.chkFreightReturn.Name = "chkFreightReturn"
        Me.chkFreightReturn.Size = New System.Drawing.Size(58, 17)
        Me.chkFreightReturn.TabIndex = 12
        Me.chkFreightReturn.Text = "Return"
        Me.chkFreightReturn.UseVisualStyleBackColor = True
        Me.chkFreightReturn.Visible = False
        '
        'chkFreightOutgoing
        '
        Me.chkFreightOutgoing.AutoSize = True
        Me.chkFreightOutgoing.Location = New System.Drawing.Point(1296, 774)
        Me.chkFreightOutgoing.Name = "chkFreightOutgoing"
        Me.chkFreightOutgoing.Size = New System.Drawing.Size(132, 17)
        Me.chkFreightOutgoing.TabIndex = 11
        Me.chkFreightOutgoing.Text = "Outgoing (Exch. prog.)"
        Me.chkFreightOutgoing.UseVisualStyleBackColor = True
        Me.chkFreightOutgoing.Visible = False
        '
        'chkFreightCorePur
        '
        Me.chkFreightCorePur.AutoSize = True
        Me.chkFreightCorePur.Location = New System.Drawing.Point(1296, 751)
        Me.chkFreightCorePur.Name = "chkFreightCorePur"
        Me.chkFreightCorePur.Size = New System.Drawing.Size(96, 17)
        Me.chkFreightCorePur.TabIndex = 10
        Me.chkFreightCorePur.Text = "Core Purchase"
        Me.chkFreightCorePur.UseVisualStyleBackColor = True
        Me.chkFreightCorePur.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1248, 752)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Freight:"
        Me.Label1.Visible = False
        '
        'lblPieceWork
        '
        Me.lblPieceWork.AutoSize = True
        Me.lblPieceWork.Location = New System.Drawing.Point(85, 102)
        Me.lblPieceWork.Name = "lblPieceWork"
        Me.lblPieceWork.Size = New System.Drawing.Size(63, 13)
        Me.lblPieceWork.TabIndex = 69
        Me.lblPieceWork.Text = "Piece Work"
        Me.lblPieceWork.Visible = False
        '
        'lblTemplateType
        '
        Me.lblTemplateType.AutoSize = True
        Me.lblTemplateType.Location = New System.Drawing.Point(12, 152)
        Me.lblTemplateType.Name = "lblTemplateType"
        Me.lblTemplateType.Size = New System.Drawing.Size(85, 13)
        Me.lblTemplateType.TabIndex = 50
        Me.lblTemplateType.Text = "lblTemplateType"
        Me.lblTemplateType.Visible = False
        '
        'lblCylinderHead
        '
        Me.lblCylinderHead.AutoSize = True
        Me.lblCylinderHead.Location = New System.Drawing.Point(75, 48)
        Me.lblCylinderHead.Name = "lblCylinderHead"
        Me.lblCylinderHead.Size = New System.Drawing.Size(73, 13)
        Me.lblCylinderHead.TabIndex = 67
        Me.lblCylinderHead.Text = "Cylinder Head"
        Me.lblCylinderHead.Visible = False
        '
        'lblLongBlock
        '
        Me.lblLongBlock.AutoSize = True
        Me.lblLongBlock.Location = New System.Drawing.Point(87, 75)
        Me.lblLongBlock.Name = "lblLongBlock"
        Me.lblLongBlock.Size = New System.Drawing.Size(61, 13)
        Me.lblLongBlock.TabIndex = 68
        Me.lblLongBlock.Text = "Long Block"
        Me.lblLongBlock.Visible = False
        '
        'cboLongBlock
        '
        Me.cboLongBlock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLongBlock.FormattingEnabled = True
        Me.cboLongBlock.Location = New System.Drawing.Point(154, 72)
        Me.cboLongBlock.Name = "cboLongBlock"
        Me.cboLongBlock.Size = New System.Drawing.Size(160, 21)
        Me.cboLongBlock.TabIndex = 2
        Me.cboLongBlock.Visible = False
        '
        'cboPieceWork
        '
        Me.cboPieceWork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPieceWork.FormattingEnabled = True
        Me.cboPieceWork.Location = New System.Drawing.Point(154, 99)
        Me.cboPieceWork.Name = "cboPieceWork"
        Me.cboPieceWork.Size = New System.Drawing.Size(160, 21)
        Me.cboPieceWork.TabIndex = 3
        Me.cboPieceWork.Visible = False
        '
        'lblItemDesc
        '
        Me.lblItemDesc.AutoSize = True
        Me.lblItemDesc.Location = New System.Drawing.Point(12, 165)
        Me.lblItemDesc.Name = "lblItemDesc"
        Me.lblItemDesc.Size = New System.Drawing.Size(62, 13)
        Me.lblItemDesc.TabIndex = 71
        Me.lblItemDesc.Text = "lblItemDesc"
        Me.lblItemDesc.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1252, 24)
        Me.MenuStrip1.TabIndex = 72
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolToolStripMenuItem
        '
        Me.ToolToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddImagesToTemplateToolStripMenuItem, Me.ToolStripSeparator1, Me.RemoveImagesFromTemplateToolStripMenuItem})
        Me.ToolToolStripMenuItem.Name = "ToolToolStripMenuItem"
        Me.ToolToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ToolToolStripMenuItem.Text = "Tools"
        '
        'AddImagesToTemplateToolStripMenuItem
        '
        Me.AddImagesToTemplateToolStripMenuItem.Name = "AddImagesToTemplateToolStripMenuItem"
        Me.AddImagesToTemplateToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.AddImagesToTemplateToolStripMenuItem.Size = New System.Drawing.Size(253, 22)
        Me.AddImagesToTemplateToolStripMenuItem.Text = "Add Images to Template"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(250, 6)
        '
        'RemoveImagesFromTemplateToolStripMenuItem
        '
        Me.RemoveImagesFromTemplateToolStripMenuItem.Name = "RemoveImagesFromTemplateToolStripMenuItem"
        Me.RemoveImagesFromTemplateToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.RemoveImagesFromTemplateToolStripMenuItem.Size = New System.Drawing.Size(253, 22)
        Me.RemoveImagesFromTemplateToolStripMenuItem.Text = "Remove Images from Template"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(108, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 80
        Me.Label6.Text = "Images Associated:"
        '
        'lblImageCount
        '
        Me.lblImageCount.AutoSize = True
        Me.lblImageCount.Location = New System.Drawing.Point(213, 142)
        Me.lblImageCount.Name = "lblImageCount"
        Me.lblImageCount.Size = New System.Drawing.Size(0, 13)
        Me.lblImageCount.TabIndex = 81
        '
        'btnViewImages
        '
        Me.btnViewImages.Location = New System.Drawing.Point(230, 137)
        Me.btnViewImages.Name = "btnViewImages"
        Me.btnViewImages.Size = New System.Drawing.Size(84, 23)
        Me.btnViewImages.TabIndex = 82
        Me.btnViewImages.Text = "View Images"
        Me.btnViewImages.UseVisualStyleBackColor = True
        '
        'ilCurrentImages
        '
        Me.ilCurrentImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ilCurrentImages.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilCurrentImages.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnCopyTemplate
        '
        Me.btnCopyTemplate.BackColor = System.Drawing.Color.Blue
        Me.btnCopyTemplate.ForeColor = System.Drawing.Color.White
        Me.btnCopyTemplate.Location = New System.Drawing.Point(636, 821)
        Me.btnCopyTemplate.Name = "btnCopyTemplate"
        Me.btnCopyTemplate.Size = New System.Drawing.Size(125, 23)
        Me.btnCopyTemplate.TabIndex = 83
        Me.btnCopyTemplate.Text = "Copy && Make As New"
        Me.btnCopyTemplate.UseVisualStyleBackColor = False
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(12, 179)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(28, 13)
        Me.lblID.TabIndex = 84
        Me.lblID.Text = "lblID"
        Me.lblID.Visible = False
        '
        'txtCylinderHead
        '
        Me.txtCylinderHead.ForeColor = System.Drawing.Color.Black
        Me.txtCylinderHead.Location = New System.Drawing.Point(154, 45)
        Me.txtCylinderHead.Name = "txtCylinderHead"
        Me.txtCylinderHead.ReadOnly = True
        Me.txtCylinderHead.Size = New System.Drawing.Size(143, 20)
        Me.txtCylinderHead.TabIndex = 85
        Me.txtCylinderHead.Visible = False
        '
        'txtLongBlock
        '
        Me.txtLongBlock.ForeColor = System.Drawing.Color.Black
        Me.txtLongBlock.Location = New System.Drawing.Point(154, 72)
        Me.txtLongBlock.Name = "txtLongBlock"
        Me.txtLongBlock.ReadOnly = True
        Me.txtLongBlock.Size = New System.Drawing.Size(143, 20)
        Me.txtLongBlock.TabIndex = 86
        Me.txtLongBlock.Visible = False
        '
        'txtPieceWork
        '
        Me.txtPieceWork.ForeColor = System.Drawing.Color.Black
        Me.txtPieceWork.Location = New System.Drawing.Point(154, 99)
        Me.txtPieceWork.Name = "txtPieceWork"
        Me.txtPieceWork.ReadOnly = True
        Me.txtPieceWork.Size = New System.Drawing.Size(143, 20)
        Me.txtPieceWork.TabIndex = 87
        Me.txtPieceWork.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(26, 179)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 13)
        Me.Label8.TabIndex = 88
        Me.Label8.Text = "Search Template Desc.:"
        '
        'txtSearchTemplateID
        '
        Me.txtSearchTemplateID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearchTemplateID.Location = New System.Drawing.Point(154, 176)
        Me.txtSearchTemplateID.Name = "txtSearchTemplateID"
        Me.txtSearchTemplateID.Size = New System.Drawing.Size(124, 20)
        Me.txtSearchTemplateID.TabIndex = 89
        '
        'btnSearchTemplateID
        '
        Me.btnSearchTemplateID.Location = New System.Drawing.Point(284, 174)
        Me.btnSearchTemplateID.Name = "btnSearchTemplateID"
        Me.btnSearchTemplateID.Size = New System.Drawing.Size(30, 23)
        Me.btnSearchTemplateID.TabIndex = 90
        Me.btnSearchTemplateID.Text = "Go"
        Me.btnSearchTemplateID.UseVisualStyleBackColor = True
        '
        'txtFreightCost
        '
        Me.txtFreightCost.Location = New System.Drawing.Point(447, 154)
        Me.txtFreightCost.Name = "txtFreightCost"
        Me.txtFreightCost.Size = New System.Drawing.Size(64, 20)
        Me.txtFreightCost.TabIndex = 80
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(375, 157)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 81
        Me.Label9.Text = "Freight Cost:"
        '
        'txtJobber
        '
        Me.txtJobber.Location = New System.Drawing.Point(622, 154)
        Me.txtJobber.Name = "txtJobber"
        Me.txtJobber.Size = New System.Drawing.Size(64, 20)
        Me.txtJobber.TabIndex = 82
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(550, 157)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 13)
        Me.Label12.TabIndex = 83
        Me.Label12.Text = "Jobber Cost:"
        '
        'frmSearchOrAddTemplate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1252, 857)
        Me.Controls.Add(Me.btnSearchTemplateID)
        Me.Controls.Add(Me.txtSearchTemplateID)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPieceWork)
        Me.Controls.Add(Me.txtLongBlock)
        Me.Controls.Add(Me.txtCylinderHead)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.btnCopyTemplate)
        Me.Controls.Add(Me.btnViewImages)
        Me.Controls.Add(Me.lblImageCount)
        Me.Controls.Add(Me.lblItemDesc)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboPieceWork)
        Me.Controls.Add(Me.lblPieceWork)
        Me.Controls.Add(Me.cboLongBlock)
        Me.Controls.Add(Me.lblTemplateType)
        Me.Controls.Add(Me.lblLongBlock)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblCylinderHead)
        Me.Controls.Add(Me.chkFreightOwn)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.lblTemplateID)
        Me.Controls.Add(Me.txtSave)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lblSave)
        Me.Controls.Add(Me.chkFreightReturn)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkFreightOutgoing)
        Me.Controls.Add(Me.cboCylinderHead)
        Me.Controls.Add(Me.lblLoad)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkFreightCorePur)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmSearchOrAddTemplate"
        Me.ShowIcon = False
        Me.Text = "Search for a template"
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents colCheckBox As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgv2 As System.Windows.Forms.DataGridView
    Friend WithEvents colCheckBox2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents lblLoad As System.Windows.Forms.Label
    Friend WithEvents cboCylinderHead As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents lblSave As System.Windows.Forms.Label
    Friend WithEvents txtSave As System.Windows.Forms.TextBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents lblTemplateID As System.Windows.Forms.Label
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtHead As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtBlock As System.Windows.Forms.TextBox
    Friend WithEvents txtCrank As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCubic As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtPO As System.Windows.Forms.TextBox
    Friend WithEvents cboYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboMake As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBlockCore As System.Windows.Forms.TextBox
    Friend WithEvents txtCrankCore As System.Windows.Forms.TextBox
    Friend WithEvents txtCamCore As System.Windows.Forms.TextBox
    Friend WithEvents txtRodCore As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cboCore As System.Windows.Forms.ComboBox
    Friend WithEvents chkFreightReturn As System.Windows.Forms.CheckBox
    Friend WithEvents chkFreightOutgoing As System.Windows.Forms.CheckBox
    Friend WithEvents chkFreightCorePur As System.Windows.Forms.CheckBox
    Friend WithEvents txtHeadCore As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents chkFreightOwn As System.Windows.Forms.CheckBox
    Friend WithEvents cboFreightCarriers As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents radPieceWork As System.Windows.Forms.RadioButton
    Friend WithEvents radLongBlock As System.Windows.Forms.RadioButton
    Friend WithEvents radCylinderHead As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTemplateType As System.Windows.Forms.Label
    Friend WithEvents lblPieceWork As System.Windows.Forms.Label
    Friend WithEvents lblCylinderHead As System.Windows.Forms.Label
    Friend WithEvents lblLongBlock As System.Windows.Forms.Label
    Friend WithEvents cboLongBlock As System.Windows.Forms.ComboBox
    Friend WithEvents cboPieceWork As System.Windows.Forms.ComboBox
    Friend WithEvents lblItemDesc As System.Windows.Forms.Label
    Friend WithEvents txtVinCode As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtModel As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rtxtNotes As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ToolToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddImagesToTemplateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnViewImages As System.Windows.Forms.Button
    Friend WithEvents lblImageCount As System.Windows.Forms.Label
    Friend WithEvents ilCurrentImages As System.Windows.Forms.ImageList
    Friend WithEvents btnCopyTemplate As System.Windows.Forms.Button
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents txtCylinderHead As System.Windows.Forms.TextBox
    Friend WithEvents txtLongBlock As System.Windows.Forms.TextBox
    Friend WithEvents txtPieceWork As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RemoveImagesFromTemplateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSearchTemplateID As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchTemplateID As System.Windows.Forms.Button
    Friend WithEvents txtJobber As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtFreightCost As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
