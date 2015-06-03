using AweSimConnect.Models;
using System;
using System.Collections.Generic;

namespace AweSimConnect.Controllers
{
    /// <summary>
    /// Store data on available OSC clusters
    /// </summary>
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
        public void SetCluster(Cluster cluster)
        {
            this.selectedCluster = cluster;
        }

        // Gets the currently selected cluster.
        public Cluster GetCluster()
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
            catch (Exception)
            {
                return selectedCluster.Domain;
            }
        }

        public Cluster GetClusterAtIndex(int index)
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
