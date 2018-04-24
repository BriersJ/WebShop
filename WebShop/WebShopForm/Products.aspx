<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="WebShopForm.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>ONLINE GITAARSCHOP - Producten<br />
            </h1>
            <asp:GridView ID="GVMain" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVMain_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ArtNr" />
                    <asp:BoundField DataField="Name" HeaderText="Naam" />
                    <asp:ImageField DataImageUrlField="Picture" DataImageUrlFormatString="~\Images\{0}" HeaderText="Foto">
                        <ControlStyle Height="150px" Width="150px" />
                    </asp:ImageField>
                    <asp:BoundField DataField="Price" HeaderText="Verkoopprijs" />
                    <asp:BoundField DataField="Stock" HeaderText="Voorraad" />
                    <asp:CommandField SelectText="Voeg toe aan winkelmandje..." ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
