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
        TextBox1 = New TextBox()
        SuspendLayout()
        ' 
        ' btnNext
        ' 
        btnNext.Location = New Point(247, 150)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(83, 31)
        btnNext.TabIndex = 8
        btnNext.Text = "Next"
        btnNext.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(12, 150)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(83, 31)
        btnCancel.TabIndex = 7
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' lblInstructionsB
        ' 
        lblInstructionsB.AutoSize = True
        lblInstructionsB.Location = New Point(12, 107)
        lblInstructionsB.Name = "lblInstructionsB"
        lblInstructionsB.Size = New Size(178, 20)
        lblInstructionsB.TabIndex = 6
        lblInstructionsB.Text = "Click on Next to continue."
        ' 
        ' lblInstructionsA
        ' 
        lblInstructionsA.AutoSize = True
        lblInstructionsA.Location = New Point(12, 25)
        lblInstructionsA.Name = "lblInstructionsA"
        lblInstructionsA.Size = New Size(277, 20)
        lblInstructionsA.TabIndex = 5
        lblInstructionsA.Text = "Please enter your twenty-digit (20) code."
        ' 
        ' lblInstructionsC
        ' 
        lblInstructionsC.AutoSize = True
        lblInstructionsC.Location = New Point(12, 127)
        lblInstructionsC.Name = "lblInstructionsC"
        lblInstructionsC.Size = New Size(318, 20)
        lblInstructionsC.TabIndex = 9
        lblInstructionsC.Text = "Otherwise, click on Cancel to quit the program."
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Consolas", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox1.Location = New Point(12, 48)
        TextBox1.MaxLength = 20
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(303, 34)
        TextBox1.TabIndex = 10
        TextBox1.Text = "11111111111111111111"
        ' 
        ' frmKey
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(338, 192)
        ControlBox = False
        Controls.Add(TextBox1)
        Controls.Add(lblInstructionsC)
        Controls.Add(btnNext)
        Controls.Add(btnCancel)
        Controls.Add(lblInstructionsB)
        Controls.Add(lblInstructionsA)
        FormBorderStyle = FormBorderStyle.Fixed3D
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmKey"
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
    Friend WithEvents TextBox1 As TextBox
End Class
