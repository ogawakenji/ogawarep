Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim result As String = ""
        Try

            Using client As New ServiceReference1.MyServiceClient
                client.Open()
                result = client.SayHello("WCF Study")
                client.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try


        TextBox1.Text = result


    End Sub
End Class
