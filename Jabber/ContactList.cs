using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using agsXMPP;
using agsXMPP.protocol.iq.roster;
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
        
        }

        public void SetStyle(LinkButton b)
        {
            b.Style.Add(HtmlTextWriterStyle.Color, "#FFFFFF");
            b.Style.Add(HtmlTextWriterStyle.BorderStyle, "1px solid #DBE0E4");
            b.Style.Add(HtmlTextWriterStyle.Padding, "20px 20px 20px 20px");
            b.Style.Add(HtmlTextWriterStyle.TextDecoration, "none");
            
        }



        public void SetText(System.Web.UI.HtmlControls.HtmlGenericControl RosterDiv, List<Jid> roster, int i)
        {
                        
            RosterDiv.InnerText = roster[i].ToString();
        }

        public void SetText(LinkButton b, List<Jid> roster, int i)
        {

            b.Text = roster[i].ToString();
        }



    }
}