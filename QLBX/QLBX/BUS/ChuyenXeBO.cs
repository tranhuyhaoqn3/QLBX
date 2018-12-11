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
        public bool Insert(ChuyenXe ChuyenXe)
        {
            ChuyenXe ChuyenXeDTO = new ChuyenXe();
            try
            {
                ChuyenXeDTO.IDBenXeDi = ChuyenXe.IDBenXeDi;
                ChuyenXeDTO.IDBenXeVe = ChuyenXe.IDBenXeVe;
                ChuyenXeDTO.GiaVe = ChuyenXe.GiaVe;
                dbs.ChuyenXes.Add(ChuyenXeDTO);
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
        public bool Delete(ChuyenXe ChuyenXe)
        {
            try
            {
               
                var n = dbs.ChuyenXes.Find(ChuyenXe.IDChuyen);
                dbs.ChuyenXes.Remove(n);
                dbs.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
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
