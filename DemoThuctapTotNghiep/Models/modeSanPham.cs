using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoThuctapTotNghiep.Models
{
    public class modeSanPham
    {
            public int   MaSP { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên sản phẩm không được bổ trống")]
        [RegularExpression(@"[^(!@#$&*)]*", ErrorMessage = "Vui lòng nhập đúng định dạng Tên sản phẩm")]
        public string TenSP { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Số lượng không được bổ trống")]
        public int  SoLuong { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tình trạng sản phẩm không được bổ trống")]
        public string TrinhTrangSP { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Danh mục sản phẩm được bổ trống")]
        public string DanhMucSP { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nhà cung cấp không được bổ trống")]
        public string NhaCungCap { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Giá bán không được bổ trống")]
        public int GiaBan { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Giá vốn không được bổ trống")]
        public int GiaVon { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mô tả sản phẩm không được bổ trống")]
        public string MoTaSP { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Hình ảnh không bổ trống")]
        [DataType(DataType.Upload)]
        public string HinhAnh { get; set; }
        public string IDDanhMuc { get; set; }

          
        
    }
}