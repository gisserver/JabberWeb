<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Jabber.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <br />
        <br />
        <br />
        <asp:TextBox ID="NewMessageBox" runat="server" ></asp:TextBox>
        <asp:Button ID="SendMessage" runat="server" OnClick="SendMessage_Click" Text="Send"  />
        <br />
    
    </div>
    </form>
</body>
</html>
