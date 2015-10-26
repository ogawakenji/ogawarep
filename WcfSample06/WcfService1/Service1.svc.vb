' メモ: コンテキスト メニューの [名前の変更] コマンドを使用すると、コード、svc、および config ファイルで同時にクラス名 "Service1" を変更できます。
' 注意: このサービスをテストするために WCF テスト クライアントを起動するには、ソリューション エクスプローラーで Service1.svc または Service1.svc.vb を選択し、デバッグを開始してください。
Public Class Service1
    Implements IService1

    Public Sub New()
    End Sub

    Public Function GetData(ByVal value As Integer) As String Implements IService1.GetData
        Return String.Format("You entered: {0}", value)
    End Function

    Public Function GetDataUsingDataContract(ByVal composite As CompositeType) As CompositeType Implements IService1.GetDataUsingDataContract
        If composite Is Nothing Then
            Throw New ArgumentNullException("composite")
        End If
        If composite.BoolValue Then
            composite.StringValue &= "Suffix"
        End If
        Return composite
    End Function

End Class
