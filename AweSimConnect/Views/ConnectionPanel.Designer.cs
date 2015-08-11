namespace AweSimConnect.Views
{
    partial class ConnectionPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerConnectionPanel = new System.Windows.Forms.Timer(this.components);
            this.lSession = new System.Windows.Forms.Label();
            this.panelProcesses = new System.Windows.Forms.Panel();
            this.toolTipConnectionPanel = new System.Windows.Forms.ToolTip(this.components);
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.tbConnectionInfo = new System.Windows.Forms.TextBox();
            this.pbTunnel = new System.Windows.Forms.PictureBox();
            this.labelVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbTunnel)).BeginInit();
            this.SuspendLayout();
            // 
            // timerConnectionPanel
            // 
            this.timerConnectionPanel.Tick += new System.EventHandler(this.timerConnectionPanel_Tick);
            // 
            // lSession
            // 
            this.lSession.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lSession.AutoSize = true;
            this.lSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSession.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lSession.Location = new System.Drawing.Point(97, 5);
            this.lSession.Name = "lSession";
            this.lSession.Size = new System.Drawing.Size(90, 18);
            this.lSession.TabIndex = 18;
            this.lSession.Text = "Session Info";
            this.lSession.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelProcesses
            // 
            this.panelProcesses.Location = new System.Drawing.Point(393, 74);
            this.panelProcesses.Name = "panelProcesses";
            this.panelProcesses.Size = new System.Drawing.Size(200, 100);
            this.panelProcesses.TabIndex = 25;
            // 
            // toolTipConnectionPanel
            // 
            this.toolTipConnectionPanel.AutomaticDelay = 100;
            this.toolTipConnectionPanel.BackColor = System.Drawing.SystemColors.HighlightText;
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDisconnect.BackgroundImage = global::AweSimConnect.Properties.Resources.stop;
            this.buttonDisconnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDisconnect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonDisconnect.FlatAppearance.BorderSize = 0;
            this.buttonDisconnect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.buttonDisconnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDisconnect.Location = new System.Drawing.Point(273, 36);
            this.buttonDisconnect.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(28, 28);
            this.buttonDisconnect.TabIndex = 22;
            this.buttonDisconnect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTipConnectionPanel.SetToolTip(this.buttonDisconnect, "Disconnect Tunnel");
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // tbConnectionInfo
            // 
            this.tbConnectionInfo.Location = new System.Drawing.Point(85, 26);
            this.tbConnectionInfo.Multiline = true;
            this.tbConnectionInfo.Name = "tbConnectionInfo";
            this.tbConnectionInfo.ReadOnly = true;
            this.tbConnectionInfo.Size = new System.Drawing.Size(185, 48);
            this.tbConnectionInfo.TabIndex = 28;
            // 
            // pbTunnel
            // 
            this.pbTunnel.Image = global::AweSimConnect.Properties.Resources.cross_gry;
            this.pbTunnel.Location = new System.Drawing.Point(9, 15);
            this.pbTunnel.Name = "pbTunnel";
            this.pbTunnel.Size = new System.Drawing.Size(70, 71);
            this.pbTunnel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTunnel.TabIndex = 17;
            this.pbTunnel.TabStop = false;
            // 
            // labelVersion
            // 
            this.labelVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F);
            this.labelVersion.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelVersion.Location = new System.Drawing.Point(160, 77);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(110, 16);
            this.labelVersion.TabIndex = 29;
            this.labelVersion.Text = "version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ConnectionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.tbConnectionInfo);
            this.Controls.Add(this.panelProcesses);
            this.Controls.Add(this.pbTunnel);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.lSession);
            this.Name = "ConnectionPanel";
            this.Size = new System.Drawing.Size(313, 102);
            ((System.ComponentModel.ISupportInitialize)(this.pbTunnel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerConnectionPanel;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Label lSession;
        private System.Windows.Forms.PictureBox pbTunnel;
        private System.Windows.Forms.Panel panelProcesses;
        private System.Windows.Forms.ToolTip toolTipConnectionPanel;
        private System.Windows.Forms.TextBox tbConnectionInfo;
        private System.Windows.Forms.Label labelVersion;
    }
}
