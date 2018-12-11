using QLBX.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBX.BUS
{
    class GheBO
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
        public List<Ghe> GetAllbyIDNgaykh(int id,DateTime NgayKH)
        {
            try
            {
                var _list = dbs.Ghes.Where(p => DbFunctions.DiffDays(p.NgayKhoiHanh, NgayKH) == 0 && p.IDXe == id);
                return _list.ToList<Ghe>();
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public bool Add(Ghe ghe)
        {
            try
            {

                dbs.Ghes.Add(ghe);
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
        public int UpdateNgayKH(int id,DateTime NgayKH,DateTime NgayEdit)
        {
            try
            {
                DateTime myDateTime = NgayKH;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
               return dbs.editghe(id, sqlFormattedDate, NgayEdit);
            }
            catch (Exception ex)

            {
                return -1;
            }

        }
        public int Delete(int id, DateTime NgayKH)
        {
            try
            {
                string sqlFormattedDate = NgayKH.ToString("yyyy-MM-dd HH:mm:ss.fff");
              return  dbs.deleteghe(id, sqlFormattedDate);
            }
            catch (Exception ex)

            {
                return -1;
            }

        }
        public bool Update(Ghe dto,int idhd)
        {
            try
            {
                var g = dbs.Ghes.Find(dto.IDGhe);
                g.IDHoaDon = idhd;
                g.TinhTrang = 1;
                if (dbs.SaveChanges() <= 0)
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
    }
}
