Imports System.Text
Imports System.Reflection.Assembly
Imports System.Resources
Imports System.Text.RegularExpressions

Public Class StringUtil

    Private Shared _SpRegex As RegularExpressions.Regex =
                  New RegularExpressions.Regex("^[^\uD800-\uDBFF\uDC00-\uDFFF]+$")

    ''' <summary>
    ''' バイト区切り(左)
    ''' </summary>
    ''' <param name="str"></param>
    ''' <param name="len"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ByteLeft(ByVal str As String, ByVal len As Integer) As String
        ' Shift-JISに変換し、バイト数で区切った文字を返却
        Dim byteSJIS As Byte() = System.Text.Encoding.GetEncoding("Shift-JIS").GetBytes(str)
        Return System.Text.Encoding.Default.GetString(byteSJIS, 0, len)
    End Function

    ''' <summary>
    ''' バイト区切り(右)
    ''' </summary>
    ''' <param name="str"></param>
    ''' <param name="len"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ByteRight(ByVal str As String, ByVal len As Integer) As String
        ' Shift-JISに変換し、バイト数で区切った文字を返却
        Dim byteSJIS As Byte() = System.Text.Encoding.GetEncoding("Shift-JIS").GetBytes(str)
        Return System.Text.Encoding.Default.GetString(byteSJIS, byteSJIS.Length - len, len)
    End Function

    ''' <summary>
    ''' バイト区切り(開始位置指定)
    ''' </summary>
    ''' <param name="str"></param>
    ''' <param name="start"></param>
    ''' <param name="len"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ByteMid(ByVal str As String, ByVal start As Integer, ByVal len As Integer) As String
        ' Shift-JISに変換し、開始位置から指定バイト数を区切った文字を返却
        Dim byteSJIS As Byte() = System.Text.Encoding.GetEncoding("Shift-JIS").GetBytes(str)
        Return System.Text.Encoding.Default.GetString(byteSJIS, start - 1, len)
    End Function

    ''' <summary>
    ''' シフトJIS判定
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsShiftJisCode(ByVal str As String) As Boolean
        ' 全ての文字がシフトJIS表現可能かつJIS2004追加文字コードではない

        ' 文字列なしはTrue
        If String.IsNullOrEmpty(str) Then
            Return True
        End If

        If _SpRegex.IsMatch(str) Then
            ' マッチする=サロゲートペアで使用しているコード範囲は存在しない

        Else
            ' マッチしない=サロゲートペアで使用しているコード範囲は存在する
            Return False

        End If

        Dim byteSJIS As Byte() = Nothing
        Dim chkChar() As Char = Nothing
        Dim byteCode As Integer = 0
        ' 1文字ずつチェックを実施
        For Each chrBuf As Char In str

            byteSJIS = System.Text.Encoding.GetEncoding("Shift-JIS").GetBytes(chrBuf)
            chkChar = System.Text.Encoding.GetEncoding("Shift-JIS").GetChars(byteSJIS)
            If chkChar(0) <> chrBuf Then
                ' Char→Byte()→Charに変換した場合に元に戻らない場合はShift-JIS未定義文字なのでFalse
                Return False
            End If

            byteCode = 0
            If byteSJIS.Length = 1 Then
                byteCode = byteSJIS(0) And &HFF
            ElseIf byteSJIS.Length = 2 Then
                byteCode = (((byteSJIS(0) And &HFF) << 8) Or (byteSJIS(1) And &HFF))
            End If

            ' JIS2004で追加された10文字の場合はFalseを返却
            ' &H879F 「倶」の厳密異体字
            ' &H889E 「剥」の厳密異体字
            ' &H9873 「叱」の慣例異体字
            ' &H989E 「呑」の厳密異体字
            ' &HEAA5 「嘘」の厳密異体字
            ' &HEFF8 「」の厳密異体字
            ' &HEFF9 「屏」の厳密異体字
            ' &HEFFA 「」の厳密異体字
            ' &HEFFB 「痩」の厳密異体字
            ' &HEFFC 「繋」の厳密異体字
            Select Case byteCode
                Case &H879F, &H889E, &H9873, &H989E, &HEAA5, &HEFF8, &HEFF9, &HEFFA, &HEFFB, &HEFFC

                    Return False

                Case Else

            End Select

        Next

        ' 全文字OKならTrueを返却
        Return True

    End Function

    ''' <summary>
    ''' 半角変換(数値)
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function NumToHankaku(ByVal str As String) As String
        Dim reg As Regex = New Regex("[０-９]+")
        Dim output As String = reg.Replace(str, AddressOf ReplacerNarrow)
        Return output
    End Function

    ''' <summary>
    ''' 半角変換(アルファベット)
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AlphaToHankaku(ByVal str As String) As String
        Dim reg As Regex = New Regex("[Ａ-Ｚ]+")
        Dim output As String = reg.Replace(str, AddressOf ReplacerNarrow)
        Return output
    End Function

    ''' <summary>
    ''' 半角変換(全て)
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AnyToHankaku(ByVal str As String) As String
        Return Strings.StrConv(str, VbStrConv.Narrow, 0)
    End Function

    Private Shared Function ReplacerNarrow(ByVal m As Match) As String
        Return Strings.StrConv(m.Value, VbStrConv.Narrow, 0)
    End Function

    ''' <summary>
    ''' 全角変換(数値)
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function NumToZenkaku(ByVal str As String) As String
        Dim reg As Regex = New Regex("[0-9]+")
        Dim output As String = reg.Replace(str, AddressOf ReplacerWide)
        Return output
    End Function

    Public Shared Function AlphaToZenkaku(ByVal str As String) As String
        Dim reg As Regex = New Regex("[A-Z]+")
        Dim output As String = reg.Replace(str, AddressOf ReplacerWide)
        Return output
    End Function

    Public Shared Function AnyToZenkaku(ByVal str As String) As String
        Return Strings.StrConv(str, VbStrConv.Wide, 0)
    End Function

    Private Shared Function ReplacerWide(ByVal m As Match) As String
        Return Strings.StrConv(m.Value, VbStrConv.Wide, 0)
    End Function

    Public Shared Function IsSurrogate(ByVal str As String) As Boolean
        ' サロゲートペアを考慮して文字を1文字ずつ処理する

        ' サロゲートペアを考慮して文字を1文字ずつ取得するにはTextElementEnumeratorに格納必要
        Dim charEnum As System.Globalization.TextElementEnumerator =
        System.Globalization.StringInfo.GetTextElementEnumerator(str)

        While (True)
            ' MoveNextメソッドを呼び出すとCurrentに1文字設定される
            If charEnum.MoveNext() = False Then
                Exit While
            End If

            If Char.IsSurrogate(charEnum.Current.ToString.Chars(0)) Then
                Return True
            End If

        End While

        Return False

    End Function

End Class
