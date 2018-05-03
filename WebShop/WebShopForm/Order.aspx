<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="WebShopForm.Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Online Guitarshop - Order</h1>
            <p>
                Your order with id
                <asp:Label ID="LBLId" runat="server"></asp:Label>
&nbsp;has been received successfully.</p>
            <p>
                After a payment of
                <asp:Label ID="LBLPrice" runat="server"></asp:Label>
&nbsp;on Bitcoin adress [put butcoin address here] we will&nbsp; continue the shipment of the products.</p>
            <p>
                Thank you for yout trust!</p>
            <p>
                <asp:Button ID="Back" runat="server" OnClick="Back_Click" Text="Back to products overview" />
            </p>
        </div>
    </form>
</body>
</html>
