Public Class NumUtil

#Region " 四捨五入、切り上げ、切り捨て"

    ''' <summary>
    ''' 四捨五入
    ''' </summary>
    ''' <param name="dVal">値</param>
    ''' <param name="iDigit">指定桁数</param>
    ''' <returns>指定桁数で四捨五入した値を返却する</returns>
    Public Shared Function Round(dVal As Decimal, iDigit As Integer) As Decimal
        Dim dCoef As Decimal = Convert.ToDecimal(System.Math.Pow(10, iDigit))

        If dVal > 0 Then
            Return Convert.ToDecimal(System.Math.Floor((dVal * dCoef) + 0.5) / dCoef)
        Else
            Return Convert.ToDecimal(System.Math.Floor((dVal * dCoef) - 0.5) / dCoef)
        End If

    End Function

    ''' <summary>
    ''' 切り捨て
    ''' </summary>
    ''' <param name="dVal">値</param>
    ''' <param name="iDigit">指定桁数</param>
    ''' <returns>指定桁数で切り捨てした値を返却する</returns>
    Public Shared Function RoundDown(dVal As Decimal, iDigit As Integer) As Decimal
        Dim dCoef As Decimal = Convert.ToDecimal((System.Math.Pow(10, iDigit)))

        If dVal > 0 Then
            Return Convert.ToDecimal(System.Math.Floor((dVal * dCoef)) / dCoef)
        Else
            Return Convert.ToDecimal(System.Math.Floor((dVal * dCoef)) / dCoef)
        End If
    End Function

    ''' <summary>
    ''' 切り上げ
    ''' </summary>
    ''' <param name="dVal">値</param>
    ''' <param name="iDigit">指定桁数</param>
    ''' <returns>指定桁数で切り上げした値を返却する</returns>
    Public Shared Function RoundUp(dVal As Decimal, iDigit As Integer) As Decimal
        Dim dCoef As Decimal = Convert.ToDecimal((System.Math.Pow(10, iDigit)))

        If dVal > 0 Then
            Return Convert.ToDecimal(System.Math.Ceiling((dVal * dCoef)) / dCoef)
        Else
            Return Convert.ToDecimal(System.Math.Ceiling((dVal * dCoef)) / dCoef)
        End If
    End Function

    ''' <summary>
    ''' 四捨五入
    ''' </summary>
    ''' <param name="dVal">値</param>
    ''' <returns>四捨五入</returns>
    Public Shared Function Round(dVal As Decimal) As Decimal
        Return Round(dVal, 0)
    End Function

    ''' <summary>
    ''' 切り捨て
    ''' </summary>
    ''' <param name="dVal">値</param>
    ''' <returns>切り捨て</returns>
    Public Shared Function RoundDown(dVal As Decimal) As Decimal
        Return RoundDown(dVal, 0)
    End Function

    ''' <summary>
    ''' 切り上げ
    ''' </summary>
    ''' <param name="dVal">値</param>
    ''' <returns>切り上げ</returns>
    Public Shared Function RoundUp(dVal As Decimal) As Decimal
        Return RoundUp(dVal, 0)
    End Function

#End Region

End Class
