Imports System.ServiceModel

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim str As String = ""

        str = New ChannelFactory(Of IMyService)(New NetNamedPipeBinding()).CreateChannel(New EndpointAddress("net.pipe://localhost/WCFSample004/MyService")).SayHello("WCF Study")

        Me.TextBox1.Text = str

    End Sub
End Class
