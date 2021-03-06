﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Jabber.Main" EnableSessionState="True" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="/Content/css?v=Z-yHEtVIQOhCWVakGuXjd207yIlDWykN0EPGLkygpbI1" rel="stylesheet"/>
    <link href="Content/default.css" rel="stylesheet" type="text/css" media="all" />
<link href="Content/fonts.css" rel="stylesheet" type="text/css" media="all" />

    <!--jquery and css for javascript forms-->
   <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
  <script src="//code.jquery.com/jquery-1.10.2.js"></script>
  <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
  <link rel="stylesheet" href="/resources/demos/style.css"/>
<script type="text/javascript" src="Scripts/joinGC.js"></script>
    
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
     

    <div id="JoinGC-form" style="visibility:hidden">
    <form title="Join GroupChat">
        <label for="name">Chat Name</label>
        <input type="text" name="name" id="GCName" class="text ui-widget-content ui-corner-all" />
        <label for="name">Password</label>
        <input type="text" name="password" id="password" class="text ui-widget-content ui-corner-all" />
        <label for="name">Nickname</label>
        <input type="text" name="nickname" id="nickname" class="text ui-widget-content ui-corner-all" value ="<%:Session["Name"]%>" />
        
    </form>
    
</div>
    <div id="AddContact-form" style="visibility:hidden">
    <form title="AddContact">
        <label for="name">Contact Name</label>
        <input type="text" name="name" id="ContactName" class="text ui-widget-content ui-corner-all" />
        <label for="domain">Domain</label>
        <input type="text" name="domain" id="ContactDomain" class="text ui-widget-content ui-corner-all" />
        
    </form>
    
</div>
    <form id="form1" runat="server" >
        
 

        
            <asp:HiddenField ID="GroupChatNameHidden" Value="" runat="server" OnValueChanged="JoinGC"/>
        <asp:HiddenField ID="PasswordHidden" Value="" runat="server" />
        <asp:HiddenField ID="NickNameHidden" Value="" runat="server" />

        <asp:HiddenField ID="ContactNameHidden" Value="" runat="server" OnValueChanged="addContact"/>
        <asp:HiddenField ID="DomainNameHidden" Value="" runat="server" />

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
                    <div runat="server" id ="roster1" >
                        </div>            
                    <asp:Button runat="server" Text="Refresh Roster" Visible="False" OnClick="Refresh_Click" style="height: 26px" ID="Refresh_But" />
                        

                   
                    </ContentTemplate>
                      </asp:UpdatePanel>

            <input id="JoinGC"  value="Join GC"  type="button" />
            <input id="AddContact" value="Add Contact" type="button" />
        </div>
            
        <div class="col-md-6">
            <br />

                    <asp:Panel ID="Panel1" runat="server">
                        <asp:TextBox id="MessageDisplay" name="MessageDisplay" runat="server"  readonly="true"></asp:TextBox>
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
