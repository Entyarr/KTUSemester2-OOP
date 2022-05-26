<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forma1.aspx.cs" Inherits="PirmasLab.forma1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Skaičiuoti" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Rezultatai"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True" OnTextChanged="TextBox1_TextChanged" Width="257px"></asp:TextBox>
    </form>
    </body>
</html>
