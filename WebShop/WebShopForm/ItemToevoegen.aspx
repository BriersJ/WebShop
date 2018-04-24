<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemToevoegen.aspx.cs" Inherits="WebShopForm.ItemToevoegen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>ONLINE GITAARSHOP - Item toevoegen</h1>
        </div>
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Image ID="Picture" runat="server" Width="150px" />
                </td>
                <td>
                    <table class="auto-style1">
                        <tr>
                            <td>ArtNr:</td>
                            <td>
                                <asp:Label ID="ProductID" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Naam:</td>
                            <td>
                                <asp:Label ID="Name" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Verkoopprijs:</td>
                            <td>
                                <asp:Label ID="Price" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Voorraad:</td>
                            <td>
                                <asp:Label ID="Stock" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Terug naar hoofdpagina..." />
    </form>
</body>
</html>
