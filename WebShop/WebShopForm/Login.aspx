<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebShopForm.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="style.css" type="text/css" rel="stylesheet" />
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="loginbox-main">
            <div class="loginbox-box">
                <table>
                    <tr>
                        <td>Username:</td>
                        <td>
                            <asp:TextBox ID="TXTUser" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Password:</td>
                        <td>
                            <asp:TextBox ID="TXTPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="BNTLogin" runat="server" OnClick="BNTLogin_Click" Text="Login" />
                <br />
                <br />
                <asp:Label ID="LBLError" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
