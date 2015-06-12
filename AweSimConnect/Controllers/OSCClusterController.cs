using AweSimConnect.Models;
using System;
using System.Collections.Generic;

namespace AweSimConnect.Controllers
{
    /// <summary>
    /// Store data on available OSC clusters
    /// </summary>
    class OSCClusterController
    {
        static OSCCluster oakley = new OSCCluster("OAK", "Oakley", "oakley.osc.edu");
        static OSCCluster ruby = new OSCCluster("RBY", "Ruby", "ruby.osc.edu");
        static OSCCluster glenn = new OSCCluster("OPT", "Glenn", "glenn.osc.edu");

        private OSCCluster selectedCluster;

        private List<OSCCluster> clusterList;

        public OSCClusterController()
        {
            init(oakley);
        }

        public OSCClusterController(OSCCluster selected)
        {
            init(selected);
        }

        private void init(OSCCluster selected)
        {
            List<OSCCluster> list = new List<OSCCluster>();
            list.Add(oakley);  // Index 0
            list.Add(ruby);    // Index 1
            list.Add(glenn);   // Index 2

            this.clusterList = list;
            this.selectedCluster = selected;
        }

        public void SetCluster(String code)
        {
            if (code.Equals(ruby.Code))
            {
                this.selectedCluster = ruby;
            }
            else if (code.Equals(glenn.Code))
            {
                this.selectedCluster = glenn;
            }
            else
            {
                this.selectedCluster = oakley;
            }
        }

        //This is just here to map the servers to numbers so I don't have to worry about what the index is.
        // 1 = Oakley
        // 2 = Ruby
        // 3 = Glenn
        // Default = Oakley
        public void SetCluster(int pos)
        {
            switch (pos)
            {
                case 1:
                    this.selectedCluster = oakley;
                    break;
                case 2:
                    this.selectedCluster = ruby;
                    break;
                case 3:
                    this.selectedCluster = glenn;
                    break;
                default:
                    this.selectedCluster = oakley;
                    break;
            }
        }

        //Sets the cluster to a user specified cluster (future proofing)
        public void SetCluster(OSCCluster cluster)
        {
            this.selectedCluster = cluster;
        }

        // Gets the currently selected cluster.
        public OSCCluster GetCluster()
        {
            return this.selectedCluster;
        }

        // Returns the name of the currently selected cluster.
        public String ClusterName()
        {
            return this.selectedCluster.Name;
        }

        // Returns the domain name of the currently selected cluster.
        public String ClusterDomain()
        {
            return this.selectedCluster.Domain;
        }

        // Returns the default list of clusters being managed by the controller.
        public List<OSCCluster> GetClusterList()
        {
            return this.clusterList;
        }

        public String GetDomainAtIndex(int index)
        {
            try
            {
                return clusterList[index].Domain;
            }
            catch (Exception)
            {
                return selectedCluster.Domain;
            }
        }

        public OSCCluster GetClusterAtIndex(int index)
        {
            try
            {
                return clusterList[index];
            }
            catch (Exception)
            {
                return clusterList[0];
            }
        }
    }
}
