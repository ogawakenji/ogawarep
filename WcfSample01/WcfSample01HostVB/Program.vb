
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports System.ServiceModel

' マルチスタートアッププロジェクトでホストとクライアントを同時に起動している
' よくわからない


Namespace WcfSample01Client
    NotInheritable Class Program
        Private Sub New()
        End Sub

        Private Const SERVICE_BASE_ADDRESS As String = "http://localhost:8081/WCFSample001"
        Private Const ENDPOINT_ADDRESS As String = "SayHello"


        ''' <summary>
        ''' アプリケーションのメイン エントリ ポイントです。
        ''' </summary>
        Public Shared Sub Main()

            Using host As ServiceHost = CreateServiceHost()

                Dim address As String = ENDPOINT_ADDRESS

                Dim binding As New BasicHttpBinding()

                Dim contract As Type = GetType(IMyService)

                host.AddServiceEndpoint(contract, binding, address)

                host.Open()
                Console.WriteLine("サービスを開始しました。")
                Console.WriteLine("Press any key to exit...")
                Console.ReadKey()


                host.Close()
            End Using






        End Sub

        Private Shared Function CreateServiceHost() As ServiceHost

            Dim serviceType As Type = GetType(MyService)
            Dim baseAddress As New Uri(SERVICE_BASE_ADDRESS)

            Return New ServiceHost(serviceType, baseAddress)

        End Function




    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
