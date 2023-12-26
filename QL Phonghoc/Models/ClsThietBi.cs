using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QL_Phonghoc.Models
{
    public class ClsThietBi
    {
        public int ID { get; set; }
        [Display(Name = "Tên Thiết bị")]
        public string TenTTB { get; set; }
        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }
        public int IDLoaiTB { get; set; }
        public int IDPhongHoc { get; set; }
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }
        [Display(Name = "Tình trạng")]
        public string TinhTrang { get; set; }
        [Display(Name = "Phòng học")]
        public string PhongHoc { get; set; }
    }
}