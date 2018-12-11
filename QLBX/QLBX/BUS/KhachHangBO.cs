using QLBX.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBX.BUS
{
    class KhachHangBO
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
        public int Add(KhachHang dto)
        {
            try
            {
             var rs=   dbs.KhachHangs.Add(dto);
                if (dbs.SaveChanges() <= 0)
                {
                    return -1;
                }
                return rs.IDKhachhang;
            }
            catch
            {
                return -1;
            }

        }
    }
}
