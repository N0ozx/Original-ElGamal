Imports System.IO
Imports System.Media
Imports System.Numerics
Imports System.Security.Cryptography

Public Class Form4

    Private originalImage As Bitmap
    Private processedImage As Bitmap
    Private decryptedImage As Bitmap
    '//////////////////////////////////////////////
    Private e, p, g, privateKey As BigInteger
    Private Bp As New List(Of BigInteger)()
    Private Sub Load_image_Click(sender As Object, e As EventArgs) Handles Load_image.Click
        Dim openFileDialog As New OpenFileDialog With {
          .Filter = "Image|*.bmp;*.jpg;*.png;*.gif;*.tif|All files|*.*"
      }

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = openFileDialog.FileName
            originalImage = New Bitmap(filePath)
            PictureBox1.Image = originalImage
            SaveImage(originalImage)

        End If
    End Sub
    Private Sub Generate_Keys_Click(sender As Object, t As EventArgs) Handles Generate_Keys.Click
        Dim primeString As String = GeneratePrime()
        p = BigInteger.Parse(primeString)

        g = BigInteger.Parse("2")

        privateKey = GeneratePrivateKey(p)

        e = BigInteger.ModPow(g, privateKey, p)
        SystemSounds.Exclamation.Play()
    End Sub

    Private Async Sub Encrypt_Click(sender As Object, t As EventArgs) Handles Encrypt.Click
        If p = 0 Then
            MessageBox.Show("Please Generate Keys First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If originalImage IsNot Nothing Then
                Load_image.Enabled = False
                Generate_Keys.Enabled = False
                Encrypt.Enabled = False
                Decrypt.Enabled = False
                Back.Enabled = False
                Stats.Enabled = False
                Await Task.Run(Sub()

                                   processedImage = New Bitmap(originalImage.Width, originalImage.Height)
                                   processedImage.SetResolution(originalImage.HorizontalResolution, originalImage.VerticalResolution)

                                   Dim desiredLength As Integer = originalImage.Width * originalImage.Height * 3
                                   Dim Fsk As New List(Of Byte)()
                                   Do While Fsk.Count < desiredLength

                                       Dim randomInteger As BigInteger = GenerateRandomInteger(p)

                                       Dim c1 As BigInteger = BigInteger.ModPow(g, randomInteger, p)

                                       Bp.Add(c1)

                                       Dim secretkey As BigInteger = BigInteger.ModPow(e, randomInteger, p)

                                       ' Convert shared key to bytes and append each byte separately to Fsk
                                       Dim skBytes() As Byte = secretkey.ToByteArray()
                                       For Each byteValue As Byte In skBytes
                                           ' Stop adding bytes if Fsk has reached the desired length
                                           If Fsk.Count >= desiredLength Then
                                               Exit For
                                           End If
                                           Fsk.Add(byteValue)
                                       Next
                                       Dim progressPercentage As Integer = (Fsk.Count / desiredLength) * 100
                                       Invoke(Sub()
                                                  Label6.Text = $"Encrypting... {progressPercentage}%"
                                              End Sub)
                                       ' Stop processing if Fsk has reached the desired length

                                       If Fsk.Count >= desiredLength Then
                                           Exit Do
                                       End If
                                   Loop

                                   Dim byteIndex As Integer = 0
                                   For x As Integer = 0 To originalImage.Width - 1
                                       For y As Integer = 0 To originalImage.Height - 1

                                           Dim originalColor As Color = originalImage.GetPixel(x, y)

                                           ' XOR each color channel with the corresponding byte from the random array
                                           Dim processedColor As Color = Color.FromArgb(
                                               originalColor.R Xor Fsk(byteIndex),
                                               originalColor.G Xor Fsk(byteIndex + 1),
                                               originalColor.B Xor Fsk(byteIndex + 2)
                                                     )

                                           ' Set the processed pixel color in the new image
                                           processedImage.SetPixel(x, y, processedColor)

                                           ' Move to the next set of bytes
                                           byteIndex += 3
                                       Next
                                   Next
                                   Fsk.Clear()

                                   PictureBox2.Image = processedImage

                               End Sub)
                Load_image.Enabled = True
                Generate_Keys.Enabled = True
                Encrypt.Enabled = True
                Decrypt.Enabled = True
                Back.Enabled = True
                Stats.Enabled = True
                SystemSounds.Exclamation.Play()
                Label6.Text = "Encrypted"

                SaveImage(processedImage)


            Else
                MessageBox.Show("Please load an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Async Sub Decrypt_Click(sender As Object, e As EventArgs) Handles Decrypt.Click
        If processedImage IsNot Nothing Then
            Load_image.Enabled = False
            Generate_Keys.Enabled = False
            Encrypt.Enabled = False
            Decrypt.Enabled = False
            Back.Enabled = False
            Stats.Enabled = False
            Await Task.Run(Sub()

                               Dim desiredLength As Integer = processedImage.Width * processedImage.Height * 3

                               decryptedImage = New Bitmap(processedImage.Width, processedImage.Height)
                               decryptedImage.SetResolution(originalImage.HorizontalResolution, originalImage.VerticalResolution)
                               Dim byteIndex As Integer = 0

                               Dim Fsk As New List(Of Byte)()
                               For Each c1 As BigInteger In Bp
                                   Dim sk As BigInteger = BigInteger.ModPow(c1, privateKey, p)

                                   Dim skBytes() As Byte = sk.ToByteArray()
                                   For Each byteValue As Byte In skBytes
                                       ' Stop adding bytes if Fsk has reached the desired length
                                       If Fsk.Count >= desiredLength Then
                                           Exit For
                                       End If
                                       Fsk.Add(byteValue)
                                   Next
                                   Dim progressPercentage As Integer = (Fsk.Count / desiredLength) * 100
                                   Invoke(Sub()
                                              Label7.Text = $"Decrypting... {progressPercentage}%"
                                          End Sub)
                                   ' Stop processing if Fsk has reached the desired length
                                   If Fsk.Count >= desiredLength Then
                                       Exit For
                                   End If
                               Next

                               ' Decrypt each pixel using XOR with the decrypted bytes
                               For x As Integer = 0 To processedImage.Width - 1
                                   For y As Integer = 0 To processedImage.Height - 1

                                       Dim processedColor As Color = processedImage.GetPixel(x, y)



                                       ' XOR each color channel with the corresponding byte from the decrypted array
                                       Dim decryptedColor As Color = Color.FromArgb(
                            processedColor.R Xor Fsk(byteIndex),
                            processedColor.G Xor Fsk(byteIndex + 1),
                            processedColor.B Xor Fsk(byteIndex + 2)
                        )

                                       ' Set the decrypted pixel color in the new image
                                       decryptedImage.SetPixel(x, y, decryptedColor)

                                       ' Move to the next set of bytes
                                       byteIndex += 3
                                   Next
                               Next
                               Fsk.Clear()

                               PictureBox3.Image = decryptedImage

                           End Sub)
            SystemSounds.Exclamation.Play()
            Label7.Text = "Decrypted"

            SaveImage(decryptedImage)

        Else
            MessageBox.Show("Please process an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Load_image.Enabled = True
        Generate_Keys.Enabled = True
        Encrypt.Enabled = True
        Decrypt.Enabled = True
        Back.Enabled = True
        Stats.Enabled = True
    End Sub


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


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If originalImage IsNot Nothing Then
            ' Open a new form for inspecting the image
            Dim inspectForm As New Form With {
                .Text = "Image Inspection",
                .Width = originalImage.Width + 20,
                .Height = originalImage.Height + 40
            }

            Dim pictureBoxInspect As New PictureBox With {
                .SizeMode = PictureBoxSizeMode.Zoom,
                .Dock = DockStyle.Fill,
                .Image = originalImage
            }

            inspectForm.Controls.Add(pictureBoxInspect)
            inspectForm.ShowDialog()
        Else
            MessageBox.Show("Please load an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If processedImage IsNot Nothing Then
            ' Open a new form for inspecting the image
            Dim inspectForm As New Form With {
                .Text = "Image Inspection",
                .Width = processedImage.Width + 20,
                .Height = processedImage.Height + 40
            }

            Dim pictureBoxInspect As New PictureBox With {
                .SizeMode = PictureBoxSizeMode.Zoom,
                .Dock = DockStyle.Fill,
                .Image = processedImage
            }

            inspectForm.Controls.Add(pictureBoxInspect)
            inspectForm.ShowDialog()
        Else
            MessageBox.Show("Please load an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If decryptedImage IsNot Nothing Then
            ' Open a new form for inspecting the image
            Dim inspectForm As New Form With {
                .Text = "Image Inspection",
                .Width = decryptedImage.Width + 20,
                .Height = decryptedImage.Height + 40
            }

            Dim pictureBoxInspect As New PictureBox With {
                .SizeMode = PictureBoxSizeMode.Zoom,
                .Dock = DockStyle.Fill,
                .Image = decryptedImage
            }

            inspectForm.Controls.Add(pictureBoxInspect)
            inspectForm.ShowDialog()
        Else
            MessageBox.Show("Please load an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub SaveImage(imageToSave As Image)
        If imageToSave IsNot Nothing Then
            Dim saveFileDialog As New SaveFileDialog With {
            .Filter = "Bitmap Image|*.bmp|JPEG Image|*.jpg|PNG Image|*.png|TIF Image|*.tif",
            .Title = "Save Processed Image"
        }
            saveFileDialog.ShowDialog()

            If saveFileDialog.FileName <> "" Then
                Try
                    imageToSave.Save(saveFileDialog.FileName)
                    MessageBox.Show("Processed image saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show($"Error saving processed image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Please provide an image to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Shared Function CompareHistograms(originalImage As Bitmap, encryptedImage As Bitmap) As Double
        ' Convert images to grayscale
        Dim originalGray As Bitmap = ConvertToGrayscale(originalImage)
        Dim encryptedGray As Bitmap = ConvertToGrayscale(encryptedImage)

        ' Calculate histograms
        Dim originalHistogram As Integer() = CalculateHistogram(originalGray)
        Dim encryptedHistogram As Integer() = CalculateHistogram(encryptedGray)

        ' Compare histograms (you can use different metrics based on your requirements)
        Dim similarity As Double = CalculateHistogramSimilarity(originalHistogram, encryptedHistogram)

        Return similarity
    End Function

    Shared Function ConvertToGrayscale(image As Bitmap) As Bitmap
        Dim result As New Bitmap(image.Width, image.Height)

        For x As Integer = 0 To image.Width - 1
            For y As Integer = 0 To image.Height - 1
                Dim color As Color = image.GetPixel(x, y)
                Dim grayValue As Integer = CInt(0.299 * color.R + 0.587 * color.G + 0.114 * color.B)
                result.SetPixel(x, y, Color.FromArgb(grayValue, grayValue, grayValue))
            Next
        Next

        Return result
    End Function

    Shared Function CalculateHistogram(image As Bitmap) As Integer()
        Dim histogram(255) As Integer

        For x As Integer = 0 To image.Width - 1
            For y As Integer = 0 To image.Height - 1
                Dim grayValue As Integer = image.GetPixel(x, y).R
                histogram(grayValue) += 1
            Next
        Next

        Return histogram
    End Function

    Shared Function CalculateHistogramSimilarity(originalHistogram As Integer(), encryptedHistogram As Integer()) As Double
        ' You can use different similarity metrics here based on your requirements
        ' One simple option is to calculate the sum of squared differences between histogram bins
        Dim sumSquaredDifferences As Double = 0

        For i As Integer = 0 To originalHistogram.Length - 1
            sumSquaredDifferences += (originalHistogram(i) - encryptedHistogram(i)) ^ 2
        Next

        ' Normalize the similarity score
        Dim maxPossibleDifference As Double = (255 * 255) * originalHistogram.Length
        Dim similarity As Double = 1 - (sumSquaredDifferences / maxPossibleDifference)

        Return similarity
    End Function

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

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Dim form1Instance As New Form1()
        form1Instance.Show()
        Close()
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