Imports System.ComponentModel
Imports WcfSample07Client.MyServiceRef
Imports System.ServiceModel


Public Class Form1
    Implements MyServiceRef.IMyServiceCallback

    Private _client As MyServiceRef.MyServiceClient

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        _client.Close()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim context As InstanceContext = New InstanceContext(Me)
        _client = New MyServiceRef.MyServiceClient(context)

    End Sub
    Private Sub SendData(name As String) Implements IMyServiceCallback.SendData
        Me.TextBox1.Text = name
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        _client.Regist("WCF Study")
    End Sub
End Class
