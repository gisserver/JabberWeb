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
using System.Collections;

namespace Jabber
{
    public partial class Main : System.Web.UI.Page
    {
        
        string output = "";
        List<Jid> roster = new List<Jid>();


        public Main()
            {
            string output = "Webform intiallized " + DateTime.Now;
            
            
        }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            XmppClientConnection xmpp = (XmppClientConnection)Session["xmpp"];
            if (xmpp.Equals(null)) {
                Response.Redirect("Login.aspx");
                        }
            //XmppClientConnection xmpp = (XmppClientConnection)Session["xmpp"];
            //string state = "";
            Response.Write(output);
            //Response.Write(state);
            
            xmpp.OnRosterStart += new ObjectHandler(Xmpp_OnRosterStart);
            xmpp.OnRosterItem += new XmppClientConnection.RosterHandler(xmpp_OnRosterItem);
            xmpp.OnRosterEnd += new ObjectHandler(Xmpp_OnRosterEnd);
            xmpp.RequestRoster();




        }
        private void Xmpp_OnRosterEnd(object sender)
        {
            List<Jid> roster = (List<Jid>)Session["roster"];
            roster.Sort();

        }




        private void Xmpp_OnRosterStart(object sender)
        {
            Session["roster"] = roster;


        }


        private void xmpp_OnRosterItem(object sender, RosterItem item)
        {
            List<Jid> roster = (List<Jid>)Session["roster"];
           
            System.Diagnostics.Debug.WriteLine(item.Jid);

            if (!roster.Contains(item.Jid))
            {
                roster.Add(item.Jid);
            }
            
            
            System.Diagnostics.Debug.WriteLine("Roster count: " + roster.Count);
            //panellabel.Text = "in the click" + roster[0];

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

        protected void LogOutBut_Click(object sender, EventArgs e)
        {
            XmppClientConnection xmpp = (XmppClientConnection)Session["xmpp"];
            xmpp.Close();
            Response.Redirect("Login.aspx");

        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            List<Jid> roster = (List<Jid>)Session["roster"];
            
            
            System.Diagnostics.Debug.WriteLine(roster.Count);
            //Login seems unreliable.
            //getroster seems to only fire sometimes
                       
            int i = 0;
            foreach (Jid j in roster)
            {
                
                TextBox1.Text += roster[i].ToString();
                i++;
            }



        }
    }
}