using QLBX.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBX.BUS
{
    class HoaDonBO
    {
        QuanLyBenXeEntities dbs = new QuanLyBenXeEntities();
        private Exception error;
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
        public int Add(HoaDon dto)
        {
            try
            {
                var rs = dbs.HoaDons.Add(dto);
                if (dbs.SaveChanges() <= 0)
                {
                    return -1;
                }
                return rs.IDHoaDon;
            }
            catch
            {
                return -1;
            }

        }
        public List<object> ChuyenXe()
        {

            try
            {
                List<object> hoadon = new List<object>();
                var p = dbs.spHoaDon();
                foreach (var pr in p)
                {
                    hoadon.Add(pr);
                }
                return hoadon;
            }
            catch
            {
                return null;
            }

        }
        public int sovedat(int ma)
        {
            int kq1 = 0;
            try
            {
                var kq = dbs.spDemsoghedadat(ma);
                foreach (int k in kq)
                {
                    kq1 = k;
                }
                return kq1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
