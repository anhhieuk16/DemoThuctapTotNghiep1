using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DemoThuctapTotNghiep.Models;
using DemoThuctapTotNghiep.DAL;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace DemoThuctapTotNghiep.Areas.ADMIN.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: ADMIN/DangNhap
        DALcsdl ketnoi = new DALcsdl();
        DALSP ketnoi2 = new DALSP();
        DALHoaDon hoadon = new DALHoaDon();
        public ActionResult Index()
        {

            List<modeSanPham> a = new List<modeSanPham>();
            List<ModelHoaDon> a1 = new List<ModelHoaDon>();
            var b = 0;
            var b1 = 0;
            var b2 = 0;
            var c = 0;
            var c1 = 0;
            var d = 0;
            var d1 = 0;
            a = ketnoi2.getListSP2();
            a1 = hoadon.getListHD();
            foreach (var i in a)
            {
                if (@i.TrinhTrangSP == "Còn hàng")
                {
                     b++;

                }
                c++;             
            }
            d = c-b;
            ViewData["hethang"] = d;
            ViewData["Conhang"] = b;

            foreach (var y in a1)
            {
                if (@y.Trangthai == "Đang chờ xử lý")
                {
                     b1 ++;

                }
                if (@y.Trangthai == "Đang giao hàng")
                {
                     b2++;

                }
                c1++;
                
                
            }
            d1 = c1 - b1 - b2;
            ViewData["DaXL"] = d1;
            ViewData["DangGH"] = b2;
            ViewData["DangXL"] = b1;
            return View();
        }
        public ActionResult Dangxuat()
        {
            Session.Clear();
            FormsAuthentication.SignOut();

            return Redirect("/Home/Index");
        }

        public ActionResult Dangnhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(ModeKhachHang kh )
        {
            List<ModeKhachHang> sp = new List<ModeKhachHang>();
            sp = ketnoi.getListKH();
            string SS = "Khách hàng";
            foreach (var i in sp)
            {
                if (@i.Usename == kh.Usename)
                {
                    if (@i.pass == kh.pass)
                    {
                        ViewBag.messg = "Đăng nhập thành công";
                        Session["hoten"] = i.HoTen;
                        Session["id"] = i.Usename;
                        Session["chucvu"] = i.Chucvu;


                        var Sess = i.Chucvu.Trim().Contains(SS);
                        if (Sess)
                        {
                            Session["kq"] = null;
                        }
                        else
                        {
                            Session["kq"] = 1;
                        }
                        return Redirect("/Home/Index");
                    }
                    else
                    {
                        ViewBag.messg = "Đăng nhập không thành công";
                        return View();
                    }

                }
                else
                {
                    ViewBag.messg = "Đăng nhập không thành công";
                }

            }
            return View();
        }


        [HttpGet]
        public ActionResult Dangky()
        {
            string constr = ConfigurationManager.ConnectionStrings["mbkConnectionString"].ToString();
            SqlConnection _con = new SqlConnection(constr);
            SqlDataAdapter _da = new SqlDataAdapter("Select * From Table_NoiCapCMND", constr);
            SqlDataAdapter _da2 = new SqlDataAdapter("Select * From Table_GioiTinh", constr);
            SqlDataAdapter _da3 = new SqlDataAdapter("Select * From Table_DiaChi", constr);
            DataTable _dt = new DataTable();
            DataTable _dt2 = new DataTable();
            DataTable _dt3 = new DataTable();
            _da.Fill(_dt);
            _da2.Fill(_dt2);
            _da3.Fill(_dt3);
            ViewBag.NoiCapList = ToSelectList(_dt, "MaNoiCapCMND", "TenNoiCap");
            ViewBag.GioiTinhList = ToSelectList(_dt2, "MaGioiTinh", "GioiTinh");
            ViewBag.DiaChiList = ToSelectList(_dt3, "MaNoiSinh", "NoiSinh");
            return View();
        }
        [HttpPost]
        public ActionResult Dangky(ModeKhachHang kh)
        {
            var list = new List<ModeKhachHang>();
            int a=0;
            list = ketnoi.getListKH();
            if (ModelState.IsValid)
            {
                foreach(var i in list)
                {
                    if (@i.Usename == kh.Usename) { 
                        a++;
                        ViewBag.messg = "tài khoản đã tồn tại";
                    }


                }
                if(a==0)
                ketnoi.AddKH(kh);
                return RedirectToAction("Dangnhap");
            }
            return View();

        }

        


        [NonAction]
        public SelectList ToSelectList(DataTable table, string valueField, string textField)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[textField].ToString(),
                    Value = row[valueField].ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }
    }
}