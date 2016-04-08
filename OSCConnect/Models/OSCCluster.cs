using System;

namespace OSCConnect.Models
{
    /// <summary>
    /// Contains data about compute clusters.
    /// </summary>
    class OSCCluster
    {
        public OSCCluster(string code, string name, string domain)
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

        public override string ToString()
        {
            return domain;
        }
    }
}
