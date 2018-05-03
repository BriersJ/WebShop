<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="WebShopForm.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 700px;
        }
        .auto-style2 {
            width: 400px;
        }
        .auto-style3 {
            width: 700px;
        }
        .auto-style4 {
            width: 400px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GVCart" runat="server" AutoGenerateColumns="False" OnRowDeleting="GVCart_RowDeleting" Width="700px">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:ImageField DataImageUrlField="Picture" DataImageUrlFormatString="~\Images\{0}" HeaderText="Picture">
                        <ControlStyle Height="100px" Width="100px" />
                    </asp:ImageField>
                    <asp:BoundField DataField="Price" DataFormatString="{0:c}" HeaderText="Price" />
                    <asp:BoundField DataField="AmountOrdered" HeaderText="Amount" />
                    <asp:BoundField DataField="TotalPrice" HeaderText="Total price" />
                    <asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/Images/Delete.png" >
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
            <table class="auto-style3">
                <tr>
                    <td class="auto-style4">
            <asp:Button ID="Back" runat="server" OnClick="Back_Click" Text="Back to products overvieuw" />
                    </td>
                    <td>
                        <asp:Button ID="Order" runat="server" Text="Order" OnClick="Order_Click" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
</body>
</html>
