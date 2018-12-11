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
using QLBX.DAO;

namespace QLBX.GUI
{
    public partial class frmBenxee : UserControl
    {
        BenXeBO benxeBO = new BenXeBO();
        private bool luu;
        public frmBenxee()
        {
            InitializeComponent();
            grid1.FindClick += GridUS1_FindClick;
            taskcontrol1.AddEvent += TaskControl1_AddEvent;
            taskcontrol1.SaveEvent += TaskControl1_SaveEvent;
            taskcontrol1.CalcelEvent += TaskControl1_CalcelEvent;
            taskcontrol1.EditEvent += TaskControl1_EditEvent;
            taskcontrol1.DeleteEvent += TaskControl1_DeleteEvent;
            grid1.Cellclick += GridUS1_CellClick;
            LoadAll();
        }
        BenXeDi dto1;
        private void GridUS1_CellClick(object sender, EventArgs e)
        {
             dto1 = grid1.GetValueRow() as BenXeDi;
            txtTenbenxe.Text = dto1.TenBenXe;
            txtDiadiem.Text = dto1.DiaDiemDi;

            taskcontrol1.IsRowClick = true;
        }
        private void TaskControl1_DeleteEvent(object sender, EventArgs e)
        {
            BenXeBO benxeBO = new BenXeBO();

            var rs = benxeBO.Delete(dto1);
            if (rs == true)
            {

                MessageBox.Show("Xóa bến xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAll();

            }
            else
            {
                MessageBox.Show("Xóa bến xe không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadAll();
            Clear();
        }

        private void TaskControl1_EditEvent(object sender, EventArgs e)
        {
            luu = false;
            txtTenbenxe.Focus();
            panel1.Enabled = true;


        }

        private void TaskControl1_CalcelEvent(object sender, EventArgs e)
        {
            LoadAll();
            panel1.Enabled = false;
            Clear();
        }

        private void TaskControl1_SaveEvent(object sender, EventArgs e)
        {
            if (!inputIsCorrect()) return;
            taskcontrol1.isSuccessFul = true;
            if (luu==true)
            {
                BenXeDi benxe = new BenXeDi();
                benxe.TenBenXe = txtTenbenxe.Text;
                benxe.DiaDiemDi = txtDiadiem.Text;
                BenXeBO benxeBO = new BenXeBO();
                var rs=benxeBO.Insert(benxe);
                if (rs == true)
                {
                    MessageBox.Show("Thêm bến xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAll();

                }
                else
                {
                    MessageBox.Show("Thêm bến xe không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            { 
                BenXeDi dto = grid1.GetValueRow() as BenXeDi;
                dto.TenBenXe = txtTenbenxe.Text;
                dto.DiaDiemDi = txtDiadiem.Text;
                BenXeBO benxeBO = new BenXeBO();
                var rs=benxeBO.Update(dto);
                if (rs == false)
                {
                    MessageBox.Show("Sửa bến xe không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa bến xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAll();

                }
            }
            LoadAll();
            Clear();
            panel1.Enabled = false;
        }

        private void TaskControl1_AddEvent(object sender, EventArgs e)
        {
            luu = true;
            Clear();
            panel1.Enabled = true;
            txtTenbenxe.Focus();
        }

        private void GridUS1_FindClick(object sender, EventArgs e)
        {

            BenXeBO benxeBO = new BenXeBO();
            var rs = new List<BenXeDi>();
            rs = benxeBO.timbenxe(grid1.ThongTinTimKiem);
            grid1.Source = rs;
            grid1.Mapcolumn("IDBenXeDi", "ID bến xe");
            grid1.Mapcolumn("TenBenXe", "Tên bến xe");
            grid1.Mapcolumn("DiaDiem", "Địa điểm");
            grid1.VisibleColumn("ChuyenXes", false);
            grid1.columnwidth();

        }
        private void LoadAll()
        {
            BenXeBO benxeBO = new BenXeBO();
            grid1.Source = benxeBO.benxe();
            grid1.Mapcolumn("IDBenXeDi","ID bến xe");
            grid1.Mapcolumn("TenBenXe", "Tên bến xe");
            grid1.Mapcolumn("DiaDiemDi", "Địa điểm");
            grid1.VisibleColumn("ChuyenXes",false);
            grid1.columnwidth();

            panel1.Enabled = false;
        }
        private bool inputIsCorrect()
        {
            if (string.IsNullOrEmpty(txtTenbenxe.Text))
            {
                MessageBox.Show("Vui lòng nhập tên bến xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenbenxe.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiadiem.Text))
            {
                MessageBox.Show("Vui lòng nhập địa điểm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiadiem.Focus();
                return false;
            }
            return true;
        }
        private void Clear()
        {
            foreach (var item in panel1.Controls)
            {
                if (item is TextBox)
                {
                    (item as TextBox).Text = "";
                }
            }
        }
    }
}
