using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QL_Phonghoc.Models
{
    public class ClsThietBiBaoHong
    {
        public int ID { get; set; }
        public int IDTB { get; set; }
        [Display(Name = "Mô tả")]
        public string MoTaBaoHong { get; set; }
        [Display(Name = "Ngày báo")]
        [DataType(DataType.DateTime)]
        public string NgayBao { get; set; }
        [Display(Name = "Người báo")]
        public string NguoiBao { get; set; }
        [Display(Name = "Tên Thiết bị")]
        public string TenTTB { get; set; }
        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; }
        [Display(Name = "Số lượng")]
        public int SoLuongHong { get; set; }
        [Display(Name = "Số lượng")]
        public int SoLuongSua { get; set; }
        [Display(Name = "Số lượng")]
        public int SoLuongBao { get; set; }
        [Display(Name = "Phòng học")]
        public string PhongHoc { get; set; }
    }
}