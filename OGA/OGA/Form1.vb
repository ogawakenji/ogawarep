Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim dtList As New List(Of Date)
        dtList.Add(DateSerial(1867, 12, 31))
        dtList.Add(DateSerial(1868, 1, 1))
        dtList.Add(DateSerial(1868, 9, 7))
        dtList.Add(DateSerial(1868, 9, 8))
        dtList.Add(DateSerial(1912, 7, 29))
        dtList.Add(DateSerial(1912, 7, 30))
        dtList.Add(DateSerial(1926, 12, 24))
        dtList.Add(DateSerial(1926, 12, 25))
        dtList.Add(DateSerial(1989, 1, 7))
        dtList.Add(DateSerial(1989, 1, 8))
        dtList.Add(Now.Date)

        For Each list In dtList
            Debug.WriteLine(String.Format("{0} {1}", DateUtil.EraAlphabetName(list), list))
        Next



    End Sub
End Class