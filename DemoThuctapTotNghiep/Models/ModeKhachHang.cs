using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoThuctapTotNghiep.Models
{
    public class ModeKhachHang
    {
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tài khoản không được bổ trống")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nhập tài khoản 3-50 ký tự")]
        [RegularExpression(@"[a-z|A-Z|0-9]*", ErrorMessage = "Vui lòng nhập đúng định dạng Họ tên")]
        public string Usename { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mật khẩu không được bổ trống")]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Nhập mật khẩu 3-12 ký tự")]
        
        public string pass { get; set; }        
        public string HoTen { get; set; }
       // public string HinhAnh { get; set; }
        public string DiaChi { get; set; }
        [DataType(DataType.Date)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ngày sinh  không được bổ trống")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgaySinh { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Số điện thoại không được bổ trống")]
        public int SDT { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Số CMND không được bổ trống")]
        public int SoCMND { get; set; }
        
        public string NoiCap { get; set; }
        public string GioiTinh { get; set; }
        public string Chucvu { get; set; }

    }
}