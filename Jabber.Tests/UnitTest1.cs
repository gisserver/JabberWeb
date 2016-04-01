using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jabber;
using System.Web.UI.WebControls;
using agsXMPP;
using System.Web.UI;
using System.Collections.Generic;

namespace Jabber.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SetRecieverTest()
        {
            LinkButton button = new LinkButton();
            button.Text = " test     unittest.com";
            Jid jid = new Jid(null);
            ContactList con = new ContactList();
            con.setReceiver(button, jid);
            string expectedUser = jid.User;
            Assert.AreEqual(expectedUser, "test");
            string expectedServer = jid.Server;
        }

        [TestMethod]
        public void SetButtonStylesTest()
        {
            LinkButton button = new LinkButton();
            ContactList con = new ContactList();
            con.SetStyle(button);

            string expected = button.Style.Value.ToString();
            
            Assert.AreEqual(expected, "color:#FFFFFF;border-style:1px solid #DBE0E4;padding:10px 60px 10px 10px;text-align:left;text-decoration:none;white-space:pre;");
        
        }

        [TestMethod]
        public void SetButtonTextTest()
        {
            LinkButton button = new LinkButton();
            ContactList con = new ContactList();
            List<Contact> roster = new List<Contact>();
            Contact contact = new Contact();
            contact.JID_Name = "test";
            contact.JID_Server = "test.com";
            roster.Add(contact);
            int i = 0;
            con.SetText(button,roster,i);

            string expected = "\t" + roster[i].JID_Name+ "\t\t" + roster[i].JID_Server;

            Assert.AreEqual(expected, "\ttest\t\ttest.com");

        }

        [TestMethod]
        public void SetDivStyleTest()
        {
            System.Web.UI.HtmlControls.HtmlGenericControl Div = new System.Web.UI.HtmlControls.HtmlGenericControl();
            ContactList con = new ContactList();
            
            con.SetStyle(Div);

            string expected = "color:#FFFFFF;border-style:1px solid #DBE0E4;padding:10px 60px 10px 10px;text-align:left;text-decoration:none;white-space:pre;";

;

            Assert.AreEqual(expected, "color:#FFFFFF;border-style:1px solid #DBE0E4;padding:10px 60px 10px 10px;text-align:left;text-decoration:none;white-space:pre;");


        }

        [TestMethod]
        public void SetDivTextTest()
        {
            System.Web.UI.HtmlControls.HtmlGenericControl Div = new System.Web.UI.HtmlControls.HtmlGenericControl();
            ContactList con = new ContactList();
            List<Contact> roster = new List<Contact>();
            Contact contact = new Contact();
            contact.JID_Presence = "available";
            roster.Add(contact);
            int i = 0;
            con.SetText(Div, roster, i);

            string expected = "available";

            Assert.AreEqual(expected, roster[i].JID_Presence);

        }




    }
}
