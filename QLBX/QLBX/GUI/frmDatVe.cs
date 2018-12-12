using QLBX.BUS;
using QLBX.DAO;
using System;
using System.Collections;
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
    public partial class frmDatVe : Form
    {
        PhanCongBO phancongBO = new PhanCongBO();
        int Tongtien;
        int giave;
        List<Ghe> rs;
        public frmDatVe()
        {
            InitializeComponent();
            grid1.Cellclick += Grid1_Cellclick;
        }

        private void Grid1_Cellclick(object sender, EventArgs e)
        {
            rs = null;
            pnGhe.Controls.Clear();
            var ob = grid1.GetRow();
            GheBO ghebo = new GheBO();
             rs = ghebo.GetAllbyIDNgaykh(int.Parse(ob.Cells["IDXe"].Value.ToString()), DateTime.Parse(ob.Cells["NgayKhoiHanh"].Value.ToString()));
            drawpos(rs);
            lbghe.Text = "";
            lbtien.Text = "";
            Tongtien = 0;
            giave = int.Parse(ob.Cells["GiaVe"].Value.ToString());
        }

        private void frmDatVe_Load(object sender, EventArgs e)
        {
            grid1.visiblefind();
            BenXeBO benxeBO = new BenXeBO();
            cboDiaDiemDi.DataSource = benxeBO.benxe();
            cboDiaDiemDi.DisplayMember = "DiaDiemDi";
            cboDiaDiemDi.ValueMember = "IDBenXeDi";
            
            cboDiaDiemVe.DataSource = benxeBO.benxeve();
            cboDiaDiemVe.DisplayMember = "DiaDiemVe";
            cboDiaDiemVe.ValueMember = "IDBenXeVe";
        }
        private void drawpos(List<Ghe> list)
        {
            int x, y;
            if (list.Count == 9)
            {
                x = 100;
                y = 10;
                int i = 0;
                foreach (Ghe item in list)
                {

                    if (i == 4)
                    {
                        y = 80;
                        x = 100;
                    }
                    if (i == 5)
                    {
                        y = 80;
                        x = 340;
                    }
                    if (i == 6)
                    {
                
                        y = 140;
                        x = 100;
                    }
                        Button bt = new Button() { BackColor = Color.White, Location = new Point(x, y), Width = 60, Height = 25, Cursor = Cursors.Hand };
                    bt.Click += Bt_Click;
                    if (item.TinhTrang == 1)
                    {
                        bt.BackColor = Color.DarkGray;
                        bt.Enabled = false;
                    }
                    bt.Text = item.ViTri;
                        x += 80;
                    pnGhe.Controls.Add(bt);
                    i++;
                }
            }
            else if (list.Count == 16)
            {
                x = 50;
                y = 10;
                int i = 0;
                foreach (Ghe item in list)
                {

                    if (i == 5)
                    {
                        y += 40;
                        x = 410;
                    }
                    if (i == 6)
                    {
                        y += 40;
                        x = 50;
                    }
                    if (i == 10)
                    {
                        y += 40;
                        x = 410;
                    }
                    if (i == 11)
                    {
                        y += 40;
                        x = 50;
                    }
                    Button bt = new Button() { BackColor = Color.White, Location = new Point(x, y), Width = 60, Height = 25, Cursor = Cursors.Hand };
                    bt.Click += Bt_Click;
                    if (item.TinhTrang == 1)
                    {
                        bt.BackColor = Color.DarkGray;
                        bt.Enabled = false;
                    }
                    bt.Text = item.ViTri;
                    i++;
                    x += 90;
                    pnGhe.Controls.Add(bt);
                }
            }
            else
            {
                x = 30;
                y = 10;
                int i = 0;
                foreach (Ghe item in list)
                {


                    if (i == 6)
                    {
                        y += 25;
                        x = 430;
                    }
                    if (i == 7)
                    {
                        y += 25;
                        x = 30;
                    }
                    if (i == 13)
                    {
                        y += 25;
                        x = 430;
                    }
                    if (i == 14)
                    {
                        y += 25;
                        x = 30;
                      
                        
                    }
                    if(i==20)
                    {
                        x = 30;
                        y += 50;
                    }
                    if (i == 26)
                    {
                      
                        y += 25;
                        x = 430;
                    }
                    if (i == 27)
                    {
                        y += 25;
                        x = 30;
                    }
                    if (i == 33)
                    {
                        y += 25;
                        x = 430;
                    }
                    if (i == 34)
                    {
                        y += 25;
                        x = 30;
                    }
                    Button bt = new Button() { BackColor = Color.White, Location = new Point(x, y), Width = 55, Height = 20, Cursor = Cursors.Hand };
                    bt.Click += Bt_Click;
                    if (item.TinhTrang == 1)
                    {
                        bt.BackColor = Color.DarkGray;
                        bt.Enabled = false;
                    }
                    bt.Text = item.ViTri;
                    i++;
                    x += 80;
                    pnGhe.Controls.Add(bt);
                }
            }
        }

        private void Bt_Click(object sender, EventArgs e)
        {
   
            Button bt = (Button)sender;
            var col = bt.BackColor;
            bt.BackColor = Color.White;
            if (checkve() == 4 && col != Color.Lime)
            {
                MessageBox.Show("Chỉ có thể đặt tối đa 4 vé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (col==Color.Lime)
            {
                Tongtien -= giave;
                lbtien.Text = Tongtien.ToString();
                string[] temp = lbghe.Text.Split(' ');
                lbghe.Text = "";
                foreach (string word in temp)
                {
                    if(word!=bt.Text&&!String.IsNullOrWhiteSpace(word)) lbghe.Text += word + " ";
                }
            }
   
            if (col == Color.White)
            {
                bt.BackColor = Color.Lime;
                lbghe.Text += bt.Text+" ";
                Tongtien += giave;
                lbtien.Text = Tongtien.ToString();
            }
        }
        private int checkve()
        {
            int count = 0;
            foreach (Button item in pnGhe.Controls)
            {
                if (item.BackColor == Color.Lime)
                    count++;
            }
            return count;
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (!inputIsCorrect()) return;
            LoadAll();
        }

        private bool inputIsCorrect()
        {
            if (cboDiaDiemDi.Text == cboDiaDiemVe.Text)
            {
                MessageBox.Show("Địa điểm bị trùng nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDiaDiemDi.Focus();
                return false;
            }
            return true;
        }
        private bool inputconfirm()
        {
            if (!inputIsCorrect()) return false;
            if (string.IsNullOrEmpty(txtHoten.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoten.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPhone.Text) || !txtPhone.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhone.Focus();
                return false;
            }
            if (checkve() <= 0) {
                MessageBox.Show("Vui lòng chọn ghế", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;}
            return true;
        }
        private void LoadAll()
        {
            var rs = phancongBO.getxelotrinh(int.Parse(cboDiaDiemDi.SelectedValue.ToString()), int.Parse(cboDiaDiemVe.SelectedValue.ToString()), dateTimePicker1.Value);
            if (rs != null&& rs.Count > 0)
            {
                grid1.Source = rs;
                grid1.Mapcolumn("Ten", "Nhà xe");
                grid1.Mapcolumn("LoTrinh", "Lộ trình");
                grid1.Mapcolumn("NgayKhoiHanh", "Ngày khởi hành");
                grid1.Mapcolumn("ThoiGianDen", "Thời gian đến");
                grid1.Mapcolumn("GiaVe", "Giá vé");
                grid1.VisibleColumn("IDXe", false);
                grid1.VisibleColumn("SoGhe", false);

                grid1.columnwidth();
            }
            else
            {
                MessageBox.Show("Không có chuyến xe nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!inputconfirm()) return;
            KhachHangBO khbo = new KhachHangBO();
            var kh = new KhachHang()
            {
                Ten = txtHoten.Text,
                SDT=int.Parse(txtPhone.Text),
            };
            int id = khbo.Add(kh);
           if ( id==-1) MessageBox.Show("Đặt vé không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           else
            {
                var hd = new HoaDon()
                {
                    TongTien = int.Parse(lbtien.Text),
                    NgayDat = DateTime.Now,
                    IDKh = id
                };
                HoaDonBO hoadonbo = new HoaDonBO();
                var idhd = hoadonbo.Add(hd);
                if(idhd==-1) MessageBox.Show("Đặt vé không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    GheBO ghebo = new GheBO();
                    foreach (var item in rs)
                    {
                        string[] temp = lbghe.Text.Split(' ');
                        foreach (string word in temp)
                        {
                            if (word ==item.ViTri)
                            {
                                if (ghebo.Update(item, idhd) == false)

                                {
                                    MessageBox.Show("Đặt vé không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }
                    }
                    MessageBox.Show("Đặt vé  thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }

        }
    }
}