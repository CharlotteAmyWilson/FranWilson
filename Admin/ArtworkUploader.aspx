<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ArtworkUploader.aspx.vb" Inherits="Admin_ArtworkUploader" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td><asp:Label runat="server" ID="lblGallery" Text="Select a Gallery"></asp:Label></td>
                <td><asp:DropDownList ID="ddlGalleries" runat="server" 
                        onselectedindexchanged="ddlGalleries_SelectedIndexChanged">
                        <asp:ListItem Id="liDefault" runat="server" Text="Select" Value="0" Selected="True"></asp:ListItem>
                    </asp:DropDownList>  
                    <asp:XmlDataSource ID="dsGallery" runat="server" XPath="Art/Gallery" DataFile="../XMLFile.xml" />
                </td>                
            </tr>
            <tr>
                <td><asp:Label runat="server" ID="lblArtworkName" Text="Name"></asp:Label></td>
                <td><asp:Textbox ID="txtArtworkName" runat="server"></asp:Textbox></td>
                
            </tr>
            <tr>
                <td><asp:Label runat="server" ID="lblArtworkDescription" Text="Description"></asp:Label></td>
                <td><asp:Textbox ID="txtArtworkDescription" runat="server"></asp:Textbox></td>
                
            </tr>
            <tr>
                <td><asp:Label runat="server" ID="lblSortOrder" Text="Choose the order, 1 being the highest"></asp:Label></td>
                <td><asp:Textbox ID="txtSortOrder" runat="server"></asp:Textbox></td>
                
            </tr>
            <tr>
                <td><asp:Label runat="server" ID="lblIsMainImage" Text="Choose as main gallery image"></asp:Label></td>
                <td><asp:CheckBox ID="chkIsMainImage" runat="server"></asp:CheckBox></td>
                
            </tr>
            <tr>
                
                <td><asp:Label runat="server" ID="lblImage" Text="Image:"></asp:Label></td>
                <td><asp:FileUpload ID="fileUploadArtwork" runat="server" /></td>
                
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><asp:Button id="btnSave"  Text="Save" runat="server" OnClick="btnSave_OnClick" /></td><%--
                <td><asp:Button ID="btnDelete" Text="Delete" runat="server" OnClick="btnDelete_OnClick" /></td> --%>               
                
            </tr>
            <tr>
                <td><asp:Label ID="lblError" runat="server" Visible="false"></asp:Label></td>
                           
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
