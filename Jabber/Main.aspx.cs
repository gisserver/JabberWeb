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
    public partial class Main : System.Web.UI.Page
    {
        
        string output = "";
        
        
        public Main()
            {
            string output = "Webform intiallized " + DateTime.Now;
         
        }
        

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["xmpp"].Equals(null)) {
                Response.Redirect("Login.aspx");
                        }
            //XmppClientConnection xmpp = (XmppClientConnection)Session["xmpp"];
            //string state = "";
            Response.Write(output);
            //Response.Write(state);
           
        }

        
        
        protected void SendMessage_Click(object sender, EventArgs e)
        {
            XmppClientConnection xmpp = (XmppClientConnection)Session["xmpp"];
            ////////////////////////Null pointer
            Jid jid_reciever = new Jid("CathalR@swissjabber.ch");
            string mbody = NewMessageBox.Text;

            Message msg = new Message(jid_reciever, mbody);
            // Send response.
            
            xmpp.Send(msg);
            ////////////////////////
        }
    }
}