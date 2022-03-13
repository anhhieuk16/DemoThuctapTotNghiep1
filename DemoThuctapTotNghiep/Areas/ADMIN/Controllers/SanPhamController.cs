using System;
using PagedList;
using PagedList.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoThuctapTotNghiep.Models;
using DemoThuctapTotNghiep.DAL;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;

namespace DemoThuctapTotNghiep.Areas.ADMIN.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: ADMIN/SanPham
        DALSP ketnoi = new DALSP();
        private string a;
        public ActionResult Index(int? page)
        {
            return View(ketnoi.getListSP2().ToPagedList(page ?? 1, 10));
        }
        [HttpGet]
        public ActionResult Create()
        {
            string constr = ConfigurationManager.ConnectionStrings["mbkConnectionString"].ToString();
            SqlConnection _con = new SqlConnection(constr);
            SqlDataAdapter _da = new SqlDataAdapter("Select * From Table_DanhMucSP", constr);
            SqlDataAdapter _da2 = new SqlDataAdapter("Select * From Table_NhaCungCap", constr);
            SqlDataAdapter _da3 = new SqlDataAdapter("Select * From Table_TinhTrangSP", constr);
            DataTable _dt = new DataTable();
            DataTable _dt2 = new DataTable();
            DataTable _dt3 = new DataTable();
            _da.Fill(_dt);
            _da2.Fill(_dt2);
            _da3.Fill(_dt3);
            ViewBag.DanhMList = ToSelectList(_dt, "MaDanhMuc", "DanhMucSP");
            ViewBag.NhaCCList = ToSelectList(_dt2, "IDNhaCungCap", "NhaCungCap");
            ViewBag.TinhTMList = ToSelectList(_dt3, "IDTinhTrangSP", "TrinhTrangSP");
            return View();
        }
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(modeSanPham sp, HttpPostedFileBase image)
        {
            string name = Path.GetFileName(image.FileName);
            string path = "/img-sanpham/" + name;

            string constr = ConfigurationManager.ConnectionStrings["mbkConnectionString"].ToString();
            SqlConnection _con = new SqlConnection(constr);
            SqlDataAdapter _da = new SqlDataAdapter("Select * From Table_DanhMucSP", constr);
            SqlDataAdapter _da2 = new SqlDataAdapter("Select * From Table_NhaCungCap", constr);
            SqlDataAdapter _da3 = new SqlDataAdapter("Select * From Table_TinhTrangSP", constr);
            DataTable _dt = new DataTable();
            DataTable _dt2 = new DataTable();
            DataTable _dt3 = new DataTable();
            _da.Fill(_dt);
            _da2.Fill(_dt2);
            _da3.Fill(_dt3);
            if (ViewBag.TinhTMList == null)
            {
            

            //Saving file to Folder
            image.SaveAs(Server.MapPath(path));
            sp.HinhAnh = path;
            if (ModelState.IsValid)
            {

                    ViewBag.TinhTMList = ToSelectList(_dt3, "IDTinhTrangSP", "TrinhTrangSP");
                }
                if (ViewBag.DanhMList == null)
                {
                    ViewBag.DanhMList = ToSelectList(_dt, "MaDanhMuc", "DanhMucSP");
                }
                if (ViewBag.NhaCCList == null)
                {
                    ViewBag.NhaCCList = ToSelectList(_dt2, "IDNhaCungCap", "NhaCungCap");
                }
                ketnoi.AddSP(sp);
                return RedirectToAction("Index");
            }
            else {
                image.SaveAs(Server.MapPath(path));
                sp.HinhAnh = path;
                if (ModelState.IsValid)
                {
                ketnoi.AddSP(sp);
                return RedirectToAction("Index");
                    }
            }
            return View();
        }
            public ActionResult Delete(int id)
        {
            ketnoi.DeleteSP(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            modeSanPham sp = new modeSanPham();
            string constr = ConfigurationManager.ConnectionStrings["mbkConnectionString"].ToString();
            SqlConnection _con = new SqlConnection(constr);
            SqlDataAdapter _da = new SqlDataAdapter("Select * From Table_DanhMucSP", constr);
            SqlDataAdapter _da2 = new SqlDataAdapter("Select * From Table_NhaCungCap", constr);
            SqlDataAdapter _da3 = new SqlDataAdapter("Select * From Table_TinhTrangSP", constr);
            DataTable _dt = new DataTable();
            DataTable _dt2 = new DataTable();
            DataTable _dt3 = new DataTable();
            _da.Fill(_dt);
            _da2.Fill(_dt2);
            _da3.Fill(_dt3);
            ViewBag.DanhMList = ToSelectList(_dt, "MaDanhMuc", "DanhMucSP");
            ViewBag.NhaCCList = ToSelectList(_dt2, "IDNhaCungCap", "NhaCungCap");
            ViewBag.TinhTMList = ToSelectList(_dt3, "IDTinhTrangSP", "TrinhTrangSP");
            sp = ketnoi.getSPID(id);
            
            return View(sp);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(modeSanPham s, HttpPostedFileBase image)
        {
         
            string name = Path.GetFileName(image.FileName);
            string path = "/img-sanpham/" + name;
            //Saving file to Folder
            image.SaveAs(Server.MapPath(path));
            s.HinhAnh = path;

            string constr = ConfigurationManager.ConnectionStrings["mbkConnectionString"].ToString();
            SqlConnection _con = new SqlConnection(constr);
            SqlDataAdapter _da = new SqlDataAdapter("Select * From Table_DanhMucSP", constr);
            SqlDataAdapter _da2 = new SqlDataAdapter("Select * From Table_NhaCungCap", constr);
            SqlDataAdapter _da3 = new SqlDataAdapter("Select * From Table_TinhTrangSP", constr);
            DataTable _dt = new DataTable();
            DataTable _dt2 = new DataTable();
            DataTable _dt3 = new DataTable();
            _da.Fill(_dt);
            _da2.Fill(_dt2);
            _da3.Fill(_dt3);
            ViewBag.DanhMList = ToSelectList(_dt, "MaDanhMuc", "DanhMucSP");
            ViewBag.NhaCCList = ToSelectList(_dt2, "IDNhaCungCap", "NhaCungCap");
            ViewBag.TinhTMList = ToSelectList(_dt3, "IDTinhTrangSP", "TrinhTrangSP");


                ketnoi.getSPID(s.MaSP);
                ketnoi.updateSP(s);
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