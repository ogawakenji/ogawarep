Imports System.IO
Imports System.Text.RegularExpressions
Imports Sgml

Public Class HtmlUtil

    ''' <summary>
    ''' htmlの文字列をXDocumentにパースする
    ''' </summary>
    ''' <param name="html">html文字列</param>
    ''' <returns>XDocument</returns>
    Public Function ParseHtml(html As String) As XDocument
        Using sgml = New SgmlReader
            sgml.DocType = "HTML"
            sgml.WhitespaceHandling = Xml.WhitespaceHandling.All
            sgml.CaseFolding = CaseFolding.ToLower
            sgml.InputStream = New StringReader(html)
            sgml.IgnoreDtd = True
            Return XDocument.Load(sgml)
        End Using
    End Function

    ''' <summary>
    ''' xmlの文字列をXDocumentにパースする
    ''' </summary>
    ''' <param name="xml">xml文字列</param>
    ''' <returns>XDocument</returns>
    Public Function ParseXml(xml As String) As XDocument
        Using sgml = New SgmlReader
            sgml.DocType = "XML"
            sgml.WhitespaceHandling = System.Xml.WhitespaceHandling.All
            sgml.CaseFolding = CaseFolding.ToLower
            sgml.InputStream = New StringReader(xml)
            sgml.IgnoreDtd = True
            Return XDocument.Load(sgml)
        End Using
    End Function

    ''' <summary>
    ''' 文字コードを判別する
    ''' </summary>
    ''' <remarks>
    ''' Jcode.pmのgetcodeメソッドを移植したものです。
    ''' Jcode.pm(http://openlab.ring.gr.jp/Jcode/index-j.html)
    ''' Jcode.pmのCopyright: Copyright 1999-2005 Dan Kogai
    ''' </remarks>
    ''' <param name="bytes">文字コードを調べるデータ</param>
    ''' <returns>適当と思われるEncodingオブジェクト。
    ''' 判断できなかった時はnull。</returns>
    Private Function GetCode(ByVal bytes As Byte()) As System.Text.Encoding
        Const bEscape As Byte = &H1B
        Const bAt As Byte = &H40
        Const bDollar As Byte = &H24
        Const bAnd As Byte = &H26
        Const bOpen As Byte = &H28 ''('
        Const bB As Byte = &H42
        Const bD As Byte = &H44
        Const bJ As Byte = &H4A
        Const bI As Byte = &H49

        Dim len As Integer = bytes.Length
        Dim b1 As Byte, b2 As Byte, b3 As Byte, b4 As Byte

        'Encode::is_utf8 は無視
        Dim isBinary As Boolean = False
        Dim i As Integer
        For i = 0 To len - 1
            b1 = bytes(i)
            If b1 <= &H6 OrElse b1 = &H7F OrElse b1 = &HFF Then
                ''binary'
                isBinary = True
                If b1 = &H0 AndAlso i < len - 1 AndAlso bytes(i + 1) <= &H7F Then
                    'smells like raw unicode
                    Return System.Text.Encoding.Unicode
                End If
            End If
        Next
        If isBinary Then
            Return Nothing
        End If

        'not Japanese
        Dim notJapanese As Boolean = True
        For i = 0 To len - 1
            b1 = bytes(i)
            If b1 = bEscape OrElse &H80 <= b1 Then
                notJapanese = False
                Exit For
            End If
        Next
        If notJapanese Then
            Return System.Text.Encoding.ASCII
        End If

        For i = 0 To len - 3
            b1 = bytes(i)
            b2 = bytes(i + 1)
            b3 = bytes(i + 2)

            If b1 = bEscape Then
                If b2 = bDollar AndAlso b3 = bAt Then
                    'JIS_0208 1978
                    'JIS
                    Return System.Text.Encoding.GetEncoding(50220)
                ElseIf b2 = bDollar AndAlso b3 = bB Then
                    'JIS_0208 1983
                    'JIS
                    Return System.Text.Encoding.GetEncoding(50220)
                ElseIf b2 = bOpen AndAlso (b3 = bB OrElse b3 = bJ) Then
                    'JIS_ASC
                    'JIS
                    Return System.Text.Encoding.GetEncoding(50220)
                ElseIf b2 = bOpen AndAlso b3 = bI Then
                    'JIS_KANA
                    'JIS
                    Return System.Text.Encoding.GetEncoding(50220)
                End If
                If i < len - 3 Then
                    b4 = bytes(i + 3)
                    If b2 = bDollar AndAlso b3 = bOpen AndAlso b4 = bD Then
                        'JIS_0212
                        'JIS
                        Return System.Text.Encoding.GetEncoding(50220)
                    End If
                    If i < len - 5 AndAlso
                        b2 = bAnd AndAlso b3 = bAt AndAlso b4 = bEscape AndAlso
                        bytes(i + 4) = bDollar AndAlso bytes(i + 5) = bB Then
                        'JIS_0208 1990
                        'JIS
                        Return System.Text.Encoding.GetEncoding(50220)
                    End If
                End If
            End If
        Next

        'should be euc|sjis|utf8
        'use of (?:) by Hiroki Ohzaki <ohzaki@iod.ricoh.co.jp>
        Dim sjis As Integer = 0
        Dim euc As Integer = 0
        Dim utf8 As Integer = 0
        For i = 0 To len - 2
            b1 = bytes(i)
            b2 = bytes(i + 1)
            If ((&H81 <= b1 AndAlso b1 <= &H9F) OrElse
                (&HE0 <= b1 AndAlso b1 <= &HFC)) AndAlso
                ((&H40 <= b2 AndAlso b2 <= &H7E) OrElse
                 (&H80 <= b2 AndAlso b2 <= &HFC)) Then
                'SJIS_C
                sjis += 2
                i += 1
            End If
        Next
        For i = 0 To len - 2
            b1 = bytes(i)
            b2 = bytes(i + 1)
            If ((&HA1 <= b1 AndAlso b1 <= &HFE) AndAlso
                (&HA1 <= b2 AndAlso b2 <= &HFE)) OrElse
                (b1 = &H8E AndAlso (&HA1 <= b2 AndAlso b2 <= &HDF)) Then
                'EUC_C
                'EUC_KANA
                euc += 2
                i += 1
            ElseIf i < len - 2 Then
                b3 = bytes(i + 2)
                If b1 = &H8F AndAlso (&HA1 <= b2 AndAlso b2 <= &HFE) AndAlso
                    (&HA1 <= b3 AndAlso b3 <= &HFE) Then
                    'EUC_0212
                    euc += 3
                    i += 2
                End If
            End If
        Next
        For i = 0 To len - 2
            b1 = bytes(i)
            b2 = bytes(i + 1)
            If (&HC0 <= b1 AndAlso b1 <= &HDF) AndAlso
                (&H80 <= b2 AndAlso b2 <= &HBF) Then
                'UTF8
                utf8 += 2
                i += 1
            ElseIf i < len - 2 Then
                b3 = bytes(i + 2)
                If (&HE0 <= b1 AndAlso b1 <= &HEF) AndAlso
                    (&H80 <= b2 AndAlso b2 <= &HBF) AndAlso
                    (&H80 <= b3 AndAlso b3 <= &HBF) Then
                    'UTF8
                    utf8 += 3
                    i += 2
                End If
            End If
        Next
        'M. Takahashi's suggestion
        'utf8 += utf8 / 2;

        If euc > sjis AndAlso euc > utf8 Then
            'EUC
            Return System.Text.Encoding.GetEncoding(51932)
        ElseIf sjis > euc AndAlso sjis > utf8 Then
            'SJIS
            Return System.Text.Encoding.GetEncoding(932)
        ElseIf utf8 > euc AndAlso utf8 > sjis Then
            'UTF8
            Return System.Text.Encoding.UTF8
        End If

        Return Nothing
    End Function

    ''' <summary>
    ''' urlからHTML文字列を取得する
    ''' </summary>
    ''' <param name="url">url</param>
    ''' <returns>HTML文字列</returns>
    Public Function GetHtml(ByVal url As String) As String

        Try

            Dim client As New Net.WebClient()
            client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; Touch; rv:11.0) like Gecko")

            Dim srmBuff As IO.Stream = client.OpenRead(url)

            Dim bytBuff As Byte() = {}

            Using srmMemory As New IO.MemoryStream

                Dim bytRead As Byte() = {}
                Dim intRead As Integer = 0
                Array.Resize(bytRead, 1024)

                intRead = srmBuff.Read(bytRead, 0, bytRead.Length)

                Do While intRead > 0
                    srmMemory.Write(bytRead, 0, intRead)
                    intRead = srmBuff.Read(bytRead, 0, bytRead.Length)
                Loop

                bytBuff = srmMemory.ToArray()

            End Using

            srmBuff.Close()

            '文字コードを取得する
            Dim enc As System.Text.Encoding = GetCode(bytBuff)

            If enc Is Nothing Then

                enc = System.Text.Encoding.ASCII

            End If

            'デコードして表示する
            Dim html As String = enc.GetString(bytBuff)

            Return html

        Catch ex As Exception

            Throw ex

        End Try

    End Function

End Class
