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
    public partial class frmXe : Form
    {
        private NhaXe nhaxe;
        private bool isAdd;
        private bool isFind;
        XeBO xeBO = new XeBO();
        public frmXe()
        {
            InitializeComponent();
            taskcontrol1.AddEvent += TaskControl1_AddEvent;
            taskcontrol1.SaveEvent += TaskControl1_SaveEvent;
            taskcontrol1.CalcelEvent += TaskControl1_CalcelEvent;
            taskcontrol1.EditEvent += TaskControl1_EditEvent;
            taskcontrol1.DeleteEvent += TaskControl1_DeleteEvent;
            grid1.FindClick += GridUS1_FindClick;
            grid1.Cellclick += Grid1_Cellclick;
        }

        public NhaXe Nhaxe
        {
            get
            {
                return nhaxe;
            }

            set
            {
                nhaxe = value;
                lbXe.Text += nhaxe.Ten;
            }
        }
        private void Grid1_Cellclick(object sender, EventArgs e)
        {
            taskcontrol1.IsRowClick = true;
            pnHead.Enabled = false;
            Bind();
        }

        private void GridUS1_FindClick(object sender, EventArgs e)
        {
            isFind = true;
            LoadAll();
        }

        private void TaskControl1_DeleteEvent(object sender, EventArgs e)
        {

            Xe xe = new Xe() { IDXe = int.Parse(txtID.Text) };
            var rs = xeBO.Delete(xe);
            if (rs == true)
            {
                MessageBox.Show("Xóa xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAll();
            }
            else
            {
                MessageBox.Show("Xóa xe không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Clear();
       
        }

        private void TaskControl1_EditEvent(object sender, EventArgs e)
        {
            pnHead.Enabled = true;
            txtLoai.Focus();
            isAdd = false;
        }

        private void TaskControl1_CalcelEvent(object sender, EventArgs e)
        {
            pnHead.Enabled = false;

        }

        private void TaskControl1_SaveEvent(object sender, EventArgs e)
        {
            isFind = false;
            if (!inputIsCorrect()) return;
            taskcontrol1.isSuccessFul = true;
            var xe = new Xe()
            {
                Loai=txtLoai.Text,
                BienSoXe=txtSo.Text,
                SoGhe=int.Parse(txtsoghe.Text),
            };
            if (isAdd)
            {
                xe.IDNhaXe = nhaxe.IDNhaXe;
                var rs = xeBO.Add(xe);
                if (rs == true)
                {
                    MessageBox.Show("Thêm xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAll();

                }
                else
                {
                    MessageBox.Show("Thêm xe không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                 xe.IDXe= int.Parse(txtID.Text);
                var rs = xeBO.Update(xe);
                if (rs == false)
                {
                    MessageBox.Show("Sửa xe không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAll();

                }
            }
            pnHead.Enabled = false;
            Clear();
        }

        private void TaskControl1_AddEvent(object sender, EventArgs e)
        {
            isAdd = true;
            Clear();
            pnHead.Enabled = true;
            txtLoai.Focus();
        }
        private void Clear()
        {
            foreach (var item in pnHead.Controls)
            {
                if (item is TextBox)
                {
                    (item as TextBox).Text = "";
                }
                else if (item is ComboBox)
                {
                    (item as ComboBox).SelectedIndex = -1;
                }
                else if (item is DateTimePicker)
                {
                    (item as DateTimePicker).Value = DateTime.Now;
                }
                else if (item is PictureBox)
                {
                    (item as PictureBox).Image = null;
                }
            }
        }
        private bool inputIsCorrect()
        {
            if (string.IsNullOrEmpty(txtSo.Text))
            {
                MessageBox.Show("Vui lòng nhập biển số xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtLoai.Text))
            {
                MessageBox.Show("Vui lòng nhập loại xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSo.Focus();
                return false;
            }
            if (txtsoghe.Text != "")
            {
                if (!txtsoghe.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Số ghế không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtsoghe.Focus();
                    return false;
                }
            }
            return true;
        }
        private void LoadAll()
        {
            grid1.Source = null;
            var rs = new List<Xe>();
            if (isFind)
            {
                rs = xeBO.FindByName(grid1.ThongTinTimKiem);
            }
            else
            {
                rs = xeBO.GetAll(nhaxe);
            }

            if (rs != null && rs.Count > 0)
            {
                grid1.Source = rs;
                grid1.Mapcolumn("IDXe", "ID");
                grid1.Mapcolumn("BienSoXe", "Biển số xe");
                grid1.Mapcolumn("Loai", "Loại");
                grid1.Mapcolumn("SoGhe", "Số ghế");

                grid1.VisibleColumn("IDNhaXe", false);
                grid1.VisibleColumn("Ghes", false);
                grid1.VisibleColumn("NhaXe", false);
                grid1.VisibleColumn("PhanCongs", false);
            }
        }
        private void Bind()
        {
            var xe = grid1.GetValueRow() as Xe;
            txtID.Text = xe.IDXe.ToString();
            txtSo.Text = xe.BienSoXe;
            txtLoai.Text = xe.Loai;
            txtsoghe.Text = xe.SoGhe.ToString();
        }

        private void frmXe_Load(object sender, EventArgs e)
        {
            LoadAll();
        }

    }
}