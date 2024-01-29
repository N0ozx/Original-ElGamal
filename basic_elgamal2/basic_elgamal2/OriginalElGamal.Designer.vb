<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OriginalElGamal
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
        decrypt = New Button()
        plain_text = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Encrypt = New Button()
        cipher_text = New TextBox()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        decrypted_text = New TextBox()
        Label13 = New Label()
        SuspendLayout()
        ' 
        ' decrypt
        ' 
        decrypt.Location = New Point(612, 396)
        decrypt.Name = "decrypt"
        decrypt.Size = New Size(96, 23)
        decrypt.TabIndex = 1
        decrypt.Text = "decrypt"
        decrypt.UseVisualStyleBackColor = True
        ' 
        ' plain_text
        ' 
        plain_text.Location = New Point(143, 121)
        plain_text.Multiline = True
        plain_text.Name = "plain_text"
        plain_text.Size = New Size(193, 116)
        plain_text.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(168, 37)
        Label1.Name = "Label1"
        Label1.Size = New Size(108, 50)
        Label1.TabIndex = 6
        Label1.Text = "Alice"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.Location = New Point(628, 37)
        Label2.Name = "Label2"
        Label2.Size = New Size(92, 50)
        Label2.TabIndex = 7
        Label2.Text = "Bob"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(80, 124)
        Label3.Name = "Label3"
        Label3.Size = New Size(57, 15)
        Label3.TabIndex = 8
        Label3.Text = "Plain Text"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(766, 124)
        Label4.Name = "Label4"
        Label4.Size = New Size(103, 15)
        Label4.TabIndex = 9
        Label4.Text = "Prime Number (p)"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(766, 163)
        Label5.Name = "Label5"
        Label5.Size = New Size(100, 15)
        Label5.TabIndex = 10
        Label5.Text = "Primitive Root (g)"
        ' 
        ' Encrypt
        ' 
        Encrypt.Location = New Point(193, 396)
        Encrypt.Name = "Encrypt"
        Encrypt.Size = New Size(96, 23)
        Encrypt.TabIndex = 0
        Encrypt.Text = "Encrypt"
        Encrypt.UseVisualStyleBackColor = True
        ' 
        ' cipher_text
        ' 
        cipher_text.Location = New Point(143, 276)
        cipher_text.Multiline = True
        cipher_text.Name = "cipher_text"
        cipher_text.ReadOnly = True
        cipher_text.Size = New Size(193, 114)
        cipher_text.TabIndex = 4
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(71, 189)
        Label8.Name = "Label8"
        Label8.Size = New Size(0, 15)
        Label8.TabIndex = 15
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(71, 327)
        Label9.Name = "Label9"
        Label9.Size = New Size(66, 15)
        Label9.TabIndex = 16
        Label9.Text = "Cipher Text"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(766, 222)
        Label10.Name = "Label10"
        Label10.Size = New Size(65, 15)
        Label10.TabIndex = 18
        Label10.Text = "Private Key"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(766, 251)
        Label11.Name = "Label11"
        Label11.Size = New Size(62, 15)
        Label11.TabIndex = 19
        Label11.Text = "Public Key"
        ' 
        ' decrypted_text
        ' 
        decrypted_text.Location = New Point(559, 276)
        decrypted_text.Multiline = True
        decrypted_text.Name = "decrypted_text"
        decrypted_text.ReadOnly = True
        decrypted_text.Size = New Size(201, 114)
        decrypted_text.TabIndex = 22
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(766, 327)
        Label13.Name = "Label13"
        Label13.Size = New Size(85, 15)
        Label13.TabIndex = 23
        Label13.Text = "Decrypted Text"
        ' 
        ' form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Orange
        ClientSize = New Size(880, 458)
        Controls.Add(Label13)
        Controls.Add(decrypted_text)
        Controls.Add(Label11)
        Controls.Add(Label10)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(cipher_text)
        Controls.Add(plain_text)
        Controls.Add(decrypt)
        Controls.Add(Encrypt)
        Name = "form1"
        Text = "Basic_Elgamal"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents decrypt As Button
    Friend WithEvents plain_text As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Encrypt As Button
    Friend WithEvents cipher_text As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents decrypted_text As TextBox
    Friend WithEvents Label13 As Label
End Class
