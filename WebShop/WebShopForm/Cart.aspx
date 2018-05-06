<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="WebShopForm.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="style.css" type="text/css" rel="stylesheet" />
    <title>Cart</title>
    <style type="text/css">
        .auto-style1 {
            width: 700px;
        }

        .auto-style2 {
            width: 400px;
        }
    </style>
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
                    <li><a class="active">Cart</a></li>
                    <li><a href="Logout.aspx">Logout</a></li>
                </ul>
            </div>
            <div class="content">
                <asp:GridView ID="GVCart" runat="server" AutoGenerateColumns="False" OnRowDeleting="GVCart_RowDeleting" Width="700px" CssClass="grid">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:ImageField DataImageUrlField="Picture" DataImageUrlFormatString="~\Images\{0}" HeaderText="Picture">
                            <ControlStyle CssClass="product-image" />
                            <ItemStyle CssClass="product-image" />
                        </asp:ImageField>
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Price" DataFormatString="{0:c}" HeaderText="Price" />
                        <asp:BoundField DataField="AmountOrdered" HeaderText="Amount" />
                        <asp:BoundField DataField="TotalPrice" HeaderText="Total price" />
                        <asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/Images/Delete.png">
                            <ControlStyle Height="30px" Width="30px" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td>
                            <asp:Label ID="LBL1" runat="server" Text="Price without BTW:"></asp:Label>
                            <br />
                            <asp:Label ID="LBL2" runat="server" Text="BTW:"></asp:Label>
                            <br />
                            <asp:Label ID="LBL3" runat="server" Text="Price with BTW:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LBLPriceNoBTW" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="LBLBTW" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="LBLPriceWithBTW" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="LBLError" runat="server"></asp:Label>
                <br />
                <br />
                <asp:Button ID="Order" runat="server" Text="Order" OnClick="Order_Click" />
            </div>
            <footer>
            </footer>
        </div>
    </form>
</body>
</html>
