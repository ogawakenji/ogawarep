Imports System.Drawing

Public Class ImageUtil

    ''' <summary>
    ''' バイト配列をImageに変換
    ''' </summary>
    ''' <param name="b"></param>
    ''' <returns></returns>
    Public Shared Function ByteArrayToImage(b As Byte()) As Image
        Dim imgConv As New ImageConverter()
        Dim img As Image = CType(imgConv.ConvertFrom(b), Image)
        Return img
    End Function

    ''' <summary>
    ''' Imageをバイト配列に変換
    ''' </summary>
    ''' <param name="img"></param>
    ''' <returns></returns>
    Public Shared Function ImageToByteArray(img As Image) As Byte()
        Dim imgConv As New ImageConverter()
        Dim b As Byte() = CType(imgConv.ConvertTo(img, GetType(Byte())), Byte())
        Return b
    End Function


    ''' <summary>
    ''' 指定したファイルパス、幅・高さでアスペクト比を固定にしてImageに変換
    ''' </summary>
    ''' <param name="imageFilePath"></param>
    ''' <param name="finalWidth"></param>
    ''' <param name="finalHeight"></param>
    ''' <returns></returns>
    Public Shared Function FixedAspectRatioResizing(ByVal imageFilePath As String,
                                         ByVal finalWidth As Integer,
                                         ByVal finalHeight As Integer) As Image

        Dim originalImage As Image = Image.FromFile(imageFilePath)

        Return FixedAspectRatioResizing(originalImage, finalWidth, finalHeight)

    End Function

    ''' <summary>
    ''' 指定したImage、幅・高さでアスペクト比を固定にしてImageに変換
    ''' </summary>
    ''' <param name="originalImage"></param>
    ''' <param name="finalWidth"></param>
    ''' <param name="finalHeight"></param>
    ''' <returns></returns>
    Public Shared Function FixedAspectRatioResizing(ByVal originalImage As Image,
                                         ByVal finalWidth As Integer,
                                         ByVal finalHeight As Integer) As Image

        Dim xRatio As Single = CSng(finalWidth / originalImage.Width)
        Dim yRatio As Single = CSng(finalHeight / originalImage.Height)
        Dim minRatio As Single = Math.Min(xRatio, yRatio)
        Dim finalSize As Size = New Size(CInt(minRatio * originalImage.Width),
                                         CInt(minRatio * originalImage.Height))
        Dim resizeImage As New Bitmap(finalSize.Width, finalSize.Height)
        Dim g As Graphics = Graphics.FromImage(resizeImage)
        g.DrawImage(originalImage, 0, 0, finalSize.Width, finalSize.Height)
        g.Dispose()
        originalImage.Dispose()
        GC.Collect()
        Return resizeImage

    End Function

End Class
