//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QL_Phonghoc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbLich_Hoc
    {
        public int ID { get; set; }
        public int IDLop { get; set; }
        public int IDPhongHoc { get; set; }
        public int IDMon { get; set; }
        public string GiaoVien { get; set; }
        public string GiaoVienThucTe { get; set; }
        public System.DateTime Ngay { get; set; }
        public int Buoi { get; set; }
        public Nullable<int> SoTiet { get; set; }
        public Nullable<int> TietBD { get; set; }
        public int IDHocKy { get; set; }
    
        public virtual tbHocKy tbHocKy { get; set; }
        public virtual tbLop tbLop { get; set; }
        public virtual tbMonHoc tbMonHoc { get; set; }
        public virtual tbPhongHoc tbPhongHoc { get; set; }
    }
}
