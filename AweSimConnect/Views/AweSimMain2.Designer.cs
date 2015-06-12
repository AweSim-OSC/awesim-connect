namespace AweSimConnect.Views
{
    partial class AweSimMain2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AweSimMain2));
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
            this.rbCOMSOL = new System.Windows.Forms.RadioButton();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.toolTipNoDelay = new System.Windows.Forms.ToolTip(this.components);
            this.gbSessionType = new System.Windows.Forms.GroupBox();
            this.gbVNCPassword = new System.Windows.Forms.GroupBox();
            this.gbSystem = new System.Windows.Forms.GroupBox();
            this.buttonAdvanced = new System.Windows.Forms.Button();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.pbIsNetworkConnected = new System.Windows.Forms.PictureBox();
            this.bConnect = new System.Windows.Forms.Button();
            this.bSFTP = new System.Windows.Forms.Button();
            this.bDashboard = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbCredentials.SuspendLayout();
            this.gbSessionInfo.SuspendLayout();
            this.gbSessionType.SuspendLayout();
            this.gbVNCPassword.SuspendLayout();
            this.gbSystem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIsNetworkConnected)).BeginInit();
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
            this.gbCredentials.Location = new System.Drawing.Point(12, 223);
            this.gbCredentials.Name = "gbCredentials";
            this.gbCredentials.Size = new System.Drawing.Size(154, 130);
            this.gbCredentials.TabIndex = 2;
            this.gbCredentials.TabStop = false;
            this.gbCredentials.Text = "1. AweSim Credentials";
            this.toolTipNoDelay.SetToolTip(this.gbCredentials, "Your AweSim Username and Password.");
            // 
            // cbRememberMe
            // 
            this.cbRememberMe.AutoSize = true;
            this.cbRememberMe.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.cbRememberMe.Location = new System.Drawing.Point(6, 107);
            this.cbRememberMe.Name = "cbRememberMe";
            this.cbRememberMe.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbRememberMe.Size = new System.Drawing.Size(95, 17);
            this.cbRememberMe.TabIndex = 5;
            this.cbRememberMe.Text = "Remember Me";
            this.cbRememberMe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbRememberMe.UseVisualStyleBackColor = true;
            this.cbRememberMe.CheckedChanged += new System.EventHandler(this.cbRememberMe_CheckedChanged);
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(6, 75);
            this.tbPassword.MaxLength = 255;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(142, 26);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.Tag = "Password";
            this.tbPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipNoDelay.SetToolTip(this.tbPassword, "Enter your AweSim password.");
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsername.Location = new System.Drawing.Point(6, 31);
            this.tbUsername.MaxLength = 255;
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(142, 26);
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
            this.labelPassword.Location = new System.Drawing.Point(51, 59);
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
            this.labelUsername.Location = new System.Drawing.Point(51, 15);
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
            this.gbSessionInfo.Location = new System.Drawing.Point(183, 246);
            this.gbSessionInfo.Name = "gbSessionInfo";
            this.gbSessionInfo.Size = new System.Drawing.Size(154, 60);
            this.gbSessionInfo.TabIndex = 6;
            this.gbSessionInfo.TabStop = false;
            this.gbSessionInfo.Text = "3. Session Info";
            this.toolTipNoDelay.SetToolTip(this.gbSessionInfo, "Session Information. Get this by requesting a session at the AweSim Dashboard.");
            // 
            // tbPort
            // 
            this.tbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPort.Location = new System.Drawing.Point(116, 34);
            this.tbPort.MaxLength = 5;
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(32, 20);
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
            this.tbHost.Location = new System.Drawing.Point(6, 34);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(104, 20);
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
            this.lPort.Location = new System.Drawing.Point(119, 18);
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
            this.lHost.Location = new System.Drawing.Point(47, 18);
            this.lHost.Name = "lHost";
            this.lHost.Size = new System.Drawing.Size(29, 13);
            this.lHost.TabIndex = 3;
            this.lHost.Text = "Host";
            // 
            // tbVNCPassword
            // 
            this.tbVNCPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVNCPassword.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbVNCPassword.Location = new System.Drawing.Point(6, 16);
            this.tbVNCPassword.MaxLength = 8;
            this.tbVNCPassword.Name = "tbVNCPassword";
            this.tbVNCPassword.Size = new System.Drawing.Size(142, 20);
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
            this.rbVNC.Location = new System.Drawing.Point(6, 17);
            this.rbVNC.Name = "rbVNC";
            this.rbVNC.Size = new System.Drawing.Size(117, 17);
            this.rbVNC.TabIndex = 4;
            this.rbVNC.TabStop = true;
            this.rbVNC.Tag = "VNC Radio Button";
            this.rbVNC.Text = "iHPC VNC Desktop";
            this.toolTipNoDelay.SetToolTip(this.rbVNC, "Click this button to access an iHPC/VNC Session");
            this.rbVNC.UseVisualStyleBackColor = true;
            this.rbVNC.CheckedChanged += new System.EventHandler(this.rbVNC_CheckedChanged);
            // 
            // rbCOMSOL
            // 
            this.rbCOMSOL.AutoSize = true;
            this.rbCOMSOL.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rbCOMSOL.Location = new System.Drawing.Point(6, 37);
            this.rbCOMSOL.Name = "rbCOMSOL";
            this.rbCOMSOL.Size = new System.Drawing.Size(130, 17);
            this.rbCOMSOL.TabIndex = 5;
            this.rbCOMSOL.TabStop = true;
            this.rbCOMSOL.Tag = "COMSOL Radio Box";
            this.rbCOMSOL.Text = "COMSOL Server Web";
            this.toolTipNoDelay.SetToolTip(this.rbCOMSOL, "Click this button if you requested a browser-based COMSOL Server session.");
            this.rbCOMSOL.UseVisualStyleBackColor = true;
            this.rbCOMSOL.CheckedChanged += new System.EventHandler(this.rbCOMSOL_CheckedChanged);
            // 
            // timerMain
            // 
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
            // gbSessionType
            // 
            this.gbSessionType.Controls.Add(this.rbCOMSOL);
            this.gbSessionType.Controls.Add(this.rbVNC);
            this.gbSessionType.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gbSessionType.Location = new System.Drawing.Point(183, 179);
            this.gbSessionType.Name = "gbSessionType";
            this.gbSessionType.Size = new System.Drawing.Size(154, 62);
            this.gbSessionType.TabIndex = 4;
            this.gbSessionType.TabStop = false;
            this.gbSessionType.Text = "2. Session Type";
            // 
            // gbVNCPassword
            // 
            this.gbVNCPassword.Controls.Add(this.tbVNCPassword);
            this.gbVNCPassword.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gbVNCPassword.Location = new System.Drawing.Point(183, 312);
            this.gbVNCPassword.Name = "gbVNCPassword";
            this.gbVNCPassword.Size = new System.Drawing.Size(154, 41);
            this.gbVNCPassword.TabIndex = 8;
            this.gbVNCPassword.TabStop = false;
            this.gbVNCPassword.Text = "4. VNC Password";
            // 
            // gbSystem
            // 
            this.gbSystem.Controls.Add(this.buttonAdvanced);
            this.gbSystem.Controls.Add(this.buttonInfo);
            this.gbSystem.Controls.Add(this.pbIsNetworkConnected);
            this.gbSystem.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gbSystem.Location = new System.Drawing.Point(12, 179);
            this.gbSystem.Name = "gbSystem";
            this.gbSystem.Size = new System.Drawing.Size(154, 40);
            this.gbSystem.TabIndex = 13;
            this.gbSystem.TabStop = false;
            // 
            // buttonAdvanced
            // 
            this.buttonAdvanced.BackgroundImage = global::AweSimConnect.Properties.Resources.officine2;
            this.buttonAdvanced.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAdvanced.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdvanced.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonAdvanced.FlatAppearance.BorderSize = 0;
            this.buttonAdvanced.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.buttonAdvanced.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonAdvanced.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdvanced.Location = new System.Drawing.Point(86, 12);
            this.buttonAdvanced.Name = "buttonAdvanced";
            this.buttonAdvanced.Size = new System.Drawing.Size(22, 22);
            this.buttonAdvanced.TabIndex = 3;
            this.toolTipNoDelay.SetToolTip(this.buttonAdvanced, "Advanced Options");
            this.buttonAdvanced.UseVisualStyleBackColor = true;
            this.buttonAdvanced.Click += new System.EventHandler(this.buttonAdvanced_Click);
            // 
            // buttonInfo
            // 
            this.buttonInfo.BackgroundImage = global::AweSimConnect.Properties.Resources.info_gry;
            this.buttonInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonInfo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonInfo.FlatAppearance.BorderSize = 0;
            this.buttonInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.buttonInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInfo.Location = new System.Drawing.Point(114, 12);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(22, 22);
            this.buttonInfo.TabIndex = 2;
            this.toolTipNoDelay.SetToolTip(this.buttonInfo, "About");
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // pbIsNetworkConnected
            // 
            this.pbIsNetworkConnected.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pbIsNetworkConnected.Image = global::AweSimConnect.Properties.Resources.cross_gry;
            this.pbIsNetworkConnected.Location = new System.Drawing.Point(19, 12);
            this.pbIsNetworkConnected.Name = "pbIsNetworkConnected";
            this.pbIsNetworkConnected.Size = new System.Drawing.Size(22, 22);
            this.pbIsNetworkConnected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIsNetworkConnected.TabIndex = 1;
            this.pbIsNetworkConnected.TabStop = false;
            // 
            // bConnect
            // 
            this.bConnect.BackColor = System.Drawing.Color.Transparent;
            this.bConnect.BackgroundImage = global::AweSimConnect.Properties.Resources.bolt_gry;
            this.bConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bConnect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bConnect.FlatAppearance.BorderSize = 0;
            this.bConnect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bConnect.Location = new System.Drawing.Point(183, 367);
            this.bConnect.Margin = new System.Windows.Forms.Padding(0);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(154, 158);
            this.bConnect.TabIndex = 10;
            this.toolTipNoDelay.SetToolTip(this.bConnect, "Connect to Session. Enter your session information and click here to connect to t" +
        "he session.");
            this.bConnect.UseVisualStyleBackColor = false;
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // bSFTP
            // 
            this.bSFTP.BackColor = System.Drawing.Color.Transparent;
            this.bSFTP.BackgroundImage = global::AweSimConnect.Properties.Resources.hdd_gry;
            this.bSFTP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bSFTP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bSFTP.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bSFTP.FlatAppearance.BorderSize = 0;
            this.bSFTP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bSFTP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bSFTP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSFTP.Location = new System.Drawing.Point(12, 367);
            this.bSFTP.Margin = new System.Windows.Forms.Padding(0);
            this.bSFTP.Name = "bSFTP";
            this.bSFTP.Size = new System.Drawing.Size(154, 158);
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
            this.bDashboard.BackgroundImage = global::AweSimConnect.Properties.Resources.awesim_ball;
            this.bDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bDashboard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bDashboard.FlatAppearance.BorderSize = 0;
            this.bDashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bDashboard.Location = new System.Drawing.Point(183, 12);
            this.bDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.bDashboard.Name = "bDashboard";
            this.bDashboard.Size = new System.Drawing.Size(154, 158);
            this.bDashboard.TabIndex = 1;
            this.bDashboard.Tag = "Dashboard";
            this.toolTipNoDelay.SetToolTip(this.bDashboard, "Click to Access the AweSim web dashboard.");
            this.bDashboard.UseVisualStyleBackColor = false;
            this.bDashboard.Click += new System.EventHandler(this.bDashboard_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.BackgroundImage = global::AweSimConnect.Properties.Resources.awesim_logo;
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbLogo.Location = new System.Drawing.Point(12, 12);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(154, 158);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            this.pbLogo.Tag = "Logo";
            // 
            // AweSimMain2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(349, 538);
            this.Controls.Add(this.gbSystem);
            this.Controls.Add(this.gbVNCPassword);
            this.Controls.Add(this.gbSessionType);
            this.Controls.Add(this.bConnect);
            this.Controls.Add(this.gbSessionInfo);
            this.Controls.Add(this.bSFTP);
            this.Controls.Add(this.gbCredentials);
            this.Controls.Add(this.bDashboard);
            this.Controls.Add(this.pbLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AweSimMain2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AweSim Connect";
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
            ((System.ComponentModel.ISupportInitialize)(this.pbIsNetworkConnected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.RadioButton rbCOMSOL;
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



    }
}