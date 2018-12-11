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
    public partial class frmNhaXe : UserControl
    {
            private bool isAdd;
            private bool isFind;
            NhaXeBO nhaxeBO = new NhaXeBO();
        public frmNhaXe()
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

        private void Grid1_Cellclick(object sender, EventArgs e)
        {
            taskcontrol1.IsRowClick = true;
            panel3.Enabled = false;
            btAdd.Enabled = true;
            Bind();
        }

        private void GridUS1_FindClick(object sender, EventArgs e)
        {
            isFind = true;
            LoadAll();
        }

        private void TaskControl1_DeleteEvent(object sender, EventArgs e)
        {
            
            NhaXe nx = new NhaXe() { IDNhaXe = int.Parse(txtID.Text) };
            var rs = nhaxeBO.Delete(nx);
            if (rs == true)
            {
                MessageBox.Show("Xóa nhà xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAll();
            }
            else
            {
                MessageBox.Show("Xóa nhà xe không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Clear();
            btAdd.Enabled = false;
        }

        private void TaskControl1_EditEvent(object sender, EventArgs e)
        {
            panel3.Enabled = true;
            txtName.Focus();
            isAdd = false;
            btAdd.Enabled = false;
        }

        private void TaskControl1_CalcelEvent(object sender, EventArgs e)
        {
            panel3.Enabled = false;
            btAdd.Enabled = false;
        }

        private void TaskControl1_SaveEvent(object sender, EventArgs e)
        {
            isFind = false;
            if (!inputIsCorrect()) return;
            taskcontrol1.isSuccessFul = true;
            var nhaxe = new NhaXe()
            {
                Ten = txtName.Text,
                SDT = txtSDT.Text,
            };
            if (isAdd)
            {
                var rs = nhaxeBO.Add(nhaxe);
                if (rs == true)
                {
                    MessageBox.Show("Thêm nhà xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAll();

                }
                else
                {
                    MessageBox.Show("Thêm nhà xe không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                nhaxe.IDNhaXe = int.Parse(txtID.Text);
                var rs = nhaxeBO.Update(nhaxe);
                if (rs == false)
                {
                    MessageBox.Show("Sửa nhà xe không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa nhà xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAll();

                }
            }
            panel3.Enabled = false;
            Clear();
            btAdd.Enabled = false;
        }

        private void TaskControl1_AddEvent(object sender, EventArgs e)
        {
            isAdd = true;
            Clear();
            panel3.Enabled = true;
            txtName.Focus();
            btAdd.Enabled = false;
        }
        private void Clear()
        {
            foreach (var item in panel3.Controls)
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
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (txtSDT.Text != "")
            {
                if (!txtSDT.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSDT.Focus();
                    return false;
                }
            }
            return true;
        }
        private void LoadAll()
        {
            grid1.Source = null;
            var rs = new List<NhaXe>();
            if (isFind)
            {
                rs = nhaxeBO.FindByName(grid1.ThongTinTimKiem);
            }
            else
            {
                rs = nhaxeBO.GetAll();
            }

            if (rs != null && rs.Count > 0)
            {
                grid1.Source = rs;
                grid1.Mapcolumn("IDNhaXe", "ID");
                grid1.Mapcolumn("Ten", "Tên nhà xe");
                grid1.Mapcolumn("SDT", "Số điện thoại");
                grid1.VisibleColumn("Xes", false);
                grid1.columnwidth();
            }
        }
        private void Bind()
        {
            var nhaxe = grid1.GetValueRow() as NhaXe;
            txtID.Text = nhaxe.IDNhaXe.ToString();
            txtName.Text = nhaxe.Ten;
            txtSDT.Text = nhaxe.SDT;
        }
        private void frmNhaXe_Load(object sender, EventArgs e)
        {
            LoadAll();
        }


        private void btAdd_Click(object sender, EventArgs e)
        {
            frmXe frm = new frmXe();
            var nhaxe = new NhaXe()
            {
                IDNhaXe = int.Parse(txtID.Text),
                Ten = txtName.Text,
                SDT = txtSDT.Text,
            };
            frm.Nhaxe = nhaxe;
            frm.ShowDialog();
        }
    }
}
