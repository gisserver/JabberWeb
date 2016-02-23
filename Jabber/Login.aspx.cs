using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using agsXMPP;
using agsXMPP.protocol.iq.roster;
using agsXMPP.protocol.iq.register;
using agsXMPP.protocol.client;
using agsXMPP.Collections;
using System.Threading;


namespace Jabber
{
    public partial class Login : System.Web.UI.Page
    {
        private XmppClientConnection xmpp = new XmppClientConnection();
        string output = "";
        string state = "";        
            
        public Login()
        {
            output += "Webform intiallized " + DateTime.Now;
            state = "" + xmpp.XmppConnectionState;

        }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(output);
            Response.Write(state);
            
        }
        
        
        protected void LoginBut_Click(object sender, EventArgs e)
        {
            xmpp.OnLogin += Xmpp_OnLogin;
            
            xmpp.OnError += Xmpp_OnError;
            Session["xmpp"] = xmpp;
            Session["Name"] = UserNameTB.Text;
           
            xmpp.Server = "swissjabber.ch";
            xmpp.ConnectServer = "5.148.184.164";
            xmpp.Username = (string)Session["Name"];
            xmpp.Password = PasswordTB.Text;
            xmpp.Resource = "BILL-HP";
            xmpp.Status = "available";
            xmpp.AutoRoster = true;
            xmpp.Show = ShowType.chat;
            xmpp.SendMyPresence();
            xmpp.Port = 5222;
            xmpp.AutoResolveConnectServer = true;
            xmpp.UseStartTLS = true;
            xmpp.KeepAlive = true;
            xmpp.Open();
            
                          
        }

        //Event handlers
        private void Xmpp_OnError(object sender, Exception ex)
        {
            Label1.Text = "Error on login. Please try again";
        }


        private void Xmpp_OnLogin(object sender)
        {
            Response.Redirect("Main.aspx");
        }
    }


    
}
