Imports Microsoft.VisualBasic

Public Class ResizeImage
    Public Shared Sub ResizeImage(ByVal img As System.Drawing.Image, ByVal newfilePath As String, ByVal NewWidth As Integer, ByVal MaxHeight As Integer, Optional ByVal OnlyResizeIfWider As Boolean = False)


        img.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone)
        img.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone)

        'resize image if 
        If OnlyResizeIfWider Then
            If img.Width <= NewWidth Then
                NewWidth = img.Width
            End If
        End If

        Dim NewHeight As Integer = img.Height * NewWidth / img.Width
        If NewHeight > MaxHeight Then

            'Resize with height instead
            NewWidth = img.Width * MaxHeight / img.Height
            NewHeight = MaxHeight

        End If

        Dim NewImage As System.Drawing.Image = img.GetThumbnailImage(NewWidth, NewHeight, Nothing, System.IntPtr.Zero)

        'Save resized picture
        NewImage.Save(newfilePath)

    End Sub
End Class
