<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Encrypt = New Button()
        decrypt = New Button()
        Back = New Button()
        Stats = New Button()
        Generate_Keys = New Button()
        load_image = New Button()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        PictureBox3 = New PictureBox()
        ComboBox1 = New ComboBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Encrypt
        ' 
        Encrypt.BackColor = SystemColors.ButtonHighlight
        Encrypt.Location = New Point(79, 361)
        Encrypt.Name = "Encrypt"
        Encrypt.Size = New Size(82, 23)
        Encrypt.TabIndex = 0
        Encrypt.Text = "Encrypt"
        Encrypt.UseVisualStyleBackColor = False
        ' 
        ' decrypt
        ' 
        decrypt.BackColor = SystemColors.ButtonHighlight
        decrypt.Location = New Point(524, 325)
        decrypt.Name = "decrypt"
        decrypt.Size = New Size(82, 23)
        decrypt.TabIndex = 1
        decrypt.Text = "decrypt"
        decrypt.UseVisualStyleBackColor = False
        ' 
        ' Back
        ' 
        Back.BackColor = SystemColors.ButtonHighlight
        Back.Location = New Point(12, 11)
        Back.Name = "Back"
        Back.Size = New Size(70, 23)
        Back.TabIndex = 5
        Back.Text = "Back"
        Back.UseVisualStyleBackColor = False
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
        ' Generate_Keys
        ' 
        Generate_Keys.BackColor = SystemColors.ButtonHighlight
        Generate_Keys.Location = New Point(513, 12)
        Generate_Keys.Name = "Generate_Keys"
        Generate_Keys.Size = New Size(102, 23)
        Generate_Keys.TabIndex = 8
        Generate_Keys.Text = "Generate Keys"
        Generate_Keys.UseVisualStyleBackColor = False
        ' 
        ' load_image
        ' 
        load_image.BackColor = SystemColors.ButtonHighlight
        load_image.Location = New Point(79, 325)
        load_image.Name = "load_image"
        load_image.Size = New Size(82, 30)
        load_image.TabIndex = 9
        load_image.Text = "Load image"
        load_image.UseVisualStyleBackColor = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(40, 186)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(156, 133)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 10
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), Image)
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(271, 50)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(156, 133)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 11
        PictureBox2.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(482, 186)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(156, 133)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.TabIndex = 12
        PictureBox3.TabStop = False
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"257", "353", "443", "4231"})
        ComboBox1.Location = New Point(271, 11)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(156, 23)
        ComboBox1.TabIndex = 13
        ComboBox1.Text = "Select a prime number"
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        CausesValidation = False
        ClientSize = New Size(701, 403)
        Controls.Add(ComboBox1)
        Controls.Add(PictureBox3)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Controls.Add(load_image)
        Controls.Add(Generate_Keys)
        Controls.Add(Stats)
        Controls.Add(Back)
        Controls.Add(decrypt)
        Controls.Add(Encrypt)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form2"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Original ElGamal"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Encrypt As Button
    Friend WithEvents decrypt As Button
    Friend WithEvents Back As Button
    Friend WithEvents Stats As Button
    Friend WithEvents Generate_Keys As Button
    Friend WithEvents load_image As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents ComboBox1 As ComboBox
End Class
