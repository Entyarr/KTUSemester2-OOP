<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="AntrasLab.Form1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Prenumeratoriai:"></asp:Label>
        <asp:Table ID="Table2" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
        </asp:Table>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Agentai:"></asp:Label>
        <asp:Table ID="Table3" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
        </asp:Table>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Įveskite mėnesį (nuo 1 iki 12)"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Reikia įvesti skaičių nuo 1 iki 12" ForeColor="Red" ValidationExpression="^[1-9]$|^1[0-2]$"></asp:RegularExpressionValidator>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Surasti" />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Agentai, kurie turi prenumeratorių duotam mėnesiui:"></asp:Label>
        <asp:Table ID="Table4" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
        </asp:Table>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Bendras leidinių kiekis:"></asp:Label>
&nbsp;<asp:Label ID="Label8" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Agentai, kurie turi daugiau parduotų leidinių, nei vidutinis leidinių skaičius:"></asp:Label>
        <asp:Table ID="Table5" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
        </asp:Table>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Agentai, kuriem buvo perduoti prenumeratoriai:"></asp:Label>
        <asp:Table ID="Table6" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
        </asp:Table>
        <br />
    </form>
</body>
</html>
