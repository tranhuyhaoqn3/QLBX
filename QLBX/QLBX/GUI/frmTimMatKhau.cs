using QLBX.BUS;
using QLBX.DAO;
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
    public partial class frmTimMatKhau : Form
    {
        public frmTimMatKhau()
        {
            InitializeComponent();
            this.AcceptButton = button1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DangNhap dangnhap = new DangNhap();
            dangnhap.TaiKhoan = txtTaiKhoan.Text;
            DangNhapBO dangnhapBO = new DangNhapBO();
            var kq = dangnhapBO.QuenMatKhau(dangnhap);
            if(kq==null) MessageBox.Show("Tài khoản không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          else  MessageBox.Show("Mật khẩu của bạn là: "+kq.MatKhau, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }
    }
}
