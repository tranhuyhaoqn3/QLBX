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
    
    public partial class Ghe
    {
        public int IDGhe { get; set; }
        public string ViTri { get; set; }
        public int TinhTrang { get; set; }
        public Nullable<int> IDXe { get; set; }
        public Nullable<int> IDHoaDon { get; set; }
    
        public virtual HoaDon HoaDon { get; set; }
        public virtual Xe Xe { get; set; }
    }
}