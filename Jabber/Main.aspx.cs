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
        List<Contact> roster = new List<Contact>();
        

        

        public Main()
            {
            string output = "Webform intiallized " + DateTime.Now;
                       
        }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (Session["Session_ID"]==null || Session["xmpp"]==null) {
                Response.Redirect("Login.aspx");
                        }
            XmppClientConnection xmpp = (XmppClientConnection)Session["xmpp"];
            Response.Write(output);

            //xmpp.OnRosterStart += new ObjectHandler(Xmpp_OnRosterStart);
            //xmpp.OnRosterItem += new XmppClientConnection.RosterHandler(xmpp_OnRosterItem);
            //xmpp.OnRosterEnd += new ObjectHandler(Xmpp_OnRosterEnd);
            xmpp.OnPresence += new PresenceHandler(Xmpp_OnPresence);
            //xmpp.RequestRoster();
            


        }

        private void Xmpp_OnPresence(object sender, Presence pres)
        {
            
            Session["roster"] = roster;
            System.Diagnostics.Debug.WriteLine(pres.From.User +"from server" + pres.From.Server +"type: " + pres.Type);
            Contact contact = new Contact();
            System.Diagnostics.Debug.WriteLine(pres);
            System.Diagnostics.Debug.WriteLine(roster);
            contact.JID_Name = pres.From.User;
            contact.JID_Server = pres.From.Server;
            contact.JID_Presence = pres.Type.ToString();


            roster.Add(contact);
            
            System.Diagnostics.Debug.WriteLine("user of on presence" + roster[0].JID_Name);
            System.Diagnostics.Debug.WriteLine("server of on presence" + roster[0].JID_Server);
            System.Diagnostics.Debug.WriteLine("status of on presence" + roster[0].JID_Presence);

            System.Diagnostics.Debug.WriteLine("Roster count from presence event: " + roster.Count);

        }

        private void Xmpp_OnRosterEnd(object sender)
        {
            //List<Contact> roster = (List<Contact>)Session["roster"];
            //roster.Sort();

        }




        private void Xmpp_OnRosterStart(object sender)
        {
            //Session["roster"] = roster;


        }


        private void xmpp_OnRosterItem(object sender, RosterItem item)
        {
            //XmppClientConnection xmpp = (XmppClientConnection) Session["xmpp"];
            //List<Contact> roster = (List<Contact>)Session["roster"];
           
            //System.Diagnostics.Debug.WriteLine(item.Jid);
            //Contact contact = new Contact();
            //if (!roster.Contains(contact))
            //{
            //    contact.JID_Name = item.Jid;
            //    xmpp.PresenceManager.Subscribe(item.Jid);
                

            //    //roster.Add(contact);
            //}
                        
            //System.Diagnostics.Debug.WriteLine("Roster count: " + roster.Count);
            
        }



        protected void SendMessage_Click(object sender, EventArgs e)
        {
            XmppClientConnection xmpp = (XmppClientConnection)Session["xmpp"];
            
            Jid jid_reciever = new Jid("CathalR@swissjabber.ch");
            string mbody = NewMessageBox.Text;

            Message msg = new Message(jid_reciever, mbody);
            // Send response.
            
            xmpp.Send(msg);
            
        }

        protected void LogOutBut_Click(object sender, EventArgs e)
        {
            XmppClientConnection xmpp = (XmppClientConnection)Session["xmpp"];
            xmpp.Close();
            Session.RemoveAll();
            Session.Abandon();

            Response.Redirect("Login.aspx");

        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            List<Contact> roster = (List<Contact>)Session["roster"];
            ContactList c = new ContactList();

            //System.Diagnostics.Debug.WriteLine(roster.Count);
            //Login seems unreliable.
            //getroster seems to only fire sometimes
            int i = 0;
            //System.Diagnostics.Debug.WriteLine("user in div" + roster[i].From.User);
            
            foreach (Contact j in roster)
            {
                
                System.Web.UI.HtmlControls.HtmlGenericControl RosterDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                RosterDiv.ID = "RosterDiv";
                c.SetStyle(RosterDiv);
               
                roster1.Controls.Add(RosterDiv);
                LinkButton b = new LinkButton();
                c.SetStyle(b);
                c.SetText(b,roster,i);
                c.SetText(RosterDiv, roster, i);
                RosterDiv.Controls.Add(b);
                i++;
            }



        }
       
    }

    
}