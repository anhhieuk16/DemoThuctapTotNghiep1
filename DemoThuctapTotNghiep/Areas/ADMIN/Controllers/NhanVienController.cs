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
using System.IO;
using PagedList;
using PagedList.Mvc;

namespace DemoThuctapTotNghiep.Areas.ADMIN.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: ADMIN/NhanVien
        DALnhanvien NV = new DALnhanvien();
        public ActionResult Index(int? page)
        {
            return View(NV.getListNV().ToPagedList(page ?? 1, 10));
        }
        public ActionResult Delete(int id)
        {
            NV.DeleteNV(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            modeNhanVien nv = new modeNhanVien();
            string constr = ConfigurationManager.ConnectionStrings["mbkConnectionString"].ToString();
            SqlConnection _con = new SqlConnection(constr);
            SqlDataAdapter _da = new SqlDataAdapter("Select * From Table_BangCap", constr);
            SqlDataAdapter _da2 = new SqlDataAdapter("Select * From Table_ChucVu", constr);
            SqlDataAdapter _da3 = new SqlDataAdapter("Select * From Table_GioiTinh", constr);
            SqlDataAdapter _da4 = new SqlDataAdapter("Select * From Table_HonNhan", constr);
            DataTable _dt = new DataTable();
            DataTable _dt2 = new DataTable();
            DataTable _dt3 = new DataTable();
            DataTable _dt4 = new DataTable();
            _da.Fill(_dt);
            _da2.Fill(_dt2);
            _da3.Fill(_dt3);
            _da4.Fill(_dt4);
            ViewBag.BangCapList = ToSelectList(_dt, "IDBangCap", "TenBangCap");
            ViewBag.ChucVuList = ToSelectList(_dt2, "MaChucVu", "TenChucVu");
            ViewBag.GioTinhList = ToSelectList(_dt3, "MaGioiTinh", "GioiTinh");
            ViewBag.HonNhanList = ToSelectList(_dt4, "IDHonNhan", "TinhTranghonNhan");
            nv = NV.getNVID(id);
            return View(nv);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(modeNhanVien s, HttpPostedFileBase image)
        {

            string name = Path.GetFileName(image.FileName);
            string path = "/uploadedImages/" + name;

            //Saving file to Folder
            image.SaveAs(Server.MapPath(path));
            s.HinhAnh = path;

            if (ModelState.IsValid)
            {
                NV.getNVID(s.IDNhanVien);
                NV.updateNV(s);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        
        public ActionResult Create()
        {
            
            modeNhanVien nv = new modeNhanVien();
            string constr = ConfigurationManager.ConnectionStrings["mbkConnectionString"].ToString();
            SqlConnection _con = new SqlConnection(constr);
            SqlDataAdapter _da = new SqlDataAdapter("Select * From Table_BangCap", constr);
            SqlDataAdapter _da2 = new SqlDataAdapter("Select * From Table_ChucVu", constr);
            SqlDataAdapter _da3 = new SqlDataAdapter("Select * From Table_GioiTinh", constr);
            SqlDataAdapter _da4 = new SqlDataAdapter("Select * From Table_HonNhan", constr);
            DataTable _dt = new DataTable();
            DataTable _dt2 = new DataTable();
            DataTable _dt3 = new DataTable();
            DataTable _dt4 = new DataTable();
            _da.Fill(_dt);
            _da2.Fill(_dt2);
            _da3.Fill(_dt3);
            _da4.Fill(_dt4);
            ViewBag.BangCapList = ToSelectList(_dt, "IDBangCap", "TenBangCap");
            ViewBag.ChucVuList = ToSelectList(_dt2, "MaChucVu", "TenChucVu");
            ViewBag.GioTinhList = ToSelectList(_dt3, "MaGioiTinh", "GioiTinh");
            ViewBag.HonNhanList = ToSelectList(_dt4, "IDHonNhan", "TinhTranghonNhan");
           
            return View();
        }
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(modeNhanVien nv, HttpPostedFileBase image)
        {
            string name = Path.GetFileName(image.FileName);
            string path = "/uploadedImages/" + name;

            //Saving file to Folder
            image.SaveAs(Server.MapPath(path));
            nv.HinhAnh = path;

            if (ModelState.IsValid)
            {
                
                NV.AddNV(nv);
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