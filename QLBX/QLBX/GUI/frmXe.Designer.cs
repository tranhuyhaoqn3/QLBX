namespace QLBX.GUI
{
    partial class frmXe
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
            this.pnHead = new System.Windows.Forms.Panel();
            this.txtSo = new System.Windows.Forms.TextBox();
            this.lbso = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lbID = new System.Windows.Forms.Label();
            this.txtLoai = new System.Windows.Forms.TextBox();
            this.lbLoai = new System.Windows.Forms.Label();
            this.txtsoghe = new System.Windows.Forms.TextBox();
            this.lbsoghe = new System.Windows.Forms.Label();
            this.pnTop = new System.Windows.Forms.Panel();
            this.lbXe = new System.Windows.Forms.Label();
            this.pnBot = new System.Windows.Forms.Panel();
            this.taskcontrol1 = new QLBX.GUI.taskcontrol();
            this.grid1 = new QLBX.GUI.Grid();
            this.pnHead.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.pnBot.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnHead
            // 
            this.pnHead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnHead.Controls.Add(this.txtSo);
            this.pnHead.Controls.Add(this.lbso);
            this.pnHead.Controls.Add(this.txtID);
            this.pnHead.Controls.Add(this.lbID);
            this.pnHead.Controls.Add(this.txtLoai);
            this.pnHead.Controls.Add(this.lbLoai);
            this.pnHead.Controls.Add(this.txtsoghe);
            this.pnHead.Controls.Add(this.lbsoghe);
            this.pnHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHead.Enabled = false;
            this.pnHead.Location = new System.Drawing.Point(0, 53);
            this.pnHead.Name = "pnHead";
            this.pnHead.Size = new System.Drawing.Size(590, 89);
            this.pnHead.TabIndex = 6;
            // 
            // txtSo
            // 
            this.txtSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSo.Location = new System.Drawing.Point(402, 52);
            this.txtSo.Name = "txtSo";
            this.txtSo.Size = new System.Drawing.Size(137, 22);
            this.txtSo.TabIndex = 4;
            // 
            // lbso
            // 
            this.lbso.AutoSize = true;
            this.lbso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbso.ForeColor = System.Drawing.Color.Blue;
            this.lbso.Location = new System.Drawing.Point(315, 55);
            this.lbso.Name = "lbso";
            this.lbso.Size = new System.Drawing.Size(64, 16);
            this.lbso.TabIndex = 6;
            this.lbso.Text = "Biển số:";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(136, 9);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(141, 22);
            this.txtID.TabIndex = 1;
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbID.ForeColor = System.Drawing.Color.Blue;
            this.lbID.Location = new System.Drawing.Point(51, 12);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(54, 16);
            this.lbID.TabIndex = 4;
            this.lbID.Text = "Mã số:";
            // 
            // txtLoai
            // 
            this.txtLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoai.Location = new System.Drawing.Point(402, 12);
            this.txtLoai.Name = "txtLoai";
            this.txtLoai.Size = new System.Drawing.Size(137, 22);
            this.txtLoai.TabIndex = 2;
            // 
            // lbLoai
            // 
            this.lbLoai.AutoSize = true;
            this.lbLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoai.ForeColor = System.Drawing.Color.Blue;
            this.lbLoai.Location = new System.Drawing.Point(315, 15);
            this.lbLoai.Name = "lbLoai";
            this.lbLoai.Size = new System.Drawing.Size(42, 16);
            this.lbLoai.TabIndex = 2;
            this.lbLoai.Text = "Loại:";
            // 
            // txtsoghe
            // 
            this.txtsoghe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsoghe.Location = new System.Drawing.Point(136, 52);
            this.txtsoghe.Name = "txtsoghe";
            this.txtsoghe.Size = new System.Drawing.Size(141, 22);
            this.txtsoghe.TabIndex = 3;
            // 
            // lbsoghe
            // 
            this.lbsoghe.AutoSize = true;
            this.lbsoghe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsoghe.ForeColor = System.Drawing.Color.Blue;
            this.lbsoghe.Location = new System.Drawing.Point(51, 55);
            this.lbsoghe.Name = "lbsoghe";
            this.lbsoghe.Size = new System.Drawing.Size(61, 16);
            this.lbsoghe.TabIndex = 0;
            this.lbsoghe.Text = "Số ghế:";
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.lbXe);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(590, 53);
            this.pnTop.TabIndex = 3;
            // 
            // lbXe
            // 
            this.lbXe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbXe.AutoSize = true;
            this.lbXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbXe.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbXe.Location = new System.Drawing.Point(35, 12);
            this.lbXe.Name = "lbXe";
            this.lbXe.Size = new System.Drawing.Size(175, 29);
            this.lbXe.TabIndex = 5;
            this.lbXe.Text = "Danh sách xe ";
            // 
            // pnBot
            // 
            this.pnBot.Controls.Add(this.taskcontrol1);
            this.pnBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBot.Location = new System.Drawing.Point(0, 401);
            this.pnBot.Name = "pnBot";
            this.pnBot.Size = new System.Drawing.Size(590, 52);
            this.pnBot.TabIndex = 5;
            // 
            // taskcontrol1
            // 
            this.taskcontrol1.isSuccessFul = false;
            this.taskcontrol1.Location = new System.Drawing.Point(22, 6);
            this.taskcontrol1.Name = "taskcontrol1";
            this.taskcontrol1.Size = new System.Drawing.Size(406, 41);
            this.taskcontrol1.TabIndex = 4;
            // 
            // grid1
            // 
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.Location = new System.Drawing.Point(0, 142);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(590, 259);
            this.grid1.Source = null;
            this.grid1.TabIndex = 7;
            this.grid1.ThongTinTimKiem = "";
            // 
            // frmXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 453);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.pnHead);
            this.Controls.Add(this.pnTop);
            this.Controls.Add(this.pnBot);
            this.MaximizeBox = false;
            this.Name = "frmXe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xe";
            this.Load += new System.EventHandler(this.frmXe_Load);
            this.pnHead.ResumeLayout(false);
            this.pnHead.PerformLayout();
            this.pnTop.ResumeLayout(false);
            this.pnTop.PerformLayout();
            this.pnBot.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnHead;
        private System.Windows.Forms.TextBox txtSo;
        private System.Windows.Forms.Label lbso;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.TextBox txtLoai;
        private System.Windows.Forms.Label lbLoai;
        private System.Windows.Forms.TextBox txtsoghe;
        private System.Windows.Forms.Label lbsoghe;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Label lbXe;
        private System.Windows.Forms.Panel pnBot;
        private taskcontrol taskcontrol1;
        private Grid grid1;
    }
}