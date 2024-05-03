<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        Label17 = New Label()
        Label12 = New Label()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(139, 17)
        Label1.TabIndex = 1
        Label1.Text = "Variable  |  Bit-length"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(103, 37)
        Label2.Name = "Label2"
        Label2.Size = New Size(14, 15)
        Label2.TabIndex = 5
        Label2.Text = "X"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(103, 66)
        Label3.Name = "Label3"
        Label3.Size = New Size(14, 15)
        Label3.TabIndex = 6
        Label3.Text = "X"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(103, 95)
        Label4.Name = "Label4"
        Label4.Size = New Size(14, 15)
        Label4.TabIndex = 7
        Label4.Text = "X"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(103, 123)
        Label5.Name = "Label5"
        Label5.Size = New Size(14, 15)
        Label5.TabIndex = 8
        Label5.Text = "X"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(12, 37)
        Label6.Name = "Label6"
        Label6.Size = New Size(51, 13)
        Label6.TabIndex = 9
        Label6.Text = "Prime (p)"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(12, 67)
        Label7.Name = "Label7"
        Label7.Size = New Size(78, 13)
        Label7.TabIndex = 10
        Label7.Text = "Generator (g) "
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(12, 97)
        Label8.Name = "Label8"
        Label8.Size = New Size(64, 13)
        Label8.TabIndex = 11
        Label8.Text = "Private Key "
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(12, 123)
        Label9.Name = "Label9"
        Label9.Size = New Size(58, 13)
        Label9.TabIndex = 12
        Label9.Text = "Public Key"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(283, 37)
        Label10.Name = "Label10"
        Label10.Size = New Size(14, 15)
        Label10.TabIndex = 13
        Label10.Text = "X"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(166, 37)
        Label11.Name = "Label11"
        Label11.Size = New Size(118, 15)
        Label11.TabIndex = 14
        Label11.Text = "Histogram Similarity:"
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Font = New Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label17.Location = New Point(146, -2)
        Label17.Name = "Label17"
        Label17.Size = New Size(23, 148)
        Label17.TabIndex = 20
        Label17.Text = "|" & vbCrLf & "|" & vbCrLf & "|" & vbCrLf & "|" & vbCrLf
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label12.Location = New Point(194, 9)
        Label12.Name = "Label12"
        Label12.Size = New Size(81, 17)
        Label12.TabIndex = 21
        Label12.Text = "Image Tests"
        ' 
        ' Form3
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(310, 155)
        Controls.Add(Label12)
        Controls.Add(Label17)
        Controls.Add(Label11)
        Controls.Add(Label10)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Location = New Point(1630, 500)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form3"
        StartPosition = FormStartPosition.Manual
        Text = "Info"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label12 As Label
End Class
