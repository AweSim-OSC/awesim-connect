namespace OSCConnect.Views
{
    partial class AdvSettingsFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvSettingsFrm));
            this.labelVersion = new System.Windows.Forms.Label();
            this.cbSaveUser = new System.Windows.Forms.CheckBox();
            this.cbHosts = new System.Windows.Forms.ComboBox();
            this.labelSSHHost = new System.Windows.Forms.Label();
            this.cbClipboardDetect = new System.Windows.Forms.CheckBox();
            this.toolTipAdvSettings = new System.Windows.Forms.ToolTip(this.components);
            this.cbLaunchTunnel = new System.Windows.Forms.CheckBox();
            this.gbConnection = new System.Windows.Forms.GroupBox();
            this.gbSystem = new System.Windows.Forms.GroupBox();
            this.cbNewVersionCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbVNCSettings = new System.Windows.Forms.GroupBox();
            this.labelQualityValue = new System.Windows.Forms.Label();
            this.labelQuality = new System.Windows.Forms.Label();
            this.tbVNCQuality = new System.Windows.Forms.TrackBar();
            this.gbConnection.SuspendLayout();
            this.gbSystem.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbVNCSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVNCQuality)).BeginInit();
            this.SuspendLayout();
            // 
            // labelVersion
            // 
            this.labelVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F);
            this.labelVersion.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelVersion.Location = new System.Drawing.Point(156, 482);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(165, 25);
            this.labelVersion.TabIndex = 30;
            this.labelVersion.Text = "version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbSaveUser
            // 
            this.cbSaveUser.AutoSize = true;
            this.cbSaveUser.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbSaveUser.Location = new System.Drawing.Point(20, 29);
            this.cbSaveUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbSaveUser.Name = "cbSaveUser";
            this.cbSaveUser.Size = new System.Drawing.Size(186, 24);
            this.cbSaveUser.TabIndex = 31;
            this.cbSaveUser.Text = "Save User Credentials";
            this.toolTipAdvSettings.SetToolTip(this.cbSaveUser, "Save your user credentials. Credentials will be accessible by this windows user a" +
        "ccount. Do not use on a public account.");
            this.cbSaveUser.UseVisualStyleBackColor = true;
            this.cbSaveUser.CheckedChanged += new System.EventHandler(this.cbSaveUser_CheckedChanged);
            // 
            // cbHosts
            // 
            this.cbHosts.AllowDrop = true;
            this.cbHosts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHosts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbHosts.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.cbHosts.FormattingEnabled = true;
            this.cbHosts.Location = new System.Drawing.Point(20, 34);
            this.cbHosts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbHosts.Name = "cbHosts";
            this.cbHosts.Size = new System.Drawing.Size(180, 28);
            this.cbHosts.TabIndex = 32;
            this.cbHosts.Tag = "SSHHost";
            this.toolTipAdvSettings.SetToolTip(this.cbHosts, "Select the default SSH login host.");
            this.cbHosts.SelectedIndexChanged += new System.EventHandler(this.cbHosts_SelectedIndexChanged);
            // 
            // labelSSHHost
            // 
            this.labelSSHHost.AutoSize = true;
            this.labelSSHHost.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelSSHHost.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelSSHHost.Location = new System.Drawing.Point(210, 38);
            this.labelSSHHost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSSHHost.Name = "labelSSHHost";
            this.labelSSHHost.Size = new System.Drawing.Size(81, 20);
            this.labelSSHHost.TabIndex = 33;
            this.labelSSHHost.Text = "SSH Host";
            // 
            // cbClipboardDetect
            // 
            this.cbClipboardDetect.AutoSize = true;
            this.cbClipboardDetect.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbClipboardDetect.Location = new System.Drawing.Point(20, 29);
            this.cbClipboardDetect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbClipboardDetect.Name = "cbClipboardDetect";
            this.cbClipboardDetect.Size = new System.Drawing.Size(200, 24);
            this.cbClipboardDetect.TabIndex = 34;
            this.cbClipboardDetect.Text = "Detect Clipboard Activity";
            this.toolTipAdvSettings.SetToolTip(this.cbClipboardDetect, "Toggle the clipboard detection functionality.");
            this.cbClipboardDetect.UseVisualStyleBackColor = true;
            this.cbClipboardDetect.CheckedChanged += new System.EventHandler(this.cbClipboardDetect_CheckedChanged);
            // 
            // cbLaunchTunnel
            // 
            this.cbLaunchTunnel.AutoSize = true;
            this.cbLaunchTunnel.Location = new System.Drawing.Point(20, 65);
            this.cbLaunchTunnel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbLaunchTunnel.Name = "cbLaunchTunnel";
            this.cbLaunchTunnel.Size = new System.Drawing.Size(208, 24);
            this.cbLaunchTunnel.TabIndex = 36;
            this.cbLaunchTunnel.Text = "Launch Tunnel On Import";
            this.toolTipAdvSettings.SetToolTip(this.cbLaunchTunnel, "Use this option to allow the application to automatically attempt to create a SSH" +
        " tunnel when connection data is imported to the application.");
            this.cbLaunchTunnel.UseVisualStyleBackColor = true;
            this.cbLaunchTunnel.CheckedChanged += new System.EventHandler(this.cbLaunchTunnel_CheckedChanged);
            // 
            // gbConnection
            // 
            this.gbConnection.Controls.Add(this.labelSSHHost);
            this.gbConnection.Controls.Add(this.cbHosts);
            this.gbConnection.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gbConnection.Location = new System.Drawing.Point(18, 18);
            this.gbConnection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbConnection.Name = "gbConnection";
            this.gbConnection.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbConnection.Size = new System.Drawing.Size(303, 82);
            this.gbConnection.TabIndex = 37;
            this.gbConnection.TabStop = false;
            this.gbConnection.Text = "Connection Settings";
            // 
            // gbSystem
            // 
            this.gbSystem.Controls.Add(this.cbNewVersionCheck);
            this.gbSystem.Controls.Add(this.cbClipboardDetect);
            this.gbSystem.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gbSystem.Location = new System.Drawing.Point(18, 109);
            this.gbSystem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbSystem.Name = "gbSystem";
            this.gbSystem.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbSystem.Size = new System.Drawing.Size(303, 100);
            this.gbSystem.TabIndex = 38;
            this.gbSystem.TabStop = false;
            this.gbSystem.Text = "System Settings";
            // 
            // cbNewVersionCheck
            // 
            this.cbNewVersionCheck.AutoSize = true;
            this.cbNewVersionCheck.Location = new System.Drawing.Point(20, 66);
            this.cbNewVersionCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbNewVersionCheck.Name = "cbNewVersionCheck";
            this.cbNewVersionCheck.Size = new System.Drawing.Size(197, 24);
            this.cbNewVersionCheck.TabIndex = 35;
            this.cbNewVersionCheck.Text = "Check for New Versions";
            this.cbNewVersionCheck.UseVisualStyleBackColor = true;
            this.cbNewVersionCheck.CheckedChanged += new System.EventHandler(this.cbNewVersionCheck_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbLaunchTunnel);
            this.groupBox1.Controls.Add(this.cbSaveUser);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(18, 218);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(303, 100);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Automation Settings";
            // 
            // gbVNCSettings
            // 
            this.gbVNCSettings.Controls.Add(this.labelQualityValue);
            this.gbVNCSettings.Controls.Add(this.labelQuality);
            this.gbVNCSettings.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gbVNCSettings.Location = new System.Drawing.Point(18, 329);
            this.gbVNCSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbVNCSettings.Name = "gbVNCSettings";
            this.gbVNCSettings.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbVNCSettings.Size = new System.Drawing.Size(300, 148);
            this.gbVNCSettings.TabIndex = 40;
            this.gbVNCSettings.TabStop = false;
            this.gbVNCSettings.Text = "VNC Settings";
            // 
            // labelQualityValue
            // 
            this.labelQualityValue.AutoSize = true;
            this.labelQualityValue.Location = new System.Drawing.Point(87, 38);
            this.labelQualityValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelQualityValue.Name = "labelQualityValue";
            this.labelQualityValue.Size = new System.Drawing.Size(18, 20);
            this.labelQualityValue.TabIndex = 2;
            this.labelQualityValue.Text = "0";
            // 
            // labelQuality
            // 
            this.labelQuality.AutoSize = true;
            this.labelQuality.Location = new System.Drawing.Point(20, 38);
            this.labelQuality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelQuality.Name = "labelQuality";
            this.labelQuality.Size = new System.Drawing.Size(57, 20);
            this.labelQuality.TabIndex = 1;
            this.labelQuality.Text = "Quality";
            // 
            // tbVNCQuality
            // 
            this.tbVNCQuality.Location = new System.Drawing.Point(28, 392);
            this.tbVNCQuality.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbVNCQuality.Maximum = 100;
            this.tbVNCQuality.Name = "tbVNCQuality";
            this.tbVNCQuality.Size = new System.Drawing.Size(280, 45);
            this.tbVNCQuality.TabIndex = 0;
            this.tbVNCQuality.TickFrequency = 10;
            this.tbVNCQuality.Scroll += new System.EventHandler(this.tbVNCQuality_Scroll);
            // 
            // AdvSettingsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(336, 522);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbVNCQuality);
            this.Controls.Add(this.gbSystem);
            this.Controls.Add(this.gbConnection);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.gbVNCSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdvSettingsFrm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advanced Settings";
            this.Load += new System.EventHandler(this.AdvSettingsFrm_Load);
            this.gbConnection.ResumeLayout(false);
            this.gbConnection.PerformLayout();
            this.gbSystem.ResumeLayout(false);
            this.gbSystem.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbVNCSettings.ResumeLayout(false);
            this.gbVNCSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVNCQuality)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.CheckBox cbSaveUser;
        private System.Windows.Forms.ComboBox cbHosts;
        private System.Windows.Forms.Label labelSSHHost;
        private System.Windows.Forms.CheckBox cbClipboardDetect;
        private System.Windows.Forms.ToolTip toolTipAdvSettings;
        private System.Windows.Forms.GroupBox gbConnection;
        private System.Windows.Forms.GroupBox gbSystem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbLaunchTunnel;
        private System.Windows.Forms.CheckBox cbNewVersionCheck;
        private System.Windows.Forms.GroupBox gbVNCSettings;
        private System.Windows.Forms.Label labelQuality;
        private System.Windows.Forms.TrackBar tbVNCQuality;
        private System.Windows.Forms.Label labelQualityValue;
    }
}