<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormViewer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        picView = New PictureBox()
        lblCaption = New Label()
        btnBack = New Button()
        btnNext = New Button()
        CType(picView, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' picView
        ' 
        picView.Location = New Point(-2, -3)
        picView.Margin = New Padding(3, 2, 3, 2)
        picView.Name = "picView"
        picView.Size = New Size(707, 340)
        picView.SizeMode = PictureBoxSizeMode.StretchImage
        picView.TabIndex = 0
        picView.TabStop = False
        ' 
        ' lblCaption
        ' 
        lblCaption.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCaption.ForeColor = Color.White
        lblCaption.Location = New Point(88, 339)
        lblCaption.Name = "lblCaption"
        lblCaption.Size = New Size(525, 31)
        lblCaption.TabIndex = 1
        lblCaption.Text = "Caption"
        lblCaption.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnBack
        ' 
        btnBack.Location = New Point(10, 341)
        btnBack.Margin = New Padding(3, 2, 3, 2)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(73, 23)
        btnBack.TabIndex = 2
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' btnNext
        ' 
        btnNext.Location = New Point(619, 341)
        btnNext.Margin = New Padding(3, 2, 3, 2)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(73, 23)
        btnNext.TabIndex = 3
        btnNext.Text = "Next"
        btnNext.UseVisualStyleBackColor = True
        ' 
        ' FormViewer
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        ClientSize = New Size(702, 370)
        Controls.Add(btnNext)
        Controls.Add(btnBack)
        Controls.Add(lblCaption)
        Controls.Add(picView)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Margin = New Padding(3, 2, 3, 2)
        MaximizeBox = False
        MinimizeBox = False
        Name = "FormViewer"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Client"
        CType(picView, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents picView As PictureBox
    Friend WithEvents lblCaption As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents btnNext As Button

End Class
