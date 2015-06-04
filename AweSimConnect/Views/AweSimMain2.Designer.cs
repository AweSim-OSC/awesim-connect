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
            this.groupBoxCredentials = new System.Windows.Forms.GroupBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbVNCPassword = new System.Windows.Forms.TextBox();
            this.rbVNC = new System.Windows.Forms.RadioButton();
            this.rbCOMSOL = new System.Windows.Forms.RadioButton();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.lPort = new System.Windows.Forms.Label();
            this.lHost = new System.Windows.Forms.Label();
            this.bConnect = new System.Windows.Forms.Button();
            this.bSFTP = new System.Windows.Forms.Button();
            this.bDashboard = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.toolTipNoDelay = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxCredentials.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCredentials
            // 
            this.groupBoxCredentials.Controls.Add(this.tbPassword);
            this.groupBoxCredentials.Controls.Add(this.tbUsername);
            this.groupBoxCredentials.Controls.Add(this.labelPassword);
            this.groupBoxCredentials.Controls.Add(this.labelUsername);
            this.groupBoxCredentials.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBoxCredentials.Location = new System.Drawing.Point(12, 187);
            this.groupBoxCredentials.Name = "groupBoxCredentials";
            this.groupBoxCredentials.Size = new System.Drawing.Size(154, 164);
            this.groupBoxCredentials.TabIndex = 2;
            this.groupBoxCredentials.TabStop = false;
            this.groupBoxCredentials.Text = "1. AweSim Credentials";
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(6, 116);
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
            this.tbUsername.Location = new System.Drawing.Point(6, 55);
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
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelPassword.Location = new System.Drawing.Point(31, 91);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(92, 24);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Password";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelUsername.Location = new System.Drawing.Point(29, 30);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(97, 24);
            this.labelUsername.TabIndex = 3;
            this.labelUsername.Text = "Username";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbPort);
            this.groupBox2.Controls.Add(this.tbHost);
            this.groupBox2.Controls.Add(this.lPort);
            this.groupBox2.Controls.Add(this.lHost);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox2.Location = new System.Drawing.Point(12, 371);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(154, 81);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2. Session Info";
            // 
            // tbVNCPassword
            // 
            this.tbVNCPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVNCPassword.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.tbVNCPassword.Location = new System.Drawing.Point(24, 33);
            this.tbVNCPassword.MaxLength = 8;
            this.tbVNCPassword.Name = "tbVNCPassword";
            this.tbVNCPassword.Size = new System.Drawing.Size(100, 20);
            this.tbVNCPassword.TabIndex = 8;
            this.tbVNCPassword.Tag = "VNC Password";
            this.tbVNCPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipNoDelay.SetToolTip(this.tbVNCPassword, "Enter the 8-character VNC password generated by the session.");
            this.tbVNCPassword.TextChanged += new System.EventHandler(this.tbVNCPassword_TextChanged);
            // 
            // rbVNC
            // 
            this.rbVNC.AutoSize = true;
            this.rbVNC.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rbVNC.Location = new System.Drawing.Point(6, 16);
            this.rbVNC.Name = "rbVNC";
            this.rbVNC.Size = new System.Drawing.Size(89, 17);
            this.rbVNC.TabIndex = 7;
            this.rbVNC.TabStop = true;
            this.rbVNC.Tag = "VNC Radio Button";
            this.rbVNC.Text = "iHPC Session";
            this.toolTipNoDelay.SetToolTip(this.rbVNC, "Click this button to access an iHPC/VNC Session");
            this.rbVNC.UseVisualStyleBackColor = true;
            // 
            // rbCOMSOL
            // 
            this.rbCOMSOL.AutoSize = true;
            this.rbCOMSOL.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rbCOMSOL.Location = new System.Drawing.Point(6, 55);
            this.rbCOMSOL.Name = "rbCOMSOL";
            this.rbCOMSOL.Size = new System.Drawing.Size(144, 17);
            this.rbCOMSOL.TabIndex = 9;
            this.rbCOMSOL.TabStop = true;
            this.rbCOMSOL.Tag = "COMSOL Radio Box";
            this.rbCOMSOL.Text = "COMSOL Server Session";
            this.toolTipNoDelay.SetToolTip(this.rbCOMSOL, "Click this button if you requested a browser-based COMSOL Server session.");
            this.rbCOMSOL.UseVisualStyleBackColor = true;
            // 
            // tbPort
            // 
            this.tbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPort.Location = new System.Drawing.Point(116, 46);
            this.tbPort.MaxLength = 5;
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(32, 20);
            this.tbPort.TabIndex = 6;
            this.tbPort.Tag = "Port";
            this.tbPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipNoDelay.SetToolTip(this.tbPort, "The port number assigned to your session. (ex. 5901) Get this from your session i" +
        "nformation on the AweSim Dashboard.");
            this.tbPort.TextChanged += new System.EventHandler(this.tbPort_TextChanged);
            // 
            // tbHost
            // 
            this.tbHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHost.Location = new System.Drawing.Point(6, 46);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(104, 20);
            this.tbHost.TabIndex = 5;
            this.tbHost.Tag = "Host";
            this.tbHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipNoDelay.SetToolTip(this.tbHost, "The host name assigned to your session. (ex. n0103.ten.osc.edu) Get this from you" +
        "r session information on the AweSim Dashboard.");
            // 
            // lPort
            // 
            this.lPort.AutoSize = true;
            this.lPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPort.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lPort.Location = new System.Drawing.Point(114, 24);
            this.lPort.Name = "lPort";
            this.lPort.Size = new System.Drawing.Size(38, 20);
            this.lPort.TabIndex = 4;
            this.lPort.Text = "Port";
            // 
            // lHost
            // 
            this.lHost.AutoSize = true;
            this.lHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lHost.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lHost.Location = new System.Drawing.Point(40, 23);
            this.lHost.Name = "lHost";
            this.lHost.Size = new System.Drawing.Size(43, 20);
            this.lHost.TabIndex = 3;
            this.lHost.Text = "Host";
            // 
            // bConnect
            // 
            this.bConnect.BackColor = System.Drawing.Color.Transparent;
            this.bConnect.BackgroundImage = global::AweSimConnect.Properties.Resources.bolt_gry;
            this.bConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bConnect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bConnect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bConnect.Location = new System.Drawing.Point(183, 377);
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
            this.bSFTP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bSFTP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bSFTP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSFTP.Location = new System.Drawing.Point(183, 193);
            this.bSFTP.Margin = new System.Windows.Forms.Padding(15);
            this.bSFTP.Name = "bSFTP";
            this.bSFTP.Size = new System.Drawing.Size(154, 158);
            this.bSFTP.TabIndex = 4;
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
            this.bDashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bDashboard.Location = new System.Drawing.Point(183, 12);
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
            // timerMain
            // 
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // toolTipNoDelay
            // 
            this.toolTipNoDelay.AutomaticDelay = 100;
            this.toolTipNoDelay.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCOMSOL);
            this.groupBox1.Controls.Add(this.rbVNC);
            this.groupBox1.Controls.Add(this.tbVNCPassword);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(12, 457);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 78);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "3. Session Type";
            // 
            // AweSimMain2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(349, 551);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bConnect);
            this.Controls.Add(this.bSFTP);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxCredentials);
            this.Controls.Add(this.bDashboard);
            this.Controls.Add(this.pbLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AweSimMain2";
            this.Text = "AweSim Connect";
            this.Load += new System.EventHandler(this.AweSimMain2_Load);
            this.groupBoxCredentials.ResumeLayout(false);
            this.groupBoxCredentials.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox groupBoxCredentials;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.GroupBox groupBox2;
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
        private System.Windows.Forms.GroupBox groupBox1;



    }
}