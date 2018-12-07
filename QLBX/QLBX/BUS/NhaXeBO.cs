using QLBX.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBX.BUS
{
    class NhaXeBO
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
        public List<NhaXe> GetAll()
        {
            try
            {
                return dbs.Database.SqlQuery<NhaXe>( "exec udsGetNhaXe").ToList<NhaXe>();
            }
            catch
            {
                return null;
            }
        }
        public List<NhaXe> FindByName(string name)
        {
            try
            {
                return dbs.NhaXes.Where(item => item.Ten.Contains(name)).ToList();
            }
            catch
            {
                return null;
            }
        }
        public bool Add(NhaXe nhaxe)
        {
            try
            {
                dbs.NhaXes.Add(nhaxe);
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
        public bool Update(NhaXe nhaxe)
        {
            try
            {
                var nx = dbs.NhaXes.Find(nhaxe.IDNhaXe);
                nx.Ten = nhaxe.Ten;
                nx.SDT = nhaxe.SDT;;
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
        public bool Delete(NhaXe nx)
        {
            try
            {

                var nhaxe = dbs.NhaXes.Find(nx.IDNhaXe);
                dbs.NhaXes.Remove(nhaxe);
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
