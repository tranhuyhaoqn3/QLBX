using QLBX.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBX.BUS
{
    class ChiTietHoaDonBO
    {

        QuanLyBenXeEntities dbs;
        public ChiTietHoaDonBO()
        {
            dbs = new QuanLyBenXeEntities();
        }
        public List<object> chitiethoadon(int mahoadon)
        {

            try
            {
                List<object> hoadon = new List<object>();
                var kq = dbs.spChitiethoadon(mahoadon);
                foreach (var p in kq)
                {
                    hoadon.Add(p);
                }
                return hoadon;

            }
            catch
            {
                return null;
            }

        }
        public string TenXe(int ma)
        {

            string kq = null;
            try
            {
                var r = from p in dbs.Ghes
                        where p.IDHoaDon == ma
                        select p;

                foreach (var p in r)
                {
                    var q = from c in dbs.Xes
                            where c.IDXe == p.IDXe
                            select c;
                    foreach (var c in q)
                    {
                        var t = from k in dbs.NhaXes
                                where k.IDNhaXe == c.IDNhaXe
                                select k;
                        foreach (var i in t)
                        {
                            kq = i.Ten;
                        }

                    }
                }
                return kq;
            }
            catch
            {
                return null;
            }
        }
        public List<string> LoTrinh(int ma)
        {
            Ghe ghe = new Ghe();
            var r = from p in dbs.Ghes
                    where p.IDHoaDon == ma
                    select p;

            foreach (var t in r)
            {
                ghe = t;
                break;
            }
            var result = dbs.getchuyenxebyghe(ghe.IDXe, ghe.NgayKhoiHanh);
            if (result == null) return null;
            else
            {
                return result.ToList<string>();
            }

        }
        public object ngayxuatphat(int ma)
        {
            try
            {

                var r = from p in dbs.Ghes
                        where p.IDHoaDon == ma
                        select p;

                foreach (var t in r)
                {

                    return t.NgayKhoiHanh;
                }
                return null;
            }
            catch
            {
                return null;
            }

        }
    }
}