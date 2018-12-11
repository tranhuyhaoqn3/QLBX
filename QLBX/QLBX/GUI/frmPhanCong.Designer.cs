namespace QLBX.GUI
{
    partial class frmPhanCong
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpDen = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpKhoihanh = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLoTrinh = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.taskcontrol1 = new QLBX.GUI.taskcontrol();
            this.grid1 = new QLBX.GUI.Grid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpDen);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpKhoihanh);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboLoTrinh);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 111);
            this.panel1.TabIndex = 0;
            // 
            // dtpDen
            // 
            this.dtpDen.CustomFormat = "\"MM/dd/yyyy hh:mm:ss\"";
            this.dtpDen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDen.Location = new System.Drawing.Point(168, 83);
            this.dtpDen.Name = "dtpDen";
            this.dtpDen.Size = new System.Drawing.Size(174, 22);
            this.dtpDen.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(62, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Thời gian đến";
            // 
            // dtpKhoihanh
            // 
            this.dtpKhoihanh.CustomFormat = "\"MM/dd/yyyy hh:mm:ss\"";
            this.dtpKhoihanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpKhoihanh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpKhoihanh.Location = new System.Drawing.Point(168, 49);
            this.dtpKhoihanh.Name = "dtpKhoihanh";
            this.dtpKhoihanh.Size = new System.Drawing.Size(174, 22);
            this.dtpKhoihanh.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(62, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ngày khởi hành";
            // 
            // cboLoTrinh
            // 
            this.cboLoTrinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoTrinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoTrinh.FormattingEnabled = true;
            this.cboLoTrinh.Location = new System.Drawing.Point(167, 11);
            this.cboLoTrinh.Margin = new System.Windows.Forms.Padding(2);
            this.cboLoTrinh.Name = "cboLoTrinh";
            this.cboLoTrinh.Size = new System.Drawing.Size(175, 24);
            this.cboLoTrinh.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(62, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Lộ trình";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.taskcontrol1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 287);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(544, 56);
            this.panel2.TabIndex = 1;
            // 
            // taskcontrol1
            // 
            this.taskcontrol1.isSuccessFul = false;
            this.taskcontrol1.Location = new System.Drawing.Point(52, 12);
            this.taskcontrol1.Name = "taskcontrol1";
            this.taskcontrol1.Size = new System.Drawing.Size(406, 41);
            this.taskcontrol1.TabIndex = 0;
            // 
            // grid1
            // 
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.Location = new System.Drawing.Point(0, 111);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(544, 176);
            this.grid1.Source = null;
            this.grid1.TabIndex = 2;
            this.grid1.ThongTinTimKiem = "";
            // 
            // frmPhanCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 343);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmPhanCong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân công";
            this.Load += new System.EventHandler(this.frmPhanCong_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpKhoihanh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboLoTrinh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private taskcontrol taskcontrol1;
        private Grid grid1;
        private System.Windows.Forms.DateTimePicker dtpDen;
        private System.Windows.Forms.Label label2;
    }
}