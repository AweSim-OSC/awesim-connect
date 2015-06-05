using System;
using System.Windows.Forms;
using AweSimConnect.Controllers;
using AweSimConnect.Models;

namespace AweSimConnect.Views
{
    public partial class ConnectionPanel : UserControl
    {
        private Connection connection;
        private PuTTYController pc;

        internal ConnectionPanel(Connection inputConnection)
        {
            InitializeComponent();
            connection = inputConnection;
            labelSession.Text = connection.GetServerAndPort();
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {

        }

        private void buttonConnection_Click(object sender, EventArgs e)
        {

        }

        private void timerConnectionPanel_Tick(object sender, EventArgs e)
        {

        }
    }
}
