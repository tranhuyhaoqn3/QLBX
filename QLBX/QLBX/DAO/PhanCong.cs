//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLBX.DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhanCong
    {
        public System.DateTime NgayKhoiHanh { get; set; }
        public int IDChuyen { get; set; }
        public int IDXe { get; set; }
        public Nullable<System.DateTime> ThoiGianDen { get; set; }
    
        public virtual ChuyenXe ChuyenXe { get; set; }
        public virtual Xe Xe { get; set; }
    }
}
