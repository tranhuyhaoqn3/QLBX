namespace QLBX.GUI
{
    partial class taskcontrol
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
            this.btCan = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btDele = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btCan
            // 
            this.btCan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(233)))));
            this.btCan.Enabled = false;
            this.btCan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCan.Image = global::QLBX.Properties.Resources.Delete_20px;
            this.btCan.Location = new System.Drawing.Point(327, 3);
            this.btCan.Name = "btCan";
            this.btCan.Size = new System.Drawing.Size(75, 34);
            this.btCan.TabIndex = 4;
            this.btCan.Text = "Hủy";
            this.btCan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCan.UseVisualStyleBackColor = false;
            this.btCan.Click += new System.EventHandler(this.btCan_Click);
            // 
            // btSave
            // 
            this.btSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(233)))));
            this.btSave.Enabled = false;
            this.btSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.Image = global::QLBX.Properties.Resources.Save_20px;
            this.btSave.Location = new System.Drawing.Point(246, 3);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 34);
            this.btSave.TabIndex = 3;
            this.btSave.Text = "Lưu";
            this.btSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSave.UseVisualStyleBackColor = false;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btEdit
            // 
            this.btEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(233)))));
            this.btEdit.Enabled = false;
            this.btEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEdit.Image = global::QLBX.Properties.Resources.Edit_20px;
            this.btEdit.Location = new System.Drawing.Point(84, 4);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(75, 34);
            this.btEdit.TabIndex = 2;
            this.btEdit.Text = "Sửa";
            this.btEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btEdit.UseVisualStyleBackColor = false;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btDele
            // 
            this.btDele.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(233)))));
            this.btDele.Enabled = false;
            this.btDele.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDele.Image = global::QLBX.Properties.Resources.Eraser_20px;
            this.btDele.Location = new System.Drawing.Point(165, 3);
            this.btDele.Name = "btDele";
            this.btDele.Size = new System.Drawing.Size(75, 34);
            this.btDele.TabIndex = 1;
            this.btDele.Text = "Xóa";
            this.btDele.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDele.UseVisualStyleBackColor = false;
            this.btDele.Click += new System.EventHandler(this.btDele_Click);
            // 
            // btAdd
            // 
            this.btAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(233)))));
            this.btAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdd.Image = global::QLBX.Properties.Resources.Plus_20px;
            this.btAdd.Location = new System.Drawing.Point(3, 4);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(75, 34);
            this.btAdd.TabIndex = 0;
            this.btAdd.Text = "Thêm";
            this.btAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btAdd.UseVisualStyleBackColor = false;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // taskcontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btCan);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btDele);
            this.Controls.Add(this.btAdd);
            this.Name = "taskcontrol";
            this.Size = new System.Drawing.Size(406, 41);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btDele;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCan;
    }
}
