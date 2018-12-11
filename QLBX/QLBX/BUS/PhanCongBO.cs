using QLBX.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBX.BUS
{
    class PhanCongBO
    {
        QuanLyBenXeEntities dbs;
        public PhanCongBO()
        {
            dbs = new QuanLyBenXeEntities();
        }
        public List<Object> GetAll(Xe xe)
        {
            try
            {
                return dbs.getLotrinhSoghe(xe.IDXe).ToList<object>();
            }
            catch
            {
                return null;
            }
        }
        public bool Insert(PhanCong phancong)
        {
            try
            {

                dbs.PhanCongs.Add(phancong);
                if (dbs.SaveChanges() <= 0)
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
        public int Delete(PhanCong phancong)
        {
          
            try
            {
                DateTime myDateTime = phancong.NgayKhoiHanh;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                var kt = dbs.deletephancong(phancong.IDXe, sqlFormattedDate, phancong.IDChuyen);
                if (kt > 0)
                    return kt;
                else
                    return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public int Update(PhanCong phancong,PhanCong phancong1)
        {
            try
            {
                DateTime myDateTime = phancong.NgayKhoiHanh;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                return dbs.updatephancong(phancong.IDXe, sqlFormattedDate, phancong.IDChuyen, phancong1.NgayKhoiHanh, phancong1.IDChuyen,phancong1.ThoiGianDen);
            }
            catch (Exception ex)
            {
                return -1;
            }

        }
        public List<object> getxelotrinh(int iddi, int idve, DateTime ngayKH)
        {
            try
            {
                DateTime myDateTime = ngayKH;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                var result = dbs.getlotrinhxe(iddi, idve, sqlFormattedDate);
               return result.ToList<object>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool checkidchuyen(int id)
        {
            try
            {
               var rs= dbs.PhanCongs.Where(p => p.IDChuyen == id).ToList();
                if (rs.Count > 0) return true;
                else return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
