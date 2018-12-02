using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBX.DAO;
namespace QLBX.BUS
{
    class DangNhapBO
    {
        QuanLyBenXeEntities dbs = new QuanLyBenXeEntities();
        private Exception error;
        public DangNhapBO()
        {
            dbs = new QuanLyBenXeEntities();
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

        public bool DangNhap(DangNhap user)
        {
            error = null;
            try
            {
                var p = dbs.DangNhaps;
                foreach (var c in p)
                {
                    if (c.TaiKhoan.Equals(user.TaiKhoan) && c.MatKhau.Equals(user.MatKhau))
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                error = e;
            }
            return false;
        }
    }
}
