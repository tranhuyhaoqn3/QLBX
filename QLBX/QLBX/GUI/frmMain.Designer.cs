namespace QLBX.GUI
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnLeft = new System.Windows.Forms.Panel();
            this.btinfo = new System.Windows.Forms.Button();
            this.btchar = new System.Windows.Forms.Button();
            this.btstation = new System.Windows.Forms.Button();
            this.btcoach = new System.Windows.Forms.Button();
            this.bttrip = new System.Windows.Forms.Button();
            this.btacc = new System.Windows.Forms.Button();
            this.pnLogo = new System.Windows.Forms.Panel();
            this.pnTop = new System.Windows.Forms.Panel();
            this.pnMain = new System.Windows.Forms.Panel();
            this.pnLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnLeft
            // 
            this.pnLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.pnLeft.Controls.Add(this.btinfo);
            this.pnLeft.Controls.Add(this.btchar);
            this.pnLeft.Controls.Add(this.btstation);
            this.pnLeft.Controls.Add(this.btcoach);
            this.pnLeft.Controls.Add(this.bttrip);
            this.pnLeft.Controls.Add(this.btacc);
            this.pnLeft.Controls.Add(this.pnLogo);
            this.pnLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnLeft.Location = new System.Drawing.Point(0, 0);
            this.pnLeft.Name = "pnLeft";
            this.pnLeft.Size = new System.Drawing.Size(192, 553);
            this.pnLeft.TabIndex = 3;
            // 
            // btinfo
            // 
            this.btinfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btinfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btinfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btinfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btinfo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btinfo.ForeColor = System.Drawing.Color.White;
            this.btinfo.Image = global::QLBX.Properties.Resources.Info_32px;
            this.btinfo.Location = new System.Drawing.Point(0, 489);
            this.btinfo.Name = "btinfo";
            this.btinfo.Size = new System.Drawing.Size(192, 65);
            this.btinfo.TabIndex = 10;
            this.btinfo.Text = "Thông tin \r\nchương trình";
            this.btinfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btinfo.UseVisualStyleBackColor = false;
            this.btinfo.Click += new System.EventHandler(this.btinfo_Click);
            // 
            // btchar
            // 
            this.btchar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btchar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btchar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btchar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btchar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btchar.ForeColor = System.Drawing.Color.White;
            this.btchar.Image = global::QLBX.Properties.Resources.Combo_Chart_32px;
            this.btchar.Location = new System.Drawing.Point(0, 424);
            this.btchar.Name = "btchar";
            this.btchar.Size = new System.Drawing.Size(192, 65);
            this.btchar.TabIndex = 9;
            this.btchar.Text = "Thống kê hóa đơn";
            this.btchar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btchar.UseVisualStyleBackColor = false;
            this.btchar.Click += new System.EventHandler(this.btchar_Click);
            // 
            // btstation
            // 
            this.btstation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btstation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btstation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btstation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btstation.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btstation.ForeColor = System.Drawing.Color.White;
            this.btstation.Image = global::QLBX.Properties.Resources._12718435381496695090bus_stop3___1_;
            this.btstation.Location = new System.Drawing.Point(0, 359);
            this.btstation.Name = "btstation";
            this.btstation.Size = new System.Drawing.Size(192, 65);
            this.btstation.TabIndex = 8;
            this.btstation.Text = "Bến xe";
            this.btstation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btstation.UseVisualStyleBackColor = false;
            this.btstation.Click += new System.EventHandler(this.btstation_Click);
            // 
            // btcoach
            // 
            this.btcoach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btcoach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btcoach.Dock = System.Windows.Forms.DockStyle.Top;
            this.btcoach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btcoach.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btcoach.ForeColor = System.Drawing.Color.White;
            this.btcoach.Image = global::QLBX.Properties.Resources.Webp_net_resizeimage__1_;
            this.btcoach.Location = new System.Drawing.Point(0, 294);
            this.btcoach.Name = "btcoach";
            this.btcoach.Size = new System.Drawing.Size(192, 65);
            this.btcoach.TabIndex = 7;
            this.btcoach.Text = "Nhà xe";
            this.btcoach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btcoach.UseVisualStyleBackColor = false;
            this.btcoach.Click += new System.EventHandler(this.btcoach_Click);
            // 
            // bttrip
            // 
            this.bttrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.bttrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bttrip.Dock = System.Windows.Forms.DockStyle.Top;
            this.bttrip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttrip.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttrip.ForeColor = System.Drawing.Color.White;
            this.bttrip.Image = global::QLBX.Properties.Resources.route_1288208__1_;
            this.bttrip.Location = new System.Drawing.Point(0, 229);
            this.bttrip.Name = "bttrip";
            this.bttrip.Size = new System.Drawing.Size(192, 65);
            this.bttrip.TabIndex = 6;
            this.bttrip.Text = "Chuyến xe";
            this.bttrip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bttrip.UseVisualStyleBackColor = false;
            this.bttrip.Click += new System.EventHandler(this.bttrip_Click);
            // 
            // btacc
            // 
            this.btacc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btacc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btacc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btacc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btacc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btacc.ForeColor = System.Drawing.Color.White;
            this.btacc.Image = ((System.Drawing.Image)(resources.GetObject("btacc.Image")));
            this.btacc.Location = new System.Drawing.Point(0, 164);
            this.btacc.Name = "btacc";
            this.btacc.Size = new System.Drawing.Size(192, 65);
            this.btacc.TabIndex = 0;
            this.btacc.Text = "Admin";
            this.btacc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btacc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btacc.UseVisualStyleBackColor = false;
            this.btacc.Click += new System.EventHandler(this.btacc_Click);
            // 
            // pnLogo
            // 
            this.pnLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnLogo.BackgroundImage")));
            this.pnLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLogo.Location = new System.Drawing.Point(0, 0);
            this.pnLogo.Name = "pnLogo";
            this.pnLogo.Size = new System.Drawing.Size(192, 164);
            this.pnLogo.TabIndex = 5;
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(192, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(692, 45);
            this.pnTop.TabIndex = 4;
            // 
            // pnMain
            // 
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(192, 45);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(692, 508);
            this.pnMain.TabIndex = 5;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(884, 553);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.pnTop);
            this.Controls.Add(this.pnLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QLBX";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnLeft;
        private System.Windows.Forms.Button btacc;
        private System.Windows.Forms.Panel pnLogo;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Button btinfo;
        private System.Windows.Forms.Button btchar;
        private System.Windows.Forms.Button btstation;
        private System.Windows.Forms.Button btcoach;
        private System.Windows.Forms.Button bttrip;
    }
}

