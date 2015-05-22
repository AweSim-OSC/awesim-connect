using System;
using System.Collections.Generic;
using System.Text;

namespace AweSimConnect.Models
{
    /*
     * Stores data on the supercompute cluster. 
     */
    class Cluster
    {
        public Cluster(string code, string name, string domain)
        {
            this.Code = code;
            this.Name = name;
            this.Domain = domain;
        }

        private String code;

        public String Code
        {
            get { return code; }
            set { code = value; }
        }

        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private String domain;

        public String Domain
        {
            get { return domain; }
            set { domain = value; }
        }
    }
}
