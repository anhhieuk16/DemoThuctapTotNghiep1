using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Mvc;
using DemoThuctapTotNghiep.Models;
using DemoThuctapTotNghiep.DAL;
using PagedList;
using PagedList.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web.Security;

namespace DemoThuctapTotNghiep.Controllers
{
    public class HomeController : Controller
    {

        DALcsdl ketnoi = new DALcsdl();
        DALSP sp = new DALSP();
        public static List<modeSanPham> sanpham2 = new List<modeSanPham>();
        public static int a1 ;
        public ActionResult Index()
        {

            ViewBag.soSP = sanpham2.Count(); 
            return View(sp.getListSP2());
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact(int? page)
        {
            ViewBag.soSP = sanpham2.Count();
            
            return View(sp.getListSP2().ToPagedList(page ?? 1, 10));
        }
        public ActionResult hienthi(string id)
        {
           
            List<modeSanPham> sanpham = new List<modeSanPham>();
            List<modeSanPham> sanpham1 = new List<modeSanPham>();
            sanpham = sp.getListSP2();
            foreach(var i in sanpham)
            {
                if (i.IDDanhMuc == id)
                {
                    sanpham1.Add(i);
                }
            }
            return View(sanpham1);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            ModeKhachHang tour = new ModeKhachHang();
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
            tour = ketnoi.getKHID(id);
            return View(tour);
        }

        [HttpPost]
        public ActionResult Edit(ModeKhachHang s)
        {
            if (ModelState.IsValid)
            {
                ketnoi.getKHID(s.Usename);
                ketnoi.updateTTKH(s);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(string id)
        {
            ketnoi.DeleteKH(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Chitiet(int id)
        {
            modeSanPham sp2 = new modeSanPham();
            
            ViewBag.soSP = sanpham2.Count();
            sp2 = sp.getSPID(id);
            sp2.SoLuong = 1;
            a1 = sp2.MaSP;
            return View(sp2);
            
        }
        [Authorize]
        public ActionResult Giohang()
        {
            ViewBag.soSP = sanpham2.Count();
            foreach(var i in sanpham2)
            {
                ViewBag.masp = i.MaSP;
                Session["maSP"] = i.MaSP;
                Session["sl"] = i.SoLuong;
                Session["TongT"] = i.SoLuong * i.GiaBan;
            }
            return View(sanpham2);

        }
        [Authorize]
        public ActionResult ThemGiohang(modeSanPham id)
        {
            modeSanPham sp11 = new modeSanPham();
            
            sp11 = sp.getSPID(id.MaSP);
            sp11.SoLuong = id.SoLuong;
            sanpham2.Add(sp11);
            return RedirectToAction("Giohang");
           
        }
        public ActionResult DeleteGioHang(int id)
        {
            foreach(var i in sanpham2)
            {
                if(i.MaSP==id)
                sanpham2.Remove(i);
                return RedirectToAction("Giohang");
            }
           
            return RedirectToAction("Giohang");
        }



        public ActionResult timKiem(string keyword)
        {


            var links = from l in sp.getListSP2() select l;

                if (!String.IsNullOrEmpty(keyword))
                {
                links = links.Where(s => s.TenSP.Contains(keyword));
                                   
                }          

            return View(links);
        }

        // GET: Login
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(ModeKhachHang kh, string ReturnUrl)
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

                        var Sess = i.Usename.Trim().Contains(SS);
                        if (Sess)
                        {
                            Session["kq"] = null;
                        }
                        else
                        {
                            Session["kq"] = 1;
                        }
                        FormsAuthentication.SetAuthCookie(i.Usename, false);
                        if (ReturnUrl == "/Home/ThemGiohang")
                        {
                            ReturnUrl = "/Home/Chitiet/"+ a1;
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return Redirect(ReturnUrl);
                        }

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