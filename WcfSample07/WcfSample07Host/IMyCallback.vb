Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.ServiceModel


Public Interface IMyCallback


    <OperationContract(IsOneWay:=True)>
    Sub SendData(name As String)


End Interface
