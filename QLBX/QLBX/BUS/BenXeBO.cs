using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBX.DAO;
using System.Windows.Forms;

namespace QLBX.BUS
{
    class BenXeBO
    {
        QuanLyBenXeEntities1 dbs;
        private Exception error;
        public BenXeBO()
        {
            dbs = new QuanLyBenXeEntities1();
        }

        public Exception Error
        {
            get
            {
                return error;
            }

            set
            {
                error = value;
            }
        }

        public List<BenXeDi> benxe()
        {
            return dbs.BenXeDis.ToList<BenXeDi>();
           

        }
        public void Delete(BenXeDi benXe)
        {
            try
            {
               // dbs.spdeleteBenXe(benXe.IDBenXeDi);
            }
           catch(Exception ex)
            {
                MessageBox.Show("Không thể kết nối với Sever!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public bool Update(BenXeDi benxe)
        {
            try
            {
                var bxd = dbs.BenXeDis.Single(p => p.IDBenXeDi == benxe.IDBenXeDi);
                bxd.TenBenXe = benxe.TenBenXe;
                bxd.DiaDiem = benxe.DiaDiem;
                var bxv = dbs.BenXeVes.Single(p => p.IDBenXeVe == benxe.IDBenXeDi);
                bxv.TenBenXe = benxe.TenBenXe;
                bxv.DiaDiem = benxe.DiaDiem;
                int kq=dbs.SaveChanges();
                if ( kq<= 0)
                {
                    return false;
                }
                return true;

            }
            catch
            {
                return false;
            }

        }
        public bool Insert(BenXeDi benXe)
        {
            BenXeDi benxediDB = new BenXeDi();
            BenXeVe benxeveDB = new BenXeVe();
            try
            {
                benxediDB.TenBenXe = benXe.TenBenXe;
                benxediDB.DiaDiem = benXe.DiaDiem;
                benxeveDB.TenBenXe= benXe.TenBenXe;
                benxeveDB.DiaDiem = benXe.DiaDiem;
                dbs.BenXeDis.Add(benxediDB);
                dbs.BenXeVes.Add(benxeveDB);
                if(dbs.SaveChanges() <= 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
          
        }
        public List<BenXeDi> timbenxe(string name)
        {
            List<BenXeDi> benxe = new List<BenXeDi>();
            var pr = from p in dbs.BenXeDis
                     where p.DiaDiem.Contains(name)
                     select p;
            foreach (var p in pr)
            {
                benxe.Add(p);
            }
            return benxe;
        }
    }
}
