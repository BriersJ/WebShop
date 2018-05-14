<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="WebShopForm.ItemToevoegen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="style.css" type="text/css" rel="stylesheet" />
    <title>Product details</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div class="header">
                <img src="Images\Banner.png" />
            </div>
            <div class="menu">
                <ul class="menu-list">
                    <li><a href="Products.aspx">Products overview</a></li>
                    <li><a href="Cart.aspx">Cart</a></li>
                    <li><a href="Logout.aspx">Logout</a></li>
                </ul>
            </div>
            <div class="content">
                <table class="max-width">
                    <tr>
                        <td>
                            <asp:Image ID="Picture" runat="server" Width="150px" />
                        </td>
                        <td>
                            <table class="max-width">
                                <tr>
                                    <td>Product ID:</td>
                                    <td>
                                        <asp:Label ID="ProductID" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Name:</td>
                                    <td>
                                        <asp:Label ID="Name" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Price:</td>
                                    <td>
                                        <asp:Label ID="Price" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Stock:</td>
                                    <td>
                                        <asp:Label ID="Stock" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
                Amount to order:
                <asp:TextBox ID="TXTAmount" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="BTN_Confirm" runat="server" OnClick="Confirm_Click" Text="Confirm" />
                <br />
                <br />
                <asp:Label ID="LBLError" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <footer>
                <a href="mailto:webshopjonas@gmail.com">Contact</a>
            </footer>
        </div>
    </form>
</body>
</html>
