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
    public partial class frmPhanCong : Form
    {
        private bool isAdd;
        private Xe xe;
        ChuyenXeBO chuyenxeBO = new ChuyenXeBO();
        PhanCongBO phancongBO = new PhanCongBO();
        PhanCong phancongdto = new PhanCong();
       
        public Xe Xe
        {
            get
            {
                return xe;
            }

            set
            {
                xe = value;
            }
        }

        public frmPhanCong()
        {
            InitializeComponent();
            taskcontrol1.AddEvent += TaskControl1_AddEvent;
            taskcontrol1.SaveEvent += TaskControl1_SaveEvent;
            taskcontrol1.CalcelEvent += TaskControl1_CalcelEvent;
            taskcontrol1.DeleteEvent += TaskControl1_DeleteEvent;
            grid1.Cellclick += Grid1_Cellclick;
            taskcontrol1.EditEvent += TaskControl1_EditEvent;
        }

        private void GridUS1_FindClick(object sender, EventArgs e)
        {

            LoadAll();
        }
        private void Grid1_Cellclick(object sender, EventArgs e)
        {
            taskcontrol1.IsRowClick = true;
            panel1.Enabled = false;
            Bind();
        }
        private void TaskControl1_DeleteEvent(object sender, EventArgs e)
        {
            var phancong = new PhanCong()
            {
                IDXe = xe.IDXe,
                IDChuyen = int.Parse(cboLoTrinh.SelectedValue.ToString()),
                NgayKhoiHanh = dtpKhoihanh.Value
            };
            var rs = phancongBO.Delete(phancong);
            if (rs >0)
            {
                GheBO ghebo = new GheBO();
                var rs1 = ghebo.Delete(xe.IDXe, dtpKhoihanh.Value);
                if (rs1>0)
                {
                    MessageBox.Show("Xóa phân công thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAll();
                }
                else MessageBox.Show("Xóa phân công không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
            else
            {
                MessageBox.Show("Xóa phân công không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Clear();
        }
        private void TaskControl1_EditEvent(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            cboLoTrinh.Focus();
            isAdd = false;

            phancongdto.IDXe = xe.IDXe;
            phancongdto.IDChuyen=int.Parse(cboLoTrinh.SelectedValue.ToString());
            phancongdto.NgayKhoiHanh = dtpKhoihanh.Value;
            phancongdto.ThoiGianDen = dtpDen.Value;
        }

        private void TaskControl1_CalcelEvent(object sender, EventArgs e)
        {
            panel1.Enabled = false;
        }

        private void TaskControl1_SaveEvent(object sender, EventArgs e)
        {

            if (!inputIsCorrect()) return;
            taskcontrol1.isSuccessFul = true;
            var phancong = new PhanCong()
            {
              IDXe=xe.IDXe,
              IDChuyen=int.Parse(cboLoTrinh.SelectedValue.ToString()),
              NgayKhoiHanh=dtpKhoihanh.Value,
              ThoiGianDen=dtpDen.Value
              
            };
            if (isAdd)
            {
                
                var rs = phancongBO.Insert(phancong);
                if (rs == true)

                {
                    List<LoaiXe> listloai = new List<LoaiXe>();
                    LoaiXeBO loaiBO = new LoaiXeBO();
                     listloai = loaiBO.GetAll();

                    if (listloai != null)
                    {
                        foreach (var item in listloai)
                        {
                            if (item.IDLoai == xe.IDLoai)
                            {
                                GheBO gheBO = new GheBO();
                                String temp = "A";
                                int vitri = 1;
                                for (int i = 0; i < item.SoGhe; i++)
                                {
                                    if (i == 20)
                                    {
                                        temp = "B";
                                        vitri = 1;
                                    }
                                    var ghe = new Ghe()
                                    {
                                        ViTri = temp + vitri,
                                        TinhTrang = 0,
                                        IDXe = xe.IDXe,
                                        NgayKhoiHanh=phancong.NgayKhoiHanh
                                    };
                                    var rs2 = gheBO.Add(ghe);
                                    if (rs2 == false)
                                    {
                                        MessageBox.Show("Phân công không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    vitri++;
                                }
                            }
                        }
                    }
                
                else
                {
                    MessageBox.Show("Phân công không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                    MessageBox.Show("Phân công thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAll();

                }
                else
                {
                    MessageBox.Show("Phân công không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                var rs = phancongBO.Update(phancongdto,phancong);
                if(rs>0)
                {
                    GheBO ghebo = new GheBO();
                    var rs1 =ghebo.UpdateNgayKH(xe.IDXe,phancongdto.NgayKhoiHanh,phancong.NgayKhoiHanh);
                    if (rs1 >0)
                    { MessageBox.Show("Sửa phân công thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAll();
                    }
                    else
                    
                        MessageBox.Show("Sửa phân công không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                else MessageBox.Show("Sửa phân công không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            panel1.Enabled = false;
            Clear();
        }

        private void TaskControl1_AddEvent(object sender, EventArgs e)
        {
            isAdd = true;
            Clear();
            panel1.Enabled = true;
            cboLoTrinh.Focus();
        }
        private void Clear()
        {
            foreach (var item in panel1.Controls)
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
            if (string.IsNullOrEmpty(cboLoTrinh.Text))
            {
                MessageBox.Show("Vui lòng chọn lộ trình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoTrinh.Focus();
                return false;
            }
            if (dtpKhoihanh.Value>=dtpDen.Value)
            {
                MessageBox.Show("Thời gian đến phải lớn hơn thời gian khởi hành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoTrinh.Focus();
                return false;
            }
            return true;
        }
        private void LoadAll()
        {
            grid1.Source = null;
            grid1.visiblefind();

            var rs = new List<object>();
            rs = phancongBO.GetAll(xe);
            if (rs != null && rs.Count > 0)
            {
                grid1.Source = rs;
                grid1.Mapcolumn("IDXe", "ID Xe");
                grid1.Mapcolumn("LoTrinh", "Lộ trình");
                grid1.Mapcolumn("NgayKhoiHanh","Ngày khởi hành");
                grid1.Mapcolumn("SoGHe", "Số ghế còn");
                grid1.Mapcolumn("ThoiGianDen", "Thời gian đến");
                grid1.columnwidth();
            }
            var rs1= chuyenxeBO.getLotrinh();
            if (rs1 != null && rs1.Count > 0)
            {
                cboLoTrinh.DataSource = rs1;
                cboLoTrinh.DisplayMember = "LoTrinh";
                cboLoTrinh.ValueMember = "IDChuyen";
            }
        }

        private void Bind()
        {
            var ob = grid1.GetRow();
            cboLoTrinh.Text = ob.Cells["LoTrinh"].Value.ToString();
            dtpKhoihanh.Value= DateTime.Parse(ob.Cells["NgayKhoiHanh"].Value.ToString());
            dtpDen.Value= DateTime.Parse(ob.Cells["ThoiGianDen"].Value.ToString());
        }


        private void frmPhanCong_Load(object sender, EventArgs e)
        {
           LoadAll();
           

        }

    }
}
