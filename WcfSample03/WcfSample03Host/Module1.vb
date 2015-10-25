Imports System.ServiceModel

Module Module1

    Sub Main()

        Using host As ServiceHost = New ServiceHost(GetType(WcfSample03Host.MyService))

            host.Open()

            Console.WriteLine("サービスを開始しました。")
            Console.WriteLine("Press any key to exit...")
            Console.ReadKey()

            host.Close()

        End Using

    End Sub

End Module
