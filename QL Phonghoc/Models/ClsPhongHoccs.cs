using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QL_Phonghoc.Models
{
    public class ClsPhongHoccs
    {
        public int ID { get; set; }
        [Display(Name = "Tên Phòng")]
        public string TenPhong { get; set; }
        [Display(Name = "Tầng")]
        public string Tang { get; set; }
        [Display(Name = "Tòa")]
        public string Toa { get; set; }
        [Display(Name = "Cơ sở")]
        public int CoSo { get; set; }
        [Display(Name = "Diện tích")]
        public Nullable<int> DienTich { get; set; }
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }
        [Display(Name = "Trạng thái")]
        public string TrangThai { get; set; }
        [Display(Name = "Lớp sử dụng")]
        public string LopSudung { get; set; }
    }
}