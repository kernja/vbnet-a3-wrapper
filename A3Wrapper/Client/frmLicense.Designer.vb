<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLicense
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
        rtbLicense = New RichTextBox()
        lblInstructionsA = New Label()
        lblInstructionsB = New Label()
        btnCancel = New Button()
        btnNext = New Button()
        SuspendLayout()
        ' 
        ' rtbLicense
        ' 
        rtbLicense.Location = New Point(12, 12)
        rtbLicense.Name = "rtbLicense"
        rtbLicense.ReadOnly = True
        rtbLicense.Size = New Size(776, 398)
        rtbLicense.TabIndex = 0
        rtbLicense.Text = ""
        ' 
        ' lblInstructionsA
        ' 
        lblInstructionsA.AutoSize = True
        lblInstructionsA.Location = New Point(16, 418)
        lblInstructionsA.Name = "lblInstructionsA"
        lblInstructionsA.Size = New Size(617, 20)
        lblInstructionsA.TabIndex = 1
        lblInstructionsA.Text = "If you agree to follow the terms of the License Agreement, click on Next to enter the CD key."
        ' 
        ' lblInstructionsB
        ' 
        lblInstructionsB.AutoSize = True
        lblInstructionsB.Location = New Point(16, 438)
        lblInstructionsB.Name = "lblInstructionsB"
        lblInstructionsB.Size = New Size(318, 20)
        lblInstructionsB.TabIndex = 2
        lblInstructionsB.Text = "Otherwise, click on Cancel to quit the program."
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(16, 464)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(83, 31)
        btnCancel.TabIndex = 3
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' btnNext
        ' 
        btnNext.Location = New Point(705, 464)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(83, 31)
        btnNext.TabIndex = 4
        btnNext.Text = "Next"
        btnNext.UseVisualStyleBackColor = True
        ' 
        ' frmLicense
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 507)
        Controls.Add(btnNext)
        Controls.Add(btnCancel)
        Controls.Add(lblInstructionsB)
        Controls.Add(lblInstructionsA)
        Controls.Add(rtbLicense)
        FormBorderStyle = FormBorderStyle.Fixed3D
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmLicense"
        StartPosition = FormStartPosition.CenterScreen
        Text = "License Agreement"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents rtbLicense As RichTextBox
    Friend WithEvents lblInstructionsA As Label
    Friend WithEvents lblInstructionsB As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnNext As Button
End Class
