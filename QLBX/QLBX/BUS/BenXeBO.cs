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
        QuanLyBenXeEntities dbs;
        private Exception error;
        public BenXeBO()
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

        public List<BenXeDi> benxe()
        {
            return dbs.BenXeDis.ToList<BenXeDi>();
        }
        public List<BenXeVe> benxeve()
        {
            return dbs.BenXeVes.ToList<BenXeVe>();
        }
        public bool Delete(BenXeDi benXe)
        {
            try
            {
                var p = dbs.ChuyenXes.ToList();
                foreach (var pr in p)
                {
                    if (pr.IDBenXeDi == benXe.IDBenXeDi || pr.IDBenXeVe == benXe.IDBenXeDi)
                    {
                        return false;
                    }
                    else
                    {
                        dbs.spdeleteBenXe(benXe.IDBenXeDi);
                        return true;
                    }
                }
                return false;
                //dbs.spdeleteBenXe(benXe.IDBenXeDi);
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Update(BenXeDi benxe)
        {
            try
            {
                var bxd = dbs.BenXeDis.Single(p => p.IDBenXeDi == benxe.IDBenXeDi);
                bxd.TenBenXe = benxe.TenBenXe;
                bxd.DiaDiemDi = benxe.DiaDiemDi;
                var bxv = dbs.BenXeVes.Single(p => p.IDBenXeVe == benxe.IDBenXeDi);
                bxv.TenBenXe = benxe.TenBenXe;
                bxv.DiaDiemVe = benxe.DiaDiemDi;
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
        public bool Insert(BenXeDi benXe)
        {
            BenXeDi benxediDB = new BenXeDi();
            BenXeVe benxeveDB = new BenXeVe();
            try
            {
                benxediDB.TenBenXe = benXe.TenBenXe;
                benxediDB.DiaDiemDi = benXe.DiaDiemDi;
                benxeveDB.TenBenXe = benXe.TenBenXe;
                benxeveDB.DiaDiemVe = benXe.DiaDiemDi;
                dbs.BenXeDis.Add(benxediDB);
                dbs.BenXeVes.Add(benxeveDB);
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
        public List<BenXeDi> timbenxe(string name)
        {
            List<BenXeDi> benxe = new List<BenXeDi>();
            var pr = from p in dbs.BenXeDis
                     where p.DiaDiemDi.Contains(name)
                     select p;
            foreach (var p in pr)
            {
                benxe.Add(p);
            }
            return benxe;
        }
        public int mabenxedi(BenXeDi BenXeDi)
        {
            int ma = 0;
            var pr = from p in dbs.BenXeDis
                     where p.DiaDiemDi == BenXeDi.DiaDiemDi
                     select p;
            foreach (var p in pr)
            {
                ma = p.IDBenXeDi;
            }
            return ma;
        }
        public int mabenxeve(BenXeVe BenXeVe)
        {
            int ma = 0;
            var pr = from p in dbs.BenXeVes
                     where p.DiaDiemVe == BenXeVe.DiaDiemVe
                     select p;
            foreach (var p in pr)
            {
                ma = p.IDBenXeVe;
            }
            return ma;
        }

    }
}
