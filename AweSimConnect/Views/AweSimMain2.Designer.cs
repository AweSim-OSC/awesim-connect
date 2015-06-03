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
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbVNCPassword = new System.Windows.Forms.TextBox();
            this.rbVNC = new System.Windows.Forms.RadioButton();
            this.rbCOMSOL = new System.Windows.Forms.RadioButton();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bConnect = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bDashboard = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.toolTipNoDelay = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxCredentials.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxCredentials
            // 
            this.groupBoxCredentials.Controls.Add(this.textBoxPassword);
            this.groupBoxCredentials.Controls.Add(this.textBoxUserName);
            this.groupBoxCredentials.Controls.Add(this.labelPassword);
            this.groupBoxCredentials.Controls.Add(this.labelUsername);
            this.groupBoxCredentials.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBoxCredentials.Location = new System.Drawing.Point(12, 185);
            this.groupBoxCredentials.Name = "groupBoxCredentials";
            this.groupBoxCredentials.Size = new System.Drawing.Size(154, 170);
            this.groupBoxCredentials.TabIndex = 2;
            this.groupBoxCredentials.TabStop = false;
            this.groupBoxCredentials.Text = "AweSim Credentials";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.Location = new System.Drawing.Point(6, 116);
            this.textBoxPassword.MaxLength = 255;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(142, 26);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.Tag = "Password";
            this.textBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipNoDelay.SetToolTip(this.textBoxPassword, "Enter your AweSim password.");
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUserName.Location = new System.Drawing.Point(6, 55);
            this.textBoxUserName.MaxLength = 255;
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(142, 26);
            this.textBoxUserName.TabIndex = 2;
            this.textBoxUserName.Tag = "Username";
            this.textBoxUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipNoDelay.SetToolTip(this.textBoxUserName, "Enter your AweSim username.");
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
            this.groupBox2.Controls.Add(this.tbVNCPassword);
            this.groupBox2.Controls.Add(this.rbVNC);
            this.groupBox2.Controls.Add(this.rbCOMSOL);
            this.groupBox2.Controls.Add(this.tbPort);
            this.groupBox2.Controls.Add(this.tbHost);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox2.Location = new System.Drawing.Point(12, 369);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(154, 170);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Session Info";
            // 
            // tbVNCPassword
            // 
            this.tbVNCPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVNCPassword.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbVNCPassword.Location = new System.Drawing.Point(26, 107);
            this.tbVNCPassword.MaxLength = 8;
            this.tbVNCPassword.Name = "tbVNCPassword";
            this.tbVNCPassword.Size = new System.Drawing.Size(100, 20);
            this.tbVNCPassword.TabIndex = 8;
            this.tbVNCPassword.Tag = "VNC Password";
            this.tbVNCPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipNoDelay.SetToolTip(this.tbVNCPassword, "Enter the 8-character VNC password generated by the session.");
            // 
            // rbVNC
            // 
            this.rbVNC.AutoSize = true;
            this.rbVNC.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rbVNC.Location = new System.Drawing.Point(6, 88);
            this.rbVNC.Name = "rbVNC";
            this.rbVNC.Size = new System.Drawing.Size(87, 17);
            this.rbVNC.TabIndex = 7;
            this.rbVNC.TabStop = true;
            this.rbVNC.Tag = "VNC Radio Button";
            this.rbVNC.Text = "VNC Session";
            this.toolTipNoDelay.SetToolTip(this.rbVNC, "Click this button to access an iHPC/VNC Session");
            this.rbVNC.UseVisualStyleBackColor = true;
            // 
            // rbCOMSOL
            // 
            this.rbCOMSOL.AutoSize = true;
            this.rbCOMSOL.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rbCOMSOL.Location = new System.Drawing.Point(6, 137);
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
            this.tbPort.Location = new System.Drawing.Point(116, 55);
            this.tbPort.MaxLength = 5;
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(32, 20);
            this.tbPort.TabIndex = 6;
            this.tbPort.Tag = "Port";
            this.tbPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipNoDelay.SetToolTip(this.tbPort, "The port number assigned to your session. (ex. 5901) Get this from your session i" +
        "nformation on the AweSim Dashboard.");
            // 
            // tbHost
            // 
            this.tbHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHost.Location = new System.Drawing.Point(6, 55);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(104, 20);
            this.tbHost.TabIndex = 5;
            this.tbHost.Tag = "Host";
            this.tbHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipNoDelay.SetToolTip(this.tbHost, "The host name assigned to your session. (ex. n0103.ten.osc.edu) Get this from you" +
        "r session information on the AweSim Dashboard.");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(114, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(40, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Host";
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
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::AweSimConnect.Properties.Resources.hdd_gry;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(183, 193);
            this.button2.Margin = new System.Windows.Forms.Padding(15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 158);
            this.button2.TabIndex = 4;
            this.button2.Tag = "File Transfer";
            this.toolTipNoDelay.SetToolTip(this.button2, "File Transfer. Enter your user credentials and click here to open an SFTP file tr" +
        "ansfer session.");
            this.button2.UseVisualStyleBackColor = false;
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
            // toolTipNoDelay
            // 
            this.toolTipNoDelay.AutomaticDelay = 100;
            this.toolTipNoDelay.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // AweSimMain2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(349, 551);
            this.Controls.Add(this.bConnect);
            this.Controls.Add(this.button2);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox groupBoxCredentials;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bConnect;
        private System.Windows.Forms.RadioButton rbVNC;
        private System.Windows.Forms.RadioButton rbCOMSOL;
        private System.Windows.Forms.Button bDashboard;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbVNCPassword;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.ToolTip toolTipNoDelay;



    }
}