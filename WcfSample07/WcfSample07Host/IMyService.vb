Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.ServiceModel

<ServiceContract([Namespace]:="http://Sample.WCF", CallbackContract:=GetType(IMyCallback))>
Interface IMyService

    <OperationContract(IsOneWay:=True)>
    Sub Regist(name As String)


End Interface

