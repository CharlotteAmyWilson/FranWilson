Imports Microsoft.VisualBasic
Imports System.Xml

Public Class Artwork
    Private _ArtWworkId As Integer
    Public Property ArtworkId As Integer
        Get
            Return _ArtWworkId
        End Get
        Set(ByVal value As Integer)
            _ArtWworkId = value
        End Set
    End Property

    Private _ArtworkName As String
    Public Property ArtworkName As String
        Get
            Return _ArtworkName
        End Get
        Set(ByVal value As String)
            _ArtworkName = value
        End Set
    End Property

    Private _ArtworkDescription As String
    Public Property ArtworkDescription As String
        Get
            Return _ArtworkDescription
        End Get
        Set(ByVal value As String)
            _ArtworkDescription = value
        End Set
    End Property


    'change to file name
    Private _ImagePath As String
    Public Property ImagePath As String
        Get
            Return _ImagePath
        End Get
        Set(ByVal value As String)
            _ImagePath = value
        End Set
    End Property


    Private _GalleryName As String
    Public Property GalleryName As String
        Get
            Return _GalleryName
        End Get
        Set(ByVal value As String)
            _GalleryName = value
        End Set
    End Property

    Private _IsMainArtWork As Boolean
    Public Property IsMainArtWork As Boolean
        Get
            Return _IsMainArtWork
        End Get
        Set(ByVal value As Boolean)
            _IsMainArtWork = value
        End Set
    End Property

    'Private Property _ArtWorkSortOrder As Integer
    'Public Property ArtWorkSortOrder As Integer
    '    Get
    '        Return _ArtWorkSortOrder
    '    End Get
    '    Set(ByVal value As Integer)
    '        _ArtWorkSortOrder = value
    '    End Set
    'End Property


    Public Function Validate() As String
        Dim errorMessages As New StringBuilder

        If Not CheckInputLength(ArtworkName) Then
            errorMessages.Append("Please select a Gallery from the drop down list")
        End If

        If Not CheckInputLength(ArtworkDescription) Then
            errorMessages.Append("Please select a Gallery from the drop down list")
        End If

        Return errorMessages.ToString
    End Function

    Public Sub Insert()
        'save the data into xml

        'If Len(Validate()) = 0 Then


        Dim xmlFilePath As String = ConfigurationManager.AppSettings("xmlFilePath")
        Dim doc As New XDocument
        doc = XDocument.Load(xmlFilePath)
        'If doc.Root IsNot Nothing Then
        doc.Root.Add(New XElement("Artwork", _
                                    New XAttribute("id", ArtworkId), _
                                    New XAttribute("name", ArtworkName), _
                                    New XAttribute("description", ArtworkDescription), _
                                    New XAttribute("imagepath", ImagePath), _
                                    New XAttribute("galleryname", GalleryName), _
                                    New XAttribute("ismainartwork", IsMainArtWork), _
                                    New XAttribute("sortorder", "")))
        doc.Save(xmlFilePath)

        'Else
        '    'send error here
        'End If
        'End If


    End Sub

    Public Sub Delete(ByVal Name As String, ByVal Description As String, ByVal smlImagePath As String, ByVal lrgImagePath As String)



    End Sub

    Public Function CheckInputLength(ByVal input As String) As Boolean
        If Len(input) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    'Private Function InsertToXMLFile() As Boolean

    'End Function
End Class
