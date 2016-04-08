using OSCConnect.Models;
using System;
using System.Collections.Generic;

namespace OSCConnect.Controllers
{
    /// <summary>
    /// Store data on available OSC clusters
    /// </summary>
    class OSCClusterController
    {
        public enum Cluster
        {
            OAKLEY,
            RUBY,
            GLENN
        }

        // SSH Nodes
        static OSCCluster oakley = new OSCCluster("OAK", "Oakley", "oakley.osc.edu");
        static OSCCluster ruby = new OSCCluster("RBY", "Ruby", "ruby.osc.edu");
        static OSCCluster glenn = new OSCCluster("OPT", "Glenn", "glenn.osc.edu");

        // Other Hosts
        public static OSCCluster SFTP_CLUSTER = new OSCCluster("FTP", "SFTP", "sftp.osc.edu");
        public static OSCCluster SCP_CLUSTER = new OSCCluster("SCP", "SCP", "scp.osc.edu");

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

        public void SetCluster(string code)
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
        public void SetCluster(Cluster cluster)
        {
            switch (cluster)
            {
                case Cluster.OAKLEY:
                    this.selectedCluster = oakley;
                    break;
                case Cluster.RUBY:
                    this.selectedCluster = ruby;
                    break;
                case Cluster.GLENN:
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

        public OSCCluster GetCluster(string code)
        {
            foreach (var cluster in clusterList)
            {
                if (cluster.Code.Equals(code))
                {
                    return cluster;
                }
            }
            return GetCluster();
        }

        // Gets the currently selected cluster.
        public OSCCluster GetCluster()
        {
            return this.selectedCluster;
        }

        // Returns the name of the currently selected cluster.
        public string ClusterName()
        {
            return this.selectedCluster.Name;
        }

        // Returns the domain name of the currently selected cluster.
        public string ClusterDomain()
        {
            return this.selectedCluster.Domain;
        }

        // Returns the default list of clusters being managed by the controller.
        public List<OSCCluster> GetClusterList()
        {
            return this.clusterList;
        }

        public string GetDomainAtIndex(int index)
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
