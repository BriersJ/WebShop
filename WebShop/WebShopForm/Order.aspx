﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="WebShopForm.Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="style.css" type="text/css" rel="stylesheet" />
    <title>Order completed</title>
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
                    <li><a href="Order.aspx">Cart</a></li>
                    <li><a href="Logout.aspx">Logout</a></li>
                </ul>
            </div>
            <div class="content">
                <h1>Online Guitarshop - Order</h1>
                <p>
                    Your order with id
               
                    <asp:Label ID="LBLId" runat="server"></asp:Label>
                    &nbsp;has been received successfully.
                </p>
                <p>
                    After a payment of
               
                    <asp:Label ID="LBLPrice" runat="server"></asp:Label>
                    &nbsp;on Bitcoin adress [put butcoin address here] we will&nbsp; continue the shipment of the products.
                </p>
                <p>
                    Thank you for yout trust!
                </p>
            </div>
            
            <footer>

            </footer>
        </div>
    </form>
</body>
</html>
