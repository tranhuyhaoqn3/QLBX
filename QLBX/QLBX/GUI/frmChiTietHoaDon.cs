using QLBX.BUS;
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
    public partial class frmChiTietHoaDon : Form
    {
        public frmChiTietHoaDon(int mahoadon)
        {
            InitializeComponent();
            loadAll(mahoadon);
            tenXe(mahoadon);
            grid1.visiblefind();
            lotrinh(mahoadon);
            ngaykhoihanh(mahoadon);
            panel1.Enabled = false;
        }
        public void loadAll(int mahoadon)
        {
            ChiTietHoaDonBO chitiethoadonBO = new ChiTietHoaDonBO();
            grid1.Source = chitiethoadonBO.chitiethoadon(mahoadon);
            grid1.columnwidth();
            grid1.visiblefind();
        }
        public void tenXe(int mahoadon)
        {
            ChiTietHoaDonBO chitiethoadonBO = new ChiTietHoaDonBO();
            txtTenXe.Text = chitiethoadonBO.TenXe(mahoadon);
        }
        public void lotrinh(int mahoadon)
        {
            ChiTietHoaDonBO chitiethoadonBO = new ChiTietHoaDonBO();
            var rs = chitiethoadonBO.LoTrinh(mahoadon);
            foreach (var item in rs)
            {
                txtLoTrinh.Text = item;
                return;
            }

        }
        public void ngaykhoihanh(int mahoadon)
        {
            ChiTietHoaDonBO chitiethoadonBO = new ChiTietHoaDonBO();
            dtmNgay.Text = chitiethoadonBO.ngayxuatphat(mahoadon).ToString();
        }
    }
}
