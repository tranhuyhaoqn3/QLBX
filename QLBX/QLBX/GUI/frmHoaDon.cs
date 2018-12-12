using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBX.BUS;

namespace QLBX.GUI
{
    public partial class frmHoaDon : UserControl
    {
        public frmHoaDon()
        {
            InitializeComponent();
            grid1.visiblefind();
            grid1.Cellclick += GridUS1_CellClick;
            loadAll();

        }
        private void loadAll()
        {
            HoaDonBO hoadonBO = new HoaDonBO();
            var rs = hoadonBO.ChuyenXe();
            if (rs != null && rs.Count>0)
            {
                grid1.Source = rs;
                grid1.Mapcolumn("IDHoaDon", "Mã hóa đơn");
                grid1.Mapcolumn("Ten", "Tên khách hàng");
                grid1.Mapcolumn("NgayDat", "Ngày đặt vé");
                grid1.Mapcolumn("TongTien", "Tổng tiền");
                grid1.columnwidth();
            }
            txtdat.Enabled = false;
        }
        private void GridUS1_CellClick(object sender, EventArgs e)
        {
            int mahoadon;
            var ob = grid1.GetRow();
            mahoadon = int.Parse(ob.Cells["IDHoaDon"].Value.ToString());
            HoaDonBO hoadonBO = new HoaDonBO();
   
            int kq = hoadonBO.sovedat(mahoadon);
            txtdat.Text = kq.ToString();
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int mahoadon;
            var ob = grid1.GetRow();
            mahoadon = int.Parse(ob.Cells["IDHoaDon"].Value.ToString());
            frmChiTietHoaDon frm = new frmChiTietHoaDon(mahoadon);
            frm.ShowDialog();
        }

    }


}
