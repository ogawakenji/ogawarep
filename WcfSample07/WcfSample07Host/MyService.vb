Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports WcfSample07Host
Imports System.ServiceModel

Public Class MyService
    Implements IMyService

    Public Sub Regist(name As String) Implements IMyService.Regist
        Console.Write("[CALL] Regist() => ")

        Dim context As OperationContext = OperationContext.Current
        Dim callback As IMyCallback = context.GetCallbackChannel(Of IMyCallback)()


        Threading.Thread.Sleep(TimeSpan.FromSeconds(5))

        Console.WriteLine("callback SendData();")
        callback.SendData(String.Format("{0}_Callback", name))

    End Sub


End Class
