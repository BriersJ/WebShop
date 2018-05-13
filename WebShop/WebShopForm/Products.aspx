<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="WebShopForm.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="style.css" type="text/css" rel="stylesheet" />
    <title>Products overview</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div class="header">
                <img src="Images\Banner.png" />
            </div>
            <div class="menu">
                <ul class="menu-list">
                    <li><a class="active">Products overview</a></li>
                    <li><a href="Cart.aspx">Cart</a></li>
                    <li><a href="Logout.aspx">Logout</a></li>
                </ul>
            </div>
            <div class="content">
                <h1>Guitarshop<br />
                </h1>
                <asp:GridView ID="GVMain" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVMain_SelectedIndexChanged" CssClass="grid">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:ImageField DataImageUrlField="Picture" DataImageUrlFormatString="~\Images\{0}" HeaderText="Picture">
                            <ControlStyle CssClass="product-image" />
                        </asp:ImageField>
                        <asp:BoundField DataField="Price" HeaderText="Price" />
                        <asp:BoundField DataField="Stock" HeaderText="Stock" />
                        <asp:CommandField SelectText="" ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/Images/Cart.png" />
                    </Columns>
                </asp:GridView>

            </div>
            <footer>
                <a href="mailto:webshopjonas@gmail.com">Contact</a>
            </footer>
        </div>
    </form>
</body>
</html>
