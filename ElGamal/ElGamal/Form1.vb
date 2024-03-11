Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ElGamal.Click
        Dim form2Instance As New Form2()

        ' Show Form2
        form2Instance.Show()
        Close()
    End Sub



    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim form4Instance As New Form4()

        ' Show Form2
        form4Instance.Show()
        Close()
    End Sub
    Private Sub Exit1_Click(sender As Object, e As EventArgs) Handles Exit1.Click
        Application.Exit()
    End Sub

End Class
