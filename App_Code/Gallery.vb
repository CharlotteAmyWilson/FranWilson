Imports Microsoft.VisualBasic

Public Class Gallery

    Private _GalleryId As Integer
    Public Property GalleryId As Integer
        Get
            Return _GalleryId
        End Get
        Set(ByVal value As Integer)
            value = _GalleryId
        End Set
    End Property

    Private _GalleryName As String
    Public Property GalleryName As String
        Get
            Return _GalleryName
        End Get
        Set(ByVal value As String)
            value = _GalleryName
        End Set
    End Property

    Public MainGalleryImagePath As String

    Public Artwork As ICollection(Of Artwork)

    Public Function getGalleries() As List(Of Gallery)
        Dim oGallery As New Gallery
        Dim listofGalleries As New List(Of Gallery)

        Dim xmlFilePath As String = ConfigurationManager.AppSettings("xmlFilePath")
        Dim doc As New XDocument
        doc = XDocument.Load(xmlFilePath)
        For Each element As XElement In doc.Elements("Gallery")
            With oGallery
                .GalleryId = element.Attribute("Id")
                .GalleryName = element.Attribute("Name")
                .MainGalleryImagePath = element.Attribute("MainImagePath")
            End With
            listofGalleries.Add(oGallery)

        Next
        Return listofGalleries
    End Function



End Class
