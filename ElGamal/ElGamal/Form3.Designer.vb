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
        Button1 = New Button()
        Label1 = New Label()
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(3, 49)
        Button1.Name = "Button1"
        Button1.Size = New Size(112, 25)
        Button1.TabIndex = 0
        Button1.Text = "Prime Number (p)"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(202, 25)
        Label1.TabIndex = 1
        Label1.Text = "Variable      Bit-length"
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(3, 88)
        Button2.Name = "Button2"
        Button2.Size = New Size(112, 25)
        Button2.TabIndex = 2
        Button2.Text = "Primitive Root (g) "
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(3, 126)
        Button3.Name = "Button3"
        Button3.Size = New Size(112, 23)
        Button3.TabIndex = 3
        Button3.Text = "Private Key "
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(3, 155)
        Button4.Name = "Button4"
        Button4.Size = New Size(112, 23)
        Button4.TabIndex = 4
        Button4.Text = "Public Key"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(157, 54)
        Label2.Name = "Label2"
        Label2.Size = New Size(14, 15)
        Label2.TabIndex = 5
        Label2.Text = "X"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(157, 93)
        Label3.Name = "Label3"
        Label3.Size = New Size(14, 15)
        Label3.TabIndex = 6
        Label3.Text = "X"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(157, 130)
        Label4.Name = "Label4"
        Label4.Size = New Size(14, 15)
        Label4.TabIndex = 7
        Label4.Text = "X"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(157, 159)
        Label5.Name = "Label5"
        Label5.Size = New Size(14, 15)
        Label5.TabIndex = 8
        Label5.Text = "X"
        ' 
        ' Form3
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(231, 194)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Label1)
        Controls.Add(Button1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Location = New Point(1630, 500)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form3"
        StartPosition = FormStartPosition.Manual
        Text = "Stats"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
