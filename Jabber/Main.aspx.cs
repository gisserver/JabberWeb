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

        public Main()
        {
            string output = "Webform intiallized " + DateTime.Now;
        }


        protected void Page_Load(object sender, EventArgs e)
        { 
            if (Session["Session_ID"] == null || Session["xmpp"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            XmppClientConnection xmpp = (XmppClientConnection)Session["xmpp"];
            Response.Write(output);
            
            //xmpp.OnRosterStart += new ObjectHandler(Xmpp_OnRosterStart);
            //xmpp.OnRosterItem += new XmppClientConnection.RosterHandler(xmpp_OnRosterItem);
            //xmpp.OnRosterEnd += new ObjectHandler(Xmpp_OnRosterEnd);
            xmpp.OnPresence += new PresenceHandler(Xmpp_OnPresence);
            //xmpp.RequestRoster();
            Refresh_Click(Refresh_But, EventArgs.Empty);

            /*
            send an iq

            IqGrabber iqgr = new IqGrabber(xmpp);
            IQ myiq = new IQ();
            System.Diagnostics.Debug.WriteLine(iqgr.Equals(null));
            myiq.Id = "auto1";
            
            IqType type = IqType.get;
            myiq.Type = type;
            
            myiq.InnerXml = "<auto save = 'true' xmlns = 'urn:xmpp:archive'/>";
            //myiq.To = "swissjabber.ch";
            System.Diagnostics.Debug.WriteLine(myiq.Equals(null));
            iqgr.SendIq(myiq,null,null);
            */

        }

        private void Xmpp_OnPresence(object sender, Presence pres)
        {
            
            System.Diagnostics.Debug.WriteLine("Recieved presence" + GetHashCode());
            
            List<Contact> roster = (List<Contact>)Session["roster"];
            System.Diagnostics.Debug.WriteLine(pres.From.User + "from server" + pres.From.Server + "type: " + pres.Type);
            Contact contact = new Contact();
            
            contact.JID_Name = pres.From.User;
            contact.JID_Server = pres.From.Server;
            contact.JID_Presence = pres.Type.ToString();
            
                for(int i = 0; i < roster.Count; i++)
            {
             if (pres.From.User == roster[i].JID_Name & pres.From.Server == roster[i].JID_Server)
                {
                    roster.Remove(roster[i]);
                    
                }
            }
            roster.Add(contact);
            

            //cause ajax update panel to postback
            
            
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
            Jid jid_receiver = (Jid)Session["jid_receiver"];
            
            string mbody = NewMessageBox.Text;
            NewMessageBox.Text = string.Empty;
            Message msg = new Message(jid_receiver, mbody);
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

        protected void Refresh_Click(object sender, EventArgs e)
        {
            List<Contact> roster = (List<Contact>)Session["roster"];
            ContactList c = new ContactList();

            
            int i = 0;
            
            foreach (Contact j in roster)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl RosterDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                RosterDiv.ID = "RosterDiv";
                c.SetStyle(RosterDiv);
                c.SetText(RosterDiv, roster, i);
                

                roster1.Controls.Add(RosterDiv);
                LinkButton b = new LinkButton();
                b.Click += new EventHandler(B_Click);
                c.SetStyle(b);
                c.SetText(b, roster, i);
                
                RosterDiv.Controls.Add(b);
                i++;
            }

        }

        private void B_Click(object sender, EventArgs e)
        {
            //Sets the message receiver on click of linkbutton
            Jid jid_receiver = (Jid)Session["jid_receiver"];
            LinkButton b = (LinkButton)sender;
            ContactList c = new ContactList();
            c.setReceiver(b, jid_receiver);
            
           
        }

    }
}