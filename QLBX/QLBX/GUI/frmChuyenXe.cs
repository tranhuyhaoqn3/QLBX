using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBX.DAO;
using QLBX.BUS;

namespace QLBX.GUI
{
    public partial class frmChuyenXe : UserControl
    {
        bool luu = true;
        public frmChuyenXe()
        {
            InitializeComponent();
            //grid1.FindClick += GridUS1_FindClick;
            taskcontrol1.AddEvent += TaskControl1_AddEvent;
            taskcontrol1.SaveEvent += TaskControl1_SaveEvent;
            taskcontrol1.CalcelEvent += TaskControl1_CalcelEvent;
            taskcontrol1.EditEvent += TaskControl1_EditEvent;
            taskcontrol1.DeleteEvent += TaskControl1_DeleteEvent;
            grid1.Cellclick += GridUS1_CellClick;
            LoadAll();
        }
        private void GridUS1_CellClick(object sender, EventArgs e)
        {
            Bind();
            

            taskcontrol1.IsRowClick = true;
        }
        private void LoadAll()
        {
            grid1.visiblefind();
            panel1.Enabled = false;

            ChuyenXeBO chuyenxeBO = new ChuyenXeBO();
            var rs = chuyenxeBO.ChuyenXe();
            if (rs != null&&rs.Count>0)
            {
                btAdd.Enabled = true;

                grid1.Source = rs;
                grid1.Mapcolumn("IDChuyen", "ID chuyến");
                grid1.Mapcolumn("GiaVe", "Giá vé");
                grid1.Mapcolumn("DiaDiemDi", "Địa điểm đi");
                grid1.Mapcolumn("DiaDiemVe", "Địa điểm đến");
               
                grid1.columnwidth();

            }
            else
            {
                MessageBox.Show("Không có chuyến nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btAdd.Enabled = false;
            }
            BenXeBO benxeBO = new BenXeBO();
            var rs1= benxeBO.benxe();
            var rs2= benxeBO.benxeve();
            if (rs1 != null && rs1.Count > 0 && rs2 != null && rs2.Count > 0)
            {
                cboDiaDiemDi.DataSource = rs1;
                cboDiaDiemDi.DisplayMember = "DiaDiemDi";
                cboDiaDiemVe.DataSource = rs2;
                cboDiaDiemVe.DisplayMember = "DiaDiemVe";
            }

        }
        private void Bind()
        {
            var ob = grid1.GetRow();
            cboDiaDiemDi.Text = ob.Cells["DiaDiemDi"].Value.ToString();
            cboDiaDiemVe.Text = ob.Cells["DiaDiemVe"].Value.ToString();
            txtGia.Text = ob.Cells["GiaVe"].Value.ToString();
        }
        private void TaskControl1_SaveEvent(object sender, EventArgs e)
        {
            if (!inputIsCorrect()) return;
            taskcontrol1.isSuccessFul = true;
            if (luu == true)
            {
                ChuyenXe chuyenxe = new ChuyenXe();
                BenXeBO benxeBO = new BenXeBO();
                BenXeDi benxediDTO = new BenXeDi();
                benxediDTO.DiaDiemDi = cboDiaDiemDi.Text;
                chuyenxe.IDBenXeDi = benxeBO.mabenxedi(benxediDTO);
                BenXeVe benxeveDTO = new BenXeVe();
                benxeveDTO.DiaDiemVe = cboDiaDiemVe.Text;
                chuyenxe.IDBenXeVe = benxeBO.mabenxeve(benxeveDTO);
                chuyenxe.GiaVe = int.Parse(txtGia.Text);
                ChuyenXeBO chuyenxeBO = new ChuyenXeBO();
                var rs = chuyenxeBO.Insert(chuyenxe);
                if (rs >0)
                {
                    MessageBox.Show("Thêm chuyến xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAll();

                }
                else
                {
                    MessageBox.Show("Thêm chuyến xe không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                ChuyenXe chuyenxe = new ChuyenXe();
                ChuyenXeBO chuyenxeBO = new ChuyenXeBO();
                BenXeBO benxeBO = new BenXeBO();
                var ob = grid1.GetRow();
                chuyenxe.IDChuyen = int.Parse(ob.Cells["IDChuyen"].Value.ToString());
                BenXeDi benxediDTO = new BenXeDi();
                benxediDTO.DiaDiemDi = cboDiaDiemDi.Text;
                chuyenxe.IDBenXeDi = benxeBO.mabenxedi(benxediDTO);
                BenXeVe benxeveDTO = new BenXeVe();
                benxeveDTO.DiaDiemVe = cboDiaDiemVe.Text;
                chuyenxe.IDBenXeVe = benxeBO.mabenxeve(benxeveDTO);
                chuyenxe.GiaVe = int.Parse(txtGia.Text);
                var rs = chuyenxeBO.Update(chuyenxe);
                if (rs == false)
                {
                    MessageBox.Show("Sửa bến xe không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private bool inputIsCorrect()
        {
                if (string.IsNullOrEmpty(txtGia.Text)||!txtGia.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Số tiền không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGia.Focus();
                    return false;
                }
            if (cboDiaDiemDi.Text == cboDiaDiemVe.Text)
            {
                MessageBox.Show("Địa điểm bị trùng nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDiaDiemDi.Focus();
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
        private void TaskControl1_DeleteEvent(object sender, EventArgs e)
        {
            ChuyenXe chuyenxe = new ChuyenXe();
            ChuyenXeBO chuyenxeBO = new ChuyenXeBO();
            var ob = grid1.GetRow();
            chuyenxe.IDChuyen = int.Parse(ob.Cells["IDChuyen"].Value.ToString());
            var kq = chuyenxeBO.Delete(chuyenxe);
            if (kq>0)
            {
                MessageBox.Show("Xóa chuyến xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAll();
                Clear();
            }
            else
            {
                MessageBox.Show("Xóa chuyến xe không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

        }
        private void TaskControl1_EditEvent(object sender, EventArgs e)
        {
            luu = false;
            panel1.Enabled = true;
            


        }
        private void TaskControl1_AddEvent(object sender, EventArgs e)
        {
            luu = true;
            Clear();
            panel1.Enabled = true;
            

        }
        private void TaskControl1_CalcelEvent(object sender, EventArgs e)
        {
            LoadAll();
            panel1.Enabled = false;
            Clear();
            

        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            frmDatVe frm = new frmDatVe();
            frm.ShowDialog();
        }

    }

}