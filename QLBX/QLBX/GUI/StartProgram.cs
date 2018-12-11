using QLBX.BUS;
using QLBX.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBX.GUI
{
    public partial class StartProgram : Form
    {
        LoaiXeBO bus = new LoaiXeBO();
        NhaXeBO nhaxe = new NhaXeBO();
        event EventHandler success;
        public StartProgram()
        {
            InitializeComponent();
            success += FrmStartProgram_success;
        }

        private void FrmStartProgram_success(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                progressBar1.Value = progressBar1.Maximum;
                this.Hide();
                frmDangNhap frm = new frmDangNhap();
                frm.Show();
                frm.FormClosed += Frm_FormClosed;

            }));

        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var number = (float)progressBar1.Value / progressBar1.Maximum * 100;
            if (number >= 99)
            {
                timer1.Stop();
            }
            lbValue.Text = string.Concat(number, "%");
            progressBar1.PerformStep();
        }

        private void frmStartProgram_Load(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                try
                {
                    var rs=nhaxe.GetAll();
                    if ( bus.GetAll().Count== 0)
                    {
                        var loaixe = new LoaiXe
                        {
                            Ten = "Limousine 9 chỗ",
                            SoGhe = 9
                        };
                        bus.Add(loaixe);
                        var loaixe1 = new LoaiXe
                        {
                            Ten = "Xe Ford Transit 16 chỗ",
                            SoGhe = 16
                        };
                        bus.Add(loaixe1);
                        var loaixe2 = new LoaiXe
                        {
                            Ten = "Giường Nằm 40 Chỗ",
                            SoGhe = 40
                        };
                        bus.Add(loaixe2);
                    }
                    if (rs != null)
                    {
                        success?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            MessageBox.Show("Có lỗi trong quá trình kết nối đến cơ sở dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }));
                    }

                }
                catch
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Có lỗi trong quá trình kết nối đến cơ sở dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }));

                }

            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
    }
}
