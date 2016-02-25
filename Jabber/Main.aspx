<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Jabber.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <style>
      #LogOutBut{
position:absolute;
          top: 2px;
          left: 782px;
      }</style>  

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <br />
         Hello <%:Session["Name"]%>, Welcome to the Matrix.
         <br />
        <br />
        <div><br />
        <asp:TextBox ID="NewMessageBox" runat="server" AutoCompleteType="Disabled" Height="55px" Width="170px" ></asp:TextBox>
        <asp:Button ID="SendMessage" runat="server" OnClick="SendMessage_Click" Text="Send"  />
         <asp:Button ID="LogOutBut" runat="server" OnClick="LogOutBut_Click" Text="LogOut" />
        <br />

        </div>
        
    
    </div>
    </form>
</body>
</html>
