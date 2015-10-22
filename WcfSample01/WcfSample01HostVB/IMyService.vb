
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.ServiceModel

Namespace WcfSample01Client
    <ServiceContract([Namespace]:="http://Sample.WCF")>
    Interface IMyService

        <OperationContract>
        Function SayHello(name As String) As String


    End Interface
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
