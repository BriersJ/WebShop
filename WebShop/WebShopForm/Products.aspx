<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="WebShopForm.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Guitarshop<br />
            </h1>
            <asp:GridView ID="GVMain" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVMain_SelectedIndexChanged" OnRowDeleting="GVMain_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:ImageField DataImageUrlField="Picture" DataImageUrlFormatString="~\Images\{0}" HeaderText="Picture">
                        <ControlStyle Height="150px" Width="150px" />
                    </asp:ImageField>
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="Stock" HeaderText="Stock" />
                    <asp:CommandField SelectText="Add to cart..." ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <asp:Button ID="Cart" runat="server" OnClick="Cart_Click" Text="Go to cart" />
    </form>
</body>
</html>
