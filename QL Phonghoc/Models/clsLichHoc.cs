using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QL_Phonghoc.Models
{
    public class clsLichHoc
    {
        public int ID { get; set; }
        public Nullable<int> IDLop { get; set; }
        public string DonViSuDung { get; set; }
        public Nullable<int> IDPhongHoc { get; set; }
        public string DiaDiemHoc { get; set; }
        public Nullable<int> IDMon { get; set; }
        public string MucDichSuDung { get; set; }
        public string GiaoVien { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Ngày")]
        public System.DateTime Ngay { get; set; }
        public int Buoi { get; set; }
        public Nullable<int> SoTiet { get; set; }
        public Nullable<int> TietBD { get; set; }
        public string Lop { get; set; }
        public string MonHoc { get; set; }
        public string PhongHoc { get; set; }
    }
}