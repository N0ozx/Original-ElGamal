Imports System.Numerics
Imports System.IO
Imports System.Security.Cryptography
Imports System.Media
Imports System.Security.Cryptography.Xml
Imports Windows.Win32.UI.Input
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form2
    Private originalImage As Bitmap
    Private processedImage As Bitmap
    Private decryptedImage As Bitmap
    '//////////////////////////////////////////////
    Private e, p, g, privateKey As BigInteger
    Private Bp As New List(Of BigInteger)()
    Private Sub GenerateKeys(sender As Object, t As EventArgs) Handles Generate_Keys.Click

        p = Convert.ToInt32(ComboBox1.SelectedItem)
        If p = 0 Then
            MessageBox.Show("Please select a prime number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            g = 2


            privateKey = 17

            e = BigInteger.ModPow(g, privateKey, p)
            SystemSounds.Exclamation.Play()
        End If
    End Sub

    Private Sub Load_image_Click(sender As Object, e As EventArgs) Handles load_image.Click
        Dim openFileDialog As New OpenFileDialog With {
          .Filter = "Image|*.bmp;*.jpg;*.png;*.gif;*.tif|All files|*.*"
      }

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = openFileDialog.FileName
            originalImage = New Bitmap(filePath)
            PictureBox1.Image = originalImage


        End If
    End Sub
    Private Sub Encrypt_(sender As Object, t As EventArgs) Handles Encrypt.Click
        If p = 0 Then
            MessageBox.Show("Please Generate Keys First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            processedImage = New Bitmap(originalImage.Width, originalImage.Height)
            processedImage.SetResolution(originalImage.HorizontalResolution, originalImage.VerticalResolution)

            ' Encrypt the image pixel by pixel
            For y As Integer = 0 To originalImage.Height - 1
                For x As Integer = 0 To originalImage.Width - 1
                    Dim pixel As Color = originalImage.GetPixel(x, y)

                    Dim randomInteger As BigInteger = GenerateRandomInteger(p)
                    Dim sk As BigInteger = BigInteger.ModPow(e, randomInteger, p)
                    Dim c1 = BigInteger.ModPow(g, randomInteger, p)
                    Bp.Add(c1)
                    ' Calculate c2 for each channel

                    Dim c2_R As BigInteger = ((sk * pixel.R) Mod p) Mod 255
                    Dim c2_G As BigInteger = ((sk * pixel.G) Mod p) Mod 255
                    Dim c2_B As BigInteger = ((sk * pixel.B) Mod p) Mod 255

                    ' Set the encrypted pixel using the combined values
                    processedImage.SetPixel(x, y, Color.FromArgb(c2_R, c2_G, c2_B))
                Next
            Next
            PictureBox2.Image = processedImage
        End If
    End Sub

    Private Sub Decrypt_(sender As Object, e As EventArgs) Handles decrypt.Click
        Dim inverse As New List(Of BigInteger)

        Dim decryptedAsciiValues As New List(Of BigInteger)
        For Each c1 In Bp
            Dim sk = BigInteger.ModPow(c1, privateKey, p)
            Dim inverse_val As BigInteger = ModInverse(sk, p)
            inverse.Add(inverse_val)
            Next
            Dim index As Integer = 0

        decryptedImage = New Bitmap(processedImage.Width, processedImage.Height)
        For y As Integer = 0 To processedImage.Height - 1
            For x As Integer = 0 To processedImage.Width - 1
                Dim encryptedPixel As Color = processedImage.GetPixel(x, y)


                Dim original_R As BigInteger = (encryptedPixel.R * inverse(index) Mod p) Mod 255
                Dim original_G As BigInteger = (encryptedPixel.G * inverse(index) Mod p) Mod 255
                Dim original_B As BigInteger = (encryptedPixel.B * inverse(index) Mod p) Mod 255

                index += 1


                decryptedImage.SetPixel(x, y, Color.FromArgb(original_R, original_G, original_B))
            Next
        Next
        PictureBox3.Image = decryptedImage

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
        Dim bitLength As Integer = 6

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

            form3Instance.Label10.Text = CompareHistograms(originalImage, decryptedImage)
            ' Show Form2
            form3Instance.Show()
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
        Dim Similarity2 As String = similarity.ToString("0.#####")
        Return Similarity2
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