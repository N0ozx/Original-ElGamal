Imports System.Numerics
Imports System.IO
Imports System.Security.Cryptography
Imports System.Media

Public Class Form2
    Dim e, p, g, privateKey As BigInteger
    Dim plainText As String
    Dim ciphertext As New List(Of BigInteger)
    Dim bp As New List(Of BigInteger)
    Private Sub GenerateKeys(sender As Object, t As EventArgs) Handles Generate_Keys.Click
        Dim primeString = GeneratePrime()
        p = BigInteger.Parse(primeString)

        g = 2
        'primitive_root.Text = g.ToString()

        privateKey = GeneratePrivateKey(p)

        'Calculate the public key
        e = BigInteger.ModPow(g, privateKey, p)
        SystemSounds.Exclamation.Play()
    End Sub
    Private Sub Encrypt_(sender As Object, t As EventArgs) Handles Encrypt.Click
        If p = 0 Then
            MessageBox.Show("Please Generate Keys First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            plainText = plain_text.Text
            If plainText = "" Then
                MessageBox.Show("type anything first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else
                'Convert the plaintext to ASCII values
                Dim asciiValues As New List(Of BigInteger)
                For Each c In plainText
                    asciiValues.Add(BigInteger.Parse(AscW(c).ToString))
                Next

                Dim display_ciphertext As New List(Of BigInteger)
                Dim index = 0
                Do While bp.Count < Len(plainText)
                    If bp.Count = Len(plainText) Then
                        Exit Do
                    End If

                    Dim randomInteger = GenerateRandomInteger(p)
                    Dim c1 = BigInteger.ModPow(g, randomInteger, p)
                    bp.Add(c1)

                    Dim sk = BigInteger.ModPow(e, randomInteger, p)

                    Dim c2 = asciiValues(index) * sk Mod p

                    ciphertext.Add(c2)
                    display_ciphertext.Add(c2 Mod 65536)

                    index += 1

                Loop
                Dim encryptedString = ""
                For Each value In display_ciphertext
                    encryptedString &= ChrW(BigInteger.Parse(value.ToString))
                Next
                display_ciphertext.Clear()
                ' Display the encrypted string
                cipher_text.Text = encryptedString
            End If
        End If
    End Sub

    Private Sub Decrypt_(sender As Object, e As EventArgs) Handles decrypt.Click

        If plainText = "" Then
            MessageBox.Show("Encrypt something first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Else
            Dim Index = 0
            Dim decryptedAsciiValues As New List(Of BigInteger)
            For Each c1 In bp

                Dim sk = BigInteger.ModPow(c1, privateKey, p)

                Dim inversec1equa = ModInverse(sk, p)

                Dim asciiValue = ciphertext(Index) * inversec1equa Mod p

                decryptedAsciiValues.Add(asciiValue)

                Index += 1
            Next

            Dim decryptedString = ""
            For Each asciiValue In decryptedAsciiValues
                decryptedString &= ChrW(BigInteger.Parse(asciiValue.ToString))
            Next

            ciphertext.Clear()
            bp.Clear()
            decrypted_text.Text = decryptedString
        End If
    End Sub
    Private Function ModInverse(a As BigInteger, m As BigInteger) As BigInteger
        Dim m0 = m
        Dim x0 As BigInteger = 0
        Dim x1 As BigInteger = 1

        While a > 1
            Dim q As BigInteger
            Dim t As BigInteger = 0

            q = BigInteger.DivRem(a, m, t)
            a = m
            m = t
            t = x0
            x0 = x1 - q * x0
            x1 = t
        End While

        If x1 < 0 Then
            x1 += m0
        End If

        Return x1
    End Function

    Private Function GenerateRandomInteger(prime As BigInteger) As BigInteger
        ' Specify the desired bit length (1000 bits)
        Dim bitLength As Integer = 1000

        ' Calculate the number of bytes needed based on the specified bit length
        Dim numBytes As Integer = (bitLength + 7) \ 8

        ' Create a Cryptographically Secure Pseudorandom Number Generator (CSPRNG)
        Using rng As RandomNumberGenerator = RandomNumberGenerator.Create()
            ' Generate a random byte array
            Dim randomBytes(numBytes - 1) As Byte

            ' Fill the byte array with random bytes
            rng.GetBytes(randomBytes)

            ' Ensure the generated BigInteger is within the specified bit length
            randomBytes(randomBytes.Length - 1) = randomBytes(randomBytes.Length - 1) And 127
            Dim randomInteger As New BigInteger(randomBytes)

            ' Ensure that 1 <= randomInteger < prime - 2
            While randomInteger <= 1 OrElse randomInteger >= prime - 2
                ' Generate a new random byte array
                rng.GetBytes(randomBytes)

                ' Ensure the generated BigInteger is within the specified bit length
                randomBytes(randomBytes.Length - 1) = randomBytes(randomBytes.Length - 1) And 127
                randomInteger = New BigInteger(randomBytes)
            End While


            Return randomInteger
        End Using
    End Function

    Private Function GeneratePrivateKey(prime As BigInteger) As BigInteger
        ' Specify the desired bit length (1024 bits)
        Dim bitLength As Integer = 1024

        ' Calculate the number of bytes needed based on the specified bit length
        Dim numBytes As Integer = (bitLength + 7) \ 8

        ' Create a Cryptographically Secure Pseudorandom Number Generator (CSPRNG)
        Using rng As RandomNumberGenerator = RandomNumberGenerator.Create()
            ' Generate a random byte array
            Dim randomBytes(numBytes - 1) As Byte

            ' Fill the byte array with random bytes
            rng.GetBytes(randomBytes)

            ' Ensure the generated BigInteger is within the specified bit length
            randomBytes(randomBytes.Length - 1) = randomBytes(randomBytes.Length - 1) And 127
            Dim privateKey As New BigInteger(randomBytes)

            ' Ensure that 1 <= randomInteger < prime - 2
            While privateKey <= 1 OrElse privateKey >= prime - 1
                ' Generate a new random byte array
                rng.GetBytes(randomBytes)

                ' Ensure the generated BigInteger is within the specified bit length
                randomBytes(randomBytes.Length - 1) = randomBytes(randomBytes.Length - 1) And 127
                privateKey = New BigInteger(randomBytes)
            End While


            Return privateKey
        End Using
    End Function
    Private Function GeneratePrime() As String
        Dim process As New Process()
        process.StartInfo.FileName = "cmd.exe"
        process.StartInfo.UseShellExecute = False
        process.StartInfo.RedirectStandardInput = True
        process.StartInfo.RedirectStandardOutput = True
        process.Start()

        Dim streamWriter As StreamWriter = process.StandardInput
        Dim streamReader As StreamReader = process.StandardOutput
        streamWriter.WriteLine("openssl prime -generate -bits 1024")
        streamWriter.WriteLine("exit")

        Dim result As String = streamReader.ReadToEnd()
        Dim lines As String() = result.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
        For Each line As String In lines
            If line.Length > 0 AndAlso Char.IsDigit(line(0)) Then
                Return line
            End If
        Next

        Return Nothing
    End Function

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Dim form1Instance As New Form1()
        form1Instance.Show()
        Close()
    End Sub

    Private Sub Stats_Click(sender As Object, t As EventArgs) Handles Stats.Click
        Dim form3Instance As New Form3()
        If p = 0 Then
            MessageBox.Show("Please Generate Keys First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            'Prime
            Dim bitLength1 As Integer = Math.Floor(BigInteger.Log(p, 2)) + 1
            Dim labelText2 As String = $"{bitLength1}"
            form3Instance.Label2.Text = labelText2

            'Generator
            Dim bitLength2 As Integer = Math.Floor(BigInteger.Log(g, 2)) + 1
            Dim labelText3 As String = $"{bitLength2}"
            form3Instance.Label3.Text = labelText3

            'Private key
            Dim bitLength3 As Integer = Math.Floor(BigInteger.Log(privateKey, 2)) + 1
            Dim labelText4 As String = $"{bitLength3}"
            form3Instance.Label4.Text = labelText4

            'Public key
            Dim bitLength4 As Integer = Math.Floor(BigInteger.Log(e, 2)) + 1
            Dim labelText5 As String = $"{bitLength4}"
            form3Instance.Label5.Text = labelText5

            ' Show Form2
            form3Instance.Show()
        End If
    End Sub


    Public ReadOnly Property Prime As BigInteger
        Get
            Return p ' Replace this with your actual variable
        End Get
    End Property

    Public ReadOnly Property Generator As BigInteger
        Get
            Return g ' Replace this with your actual variable
        End Get
    End Property

    Public ReadOnly Property Private_key As BigInteger
        Get
            Return privateKey ' Replace this with your actual variable
        End Get
    End Property
    Public ReadOnly Property Publickey As BigInteger
        Get
            Return e ' Replace this with your actual variable
        End Get
    End Property
End Class