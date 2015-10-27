Public Class Form1
    Private _client As ServiceReference1.MyServiceClient


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim watch As Stopwatch = Stopwatch.StartNew()
        _client.Regist()
        watch.Stop()
        Me.TextBox1.Text = watch.Elapsed.ToString()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _client = New ServiceReference1.MyServiceClient()

    End Sub

    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        _client.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim watch As Stopwatch = Stopwatch.StartNew()
        _client.HeavyRegist()
        watch.Stop()
        Me.TextBox2.Text = watch.Elapsed.ToString()
    End Sub
End Class
