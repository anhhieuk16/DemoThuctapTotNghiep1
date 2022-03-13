using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoThuctapTotNghiep.Models
{
    public class modeNhanVien
    {
        public int IDNhanVien { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Họ tên không được bổ trống")]

        public string HoTen { get; set; }
        [DataType(DataType.Upload)]
        public string HinhAnh { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Số điện thoại không được bổ trống")]

        public int SDT { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Số CMND không được bổ trống")]

        public int SoCMND { get; set; }

        public string GioiTinh { get; set; }

        public string BangCap { get; set; }

        public string ChucVu { get; set; }
        public string TRHonNhan { get; set; }
        
    }
}