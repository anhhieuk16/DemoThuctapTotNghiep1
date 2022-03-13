using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoThuctapTotNghiep.Models
{
    public class ModelHoaDon
    {
        public int MaHD { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Giá sản phẩm không được bổ trống")]

        public int GiasP { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Số lượng sản phẩm không được bổ trống")]

        public int SLsP { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Hị tên không được bổ trống")]

        public string HoTen { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên sản phẩm không được bổ trống")]

        public string TenSP { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Hình thức thanh toán không được bổ trống")]

        public string HinhThucTT { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nơi nhận không được bổ trống")]

        public string NoiNhan { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Trạng thái không được bổ trống")]

        public string Trangthai { get; set; }
}
}