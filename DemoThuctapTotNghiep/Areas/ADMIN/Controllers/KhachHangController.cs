using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoThuctapTotNghiep.Models;
using DemoThuctapTotNghiep.DAL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using PagedList;
using PagedList.Mvc;

namespace DemoThuctapTotNghiep.Areas.ADMIN.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: ADMIN/KhachHang
        DALcsdl ketnoi = new DALcsdl();
        public ActionResult Index(int? page)
        {
            return View(ketnoi.getListKH().ToPagedList(page ?? 1, 10));
        }

        [HttpGet]
        public ActionResult Create()
        {
            string constr = ConfigurationManager.ConnectionStrings["mbkConnectionString"].ToString();
            SqlConnection _con = new SqlConnection(constr);
            SqlDataAdapter _da = new SqlDataAdapter("Select * From Table_NoiCapCMND", constr);
            SqlDataAdapter _da2 = new SqlDataAdapter("Select * From Table_GioiTinh", constr);
            SqlDataAdapter _da3 = new SqlDataAdapter("Select * From Table_DiaChi", constr);
           // SqlDataAdapter _da4 = new SqlDataAdapter("Select * From Table_ChuVu", constr);
            DataTable _dt = new DataTable();
            DataTable _dt2 = new DataTable();
            DataTable _dt3 = new DataTable();
            DataTable _dt4 = new DataTable();
            _da.Fill(_dt);
            _da2.Fill(_dt2);
            _da3.Fill(_dt3);
            //_da4.Fill(_dt4);
            ViewBag.NoiCapList = ToSelectList(_dt, "MaNoiCapCMND", "TenNoiCap");
            ViewBag.GioiTinhList = ToSelectList(_dt2, "MaGioiTinh", "GioiTinh");
            ViewBag.DiaChiList = ToSelectList(_dt3, "MaNoiSinh", "NoiSinh");
            //ViewBag.chucVu = ToSelectList(_dt4, "MaChucVu", "TenChucVu");

            return View();
        }
        [HttpPost]
        public ActionResult Create(ModeKhachHang kh)
        {

            if (ModelState.IsValid)
            {
                kh.Chucvu = "3";
                ketnoi.AddKH(kh);
                return RedirectToAction("Index");
            }
            return View();
            
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
            SqlDataAdapter _da4 = new SqlDataAdapter("Select * From Table_ChucVu", constr);
            DataTable _dt = new DataTable();
            DataTable _dt2 = new DataTable();
            DataTable _dt3 = new DataTable();
            DataTable _dt4 = new DataTable();
            _da.Fill(_dt);
            _da2.Fill(_dt2);
            _da3.Fill(_dt3);
            _da4.Fill(_dt4);
            ViewBag.NoiCapList = ToSelectList(_dt, "MaNoiCapCMND", "TenNoiCap");
            ViewBag.GioiTinhList = ToSelectList(_dt2, "MaGioiTinh", "GioiTinh");
            ViewBag.DiaChiList = ToSelectList(_dt3, "MaNoiSinh", "NoiSinh");
            ViewBag.ChucVuList = ToSelectList(_dt4, "MaChucVu", "TenChucVu");
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