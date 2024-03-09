<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKey
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
        btnNext = New Button()
        btnCancel = New Button()
        lblInstructionsB = New Label()
        lblInstructionsA = New Label()
        lblInstructionsC = New Label()
        txtKey = New TextBox()
        SuspendLayout()
        ' 
        ' btnNext
        ' 
        btnNext.Location = New Point(203, 117)
        btnNext.Margin = New Padding(3, 2, 3, 2)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(73, 23)
        btnNext.TabIndex = 8
        btnNext.Text = "Next"
        btnNext.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(10, 117)
        btnCancel.Margin = New Padding(3, 2, 3, 2)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(73, 23)
        btnCancel.TabIndex = 7
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' lblInstructionsB
        ' 
        lblInstructionsB.AutoSize = True
        lblInstructionsB.Location = New Point(10, 80)
        lblInstructionsB.Name = "lblInstructionsB"
        lblInstructionsB.Size = New Size(145, 15)
        lblInstructionsB.TabIndex = 6
        lblInstructionsB.Text = "Click on Next to continue."
        ' 
        ' lblInstructionsA
        ' 
        lblInstructionsA.AutoSize = True
        lblInstructionsA.Location = New Point(10, 19)
        lblInstructionsA.Name = "lblInstructionsA"
        lblInstructionsA.Size = New Size(220, 15)
        lblInstructionsA.TabIndex = 5
        lblInstructionsA.Text = "Please enter your twenty-digit (20) code."
        ' 
        ' lblInstructionsC
        ' 
        lblInstructionsC.AutoSize = True
        lblInstructionsC.Location = New Point(10, 95)
        lblInstructionsC.Name = "lblInstructionsC"
        lblInstructionsC.Size = New Size(256, 15)
        lblInstructionsC.TabIndex = 9
        lblInstructionsC.Text = "Otherwise, click on Cancel to quit the program."
        ' 
        ' txtKey
        ' 
        txtKey.Font = New Font("Consolas", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtKey.Location = New Point(10, 36)
        txtKey.Margin = New Padding(3, 2, 3, 2)
        txtKey.MaxLength = 20
        txtKey.Name = "txtKey"
        txtKey.Size = New Size(266, 29)
        txtKey.TabIndex = 10
        ' 
        ' FormKey
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(284, 151)
        ControlBox = False
        Controls.Add(txtKey)
        Controls.Add(lblInstructionsC)
        Controls.Add(btnNext)
        Controls.Add(btnCancel)
        Controls.Add(lblInstructionsB)
        Controls.Add(lblInstructionsA)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Margin = New Padding(3, 2, 3, 2)
        MaximizeBox = False
        MinimizeBox = False
        Name = "FormKey"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Key Entry"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnNext As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblInstructionsB As Label
    Friend WithEvents lblInstructionsA As Label
    Friend WithEvents lblInstructionsC As Label
    Friend WithEvents txtKey As TextBox
End Class
