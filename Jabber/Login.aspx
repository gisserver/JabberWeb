<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Jabber.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <br />
        Username
        <asp:TextBox ID="UserNameTB" runat="server" CausesValidation="True"></asp:TextBox>
        @swissjabber.ch 
        <br />
        Password
        <asp:TextBox ID="PasswordTB" runat="server" ></asp:TextBox>
        <br />
        <asp:Button ID="LoginBut" runat="server" BackColor="#66FFFF" BorderWidth="1px" Text="Login" OnClick="LoginBut_Click"/>
        
        <asp:Button ID="RegUserBut" runat="server" BackColor="#66FFFF" BorderWidth="1px" Text="Register" />
        <br />
        <br />

        <br />

        <asp:Label ID="Label1" runat="server"></asp:Label>
       

        <br />
        <br />
        <br />
    </div>
    </form>
</body>
</html>
