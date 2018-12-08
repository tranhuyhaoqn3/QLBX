namespace QLBX.GUI
{
    partial class FrmBenXe
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.taskcontrol1 = new QLBX.GUI.taskcontrol();
            this.grid1 = new QLBX.GUI.Grid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grid1);
            this.panel1.Location = new System.Drawing.Point(12, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(717, 396);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.taskcontrol1);
            this.panel2.Location = new System.Drawing.Point(12, 482);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(717, 79);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(717, 68);
            this.label1.TabIndex = 2;
            this.label1.Text = "             Thông tin bến xe";
            // 
            // taskcontrol1
            // 
            this.taskcontrol1.isSuccessFul = false;
            this.taskcontrol1.Location = new System.Drawing.Point(73, 13);
            this.taskcontrol1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.taskcontrol1.Name = "taskcontrol1";
            this.taskcontrol1.Size = new System.Drawing.Size(541, 50);
            this.taskcontrol1.TabIndex = 0;
            // 
            // grid1
            // 
            this.grid1.Location = new System.Drawing.Point(0, 14);
            this.grid1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(717, 367);
            this.grid1.Source = null;
            this.grid1.TabIndex = 0;
            this.grid1.ThongTinTimKiem = "";
            // 
            // FrmBenXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 573);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmBenXe";
            this.Text = "FrmBenXe";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Grid grid1;
        private System.Windows.Forms.Panel panel2;
        private taskcontrol taskcontrol1;
        private System.Windows.Forms.Label label1;
    }
}