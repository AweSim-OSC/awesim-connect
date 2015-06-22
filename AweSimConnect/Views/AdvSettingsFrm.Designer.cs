namespace AweSimConnect.Views
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
            this.cbAutoOpen = new System.Windows.Forms.CheckBox();
            this.toolTipAdvSettings = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // labelVersion
            // 
            this.labelVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F);
            this.labelVersion.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelVersion.Location = new System.Drawing.Point(83, 118);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(110, 16);
            this.labelVersion.TabIndex = 30;
            this.labelVersion.Text = "version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbSaveUser
            // 
            this.cbSaveUser.AutoSize = true;
            this.cbSaveUser.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbSaveUser.Location = new System.Drawing.Point(12, 50);
            this.cbSaveUser.Name = "cbSaveUser";
            this.cbSaveUser.Size = new System.Drawing.Size(131, 17);
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
            this.cbHosts.Location = new System.Drawing.Point(12, 14);
            this.cbHosts.Name = "cbHosts";
            this.cbHosts.Size = new System.Drawing.Size(121, 21);
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
            this.labelSSHHost.Location = new System.Drawing.Point(139, 17);
            this.labelSSHHost.Name = "labelSSHHost";
            this.labelSSHHost.Size = new System.Drawing.Size(54, 13);
            this.labelSSHHost.TabIndex = 33;
            this.labelSSHHost.Text = "SSH Host";
            // 
            // cbClipboardDetect
            // 
            this.cbClipboardDetect.AutoSize = true;
            this.cbClipboardDetect.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbClipboardDetect.Location = new System.Drawing.Point(12, 74);
            this.cbClipboardDetect.Name = "cbClipboardDetect";
            this.cbClipboardDetect.Size = new System.Drawing.Size(142, 17);
            this.cbClipboardDetect.TabIndex = 34;
            this.cbClipboardDetect.Text = "Detect Clipboard Activity";
            this.toolTipAdvSettings.SetToolTip(this.cbClipboardDetect, "Toggle the clipboard detection functionality.");
            this.cbClipboardDetect.UseVisualStyleBackColor = true;
            this.cbClipboardDetect.CheckedChanged += new System.EventHandler(this.cbClipboardDetect_CheckedChanged);
            // 
            // cbAutoOpen
            // 
            this.cbAutoOpen.AutoSize = true;
            this.cbAutoOpen.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbAutoOpen.Location = new System.Drawing.Point(12, 98);
            this.cbAutoOpen.Name = "cbAutoOpen";
            this.cbAutoOpen.Size = new System.Drawing.Size(157, 17);
            this.cbAutoOpen.TabIndex = 35;
            this.cbAutoOpen.Text = "Automatically Open Session";
            this.toolTipAdvSettings.SetToolTip(this.cbAutoOpen, "When activated, the VNC client or browser will be launched automatically after a " +
        "connection is established.");
            this.cbAutoOpen.UseVisualStyleBackColor = true;
            this.cbAutoOpen.CheckedChanged += new System.EventHandler(this.cbAutoOpen_CheckedChanged);
            // 
            // AdvSettingsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(201, 144);
            this.Controls.Add(this.cbAutoOpen);
            this.Controls.Add(this.cbClipboardDetect);
            this.Controls.Add(this.labelSSHHost);
            this.Controls.Add(this.cbHosts);
            this.Controls.Add(this.cbSaveUser);
            this.Controls.Add(this.labelVersion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdvSettingsFrm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advanced Settings";
            this.Load += new System.EventHandler(this.AdvSettingsFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.CheckBox cbSaveUser;
        private System.Windows.Forms.ComboBox cbHosts;
        private System.Windows.Forms.Label labelSSHHost;
        private System.Windows.Forms.CheckBox cbClipboardDetect;
        private System.Windows.Forms.CheckBox cbAutoOpen;
        private System.Windows.Forms.ToolTip toolTipAdvSettings;
    }
}