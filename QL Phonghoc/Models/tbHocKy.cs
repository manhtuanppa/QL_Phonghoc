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
    
    public partial class tbHocKy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbHocKy()
        {
            this.tbHocKy_Mon = new HashSet<tbHocKy_Mon>();
            this.tbLich_Hoc = new HashSet<tbLich_Hoc>();
        }
    
        public int ID { get; set; }
        public string TenHK { get; set; }
        public System.DateTime NgayBD { get; set; }
        public System.DateTime NgayKT { get; set; }
        public string GhiChu { get; set; }
        public int IDLop { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHocKy_Mon> tbHocKy_Mon { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbLich_Hoc> tbLich_Hoc { get; set; }
        public virtual tbLop tbLop { get; set; }
    }
}