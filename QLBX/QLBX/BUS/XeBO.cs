using QLBX.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBX.BUS
{
    class XeBO
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
        public List<Xe> GetAll(NhaXe nhaxe)
        {
            try
            {
                return dbs.Xes.SqlQuery("exec udsXebyIDnhaxe @IDnhaxe ", nhaxe.IDNhaXe).ToList<Xe>();
            }
            catch
            { 
                return null;
            }
        }
        public List<Xe> FindByName(string name)
        {
            try
            {
                return dbs.Xes.Where(item => item.BienSoXe.Contains(name)).ToList();
            }
            catch
            {
                return null;
            }
        }
        public bool Add(Xe dto)
        {
            try
            {
                dbs.Xes.Add(dto);
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
        public bool Update(Xe dto)
        {
            try
            {
                var xe = dbs.Xes.Find(dto.IDXe);
                xe.Loai = dto.Loai;
                xe.BienSoXe = dto.BienSoXe;
                xe.SoGhe = dto.SoGhe;
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
        public bool Delete(Xe dto)
        {
            try
            {

                var xe = dbs.Xes.Find(dto.IDXe);
                dbs.Xes.Remove(xe);
                if (dbs.SaveChanges() <= 0) return false;
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
