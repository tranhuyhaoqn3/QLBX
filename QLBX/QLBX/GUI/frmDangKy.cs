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
    public partial class frmDangKy : Form
    {
       public frmDangKy()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (!txtTaiKhoan.Text.Trim().Equals("") && !txtMatKhau.Text.Trim().Equals(""))
            {

                DangNhap signUp = new DangNhap();
                signUp.TaiKhoan = txtTaiKhoan.Text;
                signUp.MatKhau = txtMatKhau.Text;

                DangNhapBO signInBO = new DangNhapBO();

                if (signInBO.KiemTraTenDangNhap(signUp) == false)
                {
                   if( signInBO.SignUpDisplay(signUp)>0)
                    MessageBox.Show("Đăng kí thành công", "Thông báo");
                   else
                    {
                        MessageBox.Show("Đăng kí không thành công", "Thông báo");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("xin mời nhập đầy dủ thông tin", "Thông báo");
            }
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            frmDangNhap dangnhap = new frmDangNhap();
            this.Hide();
            dangnhap.ShowDialog();
            this.Close();
        }
    }
}