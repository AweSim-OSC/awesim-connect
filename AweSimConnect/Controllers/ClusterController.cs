using AweSimConnect.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AweSimConnect.Controllers
{    
    class ClusterController
    {
        static Cluster oakley = new Cluster("OAK", "Oakley", "oakley.osc.edu");
        static Cluster ruby = new Cluster("RBY", "Ruby", "ruby.osc.edu");
        static Cluster glenn = new Cluster("OPT", "Glenn", "glenn.osc.edu");

        private Cluster selectedCluster;

        public ClusterController()
        {
            this.selectedCluster = oakley;
        }

        public void SetCluster(String code) {
            if (code.Equals(ruby.Code)) {
                this.selectedCluster = ruby;
            } else if (code.Equals(glenn.Code)) {
                this.selectedCluster = glenn;
            } else {
                this.selectedCluster = oakley;
            }
        }

        public Cluster GetCluster() {
            return this.selectedCluster;
        }

        public String ClusterName()
        {
            return this.selectedCluster.Name;
        }

        public String ClusterDomain()
        {
            return this.selectedCluster.Domain;
        }

        public List<Cluster> GetClusterList()
        {
            List<Cluster> list = new List<Cluster>();
            list.Add(oakley);
            list.Add(ruby);
            list.Add(glenn);
            return list;
        }
    }
}
