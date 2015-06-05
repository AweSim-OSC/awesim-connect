using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AweSimConnect.Views
{
    public partial class ConnectionForm : Form
    {
        private Models.Connection connection;
        private string userPass;
        private ConnectionPanel panel;
        
        internal ConnectionForm(Models.Connection connection, string userPass)
        {
            InitializeComponent();
            this.connection = connection;
            this.userPass = userPass;
        }

        private void ConnectionForm_Load(object sender, EventArgs e)
        {
            panel = new ConnectionPanel(connection, userPass);
            this.Controls.Add(panel);
        }

        private void ConnectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            panel.buttonDisconnect_Click(sender, e);
        }
    }
}
