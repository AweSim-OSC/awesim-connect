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

        private List<Cluster> clusterList;

        public ClusterController()
        {
            init(oakley);
        }

        public ClusterController(Cluster selected)
        {
            init(selected);
        }

        private void init(Cluster selected)
        {
            List<Cluster> list = new List<Cluster>();
            list.Add(oakley);
            list.Add(ruby);
            list.Add(glenn);

            this.clusterList = list;
            this.selectedCluster = selected;
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

        public void SetCluster(Cluster cluster)
        {
            this.selectedCluster = cluster;
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
            return this.clusterList;
        }

        public String GetDomainAtIndex(int index)
        {
            try
            {
                return clusterList[index].Domain;
            }
            catch (Exception ex)
            {
                return selectedCluster.Domain;
            }
        }
    }
}
