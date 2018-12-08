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
    public partial class taskcontrol : UserControl
    {
        public taskcontrol()
        {
            InitializeComponent();
        }
        public bool IsRowClick
        {

            set
            {
                if (value == true)
                {
                    btEdit.Enabled = true;
                    btDele.Enabled = true;
                    btSave.Enabled = false;
                    btCan.Enabled = false;
                }
                else
                {
                    btEdit.Enabled = false;
                    btDele.Enabled = false;
                    btAdd.Enabled = true;

                }
            }
        }
        public bool isSuccessFul { get; set; } = false;
        private event EventHandler addEvent;
        public event EventHandler AddEvent
        {
            add
            {
                addEvent += value;
            }
            remove
            {
                addEvent -= value;
            }
        }
        private event EventHandler editEvent;
        public event EventHandler EditEvent
        {
            add
            {
                editEvent += value;
            }
            remove
            {
                editEvent -= value;
            }
        }

        private event EventHandler deleteEvent;
        public event EventHandler DeleteEvent
        {
            add
            {
                deleteEvent += value;
            }
            remove
            {
                deleteEvent -= value;
            }
        }

        private event EventHandler saveEvent;
        public event EventHandler SaveEvent
        {
            add
            {
                saveEvent += value;
            }
            remove
            {
                saveEvent -= value;
            }
        }

        private event EventHandler calcelEvent;
        public event EventHandler CalcelEvent
        {
            add
            {
                calcelEvent += value;
            }
            remove
            {
                calcelEvent -= value;
            }
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            isSuccessFul = false;
            addEvent?.Invoke(this, EventArgs.Empty);
            btEdit.Enabled = false;
            btDele.Enabled = false;
            btCan.Enabled = true;
            btSave.Enabled = true;
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            editEvent?.Invoke(this, EventArgs.Empty);
            btAdd.Enabled = false;
            btDele.Enabled = false;
            btCan.Enabled = true;
            btSave.Enabled = true;
        }

        private void btDele_Click(object sender, EventArgs e)
        {
            var rs = MessageBox.Show("Bạn có thật sự muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                deleteEvent?.Invoke(this, EventArgs.Empty);
                btDele.Enabled = false;
                btEdit.Enabled = false;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            saveEvent?.Invoke(this, EventArgs.Empty);
            if (isSuccessFul == true)
            {
                btAdd.Enabled = true;
                btCan.Enabled = false;
                btEdit.Enabled = false;
                btDele.Enabled = false;
                btSave.Enabled = false;
            }

        }

        private void btCan_Click(object sender, EventArgs e)
        {
            calcelEvent?.Invoke(this, EventArgs.Empty);
            btSave.Enabled = false;
            btCan.Enabled = false;
            btDele.Enabled = false;
            btEdit.Enabled = false;
            btAdd.Enabled = true;
        }
        public void showDelete()
        {
            btAdd.Enabled = false;
            btCan.Enabled = true;
            btEdit.Enabled = false;
            btDele.Enabled = true;
            btSave.Enabled = false;
        }
        public void visibleBtn()
        {
            btAdd.Enabled = true;
            btCan.Enabled = false;
            btEdit.Enabled = false;
            btDele.Enabled = false;
            btSave.Enabled = false;
        }
    }
}
