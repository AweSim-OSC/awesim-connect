using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
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

        private Stopwatch stopwatch;

        private int ticks = 0;
        private bool tunnel_available;
        
        internal ConnectionPanel(Connection inputConnection, string userPass)
        {
            InitializeComponent();
            connection = inputConnection;
            pc = new PuTTYController(connection);
            pc.StartPlinkProcess(userPass);
            timerConnectionPanel.Start();
        }

        internal void buttonDisconnect_Click(object sender, EventArgs e)
        {
            timerConnectionPanel.Stop();
            GetProcessData();
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
            if (ticks%30 == 0)
            {
                CheckTunnel();
                EmbedProcess();
            }
            
            labelSession.Text = ticks.ToString();
            ticks++;
        }

        private void CheckTunnel()
        {
            tunnel_available = pc.IsPlinkConnected();
        }

        internal ProcessData GetProcessData()
        {
            SetProcessData();
            return processData;
        }

        internal void SetProcessData()
        {
            processData = new ProcessData(pc.GetThisProcess(), connection);
        }

        //TODO Move this block and associated dll calls into the panel. 

        internal void EmbedProcess()
        {
            //If the tunnel is connected and the process hasn't been embedded, pull it into the app.
            if (tunnel_available && !pc.IsProcessEmbedded())
            {
                SetProcessData();
                pc.EmbedProcess();

                //TODO: This is the only place these are used right now. Move them up or out if we need to.
                //int MAXIMIZE_WINDOW = 3;
                int MINIMIZE_WINDOW = 6;

                // TODO: getting an error here
                //ShowWindow(pc.GetThisProcess().MainWindowHandle, MINIMIZE_WINDOW);

                //TODO This command will embed the putty process in the main window. Hold off implementing until I can figure out how to test if tunnel is authenticated.
                SetParent(pc.GetThisProcess().MainWindowHandle, panelProcesses.Handle);


            }
        }

        // Used for embedding process into the app
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr windowHandle, int command);

        // Used for embedding process into the app

        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr windowChild, IntPtr windowParent);
    }
}
