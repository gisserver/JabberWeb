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
using agsXMPP.protocol.x.muc;
using System.IO;


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
            contact.JID_Full = pres.From.User + "@" + pres.From.Server;
            

            for (int i = 0; i < roster.Count; i++)
            {
                if (pres.From.User == roster[i].JID_Name & pres.From.Server == roster[i].JID_Server)
                {
                    roster.Remove(roster[i]);

                }
            }
            roster.Add(contact);
            

            
            
            
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
            Contact cont = (Contact)Session["Contact"];
            
            string mbody = NewMessageBox.Text;
            MessageType type;
            if (cont.JID_Server.Contains("conference"))
            {
                type = MessageType.groupchat;
            }
            else
            {
                type = MessageType.chat;
            }
            
            Message msg = new Message(cont.JID_Name+"@"+cont.JID_Server,type, mbody);
            // Send response.
            System.Diagnostics.Debug.WriteLine(type.ToString());

            xmpp.Send(msg);
            MessageDB saver = new MessageDB();
            saver.saveMessage(xmpp.Username + "@" + xmpp.Server, cont.JID_Name + "@" + cont.JID_Server, mbody, type.ToString());
            NewMessageBox.Text = string.Empty;
        }

        protected void LogOutBut_Click(object sender, EventArgs e)
        {
            List<string> conversation = (List<string>)Session["Conversation"];
            System.Diagnostics.Debug.WriteLine(conversation[0] + conversation[1]);
            foreach (string convo in conversation)
            {
                File.Delete(convo);
            }
            System.Diagnostics.Debug.WriteLine(conversation[0] + conversation[1]);
            //Session is cleaned up in Session_End
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
            Contact cont = (Contact)Session["Contact"];
            
            LinkButton b = (LinkButton)sender;
            ContactList c = new ContactList();
            c.setReceiver(b, cont);
            XmppClientConnection xmpp = (XmppClientConnection)Session["xmpp"];
            MessageGrabber messageGrab = new MessageGrabber(xmpp);
            messageGrab.Add(new Jid(cont.JID_Full), new BareJidComparer(), new MessageCB(MessageCallBack), null);


            List<string> conversation = (List<string>)Session["Conversation"];
            MessageDB loader = new MessageDB();
            string fileName = cont.JID_Full + "_hist";
            fileName = fileName.Replace("@", "");
            fileName = fileName.Replace(".", "");

            //Only store five conversations at a time
            //Delete the oldest               
            string path = @"C:\Temp\" + fileName + ".txt";
            loader.loadMessage(xmpp.Username + "@" + xmpp.Server, cont.JID_Full,conversation,path);
            StreamReader sr = File.OpenText(path);
            try
            {   // Open the text file using a stream reader.


                // Read the stream to a string, and write the string to the console.

                string line;
                while((line = sr.ReadLine()) != null)
                {
                    System.Diagnostics.Debug.WriteLine(line);
                    //Need to append the textbox with the messages
                     
                }


            }
            catch (Exception )
            {
                System.Diagnostics.Debug.WriteLine("The file could not be read:");
                
            }
            //MessageDisplay.Text = ;
            finally
            {
                sr.Close(); 
            }
            

        }
        
        private void MessageCallBack(object sender, Message msg, object data)
        {
            //Write to file or write to database???????
            XmppClientConnection xmpp = (XmppClientConnection)Session["xmpp"];

            System.Diagnostics.Debug.WriteLine(msg.From.User+"@"+msg.From.Server+xmpp.Username + "@" + xmpp.Server + msg.Body+ msg.Type.ToString());
            MessageDB saver = new MessageDB();
            saver.saveMessage(msg.From.User + "@" + msg.From.Server, xmpp.Username + "@" + xmpp.Server, msg.Body, msg.Type.ToString());

        }

        protected void JoinGC(object sender, EventArgs e)
        {
            XmppClientConnection xmpp = (XmppClientConnection)Session["xmpp"];
            MucManager mucManager = new MucManager(xmpp);
            Jid Room = new Jid(GroupChatNameHidden.Value);
            mucManager.JoinRoom(Room,NickNameHidden.Value);

            MessageType type = MessageType.groupchat;
            xmpp.Send(new Message(Room,type, "This is a test"));

        }

        protected void addContact(object sender, EventArgs e)
        {
            XmppClientConnection xmpp = (XmppClientConnection)Session["xmpp"];
            string contactName = ContactNameHidden.Value + "@" + DomainNameHidden.Value;
            xmpp.RosterManager.AddRosterItem(contactName);
            System.Diagnostics.Debug.WriteLine(contactName);
            xmpp.PresenceManager.Subscribe(contactName);
            xmpp.PresenceManager.ApproveSubscriptionRequest(contactName);

        }

    }
}