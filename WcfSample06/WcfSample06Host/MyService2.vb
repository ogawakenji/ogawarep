Imports WcfSample06Host

Public Class MyService2
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
