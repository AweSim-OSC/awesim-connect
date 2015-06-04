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
        
        internal ConnectionForm(Models.Connection connection)
        {
            InitializeComponent();
            this.connection = connection;
           
        }

        private void ConnectionForm_Load(object sender, EventArgs e)
        {
            this.Controls.Add(new ConnectionPanel(connection));
        }
    }
}
