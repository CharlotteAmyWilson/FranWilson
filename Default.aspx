<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fine Artist, Buckinghamshire UK</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />    
    <script src="jquery.js" type="text/javascript"></script>    
    <script src="general.js" type="text/javascript"></script>
    <script src="http://code.jquery.com/jquery-latest.js" type="text/javascript"></script>
    <link href="jquery.lightbox-0.5.css" rel="stylesheet" type="text/css" />
    <script src="jquery.lightbox-0.5.js" type="text/javascript"></script>
    <script src="jquery.lightbox-0.5.min.js" type="text/javascript"></script>
    <script src="jquery.lightbox-0.5.pack.js" type="text/javascript"></script>
    <meta name="Keywords" content="Fine Artists UK, Artists Buckinghamshire, Fine Art, Abstract Paintings, landscape Paintings, Sculpture, Frances Wilson, Painters Buckinghamshire, buckingham fine art"/>
    <meta name="description" content="Fine Artist UK"/>
    <script>
            (function (i, s, o, g, r, a, m) {
                i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                    (i[r].q = i[r].q || []).push(arguments)
                }, i[r].l = 1 * new Date(); a = s.createElement(o),
      m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
            })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

            ga('create', 'UA-43296106-1', 'franwilson.co.uk');
            ga('send', 'pageview');

    </script>
</head>
<body>
    <div class="banner">
        <div>
            <p id="header">
                Fran Wilson</p>
            <p id="subheader">
                Fine Artist</p>
        </div>
    </div>
    <div id="navigation" style="display: none;">
        <ul class="jumpto">
         <asp:XmlDataSource ID="xmldatasource2" runat="server" DataFile="~/XMLFile.xml" XPath="galleries/gallery[@Id<7]"></asp:XmlDataSource>
            <asp:Repeater DataSourceID="xmldatasource2" runat="server">
                <ItemTemplate>
                    <li id="<%# XPath("@Id")%><%# XPath("@Name")%>">
                        <h4>
                            <a href="" class="jumptolink">                       
                                <%# XPath("@Name")%></a></h4>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <div class="content">
        <div class="gallery">
            <asp:XmlDataSource ID="xmldatasource1" runat="server" DataFile="~/XMLFile.xml" XPath="galleries/gallery[@Id<6]">
            </asp:XmlDataSource>
            <asp:Repeater DataSourceID="xmldatasource1" runat="server">
                <ItemTemplate>
                    <div class="window" style="background-image: url('<%#XPath("@MainImagePath") %>');">
                        <a href="" class="gallerylink">
                            <input type="hidden" value="<%# XPath("@Name")%>" />
                            <div class="overlay">
                                <h2>
                                    <%# XPath("@Name")%>
                                </h2>
                                <center><h5><%# XPath("@Description")%></h5></center>
                            </div>
                        </a>
                    </div>
                    <div class="window" style="background-image: url('<%#XPath("@SubImagePath") %>');">
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div id="about">
        <h3>Frances Wilson, Fine Artist</h3>
        <p>Frances Wilson, is a Buckinghamshire based Fine Artist, currently working as a part time Fine Art lecturer. 
            
            <br />
            <br />
            In addition to her BA Honours’ degree in Fine Art, she is also professional and practised painter, sculptor and potter. 
            <br />
            <br />
            Her creative development has been influenced by world class international artists and her inspirations drawn from everyday life experiences, with emotion coming from every stroke of the brush to the canvas. Every piece of work tells a story which the viewer can take and relate too.<br />
            <br />
        </p>
        <br />
        <h3>
            Contact:</h3>
        <p>
            <a href="mailto:franwilsonfineart@gmail.com">franwilsonfineart@gmail.com</a> | Tel: 07719 584
            841</p>
        <p>More work available to view on 
            <a href="http://www.saatchionline.com/franella" target="_blank">www.saatchionline.com/franella</a></p>
        <p>Follow Frances on <a href="https://www.facebook.com/franella" target="_blank" class="facebook"></a></p>
        <img class="shadow" src="franwilsonbw300.jpg" alt="Fran Wilson - Fine Artist, Buckinghamshire" />
    </div>

    <asp:XmlDataSource ID="xmlGalleries" runat="server" DataFile="~/XMLFile.xml" XPath="galleries/gallery">
    </asp:XmlDataSource>
    <asp:Repeater ID="rptGalleries" OnItemDataBound="rptGalleries_ItemDataBound" DataSourceID="xmlGalleries"
        runat="server">
        <ItemTemplate>
            <div class="main" id="<%# XPath("@Name")%>">
                <center><h1><%# XPath("@Name")%></h1></center>
            </div>
            <div class="gallerycontent" id="<%# XPath("@Id")%>">
                <div>
                    <asp:Repeater ID="rptleftartwork" runat="server" DataSource='<%# XPathSelect ("artworks/leftartwork") %>'>

                        <ItemTemplate>
                            <a href="Images/<%# XPath("@GalleryName")%>/lrg/<%# XPath("@ImagePath")%>" class="<%# XPath("@Lightbox")%>"><image src="Images/<%# XPath("@GalleryName")%>/sml/<%# XPath("@ImagePath")%>" class="galleryimg" alt="<%# XPath("@GalleryName")%> - <%# XPath("@Name")%>"></image></a>
                            <center><h3><%# XPath("@Name")%></h3></center>
                            <center><h4>Medium - <%# XPath("@Medium")%></h4></center>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div id="middleGalleryDiv">
                    <asp:Repeater ID="rptmiddleartwork" runat="server" DataSource='<%# XPathSelect("artworks/middleartwork") %>'>
                        <ItemTemplate>
                            <a href="Images/<%# XPath("@GalleryName")%>/lrg/<%# XPath("@ImagePath")%>" class="<%# XPath("@Lightbox")%>"><image src="Images/<%# XPath("@GalleryName")%>/sml/<%# XPath("@ImagePath")%>" class="galleryimg" alt="<%# XPath("@GalleryName")%> - <%# XPath("@Name")%>"></image></a>
                            <center><h3><%# XPath("@Name")%></h3></center>
                            <center><h4>Medium - <%# XPath("@Medium")%></h4></center>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div>
                    <asp:Repeater ID="rptrightartwork" runat="server" DataSource='<%# XPathSelect("artworks/rightartwork") %>'>
                        <ItemTemplate>
                            <a href="Images/<%# XPath("@GalleryName")%>/lrg/<%# XPath("@ImagePath")%>" class="<%# XPath("@Lightbox")%>"><image src="Images/<%# XPath("@GalleryName")%>/sml/<%# XPath("@ImagePath")%>" class="galleryimg" alt="<%# XPath("@GalleryName")%> - <%# XPath("@Name")%>"></image></a>
                            <center><h3><%# XPath("@Name")%></h3></center>
                            <center><h4>Medium - <%# XPath("@Medium")%></h4></center>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </ItemTemplate>
    </asp:Repeater>
 
</body>
</html>
