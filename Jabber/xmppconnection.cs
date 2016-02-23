using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using agsXMPP;
using agsXMPP.protocol.iq.roster;
using agsXMPP.protocol.iq.register;
using agsXMPP.protocol.client;
using agsXMPP.Collections;
using System.Threading;

namespace Jabber
{
    public class XmppConnection
    {

        XmppClientConnection xmpp = new XmppClientConnection();

        public void setLoginDetails(String username, String password)
        {

            Console.WriteLine(xmpp.XmppConnectionState);
            xmpp.Server = "swissjabber.ch";
            xmpp.ConnectServer = "5.148.184.164";
            xmpp.Username = username;
            xmpp.Password = password;
            xmpp.Resource = "BILL-HP";
            xmpp.Status = "available";
            xmpp.AutoRoster = true;
            xmpp.Show = ShowType.chat;
            xmpp.SendMyPresence();
            xmpp.Port = 5222;
            xmpp.AutoResolveConnectServer = true;
            xmpp.UseStartTLS = true;
            xmpp.KeepAlive = true;
            Console.WriteLine(xmpp.XmppConnectionState);
        }


        public void openStream()
        {

            xmpp.Open();
            int i = 0;
            while (i <= 5)
            {
                Thread.Sleep(1000);
                i++;
            }
            Jid jid_reciever = new Jid("CathalR@swissjabber.ch");
            string mbody = "Logged in";

            Message msg = new Message(jid_reciever, mbody);
            // Send response.
            xmpp.Send(msg);
            Console.WriteLine(xmpp.XmppConnectionState);
        }

        public void sendMessage()
        {
            Console.WriteLine(xmpp.Username);
            Console.WriteLine(xmpp.XmppConnectionState);
            Jid jid_reciever = new Jid("CathalR@swissjabber.ch");
            string mbody = "sup brah";

            Message msg = new Message(jid_reciever, mbody);
            // Send response.
            xmpp.Send(msg);
        }


    }
}
