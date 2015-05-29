namespace AweSimConnect
{
    partial class AweSimMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AweSimMain));
            this.pbAweSimLogo = new System.Windows.Forms.PictureBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lUsername = new System.Windows.Forms.Label();
            this.lPassword = new System.Windows.Forms.Label();
            this.cbCluster = new System.Windows.Forms.ComboBox();
            this.lCluster = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lRemotePort = new System.Windows.Forms.Label();
            this.tbRemotePort = new System.Windows.Forms.TextBox();
            this.lRedirect = new System.Windows.Forms.Label();
            this.tbLocalPort = new System.Windows.Forms.TextBox();
            this.hostLabel = new System.Windows.Forms.Label();
            this.bConnect = new System.Windows.Forms.Button();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelVNCPassword = new System.Windows.Forms.Label();
            this.bVNCConnect = new System.Windows.Forms.Button();
            this.tbVNCPassword = new System.Windows.Forms.TextBox();
            this.timerConnection = new System.Windows.Forms.Timer(this.components);
            this.tooltips = new System.Windows.Forms.ToolTip(this.components);
            this.bWeb = new System.Windows.Forms.Button();
            this.bSFTP = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelWeb = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelSFTP = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panelProcesses = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbTunnel = new System.Windows.Forms.PictureBox();
            this.pbNetwork = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbAweSimLogo)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTunnel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNetwork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // pbAweSimLogo
            // 
            this.pbAweSimLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbAweSimLogo.Image = global::AweSimConnect.Properties.Resources.awesimsm;
            this.pbAweSimLogo.Location = new System.Drawing.Point(30, 12);
            this.pbAweSimLogo.Name = "pbAweSimLogo";
            this.pbAweSimLogo.Size = new System.Drawing.Size(200, 84);
            this.pbAweSimLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbAweSimLogo.TabIndex = 1;
            this.pbAweSimLogo.TabStop = false;
            this.tooltips.SetToolTip(this.pbAweSimLogo, "Click to visit the AweSim Dashboard.");
            this.pbAweSimLogo.Click += new System.EventHandler(this.pbAweSimLogo_Click);
            // 
            // tbUserName
            // 
            this.tbUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUserName.Location = new System.Drawing.Point(324, 14);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(125, 20);
            this.tbUserName.TabIndex = 1;
            this.tbUserName.Tag = "Username";
            this.tooltips.SetToolTip(this.tbUserName, "Your AweSim user name.\r\n\r\nGet yours at http://www.awesim.org");
            this.tbUserName.TextChanged += new System.EventHandler(this.tbUserName_TextChanged);
            // 
            // tbPassword
            // 
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPassword.Location = new System.Drawing.Point(324, 45);
            this.tbPassword.MaxLength = 200;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(125, 20);
            this.tbPassword.TabIndex = 2;
            this.tbPassword.Tag = "Password";
            this.tooltips.SetToolTip(this.tbPassword, "Your AweSim password.");
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // lUsername
            // 
            this.lUsername.AutoSize = true;
            this.lUsername.BackColor = System.Drawing.Color.Transparent;
            this.lUsername.Location = new System.Drawing.Point(256, 16);
            this.lUsername.Name = "lUsername";
            this.lUsername.Size = new System.Drawing.Size(58, 13);
            this.lUsername.TabIndex = 4;
            this.lUsername.Text = "Username:";
            // 
            // lPassword
            // 
            this.lPassword.AutoSize = true;
            this.lPassword.BackColor = System.Drawing.Color.Transparent;
            this.lPassword.Location = new System.Drawing.Point(258, 47);
            this.lPassword.Name = "lPassword";
            this.lPassword.Size = new System.Drawing.Size(56, 13);
            this.lPassword.TabIndex = 5;
            this.lPassword.Text = "Password:";
            // 
            // cbCluster
            // 
            this.cbCluster.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCluster.DisplayMember = "Name";
            this.cbCluster.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCluster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCluster.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCluster.FormattingEnabled = true;
            this.cbCluster.Location = new System.Drawing.Point(324, 76);
            this.cbCluster.Name = "cbCluster";
            this.cbCluster.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbCluster.Size = new System.Drawing.Size(127, 23);
            this.cbCluster.TabIndex = 3;
            this.cbCluster.Tag = "Cluster";
            this.tooltips.SetToolTip(this.cbCluster, "The SSH host.\r\n\r\nDefault: oakley.osc.edu");
            this.cbCluster.ValueMember = "Name";
            this.cbCluster.SelectedIndexChanged += new System.EventHandler(this.cbCluster_SelectedIndexChanged);
            // 
            // lCluster
            // 
            this.lCluster.AutoSize = true;
            this.lCluster.BackColor = System.Drawing.Color.Transparent;
            this.lCluster.Location = new System.Drawing.Point(257, 81);
            this.lCluster.Name = "lCluster";
            this.lCluster.Size = new System.Drawing.Size(57, 13);
            this.lCluster.TabIndex = 7;
            this.lCluster.Text = "SSH Host:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.lRemotePort);
            this.groupBox1.Controls.Add(this.tbRemotePort);
            this.groupBox1.Controls.Add(this.lRedirect);
            this.groupBox1.Controls.Add(this.tbLocalPort);
            this.groupBox1.Controls.Add(this.hostLabel);
            this.groupBox1.Controls.Add(this.bConnect);
            this.groupBox1.Controls.Add(this.tbHost);
            this.groupBox1.Location = new System.Drawing.Point(12, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 63);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::AweSimConnect.Properties.Resources.network_socket;
            this.pictureBox4.Location = new System.Drawing.Point(18, 15);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(39, 38);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 14;
            this.pictureBox4.TabStop = false;
            // 
            // lRemotePort
            // 
            this.lRemotePort.AutoSize = true;
            this.lRemotePort.Location = new System.Drawing.Point(73, 14);
            this.lRemotePort.Name = "lRemotePort";
            this.lRemotePort.Size = new System.Drawing.Size(66, 13);
            this.lRemotePort.TabIndex = 17;
            this.lRemotePort.Text = "Remote Port";
            // 
            // tbRemotePort
            // 
            this.tbRemotePort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRemotePort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRemotePort.Location = new System.Drawing.Point(82, 30);
            this.tbRemotePort.Name = "tbRemotePort";
            this.tbRemotePort.Size = new System.Drawing.Size(45, 22);
            this.tbRemotePort.TabIndex = 4;
            this.tbRemotePort.Tag = "Remote Port";
            this.tbRemotePort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tooltips.SetToolTip(this.tbRemotePort, "The remote port of the resource to connect to. Ex: 5901");
            this.tbRemotePort.TextChanged += new System.EventHandler(this.tbRemotePort_TextChanged);
            // 
            // lRedirect
            // 
            this.lRedirect.AutoSize = true;
            this.lRedirect.Location = new System.Drawing.Point(275, 14);
            this.lRedirect.Name = "lRedirect";
            this.lRedirect.Size = new System.Drawing.Size(55, 13);
            this.lRedirect.TabIndex = 15;
            this.lRedirect.Text = "Local Port";
            // 
            // tbLocalPort
            // 
            this.tbLocalPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLocalPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLocalPort.Location = new System.Drawing.Point(279, 30);
            this.tbLocalPort.Name = "tbLocalPort";
            this.tbLocalPort.Size = new System.Drawing.Size(45, 22);
            this.tbLocalPort.TabIndex = 6;
            this.tbLocalPort.Tag = "Local Port";
            this.tbLocalPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tooltips.SetToolTip(this.tbLocalPort, "The port to map to your local machine. \r\n\r\nExample: 5901 for VNC or 8080 for brow" +
        "ser tunneling.");
            this.tbLocalPort.TextChanged += new System.EventHandler(this.tbRedirect_TextChanged);
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.Location = new System.Drawing.Point(189, 14);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(29, 13);
            this.hostLabel.TabIndex = 12;
            this.hostLabel.Tag = "Host";
            this.hostLabel.Text = "Host";
            // 
            // bConnect
            // 
            this.bConnect.Location = new System.Drawing.Point(348, 19);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(89, 34);
            this.bConnect.TabIndex = 7;
            this.bConnect.Text = "Connect";
            this.tooltips.SetToolTip(this.bConnect, "Enter your connection information and click here to establish a secure connection" +
        " to AweSim servers.");
            this.bConnect.UseVisualStyleBackColor = false;
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // tbHost
            // 
            this.tbHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHost.Location = new System.Drawing.Point(133, 30);
            this.tbHost.MaxLength = 300;
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(140, 22);
            this.tbHost.TabIndex = 5;
            this.tbHost.Tag = "Host";
            this.tbHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tooltips.SetToolTip(this.tbHost, "The host name of your requested node. Get this from the AweSim Dashboard.\r\n\r\nEx: " +
        "n231.ten.osc.edu");
            this.tbHost.TextChanged += new System.EventHandler(this.tbHost_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.labelVNCPassword);
            this.groupBox2.Controls.Add(this.bVNCConnect);
            this.groupBox2.Controls.Add(this.tbVNCPassword);
            this.groupBox2.Location = new System.Drawing.Point(12, 241);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(458, 62);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AweSimConnect.Properties.Resources.monitor;
            this.pictureBox1.Location = new System.Drawing.Point(18, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // labelVNCPassword
            // 
            this.labelVNCPassword.AutoSize = true;
            this.labelVNCPassword.Location = new System.Drawing.Point(167, 15);
            this.labelVNCPassword.Name = "labelVNCPassword";
            this.labelVNCPassword.Size = new System.Drawing.Size(78, 13);
            this.labelVNCPassword.TabIndex = 12;
            this.labelVNCPassword.Tag = "Host";
            this.labelVNCPassword.Text = "VNC Password";
            // 
            // bVNCConnect
            // 
            this.bVNCConnect.Location = new System.Drawing.Point(348, 19);
            this.bVNCConnect.Name = "bVNCConnect";
            this.bVNCConnect.Size = new System.Drawing.Size(89, 34);
            this.bVNCConnect.TabIndex = 9;
            this.bVNCConnect.Text = "Launch VNC";
            this.tooltips.SetToolTip(this.bVNCConnect, "Click to launch a VNC Connection");
            this.bVNCConnect.UseVisualStyleBackColor = false;
            this.bVNCConnect.Click += new System.EventHandler(this.bVNCConnect_Click);
            // 
            // tbVNCPassword
            // 
            this.tbVNCPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbVNCPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVNCPassword.Location = new System.Drawing.Point(133, 31);
            this.tbVNCPassword.MaxLength = 300;
            this.tbVNCPassword.Name = "tbVNCPassword";
            this.tbVNCPassword.Size = new System.Drawing.Size(140, 22);
            this.tbVNCPassword.TabIndex = 8;
            this.tbVNCPassword.Tag = "VNC Password";
            this.tbVNCPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tooltips.SetToolTip(this.tbVNCPassword, "The 8 character password associated with your node.");
            this.tbVNCPassword.TextChanged += new System.EventHandler(this.tbVNCPassword_TextChanged);
            this.tbVNCPassword.Enter += new System.EventHandler(this.tbVNCPassword_Enter);
            this.tbVNCPassword.Leave += new System.EventHandler(this.tbVNCPassword_Leave);
            // 
            // timerConnection
            // 
            this.timerConnection.Interval = 1000;
            this.timerConnection.Tag = "timer";
            this.timerConnection.Tick += new System.EventHandler(this.timerConnection_Tick);
            // 
            // tooltips
            // 
            this.tooltips.AutoPopDelay = 5000;
            this.tooltips.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tooltips.InitialDelay = 2000;
            this.tooltips.IsBalloon = true;
            this.tooltips.ReshowDelay = 100;
            // 
            // bWeb
            // 
            this.bWeb.Location = new System.Drawing.Point(348, 19);
            this.bWeb.Name = "bWeb";
            this.bWeb.Size = new System.Drawing.Size(89, 34);
            this.bWeb.TabIndex = 9;
            this.bWeb.Text = "Launch Web";
            this.tooltips.SetToolTip(this.bWeb, "Click to launch a Browser Session");
            this.bWeb.UseVisualStyleBackColor = false;
            this.bWeb.Click += new System.EventHandler(this.bWeb_Click);
            // 
            // bSFTP
            // 
            this.bSFTP.Location = new System.Drawing.Point(348, 19);
            this.bSFTP.Name = "bSFTP";
            this.bSFTP.Size = new System.Drawing.Size(89, 34);
            this.bSFTP.TabIndex = 9;
            this.bSFTP.Text = "Launch SFTP";
            this.tooltips.SetToolTip(this.bSFTP, "Click to launch an SFTP connection (if installed)");
            this.bSFTP.UseVisualStyleBackColor = false;
            this.bSFTP.Click += new System.EventHandler(this.bSFTP_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.labelWeb);
            this.groupBox3.Controls.Add(this.pictureBox2);
            this.groupBox3.Controls.Add(this.bWeb);
            this.groupBox3.Location = new System.Drawing.Point(12, 309);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(458, 62);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::AweSimConnect.Properties.Resources.window;
            this.pictureBox2.Location = new System.Drawing.Point(18, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(39, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // labelWeb
            // 
            this.labelWeb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWeb.AutoSize = true;
            this.labelWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWeb.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelWeb.Location = new System.Drawing.Point(105, 22);
            this.labelWeb.Name = "labelWeb";
            this.labelWeb.Size = new System.Drawing.Size(101, 24);
            this.labelWeb.TabIndex = 13;
            this.labelWeb.Text = "Web Label";
            this.labelWeb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.labelSFTP);
            this.groupBox4.Controls.Add(this.pictureBox3);
            this.groupBox4.Controls.Add(this.bSFTP);
            this.groupBox4.Location = new System.Drawing.Point(12, 377);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(458, 62);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            // 
            // labelSFTP
            // 
            this.labelSFTP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSFTP.AutoSize = true;
            this.labelSFTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSFTP.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelSFTP.Location = new System.Drawing.Point(105, 22);
            this.labelSFTP.Name = "labelSFTP";
            this.labelSFTP.Size = new System.Drawing.Size(109, 24);
            this.labelSFTP.TabIndex = 16;
            this.labelSFTP.Text = "SFTP Label";
            this.labelSFTP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::AweSimConnect.Properties.Resources.hard_disk;
            this.pictureBox3.Location = new System.Drawing.Point(18, 15);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(39, 38);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // panelProcesses
            // 
            this.panelProcesses.Location = new System.Drawing.Point(15, 449);
            this.panelProcesses.Name = "panelProcesses";
            this.panelProcesses.Size = new System.Drawing.Size(452, 342);
            this.panelProcesses.TabIndex = 14;
            this.panelProcesses.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.pbTunnel);
            this.groupBox5.Controls.Add(this.pbNetwork);
            this.groupBox5.Controls.Add(this.pictureBox5);
            this.groupBox5.Location = new System.Drawing.Point(12, 175);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(458, 62);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(256, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 24);
            this.label2.TabIndex = 18;
            this.label2.Text = "Secure Tunnel";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(125, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "Network";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbTunnel
            // 
            this.pbTunnel.Image = global::AweSimConnect.Properties.Resources.redlight;
            this.pbTunnel.Location = new System.Drawing.Point(226, 23);
            this.pbTunnel.Name = "pbTunnel";
            this.pbTunnel.Size = new System.Drawing.Size(24, 24);
            this.pbTunnel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTunnel.TabIndex = 17;
            this.pbTunnel.TabStop = false;
            // 
            // pbNetwork
            // 
            this.pbNetwork.Image = global::AweSimConnect.Properties.Resources.redlight;
            this.pbNetwork.Location = new System.Drawing.Point(95, 23);
            this.pbNetwork.Name = "pbNetwork";
            this.pbNetwork.Size = new System.Drawing.Size(24, 24);
            this.pbNetwork.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNetwork.TabIndex = 16;
            this.pbNetwork.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::AweSimConnect.Properties.Resources.plug;
            this.pictureBox5.Location = new System.Drawing.Point(18, 15);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(39, 38);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 15;
            this.pictureBox5.TabStop = false;
            // 
            // AweSimMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::AweSimConnect.Properties.Resources.header;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(479, 447);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.panelProcesses);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lPassword);
            this.Controls.Add(this.lCluster);
            this.Controls.Add(this.lUsername);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.cbCluster);
            this.Controls.Add(this.pbAweSimLogo);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AweSimMain";
            this.Text = "AweSim Connect";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AweSimMain_FormClosing);
            this.Load += new System.EventHandler(this.AweSimMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbAweSimLogo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTunnel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNetwork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbAweSimLogo;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lUsername;
        private System.Windows.Forms.Label lPassword;
        private System.Windows.Forms.ComboBox cbCluster;
        private System.Windows.Forms.Label lCluster;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bConnect;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.TextBox tbLocalPort;
        private System.Windows.Forms.Label lRedirect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelVNCPassword;
        private System.Windows.Forms.Button bVNCConnect;
        private System.Windows.Forms.TextBox tbVNCPassword;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.Timer timerConnection;
        private System.Windows.Forms.Label lRemotePort;
        private System.Windows.Forms.TextBox tbRemotePort;
        private System.Windows.Forms.ToolTip tooltips;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bWeb;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button bSFTP;
        private System.Windows.Forms.Panel panelProcesses;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label labelWeb;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbTunnel;
        private System.Windows.Forms.PictureBox pbNetwork;
        private System.Windows.Forms.Label labelSFTP;

    }
}

