using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBX.BUS;
using QLBX.DAO;
namespace QLBX.GUI
{
    public partial class frmDangNhap : Form
    {
        DangNhapBO dangnhapBO;
        public frmDangNhap()
        {
            InitializeComponent();
            dangnhapBO = new DangNhapBO();
            this.AcceptButton = btnDangnhap;
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            DangNhap user = new DangNhap();
            user.TaiKhoan = txtTaiKhoan.Text;
            user.MatKhau = txtMatKhau.Text;
            bool b = dangnhapBO.DangNhap(user);
            if (b)
            {
                frmMain frm = new frmMain();
                this.Visible = false;
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                if (dangnhapBO.Error != null)
                {
                    MessageBox.Show(dangnhapBO.Error.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Tài khoản không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmTimMatKhau frm = new frmTimMatKhau();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }

        private void linkLabelDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDangKy frm = new frmDangKy();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }
    }
}
