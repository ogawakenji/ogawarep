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


    Public Shared Function EraAlphabetName(dtVal As Date) As String

        Dim calendarJp = New System.Globalization.JapaneseCalendar()
        Dim cultureJp = New System.Globalization.CultureInfo("ja-JP", False)
        cultureJp.DateTimeFormat.Calendar = calendarJp

        Dim eraTable As New Dictionary(Of Integer, String)()

        For code = AscW("A"c) To AscW("Z"c)
            Dim e As String = ChrW(code)
            Dim eraIndex As Integer = cultureJp.DateTimeFormat.GetEra(e)
            If eraIndex > 0 Then
                eraTable.Add(eraIndex, e)
            End If
        Next

        ' https://msdn.microsoft.com/ja-jp/library/system.globalization.japanesecalendar.getera(v=vs.110).aspx
        ' http://www.kumamotokokufu-h.ed.jp/kumamoto/bungaku/wa_seireki.html
        Try
            Dim era As Integer = calendarJp.GetEra(dtVal)
            Return eraTable(era)

        Catch ex As ArgumentOutOfRangeException
            Return ""
        End Try

    End Function


End Class
