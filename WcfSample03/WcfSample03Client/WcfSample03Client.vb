Imports System.ServiceModel



Public Class WcfSample03Client
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim str As String = ""

        str = New ChannelFactory(Of IMyService)(New NetTcpBinding()).CreateChannel(New EndpointAddress("net.tcp://localhost:8082/WCFSample003/SayHello")).SayHello("WCF Study")


        Me.TextBox1.Text = str



    End Sub
End Class
