﻿using QLBX.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBX.BUS
{
    class LoaiXeBO
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
        public List<LoaiXe> GetAll()
        {
            try
            {
                return dbs.LoaiXes.ToList<LoaiXe>();
            }
            catch
            {
                return null;
            }
        }
    }
}