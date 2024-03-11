<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        ElGamal = New Button()
        Exit1 = New Button()
        Button1 = New Button()
        SuspendLayout()
        ' 
        ' ElGamal
        ' 
        ElGamal.BackColor = Color.DimGray
        ElGamal.FlatStyle = FlatStyle.Flat
        ElGamal.Font = New Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ElGamal.ForeColor = SystemColors.Control
        ElGamal.Location = New Point(276, 125)
        ElGamal.Name = "ElGamal"
        ElGamal.Size = New Size(148, 37)
        ElGamal.TabIndex = 0
        ElGamal.Text = "Original ElGamal"
        ElGamal.UseVisualStyleBackColor = False
        ' 
        ' Exit1
        ' 
        Exit1.BackColor = Color.DimGray
        Exit1.FlatStyle = FlatStyle.Flat
        Exit1.Font = New Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Exit1.ForeColor = SystemColors.ControlLight
        Exit1.Location = New Point(318, 318)
        Exit1.Name = "Exit1"
        Exit1.Size = New Size(70, 31)
        Exit1.TabIndex = 1
        Exit1.Text = "Exit"
        Exit1.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.DimGray
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = SystemColors.ControlLight
        Button1.Location = New Point(276, 168)
        Button1.Name = "Button1"
        Button1.Size = New Size(148, 37)
        Button1.TabIndex = 2
        Button1.Text = "Enhansed ElGamal"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(701, 403)
        Controls.Add(Button1)
        Controls.Add(Exit1)
        Controls.Add(ElGamal)
        Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form1"
        RightToLeft = RightToLeft.No
        StartPosition = FormStartPosition.CenterScreen
        Text = "ElGamal Cryptosystem"
        ResumeLayout(False)
    End Sub

    Friend WithEvents ElGamal As Button
    Friend WithEvents Exit1 As Button
    Friend WithEvents Button1 As Button

End Class
