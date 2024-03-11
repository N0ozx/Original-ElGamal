Public Class Form3
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Application.OpenForms().OfType(Of Form2).Any Then
            Dim form2Instance As Form2 = DirectCast(Application.OpenForms("Form2"), Form2)
            MessageBox.Show(form2Instance.Prime.ToString())
        ElseIf Application.OpenForms().OfType(Of Form4).Any Then
            Dim form4Instance As Form4 = DirectCast(Application.OpenForms("Form4"), Form4)
            MessageBox.Show(form4Instance.Prime.ToString())
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Application.OpenForms().OfType(Of Form2).Any Then
            Dim form2Instance As Form2 = DirectCast(Application.OpenForms("Form2"), Form2)
            MessageBox.Show(form2Instance.Generator.ToString())
        ElseIf Application.OpenForms().OfType(Of Form4).Any Then
            Dim form4Instance As Form4 = DirectCast(Application.OpenForms("Form4"), Form4)
            MessageBox.Show(form4Instance.Generator.ToString())
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Application.OpenForms().OfType(Of Form2).Any Then
            Dim form2Instance As Form2 = DirectCast(Application.OpenForms("Form2"), Form2)
            MessageBox.Show(form2Instance.Private_key.ToString())
        ElseIf Application.OpenForms().OfType(Of Form4).Any Then
            Dim form4Instance As Form4 = DirectCast(Application.OpenForms("Form4"), Form4)
            MessageBox.Show(form4Instance.Private_key.ToString())

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Application.OpenForms().OfType(Of Form2).Any Then
            Dim form2Instance As Form2 = DirectCast(Application.OpenForms("Form2"), Form2)
            MessageBox.Show(form2Instance.Publickey.ToString())
        ElseIf Application.OpenForms().OfType(Of Form4).Any Then
            Dim form4Instance As Form4 = DirectCast(Application.OpenForms("Form4"), Form4)
            MessageBox.Show(form4Instance.Publickey.ToString())
        End If

    End Sub

End Class