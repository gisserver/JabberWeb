<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Jabber.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Jabber Web Client</title>
    <link href="Content/default.css" rel="stylesheet" type="text/css" media="all" />
<link href="Content/fonts.css" rel="stylesheet" type="text/css" media="all" />

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
        <asp:Button ID="LoginBut" runat="server"  BorderWidth="1px" Text="Login" OnClick="LoginBut_Click"/>
        
        <asp:Button ID="RegUserBut" runat="server"  BorderWidth="1px" Text="Register New User" OnClick="RegUserBut_Click" />
        <br />
        <br />

        <br />

        <asp:Label ID="Label1" runat="server"></asp:Label>
       

        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
       

        <br />
        <br />
        <br />
    </div>
    </form>
</body>
</html>
