using QLBX.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBX.BUS
{
    class ChuyenXeBO
    {
        QuanLyBenXeEntities dbs;
        public ChuyenXeBO()
        {
            dbs = new QuanLyBenXeEntities();
        }
        public List<object> getLotrinh()
        {
            try
            {
                return dbs.getLotrinh().ToList<object>();
            }
            catch
            {
                return null;
            }

        }
        public List<object> ChuyenXe()
        {
            try
            {
                List<object> chuyenxe = new List<object>();
                var p = dbs.spchuyenxe1();
                foreach (var pr in p)
                {
                    chuyenxe.Add(pr);
                }
                return chuyenxe;
            }
            catch
            {
                return null;
            }

        }
        //public List<object> timbenxe(string name)
        //{
        //    List<object> benxe = new List<object>();
        //    var pr = from p in dbs.BenXeDis
        //             where p.DiaDiem.Contains(name)
        //             select p;
        //    foreach (var p in pr)
        //    {
        //        benxe.Add(p);
        //    }
        //    return benxe;
        //}
        public int Insert(ChuyenXe ChuyenXe)
        {
          
            try
            {
                return dbs.insertchuyenxe(ChuyenXe.IDBenXeDi, ChuyenXe.IDBenXeVe, ChuyenXe.GiaVe);
            }
            catch (Exception ex)
            {
                return -1;
            }

        }
        public int Delete(ChuyenXe ChuyenXe)
        {
            try
            {

              return dbs.spXoaChuyenXe(ChuyenXe.IDChuyen);
          
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public bool Update(ChuyenXe chuyenxeDTO)
        {
            try
            {
                var ch = dbs.ChuyenXes.Single(p => p.IDChuyen == chuyenxeDTO.IDChuyen);
                ch.IDBenXeDi = chuyenxeDTO.IDBenXeDi;
                ch.IDBenXeVe = chuyenxeDTO.IDBenXeVe;
                ch.GiaVe = chuyenxeDTO.GiaVe;
                int kq = dbs.SaveChanges();
                if (kq <= 0)
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
