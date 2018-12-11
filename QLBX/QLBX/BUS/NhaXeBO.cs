using QLBX.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public int Add(NhaXe nhaxe)
        {
            try
            {

                return dbs.insertnhaxe(nhaxe.Ten, nhaxe.SDT);
            }
            catch(Exception ex)

            {
    
                return -1;
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
        public int Delete(NhaXe nx)
        {
            try
            {

                return dbs.deletenhaxe(nx.IDNhaXe);
            }
            catch
            {
                return -1;
            }

        }

    }
}
