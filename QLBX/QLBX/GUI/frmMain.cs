using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBX.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
  
        }
        private Button bt;
        private void btacc_Click(object sender, EventArgs e)
        {
            this.pnMain.Controls.Clear();
            btselec(sender);
            frmIntroduce frm = new frmIntroduce();
            this.pnMain.Controls.Add(frm);
            frm.Show();
        }

        private void bttrip_Click(object sender, EventArgs e)
        {
            this.pnMain.Controls.Clear();
            btselec(sender);
            frmChuyenXe frm = new frmChuyenXe();
            this.pnMain.Controls.Add(frm);
            frm.Show();


        }

        private void btcoach_Click(object sender, EventArgs e)
        {
            this.pnMain.Controls.Clear();
            btselec(sender);
            frmNhaXe frm = new frmNhaXe();
            this.pnMain.Controls.Add(frm);
            frm.Show();
        }

        private void btstation_Click(object sender, EventArgs e)
        {
            this.pnMain.Controls.Clear();
            btselec(sender);
            frmBenxee frm = new frmBenxee();
            this.pnMain.Controls.Add(frm);
            frm.Show();
        }

        private void btchar_Click(object sender, EventArgs e)
        {
            this.pnMain.Controls.Clear();
            btselec(sender);
            frmHoaDon frm = new frmHoaDon();
            this.pnMain.Controls.Add(frm);
            frm.Show();
        }

        private void btinfo_Click(object sender, EventArgs e)
        {
            this.pnMain.Controls.Clear();
            btselec(sender);
            frmThongTinChuongTrinh frm = new frmThongTinChuongTrinh();
            this.pnMain.Controls.Add(frm);
            frm.Show();
        }
        private void btselec(object sender)
        {
            if (bt != null)
            {
                bt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            }
            bt = (Button)sender;
            bt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(132)))), ((int)(((byte)(202)))));
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmIntroduce frm = new frmIntroduce();
            this.pnMain.Controls.Add(frm);
            frm.Show();
        }
    }
}
