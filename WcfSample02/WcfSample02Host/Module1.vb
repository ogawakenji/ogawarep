'' http://devlights.hatenablog.com/entry/20111020/p2
'' WCF入門002 アプリケーション構成ファイルに記述したサンプル

Imports System.ServiceModel

Module Module1

    Sub Main()
        Using host As ServiceHost = New ServiceHost(GetType(WcfSample02Host.MyService))

            host.Open()

            Console.WriteLine("サービスを開始しました。")
            Console.WriteLine("Press any key to exit...")
            Console.ReadKey()

            host.Close()
        End Using
    End Sub
End Module
