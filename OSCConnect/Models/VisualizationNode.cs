using System.Collections.Generic;

namespace OSCConnect.Models
{
    class VisualizationNode
    {
        private List<VisualizationNode> nodes;

        private string _publicHost;
        private string _privateHost;

        private VisualizationNode(string publicHost, string privateHost)
        {
            _publicHost = publicHost;
            _privateHost = privateHost;
        }

        /// <summary>
        /// Builds a list of visualization nodes to be checked and remapped to the internal hosts.
        /// </summary>
        public VisualizationNode()
        {
            nodes = new List<VisualizationNode>
            {
                new VisualizationNode("vis033.osc.edu", "opt2647.ten.osc.edu"),
                new VisualizationNode("vis034.osc.edu", "opt2648.ten.osc.edu"),
                new VisualizationNode("vis035.osc.edu", "opt2649.ten.osc.edu"),
                new VisualizationNode("vis036.osc.edu", "opt2650.ten.osc.edu"),
                new VisualizationNode("oak-vis001.osc.edu", "n0691.ten.osc.edu"),
                new VisualizationNode("oak-vis002.osc.edu", "n0692.ten.osc.edu")
            };
        }

        /// <summary>
        /// Checks the user-submitted host against the list of knows vis nodes.
        /// If the node is found, it swaps with the internal mapping, otherwise
        /// it returns the original.
        /// </summary>
        /// <param name="host">The host to be remapped.</param>
        /// <returns>The internal vis node mapping if found.</returns>
        public string RemapPublicHostToInternalHost(string host)
        {
            string checkHost = host;
            foreach (var node in nodes)
            {
                if (node._publicHost.Equals(checkHost))
                    checkHost = node._privateHost;
            }
            return checkHost;
        }
    }
}
