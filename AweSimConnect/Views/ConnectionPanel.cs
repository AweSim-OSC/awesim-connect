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

        private ProcessData processData;
        private string userPass;
        
        internal ConnectionPanel(Connection inputConnection, string userPass)
        {
            InitializeComponent();
            connection = inputConnection;
            pc = new PuTTYController(connection);
            pc.StartPlinkProcess(userPass);
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            if (processData.IsRunning())
            {
                processData.Process.Kill();
            }
        }

        private void buttonConnection_Click(object sender, EventArgs e)
        {

        }

        private void timerConnectionPanel_Tick(object sender, EventArgs e)
        {

        }

        internal ProcessData GetProcessData()
        {
            return processData;
        }
    }
}
