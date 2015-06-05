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
            this.buttonConnection = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.labelSession = new System.Windows.Forms.Label();
            this.pbTunnel = new System.Windows.Forms.PictureBox();
            this.lRunTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbTunnel)).BeginInit();
            this.SuspendLayout();
            // 
            // timerConnectionPanel
            // 
            this.timerConnectionPanel.Tick += new System.EventHandler(this.timerConnectionPanel_Tick);
            // 
            // buttonConnection
            // 
            this.buttonConnection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonConnection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConnection.Image = global::AweSimConnect.Properties.Resources.monitor;
            this.buttonConnection.Location = new System.Drawing.Point(251, 11);
            this.buttonConnection.Name = "buttonConnection";
            this.buttonConnection.Size = new System.Drawing.Size(70, 57);
            this.buttonConnection.TabIndex = 23;
            this.buttonConnection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonConnection.UseVisualStyleBackColor = true;
            this.buttonConnection.Click += new System.EventHandler(this.buttonConnection_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDisconnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDisconnect.Image = global::AweSimConnect.Properties.Resources.plug;
            this.buttonDisconnect.Location = new System.Drawing.Point(327, 11);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(70, 57);
            this.buttonDisconnect.TabIndex = 22;
            this.buttonDisconnect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // labelSession
            // 
            this.labelSession.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSession.AutoSize = true;
            this.labelSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSession.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelSession.Location = new System.Drawing.Point(40, 11);
            this.labelSession.Name = "labelSession";
            this.labelSession.Size = new System.Drawing.Size(210, 24);
            this.labelSession.TabIndex = 18;
            this.labelSession.Text = "n0103.ten.osc.edu:5901";
            this.labelSession.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbTunnel
            // 
            this.pbTunnel.Image = global::AweSimConnect.Properties.Resources.cross_gry;
            this.pbTunnel.Location = new System.Drawing.Point(3, 17);
            this.pbTunnel.Name = "pbTunnel";
            this.pbTunnel.Size = new System.Drawing.Size(28, 33);
            this.pbTunnel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTunnel.TabIndex = 17;
            this.pbTunnel.TabStop = false;
            // 
            // lRunTime
            // 
            this.lRunTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lRunTime.AutoSize = true;
            this.lRunTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRunTime.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lRunTime.Location = new System.Drawing.Point(37, 44);
            this.lRunTime.Name = "lRunTime";
            this.lRunTime.Size = new System.Drawing.Size(217, 24);
            this.lRunTime.TabIndex = 24;
            this.lRunTime.Text = "Running time: 0:00:00:00";
            this.lRunTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConnectionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.buttonConnection);
            this.Controls.Add(this.lRunTime);
            this.Controls.Add(this.pbTunnel);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.labelSession);
            this.Name = "ConnectionPanel";
            this.Size = new System.Drawing.Size(400, 80);
            ((System.ComponentModel.ISupportInitialize)(this.pbTunnel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerConnectionPanel;
        private System.Windows.Forms.Button buttonConnection;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Label labelSession;
        private System.Windows.Forms.PictureBox pbTunnel;
        private System.Windows.Forms.Label lRunTime;
    }
}
