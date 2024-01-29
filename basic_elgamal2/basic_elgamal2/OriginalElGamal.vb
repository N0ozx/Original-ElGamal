Imports System.Numerics
Imports System.Drawing
Imports System.IO
Imports System.Security.Cryptography

Public Class OriginalElGamal
    Dim e, p, g, privateKey As BigInteger
    Dim plainText As String
    Dim ciphertext As New List(Of BigInteger)
    Dim bp As New List(Of BigInteger)
    Private Sub Encrypt_Click(sender As Object, t As EventArgs) Handles Encrypt.Click
        Dim index As Integer = 0
        plainText = plain_text.Text

        'Convert the plaintext to ASCII values
        Dim asciiValues As New List(Of BigInteger)
        For Each c As Char In plainText
            asciiValues.Add(BigInteger.Parse(AscW(c).ToString()))
        Next


        Dim primeString As String = GeneratePrime()
        p = BigInteger.Parse(primeString)

        g = 2
        'primitive_root.Text = g.ToString()

        privateKey = GeneratePrivateKey(p)

        'Calculate the public key
        e = BigInteger.ModPow(g, privateKey, p)
        ' Dim publicKeyString As String = $"{p}{g}{e}"
        '  public_key.Text = publicKeyString.ToString()

        ' Encrypt the ASCII values


        Dim display_ciphertext As New List(Of BigInteger)
        Do While bp.Count < Len(plainText)
            If bp.Count = Len(plainText) Then
                Exit Do
            End If

            Dim randomInteger As BigInteger = GenerateRandomInteger(p)
            Dim c1 As BigInteger = BigInteger.ModPow(g, randomInteger, p)
            bp.Add(c1)

            Dim sk As BigInteger = BigInteger.ModPow(e, randomInteger, p)



            Dim c2 As BigInteger = (asciiValues(index) * sk) Mod p

            ciphertext.Add(c2)
            display_ciphertext.Add(c2 Mod 65536)

            index += 1

        Loop
        Dim encryptedString As String = ""
        For Each value As BigInteger In display_ciphertext
            encryptedString &= ChrW(BigInteger.Parse(value.ToString()))
        Next
        display_ciphertext.Clear()
        ' Display the encrypted string
        cipher_text.Text = encryptedString

    End Sub

    Private Sub Decrypt_Click(sender As Object, e As EventArgs) Handles decrypt.Click
        Dim Index As Integer = 0
        Dim decryptedAsciiValues As New List(Of BigInteger)
        For Each c1 As BigInteger In bp

            Dim sk As BigInteger = BigInteger.ModPow(c1, privateKey, p)

            Dim inversec1equa = ModInverse(sk, p)

            Dim asciiValue As BigInteger = (ciphertext(Index) * inversec1equa) Mod p

            decryptedAsciiValues.Add(asciiValue)

            Index += 1
        Next
        ' Calculate decrypted ASCII values



        ' Convert ASCII values to characters
        Dim decryptedString As String = ""
        For Each asciiValue As BigInteger In decryptedAsciiValues
            decryptedString &= ChrW(BigInteger.Parse(asciiValue.ToString()))
        Next

        ciphertext.Clear()
        bp.Clear()
        decrypted_text.Text = decryptedString
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


End Class