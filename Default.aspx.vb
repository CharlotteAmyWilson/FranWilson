Imports System.Xml
Imports System.Xml.XPath
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub rptGalleries_ItemDataBound(Sender As Object, e As RepeaterItemEventArgs)

        'If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then

        '    Dim leftartworkRepeater As Repeater = e.Item.FindControl("rptleftartwork")
        '    Dim middleartworkRepeater As Repeater = e.Item.FindControl("rptmiddleartwork")
        '    Dim rightartworkRepeater As Repeater = e.Item.FindControl("rptrightartwork")

        '    'Dim xml As XmlDataSource = e.Item.DataItem("leftartwork")
        '    'Dim drv As DataRowView = DirectCast(e.Item.DataItem, DataRowView)



        '    ' DataRowView drv = (DataRowView)item.DataItem;
        '    'leftartworkRepeater.DataSource = drv.CreateChildView("leftartwork")

        '    leftartworkRepeater.DataSource = XPathBinder.Eval(e.Item.DataItem, "./leftartwork", "")
        '    middleartworkRepeater.DataSource = e.Item.DataItem("middleartwork")
        '    rightartworkRepeater.DataSource = e.Item.DataItem("rightartwork")

        '    leftartworkRepeater.DataBind()
        '    middleartworkRepeater.DataBind()
        '    rightartworkRepeater.DataBind()



        'End If

        'If (e.Item.ItemType = ListItemType.Item) Then

        '    Dim nav As XPathNavigator = CType(e.Item.DataItem, IXPathNavigable).CreateNavigator()
        '    Dim xePage As XmlElement = CType(nav.UnderlyingObject, XmlElement)

        '    Dim count As Integer = 1
        '    For Each node As XmlNode In xePage.GetElementsByTagName("artwork")
        '        CType(e.Item.FindControl("Image" & count), Image).ImageUrl = node.Attributes.ItemOf("ImagePath").Value
        '        count += 1
        '    Next

        'End If
    End Sub



End Class
