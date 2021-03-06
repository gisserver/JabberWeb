﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using agsXMPP;
using System.IO;

namespace Jabber
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }
        void Session_Start() {
            Response.Write("Session Started");
            System.Diagnostics.Debug.WriteLine("Session started");
            Session["Session_ID"] = Guid.NewGuid();

        }
        void Session_End()
        {
            System.Diagnostics.Debug.WriteLine("Session ended");
            
                         
            
        }
    }
}