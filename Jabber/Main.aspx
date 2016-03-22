<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Jabber.Main" EnableSessionState="True" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="/Content/css?v=Z-yHEtVIQOhCWVakGuXjd207yIlDWykN0EPGLkygpbI1" rel="stylesheet"/>
    <style>
        #LogOutBut {
            position: absolute;
            top: 2px;
            margin-right: 2px;
            right: 10px;
        }

        #TextArea1 {
            height: 200px;
            width: 744px;
            margin-top: 0px;
        }
    </style>

    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
         <asp:Button ID="LogOutBut" runat="server" OnClick="LogOutBut_Click" Text="LogOut" />
        <div >
            <br />
            <h1> Hello <%:Session["Name"]%>, Welcome to the Jabber Web Client.</h1>
           
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
           
         <br />

        </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering= "true"></asp:ScriptManager>
        <div class="row">
        <div class="col-md-3">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                
                <ContentTemplate>
                    <div runat="server" id ="roster1">
                <asp:Button runat="server" Text="Refresh Roster" OnClick="Unnamed2_Click" style="height: 26px" />
                        </div>
                    </ContentTemplate>
                      </asp:UpdatePanel>
        </div>
        <div class="col-md-6">
            <br />

                    <textarea id="TextArea1" name="S1" readonly="readonly"></textarea><asp:Panel ID="Panel1" runat="server">
                        <asp:TextBox ID="NewMessageBox" runat="server" AutoCompleteType="Disabled" Height="20px" Width="675px"></asp:TextBox>
                        <asp:Button ID="SendMessage" runat="server" OnClick="SendMessage_Click" Text="Send" />
                    </asp:Panel>
                    <br />
        </div>
        <div class="col-md-4">
  
        </div>
    </div>


        
    </form>
</body>
</html>
