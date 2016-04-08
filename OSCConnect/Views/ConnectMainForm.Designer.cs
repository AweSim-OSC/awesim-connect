namespace OSCConnect.Views
{
    partial class ConnectMainForm
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
            this.gbCredentials = new System.Windows.Forms.GroupBox();
            this.cbRememberMe = new System.Windows.Forms.CheckBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.gbSessionInfo = new System.Windows.Forms.GroupBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.lPort = new System.Windows.Forms.Label();
            this.lHost = new System.Windows.Forms.Label();
            this.tbVNCPassword = new System.Windows.Forms.TextBox();
            this.rbVNC = new System.Windows.Forms.RadioButton();
            this.rbBROWSER = new System.Windows.Forms.RadioButton();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.toolTipNoDelay = new System.Windows.Forms.ToolTip(this.components);
            this.buttonInfo = new System.Windows.Forms.Button();
            this.buttonAdvanced = new System.Windows.Forms.Button();
            this.buttonConsole = new System.Windows.Forms.Button();
            this.bConnect = new System.Windows.Forms.Button();
            this.bSFTP = new System.Windows.Forms.Button();
            this.bDashboard = new System.Windows.Forms.Button();
            this.gbSessionType = new System.Windows.Forms.GroupBox();
            this.gbVNCPassword = new System.Windows.Forms.GroupBox();
            this.gbSystem = new System.Windows.Forms.GroupBox();
            this.lConnectionStatus = new System.Windows.Forms.Label();
            this.pbIsNetworkConnected = new System.Windows.Forms.PictureBox();
            this.gbSFTP = new System.Windows.Forms.GroupBox();
            this.gbConnect = new System.Windows.Forms.GroupBox();
            this.gbConsole = new System.Windows.Forms.GroupBox();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.gbAbout = new System.Windows.Forms.GroupBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.linkLabelNewVersion = new System.Windows.Forms.LinkLabel();
            this.gbCredentials.SuspendLayout();
            this.gbSessionInfo.SuspendLayout();
            this.gbSessionType.SuspendLayout();
            this.gbVNCPassword.SuspendLayout();
            this.gbSystem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIsNetworkConnected)).BeginInit();
            this.gbSFTP.SuspendLayout();
            this.gbConnect.SuspendLayout();
            this.gbConsole.SuspendLayout();
            this.gbSettings.SuspendLayout();
            this.gbAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCredentials
            // 
            this.gbCredentials.Controls.Add(this.cbRememberMe);
            this.gbCredentials.Controls.Add(this.tbPassword);
            this.gbCredentials.Controls.Add(this.tbUsername);
            this.gbCredentials.Controls.Add(this.labelPassword);
            this.gbCredentials.Controls.Add(this.labelUsername);
            this.gbCredentials.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gbCredentials.Location = new System.Drawing.Point(18, 215);
            this.gbCredentials.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbCredentials.Name = "gbCredentials";
            this.gbCredentials.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbCredentials.Size = new System.Drawing.Size(231, 200);
            this.gbCredentials.TabIndex = 2;
            this.gbCredentials.TabStop = false;
            this.gbCredentials.Text = "1. AweSim Credentials";
            this.toolTipNoDelay.SetToolTip(this.gbCredentials, "Your AweSim Username and Password.");
            // 
            // cbRememberMe
            // 
            this.cbRememberMe.AutoSize = true;
            this.cbRememberMe.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.cbRememberMe.Location = new System.Drawing.Point(9, 165);
            this.cbRememberMe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbRememberMe.Name = "cbRememberMe";
            this.cbRememberMe.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbRememberMe.Size = new System.Drawing.Size(133, 24);
            this.cbRememberMe.TabIndex = 5;
            this.cbRememberMe.Text = "Remember Me";
            this.cbRememberMe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbRememberMe.UseVisualStyleBackColor = true;
            this.cbRememberMe.CheckedChanged += new System.EventHandler(this.cbRememberMe_CheckedChanged);
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(9, 115);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPassword.MaxLength = 255;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(211, 26);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.Tag = "Password";
            this.tbPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipNoDelay.SetToolTip(this.tbPassword, "Enter your AweSim password.");
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsername.Location = new System.Drawing.Point(9, 48);
            this.tbUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbUsername.MaxLength = 255;
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(211, 26);
            this.tbUsername.TabIndex = 2;
            this.tbUsername.Tag = "Username";
            this.tbUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipNoDelay.SetToolTip(this.tbUsername, "Enter your AweSim username.");
            this.tbUsername.TextChanged += new System.EventHandler(this.tbUsername_TextChanged);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.BackColor = System.Drawing.Color.Transparent;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.labelPassword.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelPassword.Location = new System.Drawing.Point(76, 91);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Password";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.BackColor = System.Drawing.Color.Transparent;
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelUsername.Location = new System.Drawing.Point(76, 23);
            this.labelUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(55, 13);
            this.labelUsername.TabIndex = 3;
            this.labelUsername.Text = "Username";
            // 
            // gbSessionInfo
            // 
            this.gbSessionInfo.Controls.Add(this.tbPort);
            this.gbSessionInfo.Controls.Add(this.tbHost);
            this.gbSessionInfo.Controls.Add(this.lPort);
            this.gbSessionInfo.Controls.Add(this.lHost);
            this.gbSessionInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gbSessionInfo.Location = new System.Drawing.Point(18, 526);
            this.gbSessionInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbSessionInfo.Name = "gbSessionInfo";
            this.gbSessionInfo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbSessionInfo.Size = new System.Drawing.Size(231, 92);
            this.gbSessionInfo.TabIndex = 6;
            this.gbSessionInfo.TabStop = false;
            this.gbSessionInfo.Text = "3. Session Info";
            this.toolTipNoDelay.SetToolTip(this.gbSessionInfo, "Session Information. Get this by requesting a session at the AweSim Dashboard.");
            // 
            // tbPort
            // 
            this.tbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPort.Location = new System.Drawing.Point(174, 52);
            this.tbPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPort.MaxLength = 5;
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(46, 20);
            this.tbPort.TabIndex = 7;
            this.tbPort.Tag = "Port";
            this.tbPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipNoDelay.SetToolTip(this.tbPort, "The port number assigned to your session. (ex. 5901) Get this from your session i" +
        "nformation on the AweSim Dashboard.");
            this.tbPort.TextChanged += new System.EventHandler(this.tbPort_TextChanged);
            // 
            // tbHost
            // 
            this.tbHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHost.Location = new System.Drawing.Point(9, 52);
            this.tbHost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(154, 20);
            this.tbHost.TabIndex = 6;
            this.tbHost.Tag = "Host";
            this.tbHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipNoDelay.SetToolTip(this.tbHost, "The host name assigned to your session. (ex. n0103.ten.osc.edu) Get this from you" +
        "r session information on the AweSim Dashboard.");
            this.tbHost.TextChanged += new System.EventHandler(this.tbHost_TextChanged);
            // 
            // lPort
            // 
            this.lPort.AutoSize = true;
            this.lPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lPort.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lPort.Location = new System.Drawing.Point(178, 28);
            this.lPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lPort.Name = "lPort";
            this.lPort.Size = new System.Drawing.Size(26, 13);
            this.lPort.TabIndex = 4;
            this.lPort.Text = "Port";
            // 
            // lHost
            // 
            this.lHost.AutoSize = true;
            this.lHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lHost.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lHost.Location = new System.Drawing.Point(70, 28);
            this.lHost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lHost.Name = "lHost";
            this.lHost.Size = new System.Drawing.Size(29, 13);
            this.lHost.TabIndex = 3;
            this.lHost.Text = "Host";
            // 
            // tbVNCPassword
            // 
            this.tbVNCPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVNCPassword.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbVNCPassword.Location = new System.Drawing.Point(9, 25);
            this.tbVNCPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbVNCPassword.MaxLength = 8;
            this.tbVNCPassword.Name = "tbVNCPassword";
            this.tbVNCPassword.Size = new System.Drawing.Size(211, 20);
            this.tbVNCPassword.TabIndex = 9;
            this.tbVNCPassword.Tag = "VNC Password";
            this.tbVNCPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipNoDelay.SetToolTip(this.tbVNCPassword, "Enter the 8-character VNC password generated by the session.");
            this.tbVNCPassword.TextChanged += new System.EventHandler(this.tbVNCPassword_TextChanged);
            // 
            // rbVNC
            // 
            this.rbVNC.AutoSize = true;
            this.rbVNC.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rbVNC.Location = new System.Drawing.Point(9, 26);
            this.rbVNC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbVNC.Name = "rbVNC";
            this.rbVNC.Size = new System.Drawing.Size(164, 24);
            this.rbVNC.TabIndex = 4;
            this.rbVNC.TabStop = true;
            this.rbVNC.Tag = "VNC Radio Button";
            this.rbVNC.Text = "iHPC VNC Desktop";
            this.toolTipNoDelay.SetToolTip(this.rbVNC, "Click this button to access an iHPC/VNC Session");
            this.rbVNC.UseVisualStyleBackColor = true;
            this.rbVNC.CheckedChanged += new System.EventHandler(this.rbVNC_CheckedChanged);
            // 
            // rbBROWSER
            // 
            this.rbBROWSER.AutoSize = true;
            this.rbBROWSER.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rbBROWSER.Location = new System.Drawing.Point(9, 57);
            this.rbBROWSER.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbBROWSER.Name = "rbBROWSER";
            this.rbBROWSER.Size = new System.Drawing.Size(183, 24);
            this.rbBROWSER.TabIndex = 5;
            this.rbBROWSER.TabStop = true;
            this.rbBROWSER.Tag = "BROWSER Radio Box";
            this.rbBROWSER.Text = "Web Browser Session";
            this.toolTipNoDelay.SetToolTip(this.rbBROWSER, "Click this button to use a browser-based session.");
            this.rbBROWSER.UseVisualStyleBackColor = true;
            this.rbBROWSER.CheckedChanged += new System.EventHandler(this.rbBROWSER_CheckedChanged);
            // 
            // timerMain
            // 
            this.timerMain.Interval = 300;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // toolTipNoDelay
            // 
            this.toolTipNoDelay.AutomaticDelay = 100;
            this.toolTipNoDelay.AutoPopDelay = 5000;
            this.toolTipNoDelay.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolTipNoDelay.InitialDelay = 100;
            this.toolTipNoDelay.ReshowDelay = 20;
            // 
            // buttonInfo
            // 
            this.buttonInfo.BackgroundImage = global::OSCConnect.Properties.Resources.info_gry;
            this.buttonInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonInfo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonInfo.FlatAppearance.BorderSize = 0;
            this.buttonInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.buttonInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInfo.Location = new System.Drawing.Point(10, 26);
            this.buttonInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(93, 91);
            this.buttonInfo.TabIndex = 2;
            this.toolTipNoDelay.SetToolTip(this.buttonInfo, "About");
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // buttonAdvanced
            // 
            this.buttonAdvanced.BackgroundImage = global::OSCConnect.Properties.Resources.officine2;
            this.buttonAdvanced.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAdvanced.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdvanced.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonAdvanced.FlatAppearance.BorderSize = 0;
            this.buttonAdvanced.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.buttonAdvanced.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonAdvanced.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdvanced.Location = new System.Drawing.Point(9, 25);
            this.buttonAdvanced.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAdvanced.Name = "buttonAdvanced";
            this.buttonAdvanced.Size = new System.Drawing.Size(93, 91);
            this.buttonAdvanced.TabIndex = 3;
            this.toolTipNoDelay.SetToolTip(this.buttonAdvanced, "Advanced Options");
            this.buttonAdvanced.UseVisualStyleBackColor = true;
            this.buttonAdvanced.Click += new System.EventHandler(this.buttonAdvanced_Click);
            // 
            // buttonConsole
            // 
            this.buttonConsole.BackColor = System.Drawing.Color.Transparent;
            this.buttonConsole.BackgroundImage = global::OSCConnect.Properties.Resources.console;
            this.buttonConsole.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonConsole.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonConsole.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonConsole.FlatAppearance.BorderSize = 0;
            this.buttonConsole.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.buttonConsole.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonConsole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConsole.ForeColor = System.Drawing.Color.White;
            this.buttonConsole.Location = new System.Drawing.Point(9, 26);
            this.buttonConsole.Margin = new System.Windows.Forms.Padding(0);
            this.buttonConsole.Name = "buttonConsole";
            this.buttonConsole.Size = new System.Drawing.Size(93, 91);
            this.buttonConsole.TabIndex = 12;
            this.buttonConsole.Tag = "Console";
            this.toolTipNoDelay.SetToolTip(this.buttonConsole, "Open a console session.");
            this.buttonConsole.UseVisualStyleBackColor = false;
            this.buttonConsole.Click += new System.EventHandler(this.buttonConsole_Click);
            // 
            // bConnect
            // 
            this.bConnect.BackColor = System.Drawing.Color.Transparent;
            this.bConnect.BackgroundImage = global::OSCConnect.Properties.Resources.bolt_gry;
            this.bConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bConnect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bConnect.FlatAppearance.BorderSize = 0;
            this.bConnect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bConnect.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bConnect.Location = new System.Drawing.Point(9, 32);
            this.bConnect.Margin = new System.Windows.Forms.Padding(0);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(213, 212);
            this.bConnect.TabIndex = 10;
            this.toolTipNoDelay.SetToolTip(this.bConnect, "Connect to Session. Enter your session information and click here to connect to t" +
        "he session.");
            this.bConnect.UseVisualStyleBackColor = true;
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // bSFTP
            // 
            this.bSFTP.BackColor = System.Drawing.Color.Transparent;
            this.bSFTP.BackgroundImage = global::OSCConnect.Properties.Resources.hdd_gry;
            this.bSFTP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bSFTP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bSFTP.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bSFTP.FlatAppearance.BorderSize = 0;
            this.bSFTP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bSFTP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bSFTP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSFTP.ForeColor = System.Drawing.Color.White;
            this.bSFTP.Location = new System.Drawing.Point(10, 23);
            this.bSFTP.Margin = new System.Windows.Forms.Padding(0);
            this.bSFTP.Name = "bSFTP";
            this.bSFTP.Size = new System.Drawing.Size(93, 91);
            this.bSFTP.TabIndex = 11;
            this.bSFTP.Tag = "File Transfer";
            this.toolTipNoDelay.SetToolTip(this.bSFTP, "File Transfer. Enter your user credentials and click here to open an SFTP file tr" +
        "ansfer session.");
            this.bSFTP.UseVisualStyleBackColor = false;
            this.bSFTP.Click += new System.EventHandler(this.buttonSFTP_Click);
            // 
            // bDashboard
            // 
            this.bDashboard.BackColor = System.Drawing.Color.Transparent;
            this.bDashboard.BackgroundImage = global::OSCConnect.Properties.Resources.osclogo2;
            this.bDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bDashboard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bDashboard.FlatAppearance.BorderSize = 0;
            this.bDashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bDashboard.Location = new System.Drawing.Point(27, 27);
            this.bDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.bDashboard.Name = "bDashboard";
            this.bDashboard.Size = new System.Drawing.Size(85, 94);
            this.bDashboard.TabIndex = 1;
            this.bDashboard.Tag = "Dashboard";
            this.toolTipNoDelay.SetToolTip(this.bDashboard, "Click to Access the AweSim web dashboard.");
            this.bDashboard.UseVisualStyleBackColor = true;
            this.bDashboard.Click += new System.EventHandler(this.bDashboard_Click);
            // 
            // gbSessionType
            // 
            this.gbSessionType.Controls.Add(this.rbBROWSER);
            this.gbSessionType.Controls.Add(this.rbVNC);
            this.gbSessionType.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gbSessionType.Location = new System.Drawing.Point(18, 423);
            this.gbSessionType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbSessionType.Name = "gbSessionType";
            this.gbSessionType.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbSessionType.Size = new System.Drawing.Size(231, 95);
            this.gbSessionType.TabIndex = 4;
            this.gbSessionType.TabStop = false;
            this.gbSessionType.Text = "2. Session Type";
            // 
            // gbVNCPassword
            // 
            this.gbVNCPassword.Controls.Add(this.tbVNCPassword);
            this.gbVNCPassword.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gbVNCPassword.Location = new System.Drawing.Point(18, 627);
            this.gbVNCPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbVNCPassword.Name = "gbVNCPassword";
            this.gbVNCPassword.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbVNCPassword.Size = new System.Drawing.Size(231, 63);
            this.gbVNCPassword.TabIndex = 8;
            this.gbVNCPassword.TabStop = false;
            this.gbVNCPassword.Text = "4. VNC Passphrase";
            // 
            // gbSystem
            // 
            this.gbSystem.Controls.Add(this.lConnectionStatus);
            this.gbSystem.Controls.Add(this.pbIsNetworkConnected);
            this.gbSystem.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gbSystem.Location = new System.Drawing.Point(18, 147);
            this.gbSystem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbSystem.Name = "gbSystem";
            this.gbSystem.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbSystem.Size = new System.Drawing.Size(231, 62);
            this.gbSystem.TabIndex = 13;
            this.gbSystem.TabStop = false;
            this.gbSystem.Text = "Network Status";
            // 
            // lConnectionStatus
            // 
            this.lConnectionStatus.AutoSize = true;
            this.lConnectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.lConnectionStatus.Location = new System.Drawing.Point(48, 28);
            this.lConnectionStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lConnectionStatus.Name = "lConnectionStatus";
            this.lConnectionStatus.Size = new System.Drawing.Size(77, 13);
            this.lConnectionStatus.TabIndex = 2;
            this.lConnectionStatus.Text = "Not Connected";
            // 
            // pbIsNetworkConnected
            // 
            this.pbIsNetworkConnected.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pbIsNetworkConnected.Image = global::OSCConnect.Properties.Resources.cross_gry;
            this.pbIsNetworkConnected.Location = new System.Drawing.Point(10, 25);
            this.pbIsNetworkConnected.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbIsNetworkConnected.Name = "pbIsNetworkConnected";
            this.pbIsNetworkConnected.Size = new System.Drawing.Size(33, 29);
            this.pbIsNetworkConnected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIsNetworkConnected.TabIndex = 1;
            this.pbIsNetworkConnected.TabStop = false;
            // 
            // gbSFTP
            // 
            this.gbSFTP.Controls.Add(this.bSFTP);
            this.gbSFTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.gbSFTP.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gbSFTP.Location = new System.Drawing.Point(273, 286);
            this.gbSFTP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbSFTP.Name = "gbSFTP";
            this.gbSFTP.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbSFTP.Size = new System.Drawing.Size(112, 126);
            this.gbSFTP.TabIndex = 14;
            this.gbSFTP.TabStop = false;
            this.gbSFTP.Text = "SFTP";
            // 
            // gbConnect
            // 
            this.gbConnect.Controls.Add(this.bConnect);
            this.gbConnect.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gbConnect.Location = new System.Drawing.Point(273, 423);
            this.gbConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbConnect.Name = "gbConnect";
            this.gbConnect.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbConnect.Size = new System.Drawing.Size(231, 267);
            this.gbConnect.TabIndex = 15;
            this.gbConnect.TabStop = false;
            this.gbConnect.Text = "Connect";
            // 
            // gbConsole
            // 
            this.gbConsole.Controls.Add(this.buttonConsole);
            this.gbConsole.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gbConsole.Location = new System.Drawing.Point(392, 284);
            this.gbConsole.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbConsole.Name = "gbConsole";
            this.gbConsole.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbConsole.Size = new System.Drawing.Size(112, 128);
            this.gbConsole.TabIndex = 16;
            this.gbConsole.TabStop = false;
            this.gbConsole.Text = "Console";
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.buttonAdvanced);
            this.gbSettings.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gbSettings.Location = new System.Drawing.Point(273, 147);
            this.gbSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbSettings.Size = new System.Drawing.Size(112, 129);
            this.gbSettings.TabIndex = 17;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // gbAbout
            // 
            this.gbAbout.Controls.Add(this.buttonInfo);
            this.gbAbout.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gbAbout.Location = new System.Drawing.Point(392, 147);
            this.gbAbout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbAbout.Name = "gbAbout";
            this.gbAbout.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbAbout.Size = new System.Drawing.Size(112, 129);
            this.gbAbout.TabIndex = 18;
            this.gbAbout.TabStop = false;
            this.gbAbout.Text = "About";
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.BackgroundImage = global::OSCConnect.Properties.Resources.osclogotext;
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbLogo.Location = new System.Drawing.Point(119, -21);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(396, 194);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            this.pbLogo.Tag = "Logo";
            // 
            // linkLabelNewVersion
            // 
            this.linkLabelNewVersion.AllowDrop = true;
            this.linkLabelNewVersion.AutoSize = true;
            this.linkLabelNewVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelNewVersion.Location = new System.Drawing.Point(326, 110);
            this.linkLabelNewVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelNewVersion.Name = "linkLabelNewVersion";
            this.linkLabelNewVersion.Size = new System.Drawing.Size(144, 32);
            this.linkLabelNewVersion.TabIndex = 20;
            this.linkLabelNewVersion.TabStop = true;
            this.linkLabelNewVersion.Text = "New Version Available\r\nClick to Download";
            this.linkLabelNewVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelNewVersion.Visible = false;
            this.linkLabelNewVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelNewVersion_LinkClicked);
            // 
            // ConnectMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(520, 705);
            this.Controls.Add(this.linkLabelNewVersion);
            this.Controls.Add(this.gbAbout);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.gbConsole);
            this.Controls.Add(this.gbConnect);
            this.Controls.Add(this.gbSFTP);
            this.Controls.Add(this.gbSystem);
            this.Controls.Add(this.gbVNCPassword);
            this.Controls.Add(this.gbSessionType);
            this.Controls.Add(this.gbSessionInfo);
            this.Controls.Add(this.gbCredentials);
            this.Controls.Add(this.bDashboard);
            this.Controls.Add(this.pbLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "ConnectMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OSC Connect";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AweSimMain_FormClosing);
            this.Load += new System.EventHandler(this.AweSimMain2_Load);
            this.gbCredentials.ResumeLayout(false);
            this.gbCredentials.PerformLayout();
            this.gbSessionInfo.ResumeLayout(false);
            this.gbSessionInfo.PerformLayout();
            this.gbSessionType.ResumeLayout(false);
            this.gbSessionType.PerformLayout();
            this.gbVNCPassword.ResumeLayout(false);
            this.gbVNCPassword.PerformLayout();
            this.gbSystem.ResumeLayout(false);
            this.gbSystem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIsNetworkConnected)).EndInit();
            this.gbSFTP.ResumeLayout(false);
            this.gbConnect.ResumeLayout(false);
            this.gbConsole.ResumeLayout(false);
            this.gbSettings.ResumeLayout(false);
            this.gbAbout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbCredentials;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.GroupBox gbSessionInfo;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.Label lPort;
        private System.Windows.Forms.Label lHost;
        private System.Windows.Forms.Button bConnect;
        private System.Windows.Forms.RadioButton rbVNC;
        private System.Windows.Forms.RadioButton rbBROWSER;
        private System.Windows.Forms.Button bDashboard;
        private System.Windows.Forms.Button bSFTP;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.ToolTip toolTipNoDelay;
        private System.Windows.Forms.TextBox tbVNCPassword;
        private System.Windows.Forms.GroupBox gbSessionType;
        private System.Windows.Forms.GroupBox gbVNCPassword;
        private System.Windows.Forms.GroupBox gbSystem;
        private System.Windows.Forms.PictureBox pbIsNetworkConnected;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.Button buttonAdvanced;
        private System.Windows.Forms.CheckBox cbRememberMe;
        private System.Windows.Forms.GroupBox gbSFTP;
        private System.Windows.Forms.GroupBox gbConnect;
        private System.Windows.Forms.GroupBox gbConsole;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.GroupBox gbAbout;
        private System.Windows.Forms.Label lConnectionStatus;
        private System.Windows.Forms.Button buttonConsole;
        private System.Windows.Forms.LinkLabel linkLabelNewVersion;
    }
}