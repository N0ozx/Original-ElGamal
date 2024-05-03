<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Back = New Button()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        PictureBox3 = New PictureBox()
        Encrypt = New Button()
        Decrypt = New Button()
        Generate_Keys = New Button()
        Stats = New Button()
        Load_image = New Button()
        Label6 = New Label()
        Label7 = New Label()
        Label1 = New Label()
        ComboBox1 = New ComboBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Back
        ' 
        Back.BackColor = SystemColors.ButtonHighlight
        Back.Location = New Point(12, 11)
        Back.Name = "Back"
        Back.Size = New Size(70, 23)
        Back.TabIndex = 0
        Back.Text = "Back"
        Back.UseVisualStyleBackColor = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(40, 186)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(156, 133)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), Image)
        PictureBox2.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox2.Location = New Point(271, 50)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(156, 133)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 2
        PictureBox2.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackgroundImage = CType(resources.GetObject("PictureBox3.BackgroundImage"), Image)
        PictureBox3.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox3.Location = New Point(482, 186)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(156, 133)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.TabIndex = 3
        PictureBox3.TabStop = False
        ' 
        ' Encrypt
        ' 
        Encrypt.BackColor = SystemColors.ButtonHighlight
        Encrypt.Location = New Point(79, 361)
        Encrypt.Name = "Encrypt"
        Encrypt.Size = New Size(82, 23)
        Encrypt.TabIndex = 4
        Encrypt.Text = "Encrypt"
        Encrypt.UseVisualStyleBackColor = False
        ' 
        ' Decrypt
        ' 
        Decrypt.BackColor = SystemColors.ButtonHighlight
        Decrypt.Location = New Point(521, 325)
        Decrypt.Name = "Decrypt"
        Decrypt.Size = New Size(82, 23)
        Decrypt.TabIndex = 5
        Decrypt.Text = "Decrypt"
        Decrypt.UseVisualStyleBackColor = False
        ' 
        ' Generate_Keys
        ' 
        Generate_Keys.BackColor = SystemColors.ButtonHighlight
        Generate_Keys.Location = New Point(521, 12)
        Generate_Keys.Name = "Generate_Keys"
        Generate_Keys.Size = New Size(90, 23)
        Generate_Keys.TabIndex = 6
        Generate_Keys.Text = "Generate Keys"
        Generate_Keys.UseVisualStyleBackColor = False
        ' 
        ' Stats
        ' 
        Stats.BackColor = SystemColors.ButtonHighlight
        Stats.Location = New Point(614, 368)
        Stats.Name = "Stats"
        Stats.Size = New Size(75, 23)
        Stats.TabIndex = 7
        Stats.Text = "Info"
        Stats.UseVisualStyleBackColor = False
        ' 
        ' Load_image
        ' 
        Load_image.BackColor = SystemColors.ButtonHighlight
        Load_image.Location = New Point(79, 325)
        Load_image.Name = "Load_image"
        Load_image.Size = New Size(82, 30)
        Load_image.TabIndex = 8
        Load_image.Text = "Load Image"
        Load_image.UseVisualStyleBackColor = False
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.White
        Label6.Location = New Point(144, 78)
        Label6.Name = "Label6"
        Label6.Size = New Size(0, 15)
        Label6.TabIndex = 9
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.White
        Label7.Location = New Point(595, 78)
        Label7.Name = "Label7"
        Label7.Size = New Size(0, 15)
        Label7.TabIndex = 10
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(262, 368)
        Label1.Name = "Label1"
        Label1.Size = New Size(0, 15)
        Label1.TabIndex = 11
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"Secure Encryption(slow)", "Insecure Encryption(fast)"})
        ComboBox1.Location = New Point(271, 12)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(156, 23)
        ComboBox1.TabIndex = 12
        ComboBox1.Text = "Security level"
        ' 
        ' Form4
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(702, 403)
        Controls.Add(ComboBox1)
        Controls.Add(Label1)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Load_image)
        Controls.Add(Stats)
        Controls.Add(Generate_Keys)
        Controls.Add(Decrypt)
        Controls.Add(Encrypt)
        Controls.Add(PictureBox3)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Controls.Add(Back)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form4"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Improved ElGamal"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Back As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Encrypt As Button
    Friend WithEvents Decrypt As Button
    Friend WithEvents Generate_Keys As Button
    Friend WithEvents Stats As Button
    Friend WithEvents Load_image As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
End Class
