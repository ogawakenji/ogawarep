Public Class DateUtil

    ''' <summary>
    ''' 月初
    ''' </summary>
    ''' <param name="dtVal">日付</param>
    ''' <returns>月初を返却</returns>
    Public Shared Function MonthBeginning(dtVal As Date) As Date
        Return Date.Parse(String.Format("{0}/{1}/01", dtVal.Year, dtVal.Month))
    End Function

    ''' <summary>
    ''' 月末
    ''' </summary>
    ''' <param name="dtVal">日付</param>
    ''' <returns>月末</returns>
    Public Shared Function MonthEnd(dtVal As Date) As Date
        Return MonthBeginning(dtVal).AddMonths(1).AddDays(-1)
    End Function

End Class
