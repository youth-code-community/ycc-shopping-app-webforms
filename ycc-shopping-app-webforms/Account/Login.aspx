<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ycc_shopping_app_webforms.Account.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="txtOne" />
            <asp:TextBox runat="server" ID="TextBox1" />
            <asp:TextBox runat="server" ID="TextBox2" />
            <asp:Button runat="server" ID="BTN" OnClick="BTN_Click"/>
        </div>
    </form>
</body>
</html>
