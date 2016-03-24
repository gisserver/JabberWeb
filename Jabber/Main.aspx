<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Jabber.Main" EnableSessionState="True" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="/Content/css?v=Z-yHEtVIQOhCWVakGuXjd207yIlDWykN0EPGLkygpbI1" rel="stylesheet"/>
    <link href="Content/default.css" rel="stylesheet" type="text/css" media="all" />
<link href="Content/fonts.css" rel="stylesheet" type="text/css" media="all" />
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
           
            
           
         <br />

        </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering= "true"></asp:ScriptManager>
        <div class="row">
        <div class="col-md-3">
            <asp:Timer ID="Timer1"  runat="server" Interval="5000">
            </asp:Timer>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                

                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick"/>
                    <asp:AsyncPostBackTrigger ControlID="Refresh_But" EventName="Click"/>
            </Triggers>
                
                <ContentTemplate>
                    <div runat="server" id ="roster1">
                        </div>            
                    <asp:Button runat="server" Text="Refresh Roster" Visible="False" OnClick="Refresh_Click" style="height: 26px" ID="Refresh_But" />

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
