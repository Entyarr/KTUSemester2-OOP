<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="Lab4.Form1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="~/Style/Lab4Style.css" type="text/css" runat="server"/>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Generuoti" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Pradiniai duomenys"></asp:Label>
            <br />
            <asp:Table ID="Table1" runat="server">
            </asp:Table>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Megstamiausi aktoriai"></asp:Label>
            <br />
            <asp:Table ID="Table2" runat="server">
            </asp:Table>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Filmai ir serialai, kuriuos mate visi"></asp:Label>
            <br />
            <asp:Table ID="Table3" runat="server">
            </asp:Table>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Rekomenduojami filmai ir serialai"></asp:Label>
            <br />
            <asp:Table ID="Table4" runat="server">
            </asp:Table>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Nauji filmai ir serialai"></asp:Label>
            <br />
            <asp:Table ID="Table5" runat="server">
            </asp:Table>
        </div>
    </form>
</body>
</html>
