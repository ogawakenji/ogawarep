﻿'------------------------------------------------------------------------------
' <auto-generated>
'     このコードはツールによって生成されました。
'     ランタイム バージョン:4.0.30319.42000
'
'     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
'     コードが再生成されるときに損失したりします。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace MyServiceRef
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute([Namespace]:="http://Sample.WCF", ConfigurationName:="MyServiceRef.IMyService", CallbackContract:=GetType(MyServiceRef.IMyServiceCallback))>  _
    Public Interface IMyService
        
        <System.ServiceModel.OperationContractAttribute(IsOneWay:=true, Action:="http://Sample.WCF/IMyService/Regist")>  _
        Sub Regist(ByVal name As String)
        
        <System.ServiceModel.OperationContractAttribute(IsOneWay:=true, Action:="http://Sample.WCF/IMyService/Regist")>  _
        Function RegistAsync(ByVal name As String) As System.Threading.Tasks.Task
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface IMyServiceCallback
        
        <System.ServiceModel.OperationContractAttribute(IsOneWay:=true, Action:="http://Sample.WCF/IMyService/SendData")>  _
        Sub SendData(ByVal name As String)
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface IMyServiceChannel
        Inherits MyServiceRef.IMyService, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class MyServiceClient
        Inherits System.ServiceModel.DuplexClientBase(Of MyServiceRef.IMyService)
        Implements MyServiceRef.IMyService
        
        Public Sub New(ByVal callbackInstance As System.ServiceModel.InstanceContext)
            MyBase.New(callbackInstance)
        End Sub
        
        Public Sub New(ByVal callbackInstance As System.ServiceModel.InstanceContext, ByVal endpointConfigurationName As String)
            MyBase.New(callbackInstance, endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal callbackInstance As System.ServiceModel.InstanceContext, ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(callbackInstance, endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal callbackInstance As System.ServiceModel.InstanceContext, ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(callbackInstance, endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal callbackInstance As System.ServiceModel.InstanceContext, ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(callbackInstance, binding, remoteAddress)
        End Sub
        
        Public Sub Regist(ByVal name As String) Implements MyServiceRef.IMyService.Regist
            MyBase.Channel.Regist(name)
        End Sub
        
        Public Function RegistAsync(ByVal name As String) As System.Threading.Tasks.Task Implements MyServiceRef.IMyService.RegistAsync
            Return MyBase.Channel.RegistAsync(name)
        End Function
    End Class
End Namespace
