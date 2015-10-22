
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace WcfSample01Client
    Class MyService
        Implements IMyService
        Public Function SayHello(name As String) As String Implements IMyService.SayHello
            Console.WriteLine("[CALL] MyService.SayHello()")
            Return String.Format("Hello. '{0}'!", name)
        End Function
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
