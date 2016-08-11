
Partial Class Admin_ArtworkUploader
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ddlGalleries.DataSource = System.Enum.GetNames(GetType(Galleries))
            ddlGalleries.DataBind()
        End If
    End Sub

    Private _GalleryName As String = ""
    Public Property GalleryName() As String
        Get
            Return _GalleryName
        End Get
        Set(ByVal value As String)
            _GalleryName = value
        End Set
    End Property

    Private Enum Galleries
        Landscape = 1
        Abstract = 2
        Portrait = 3
        Figurative = 4
        Sculpture = 5
        Ceramic = 6
    End Enum


    Public Sub btnSave_OnClick(ByVal sender As Object, _
                          ByVal e As EventArgs)

        'get data from form into artwork object
        Dim oArtwork As New Artwork
        With oArtwork
            .ArtworkName = txtArtworkName.Text
            .ImagePath = ""
        End With

        'Dim errorMessages As String = ValidateData(oArtwork)

        'If Len(errorMessages) = 0 Then

        'resize image and save in correct folders




        Dim thumbImagePath As String = ConfigurationManager.AppSettings("thumbImagePath")
        Dim largeImagePath As String = ConfigurationManager.AppSettings("largeImagePath")
        Dim tempImagePath As String = ConfigurationManager.AppSettings("tempImagePath")

        Dim thumbFilePath As String = ""




        'get all form data
        If fileUploadArtwork.HasFile Then

            Dim imagesizes As Dictionary(Of Integer, KeyValuePair(Of Integer, Integer))
            'imagesizes.Add(1, New Pair(200, 300))



            Dim appPath As String = Request.PhysicalApplicationPath
            Dim filePath As String = appPath + tempImagePath + _
                Server.HtmlEncode(fileUploadArtwork.FileName)

            'fileUploadArtwork.SaveAs(tempImagePath)
            fileUploadArtwork.PostedFile.SaveAs(filePath)

            thumbFilePath = appPath + thumbImagePath + _
                Server.HtmlEncode(fileUploadArtwork.FileName)

            Dim img As System.Drawing.Image = System.Drawing.Image.FromFile(filePath)

            'create and save thumb image
            'ResizeImage.ResizeImage(img, thumbFilePath, thumbWidth, thumbHeight)

        Else

            lblError.Text = "Please upload an image"
            lblError.Visible = True

        End If

        'Dim galleries As Galleries = System.Enum.Parse(GetType(Galleries), ddlGalleries.SelectedValue)

        GalleryName = ddlGalleries.SelectedValue

        oArtwork.GalleryName = GalleryName
        'oArtwork.smallImagePath = thumbFilePath
        'oArtwork.largeImagePath = largeImagePath & fileUploadArtwork.FileName

        oArtwork.Insert()
        'Else
        'lblError.Text = errorMessages
        'End If



    End Sub

    Public Sub btnDelete_OnClick(ByVal sender As Object, _
                      ByVal e As EventArgs)

        'get all form data
        'validate
        'delete

    End Sub


    Private Function ValidateData(ByVal oArtwork As Artwork) As String
        Dim errorMessages As New StringBuilder

        'If Not checkInputLength(Gallery) Then
        '    errorMessages.Append("Please select a Gallery from the drop down list")
        'End If

        If txtArtworkName.Text.Length > 0 Then
            oArtwork.ArtworkName = txtArtworkName.Text
        End If

        If txtArtworkDescription.Text.Length > 0 Then
            oArtwork.ArtworkDescription = txtArtworkDescription.Text
        End If

        If fileUploadArtwork.HasFile Then
            'upload file to flicker, then get path back
            Dim filePath As String = ""
            oArtwork.ImagePath = filePath
        End If
        Return errorMessages.ToString
    End Function

    Private Function checkInputLength(ByVal text As String) As Boolean
       Return text.Length > 0 
    End Function

    Protected Sub ddlGalleries_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        GalleryName = ddlGalleries.SelectedValue
    End Sub


End Class
