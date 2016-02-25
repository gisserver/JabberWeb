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
        bool redirect = true;       
            
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
            Label1.Text = "";
            //Label doesnt change on click

            //need to implement the handlers
            //xmpp.OnLogin += Xmpp_OnLogin; 
            Response.Write(redirect);
           

            setConnectionDetails();
            xmpp.Open();
            xmpp.OnError += Xmpp_OnError;
            Response.Write(redirect);


            //if the is an error on login
            //attempt login again

            //else redirect to main page
            if (redirect == true)
            {
                Response.Redirect("Main.aspx");
            }
            


        }


        private void Xmpp_OnLogin(object sender)
        {
          
               
               
            
           
        }

        private void setConnectionDetails()
        {
            
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

        }

        //Event handlers
        private void Xmpp_OnError(object sender, Exception ex)
        {
            try
            {
                redirect = false;
                Label1.Text = "Error on login. Please try again";
                xmpp.Close();
            }
            catch
            {
                throw ex;
            }
        }


    }


    
}
