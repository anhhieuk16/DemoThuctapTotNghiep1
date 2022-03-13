using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoThuctapTotNghiep.Models;
using DemoThuctapTotNghiep.DAL;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using PagedList;
using PagedList.Mvc;

namespace DemoThuctapTotNghiep.Areas.ADMIN.Controllers
{
    public class QuanLyHDController : Controller
    {
        // GET: ADMIN/QuanLyHD
        DALHoaDon hoadon = new DALHoaDon();
        public ActionResult Index(int? page)
        {
            return View(hoadon.getListHD().ToPagedList(page ?? 1, 10));
        }
        public ActionResult Delete(int id)
        {
            hoadon.DeleteHD(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            ModelHoaDon hd = new ModelHoaDon();
            string constr = ConfigurationManager.ConnectionStrings["mbkConnectionString"].ToString();
            SqlConnection _con = new SqlConnection(constr);
            SqlDataAdapter _da = new SqlDataAdapter("Select * From Table_Trangthai", constr);
            SqlDataAdapter _da2 = new SqlDataAdapter("Select * From Table_HinhThucTT", constr);

            DataTable _dt = new DataTable();
            DataTable _dt2 = new DataTable();

            _da.Fill(_dt);
            _da2.Fill(_dt2);

            ViewBag.TrangthaiHDList = ToSelectList(_dt, "MaTrangThai", "TenTrangThai");
            ViewBag.HinhthucTTList = ToSelectList(_dt2, "MaThanhtoan", "HinhThuc");
            return View();
        }
        [HttpPost]    
        public ActionResult Create(ModelHoaDon hd)
        {
            string constr = ConfigurationManager.ConnectionStrings["mbkConnectionString"].ToString();
            SqlConnection _con = new SqlConnection(constr);
            SqlDataAdapter _da2 = new SqlDataAdapter("Select * From Table_HinhThucTT", constr);    
            DataTable _dt2 = new DataTable();
            _da2.Fill(_dt2);
            if (ViewBag.HinhthucTTList == null)
            {
                ViewBag.HinhthucTTList = ToSelectList(_dt2, "MaThanhtoan", "HinhThuc");
                if (ModelState.IsValid)
                {
                   
                    hoadon.AddHD(hd);
                    return Redirect("/Home/Index");
                }
            }
            else {
                if (ModelState.IsValid)
                {
                    hd.Trangthai = "1";
                    hoadon.AddHD(hd);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            ModelHoaDon hd = new ModelHoaDon();
            string constr = ConfigurationManager.ConnectionStrings["mbkConnectionString"].ToString();
            SqlConnection _con = new SqlConnection(constr);
            SqlDataAdapter _da = new SqlDataAdapter("Select * From Table_Trangthai", constr);
            SqlDataAdapter _da2 = new SqlDataAdapter("Select * From Table_HinhThucTT", constr);

            DataTable _dt = new DataTable();
            DataTable _dt2 = new DataTable();

            _da.Fill(_dt);
            _da2.Fill(_dt2);

            ViewBag.TrangthaiHDList = ToSelectList(_dt, "MaTrangThai", "TenTrangThai");
            ViewBag.HinhthucTTList = ToSelectList(_dt2, "MaThanhtoan", "HinhThuc");
            hd = hoadon.getIDHD(id);
            return View(hd);
        }
        [HttpPost]

        public ActionResult Edit(ModelHoaDon hd)
        {

            if (ModelState.IsValid)
            {
                hoadon.getIDHD(hd.MaHD);
                hoadon.updateHD(hd);
                return RedirectToAction("Index");
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