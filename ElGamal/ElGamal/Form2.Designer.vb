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
        plain_text = New TextBox()
        cipher_text = New TextBox()
        decrypted_text = New TextBox()
        Back = New Button()
        Label1 = New Label()
        Stats = New Button()
        Generate_Keys = New Button()
        SuspendLayout()
        ' 
        ' Encrypt
        ' 
        Encrypt.BackColor = SystemColors.ButtonFace
        Encrypt.Location = New Point(85, 284)
        Encrypt.Name = "Encrypt"
        Encrypt.Size = New Size(75, 30)
        Encrypt.TabIndex = 0
        Encrypt.Text = "Encrypt"
        Encrypt.UseVisualStyleBackColor = False
        ' 
        ' decrypt
        ' 
        decrypt.BackColor = SystemColors.ButtonFace
        decrypt.Location = New Point(524, 284)
        decrypt.Name = "decrypt"
        decrypt.Size = New Size(75, 30)
        decrypt.TabIndex = 1
        decrypt.Text = "decrypt"
        decrypt.UseVisualStyleBackColor = False
        ' 
        ' plain_text
        ' 
        plain_text.BorderStyle = BorderStyle.FixedSingle
        plain_text.Cursor = Cursors.IBeam
        plain_text.Location = New Point(48, 184)
        plain_text.Multiline = True
        plain_text.Name = "plain_text"
        plain_text.Size = New Size(144, 94)
        plain_text.TabIndex = 2
        ' 
        ' cipher_text
        ' 
        cipher_text.BackColor = SystemColors.Window
        cipher_text.BorderStyle = BorderStyle.FixedSingle
        cipher_text.CausesValidation = False
        cipher_text.Cursor = Cursors.No
        cipher_text.Location = New Point(276, 96)
        cipher_text.Multiline = True
        cipher_text.Name = "cipher_text"
        cipher_text.ReadOnly = True
        cipher_text.ShortcutsEnabled = False
        cipher_text.Size = New Size(144, 94)
        cipher_text.TabIndex = 3
        ' 
        ' decrypted_text
        ' 
        decrypted_text.BackColor = SystemColors.Window
        decrypted_text.BorderStyle = BorderStyle.FixedSingle
        decrypted_text.Cursor = Cursors.No
        decrypted_text.Location = New Point(490, 184)
        decrypted_text.Multiline = True
        decrypted_text.Name = "decrypted_text"
        decrypted_text.ReadOnly = True
        decrypted_text.Size = New Size(144, 94)
        decrypted_text.TabIndex = 4
        ' 
        ' Back
        ' 
        Back.BackColor = SystemColors.ButtonFace
        Back.Location = New Point(12, 12)
        Back.Name = "Back"
        Back.Size = New Size(70, 23)
        Back.TabIndex = 5
        Back.Text = "Back"
        Back.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(276, 76)
        Label1.Name = "Label1"
        Label1.Size = New Size(67, 17)
        Label1.TabIndex = 6
        Label1.Text = "Ciphertext"
        ' 
        ' Stats
        ' 
        Stats.BackColor = SystemColors.ButtonFace
        Stats.Location = New Point(617, 368)
        Stats.Name = "Stats"
        Stats.Size = New Size(72, 23)
        Stats.TabIndex = 7
        Stats.Text = "Stats"
        Stats.UseVisualStyleBackColor = False
        ' 
        ' Generate_Keys
        ' 
        Generate_Keys.Location = New Point(515, 12)
        Generate_Keys.Name = "Generate_Keys"
        Generate_Keys.Size = New Size(102, 23)
        Generate_Keys.TabIndex = 8
        Generate_Keys.Text = "Generate Keys"
        Generate_Keys.UseVisualStyleBackColor = True
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
        Controls.Add(Generate_Keys)
        Controls.Add(Stats)
        Controls.Add(Label1)
        Controls.Add(plain_text)
        Controls.Add(Back)
        Controls.Add(decrypted_text)
        Controls.Add(cipher_text)
        Controls.Add(decrypt)
        Controls.Add(Encrypt)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form2"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Original ElGamal"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Encrypt As Button
    Friend WithEvents decrypt As Button
    Friend WithEvents plain_text As TextBox
    Friend WithEvents cipher_text As TextBox
    Friend WithEvents decrypted_text As TextBox
    Friend WithEvents Back As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Stats As Button
    Friend WithEvents Generate_Keys As Button
End Class
