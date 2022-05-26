<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="Lab5.Form1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="~/Style/WebStyle.css" type="text/css" runat="server"/>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Vykdyti užsakymą"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" CausesValidation="False" OnClick="Button1_Click" Text="Generuoti" ValidateRequestMode="Disabled" />
            <br />
            <br />
            <asp:Label ID="Label8" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Užsakymas"></asp:Label>
            <asp:Table ID="Table2" runat="server">
            </asp:Table>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Parduodamos prekės"></asp:Label>
            <asp:Table ID="Table1" runat="server">
            </asp:Table>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Įveskite sumos ribą"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Generuoti" />
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Parduodamos prekės"></asp:Label>
            <asp:Table ID="Table3" runat="server">
            </asp:Table>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Neparduotos prekės"></asp:Label>
            <asp:Table ID="Table4" runat="server">
            </asp:Table>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Sandėliai"></asp:Label>
            <asp:Table ID="Table5" runat="server">
            </asp:Table>
        </div>
    </form>
</body>
</html>
