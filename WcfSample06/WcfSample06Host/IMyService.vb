Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.ServiceModel

<ServiceContract([Namespace]:="http://Sample.WCF")>
Interface IMyService

    <OperationContract(IsOneWay:=True)>
    Sub Regist()

    <OperationContract>
    Sub HeavyRegist()


End Interface

