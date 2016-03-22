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
using System.IO;
using System.Collections;

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

            //Handlers allow xml stream to be viewed in the debugger for debugging purposes
            xmpp.OnReadXml += new XmlHandler(Xmpp_OnReadXml);
            xmpp.OnWriteXml += new XmlHandler(Xmpp_OnWriteXml);

            



        }
       


        private void Xmpp_OnReadXml(object sender, string xml)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("recieve: " + xml);

            }
            catch { }
        }

        private void Xmpp_OnWriteXml(object sender, string xml)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("sent: " + xml);
            }
            catch { }
            
        }

        protected void LoginBut_Click(object sender, EventArgs e)
        {
            //need to implement the handlers
            xmpp.OnLogin += Xmpp_OnLogin;
           

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

        protected void RegUserBut_Click(object sender, EventArgs e)
        {
            

            
            xmpp.RegisterAccount = true;

            setConnectionDetails();
            xmpp.OnError += new ErrorHandler(Xmpp_OnError);
            // xmpp.OnRegisterInformation += Xmpp_OnRegisterInformation;
            //register events wont fire
            xmpp.OnRegistered += new ObjectHandler(Xmpp_OnRegistered);
            
            xmpp.OnRegisterError += new XmppElementHandler(Xmpp_OnRegisterError);

            
            //events do not fire until after connection trys to open.
            xmpp.Open();
            Response.Write(redirect);

            //if the is an error on login
            //attempt login again

            //else redirect to main page
            if (redirect == true)
            {
                Response.Redirect("Main.aspx");
            }

        }

        
        //Event handlers
        private void Xmpp_OnError(object sender, Exception ex)
        {
            
            try
            {
                redirect = false;
                Label1.Text = "Error. Please try again\nIf registering, try a different username";
                xmpp.Close();
            }
            catch
            {
                throw ex;
            }
        }

        

        private void Xmpp_OnRegisterError(object sender, agsXMPP.Xml.Dom.Element e)
        {
            
            try
            {
                Label2.Text = "Error on registration";
                redirect = false;
               //Response.Write("onregerror");
                
                
            }
            catch
            {

            }
            
        }

        private void Xmpp_OnLogin(object sender)
        {
            
            redirect = true;
 
        }

        private void Xmpp_OnRegistered(object sender)
        {
            try
            {
                Label2.Text="Sucessfully Registered";
                redirect = true;
                
            }
            catch {
                
            }
            
        }
    }


    
}
