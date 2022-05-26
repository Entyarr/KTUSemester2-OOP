<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="AntrasLab.Form1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="~/Styles/WebStyle.css" type="text/css" runat="server"/>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label10" runat="server" Text="Prenumeratorių failas:"></asp:Label>
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Būtina nurodyti prenumeratorius" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" Text="Agentų failas:"></asp:Label>
        <br />
        <asp:FileUpload ID="FileUpload2" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FileUpload2" ErrorMessage="Būtina nurodyti agentus" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Įveskite mėnesį (nuo 1 iki 12)"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Reikia įvesti skaičių nuo 1 iki 12" ForeColor="Red" ValidationExpression="^[1-9]$|^1[0-2]$"></asp:RegularExpressionValidator>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Surasti" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Prenumeratoriai:"></asp:Label>
        <br />
        <asp:Table ID="Table2" runat="server">
        </asp:Table>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Agentai:"></asp:Label>
        <asp:Table ID="Table3" runat="server">
        </asp:Table>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Agentai, kurie turi prenumeratorių duotam mėnesiui:"></asp:Label>
        <asp:Table ID="Table4" runat="server">
        </asp:Table>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Bendras leidinių kiekis:"></asp:Label>
&nbsp;<asp:Label ID="Label8" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Agentai, kurie turi daugiau parduotų leidinių, nei vidutinis leidinių skaičius:"></asp:Label>
        <asp:Table ID="Table5" runat="server">
        </asp:Table>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Agentai, kuriem buvo perduoti prenumeratoriai:"></asp:Label>
        <asp:Table ID="Table6" runat="server">
        </asp:Table>
        <br />
    </form>
</body>
</html>
