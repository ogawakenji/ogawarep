Imports System.ServiceModel
Imports WcfSample01ClientVB.WcfSample01Client

Public Class Form2
    Private Const ENDPOINT_ADDRESS As String = "http://localhost:8081/WCFSample001/SayHello"


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblResult.Text = String.Empty
        ActiveControl = btnCallSerivceMethod
    End Sub

    Private Sub btnCallSerivceMethod_Click(sender As Object, e As EventArgs) Handles btnCallSerivceMethod.Click

        Dim endpointAddr As New EndpointAddress(ENDPOINT_ADDRESS)

        Dim result As String = [String].Empty
        Try
            '
            ' チャネルを構築しサービス呼び出しを行う.
            '
            Using channel As New ChannelFactory(Of IMyService)(New BasicHttpBinding())
                '
                ' サービスへのプロキシを取得.
                '
                Dim service As IMyService = channel.CreateChannel(endpointAddr)

                '
                ' サービスメソッドの呼び出し.
                '
                result = service.SayHello("WCF Study")

                '
                ' チャネルを閉じる.
                '
                channel.Close()
            End Using
        Catch ex As CommunicationException
            '
            ' エラーが発生.
            ' 
            ' WCFでは、サービスとクライアント間の通信中にエラーが発生した場合
            ' CommunicationExceptionがスローされる。
            '
            MessageBox.Show(ex.Message)
        End Try

        lblResult.Text = result

        '=======================================================
        'Service provided by Telerik (www.telerik.com)
        'Conversion powered by NRefactory.
        'Twitter: @telerik
        'Facebook: facebook.com/telerik
        '=======================================================

    End Sub
End Class