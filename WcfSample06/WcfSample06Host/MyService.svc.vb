' メモ: コンテキスト メニューの [名前の変更] コマンドを使用すると、コード、svc、および config ファイルで同時にクラス名 "Service1" を変更できます。
' 注意: このサービスをテストするために WCF テスト クライアントを起動するには、ソリューション エクスプローラーで Service1.svc または Service1.svc.vb を選択し、デバッグを開始してください。
Public Class MyService
    Implements IMyService

    Public Sub HeavyRegist() Implements IMyService.HeavyRegist

        Console.Write("[CALL] HeavyRegist()...")
        Wait()
        Console.Write("Done.")

    End Sub

    Public Sub Regist() Implements IMyService.Regist

        Console.Write("[CALL] Regist()...")
        Wait()
        Console.Write("Done.")

    End Sub

    Private Sub Wait()
        Threading.Thread.Sleep(TimeSpan.FromSeconds(5))
    End Sub

End Class
