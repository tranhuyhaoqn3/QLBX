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
        XeBO xeBO = new XeBO();
        List<LoaiXe> listloai;
        public frmXe()
        {
            InitializeComponent();
            taskcontrol1.AddEvent += TaskControl1_AddEvent;
            taskcontrol1.SaveEvent += TaskControl1_SaveEvent;
            taskcontrol1.CalcelEvent += TaskControl1_CalcelEvent;
            taskcontrol1.EditEvent += TaskControl1_EditEvent;
            taskcontrol1.DeleteEvent += TaskControl1_DeleteEvent;
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
            btChuyen.Enabled = true;
        }


        private void TaskControl1_DeleteEvent(object sender, EventArgs e)
        {

            Xe xe = new Xe() { IDXe = int.Parse(txtID.Text) };
            var rs = xeBO.Delete(xe);
            if (rs >0)
            {
                MessageBox.Show("Xóa xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAll();
            }
            else
            {
                MessageBox.Show("Xóa xe không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Clear();
            btChuyen.Enabled = false;
        }

        private void TaskControl1_EditEvent(object sender, EventArgs e)
        {
            pnHead.Enabled = true;
            cbbLoai.Focus();
            isAdd = false;
            cbbLoai.Enabled = false;
            btChuyen.Enabled = false;
        }

        private void TaskControl1_CalcelEvent(object sender, EventArgs e)
        {
            pnHead.Enabled = false;
            btChuyen.Enabled = false;
        }

        private void TaskControl1_SaveEvent(object sender, EventArgs e)
        {
            if (!inputIsCorrect()) return;
            taskcontrol1.isSuccessFul = true;
            var xe = new Xe()
            {
                IDLoai =int.Parse( cbbLoai.SelectedValue.ToString()),
                BienSoXe=txtSo.Text
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
                    MessageBox.Show("Thêm xe không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                 xe.IDXe= int.Parse(txtID.Text);
                var rs = xeBO.Update(xe);
                if (rs == false)
                {
                    MessageBox.Show("Sửa xe không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Sửa xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAll();

                }
            }
            pnHead.Enabled = false;
            Clear();
            btChuyen.Enabled = false;

        }

        private void TaskControl1_AddEvent(object sender, EventArgs e)
        {
            isAdd = true;
            Clear();
            pnHead.Enabled = true;
            cbbLoai.Enabled = true;
            cbbLoai.Focus();
            btChuyen.Enabled = false;
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
            if (string.IsNullOrEmpty(cbbLoai.Text))
            {
                MessageBox.Show("Vui lòng chọn loại xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSo.Focus();
                return false;
            }
            return true;
        }
        private void LoadAll()
        {
            grid1.Source = null;
            var rs = new List<object>();      
              
                rs = xeBO.GetAll(nhaxe);

            if (rs != null && rs.Count > 0)
            {
    
                grid1.Source = rs;
                grid1.Mapcolumn("IDXe", "ID");
                grid1.Mapcolumn("BienSoXe", "Biển số xe");
                grid1.Mapcolumn("Ten", "Loại xe");
                grid1.Mapcolumn("SoGhe", "Số ghế");
                grid1.columnwidth();


            }

        }
        private void Bind()
        {
            var ob = grid1.GetRow();
            txtID.Text = ob.Cells["IDXe"].Value.ToString();
            txtSo.Text = ob.Cells["BienSoXe"].Value.ToString();
            cbbLoai.Text = ob.Cells["Ten"].Value.ToString();
            txtSoghe.Text = ob.Cells["SoGhe"].Value.ToString();
        }

        private void frmXe_Load(object sender, EventArgs e)
        {
            LoadAll();
            mapcombobox();
            grid1.visiblefind();

        }
        private void mapcombobox()
        {
            LoaiXeBO loaixeBO = new LoaiXeBO();
            listloai = loaixeBO.GetAll();
            cbbLoai.DataSource = listloai;
            cbbLoai.ValueMember = "IDLoai";
            cbbLoai.DisplayMember = "Ten";
        }

        private void cbbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
             sender = cbbLoai.SelectedValue;
            if (sender == null) return;
            foreach (var item1 in listloai)
            {
                if(item1.IDLoai.ToString() == sender.ToString())
                {
                    txtSoghe.Text = item1.SoGhe.ToString();
                }
            }
        }
        private void btChuyen_Click(object sender, EventArgs e)
        {
            frmPhanCong frm = new frmPhanCong();
            var xe = new Xe()
            {
                IDXe = int.Parse(txtID.Text),
                IDLoai=int.Parse(cbbLoai.SelectedValue.ToString())
            };
            frm.Xe = xe;
            frm.ShowDialog();
        }
    }
}