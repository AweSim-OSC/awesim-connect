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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AweSimMain));
            this.pbAweSimLogo = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lUsername = new System.Windows.Forms.Label();
            this.lPassword = new System.Windows.Forms.Label();
            this.cbCluster = new System.Windows.Forms.ComboBox();
            this.lCluster = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bConnect = new System.Windows.Forms.Button();
            this.tbHost = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbAweSimLogo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbAweSimLogo
            // 
            this.pbAweSimLogo.Image = global::AweSimConnect.Properties.Resources.awesim_sm;
            this.pbAweSimLogo.Location = new System.Drawing.Point(30, 12);
            this.pbAweSimLogo.Name = "pbAweSimLogo";
            this.pbAweSimLogo.Size = new System.Drawing.Size(200, 84);
            this.pbAweSimLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbAweSimLogo.TabIndex = 1;
            this.pbAweSimLogo.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(323, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(323, 62);
            this.textBox2.MaxLength = 200;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // lUsername
            // 
            this.lUsername.AutoSize = true;
            this.lUsername.Location = new System.Drawing.Point(259, 37);
            this.lUsername.Name = "lUsername";
            this.lUsername.Size = new System.Drawing.Size(58, 13);
            this.lUsername.TabIndex = 4;
            this.lUsername.Text = "Username:";
            // 
            // lPassword
            // 
            this.lPassword.AutoSize = true;
            this.lPassword.Location = new System.Drawing.Point(259, 65);
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
            this.cbCluster.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCluster.FormattingEnabled = true;
            this.cbCluster.Location = new System.Drawing.Point(18, 30);
            this.cbCluster.Name = "cbCluster";
            this.cbCluster.Size = new System.Drawing.Size(67, 23);
            this.cbCluster.TabIndex = 6;
            this.cbCluster.ValueMember = "Name";
            // 
            // lCluster
            // 
            this.lCluster.AutoSize = true;
            this.lCluster.Location = new System.Drawing.Point(28, 14);
            this.lCluster.Name = "lCluster";
            this.lCluster.Size = new System.Drawing.Size(39, 13);
            this.lCluster.TabIndex = 7;
            this.lCluster.Text = "Cluster";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.bConnect);
            this.groupBox1.Controls.Add(this.tbHost);
            this.groupBox1.Controls.Add(this.lCluster);
            this.groupBox1.Controls.Add(this.cbCluster);
            this.groupBox1.Location = new System.Drawing.Point(12, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 63);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Redirect";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(260, 30);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(64, 22);
            this.textBox3.TabIndex = 14;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Host";
            // 
            // bConnect
            // 
            this.bConnect.Location = new System.Drawing.Point(347, 19);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(89, 34);
            this.bConnect.TabIndex = 10;
            this.bConnect.Text = "Connect";
            this.bConnect.UseVisualStyleBackColor = true;
            // 
            // tbHost
            // 
            this.tbHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHost.Location = new System.Drawing.Point(105, 30);
            this.tbHost.MaxLength = 300;
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(131, 22);
            this.tbHost.TabIndex = 8;
            this.tbHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AweSimMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(479, 178);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lPassword);
            this.Controls.Add(this.lUsername);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pbAweSimLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AweSimMain";
            this.Text = "AweSim Connect";
            this.Load += new System.EventHandler(this.AweSimMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbAweSimLogo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbAweSimLogo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lUsername;
        private System.Windows.Forms.Label lPassword;
        private System.Windows.Forms.ComboBox cbCluster;
        private System.Windows.Forms.Label lCluster;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.Button bConnect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;

    }
}

