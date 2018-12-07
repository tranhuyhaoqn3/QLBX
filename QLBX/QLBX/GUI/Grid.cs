using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBX.GUI
{
    public partial class Grid : UserControl
    {
        public Grid()
        {
            InitializeComponent();
        }
        public object Source
        {
            get
            {
                return dgvData.DataSource;
            }

            set
            {
                dgvData.DataSource = null;
                dgvData.Columns.Clear();
                if (value != null)
                {
                    dgvData.DataSource = value;

                }
            }
        }
        private event EventHandler cellclick;
        public event EventHandler Cellclick
        {
            add
            {
                cellclick += value;
            }
            remove
            {
                cellclick -= value;
            }
        }
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cellclick?.Invoke(sender, e);
        }
        public string ThongTinTimKiem
        {
            get
            {
                return txtSearch.Text;

            }

            set
            {
                txtSearch.Text = value;

            }
        }
        private event EventHandler findClick;
        public event EventHandler FindClick
        {
            add
            {
                findClick += value;
            }
            remove
            {
                findClick -= value;
            }
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            findClick?.Invoke(sender, e);
        }
        public void Mapcolumn(string nameProperty, string caption)
        {
            dgvData.Columns[nameProperty].HeaderText = caption;

        }
        public void VisibleColumn(string nameProperty, bool option)
        {
            dgvData.Columns[nameProperty].Visible = option;
        }
        public void AddColumn(string fieldName, string caption, bool visible)
        { 
           
            DataGridViewColumn myCol = new DataGridViewColumn() { Name = caption, Visible = visible, DataPropertyName = fieldName };
            dgvData.Columns.Add(myCol);
        }
        public void DeleteColumn(string fieldName)
        {
            dgvData.Columns.Remove(dgvData.Columns[fieldName]);
        }
        public Object GetValueRow()
        {
            return dgvData.CurrentRow.DataBoundItem;
        }
        public int GetIndexRow()
        {
            return dgvData.CurrentRow.Index;
        }
    }
}
