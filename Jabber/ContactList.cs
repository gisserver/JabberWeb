using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using agsXMPP;
using agsXMPP.protocol.iq.roster;
using agsXMPP.protocol.client;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jabber
{
    public class ContactList
    {
        

        
        public void SetStyle(System.Web.UI.HtmlControls.HtmlGenericControl RosterDiv)
        {
            
            RosterDiv.Style.Add(HtmlTextWriterStyle.BorderStyle, "solid");
            RosterDiv.Style.Add(HtmlTextWriterStyle.BorderColor, "#000000");
            RosterDiv.Style.Add(HtmlTextWriterStyle.BorderWidth, "1px");
            RosterDiv.Style.Add(HtmlTextWriterStyle.Padding, "10px 10px 10px 10px");
            RosterDiv.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#808080");
            RosterDiv.Style.Add(HtmlTextWriterStyle.TextAlign, "left");
            
        }

        public void SetStyle(LinkButton b)
        {
            b.Style.Add(HtmlTextWriterStyle.Color, "#FFFFFF");
            b.Style.Add(HtmlTextWriterStyle.BorderStyle, "1px solid #DBE0E4");
            b.Style.Add(HtmlTextWriterStyle.Padding, "10px 60px 10px 10px");
            b.Style.Add(HtmlTextWriterStyle.TextAlign, "left");
            b.Style.Add(HtmlTextWriterStyle.TextDecoration, "none");
            b.Style.Add(HtmlTextWriterStyle.WhiteSpace, "pre");

            
        }

        
        public void SetText(System.Web.UI.HtmlControls.HtmlGenericControl RosterDiv, List<Contact> roster, int i)
        {
            if (roster[i].JID_Presence.ToString().Equals("available") || roster[i].JID_Presence.ToString().Equals("subscribe"))
            {
                RosterDiv.Style.Add(HtmlTextWriterStyle.Color, "#5DFC0A");
            }
            else
            {
                RosterDiv.Style.Add(HtmlTextWriterStyle.Color, "#000000");
            }
            RosterDiv.ID = "div_" + i;
            RosterDiv.InnerText = roster[i].JID_Presence.ToString();
        }

        //invisable button
        public void SetText(LinkButton b, List<Contact> roster, int i)
        {

            string name = roster[i].JID_Name;
            string domain = roster[i].JID_Server;
            


            b.ID = "L_Button_" + i;

            b.Text = ("\t" + name + "\t\t" + domain );
             
        }

        public void setReceiver(LinkButton linkButton , Contact cont)
        {
            char[] delimiterChars = { ' ', '\t' };
            string[] words = linkButton.Text.Split(delimiterChars);
            cont.JID_Name = words[1];
            cont.JID_Server = words[3];

        }



    }
}