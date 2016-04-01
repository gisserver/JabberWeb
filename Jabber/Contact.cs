using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jabber
{
    public class Contact
    {
        private string name = "";
        private string presence = "";
        private string server = "";
        private string type = "";
        private string full = "";

        public string JID_Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public string JID_Presence
        {
            get
            {
                return this.presence;
            }
            set
            {
                this.presence = value;
            }
        }
        public string JID_Server
        {
            get
            {
                return this.server;
            }
            set
            {
                this.server = value;
            }
        }
        public string JID_Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
        public string JID_Full
        {
            get
            {
                return this.full;
            }
            set
            {
                this.full = value;
            }
        }


    }
}