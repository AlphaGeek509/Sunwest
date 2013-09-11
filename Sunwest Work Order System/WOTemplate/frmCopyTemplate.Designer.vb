<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCopyTemplate
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
        Me.txtNewTemplateName = New System.Windows.Forms.TextBox
        Me.btnCopy = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblOldTemplateName = New System.Windows.Forms.Label
        Me.chkIncludePictures = New System.Windows.Forms.CheckBox
        Me.lblIncludeImages = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "New Template Name:"
        '
        'txtNewTemplateName
        '
        Me.txtNewTemplateName.Location = New System.Drawing.Point(144, 65)
        Me.txtNewTemplateName.Name = "txtNewTemplateName"
        Me.txtNewTemplateName.Size = New System.Drawing.Size(216, 20)
        Me.txtNewTemplateName.TabIndex = 1
        '
        'btnCopy
        '
        Me.btnCopy.Location = New System.Drawing.Point(285, 136)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(75, 23)
        Me.btnCopy.TabIndex = 2
        Me.btnCopy.Text = "Copy Template"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Original Template Name:"
        '
        'lblOldTemplateName
        '
        Me.lblOldTemplateName.AutoSize = True
        Me.lblOldTemplateName.Location = New System.Drawing.Point(141, 22)
        Me.lblOldTemplateName.Name = "lblOldTemplateName"
        Me.lblOldTemplateName.Size = New System.Drawing.Size(79, 13)
        Me.lblOldTemplateName.TabIndex = 4
        Me.lblOldTemplateName.Text = "Text to go here"
        '
        'chkIncludePictures
        '
        Me.chkIncludePictures.AutoSize = True
        Me.chkIncludePictures.Location = New System.Drawing.Point(316, 103)
        Me.chkIncludePictures.Name = "chkIncludePictures"
        Me.chkIncludePictures.Size = New System.Drawing.Size(44, 17)
        Me.chkIncludePictures.TabIndex = 5
        Me.chkIncludePictures.Text = "Yes"
        Me.chkIncludePictures.UseVisualStyleBackColor = True
        '
        'lblIncludeImages
        '
        Me.lblIncludeImages.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblIncludeImages.Location = New System.Drawing.Point(9, 101)
        Me.lblIncludeImages.Name = "lblIncludeImages"
        Me.lblIncludeImages.Size = New System.Drawing.Size(276, 18)
        Me.lblIncludeImages.TabIndex = 6
        Me.lblIncludeImages.Text = "Include Images?"
        Me.lblIncludeImages.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCopyTemplate
        '
        Me.AcceptButton = Me.btnCopy
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(364, 167)
        Me.Controls.Add(Me.lblIncludeImages)
        Me.Controls.Add(Me.chkIncludePictures)
        Me.Controls.Add(Me.lblOldTemplateName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.txtNewTemplateName)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmCopyTemplate"
        Me.Text = "Copy Template"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNewTemplateName As System.Windows.Forms.TextBox
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblOldTemplateName As System.Windows.Forms.Label
    Friend WithEvents chkIncludePictures As System.Windows.Forms.CheckBox
    Friend WithEvents lblIncludeImages As System.Windows.Forms.Label
End Class
