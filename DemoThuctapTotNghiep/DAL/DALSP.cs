using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DemoThuctapTotNghiep.Models;

namespace DemoThuctapTotNghiep.DAL
{
    public class DALSP
    {
        public static SqlConnection ketnoi()
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["dataConnectionString"].ConnectionString); // tao đối tượng connecttion
          

            return con1;
        }
        public List<modeSanPham> getListSP2()
        {
            SqlConnection con = DALSP.ketnoi(); // tao doi tuong
            con.Open(); // mở connect
            SqlCommand cm = new SqlCommand(); // khoi tao doi tuong sql conmand
            // gọi thủ tục đã xây dựng trong sql sever
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_hienthiSP";
            cm.Connection = con;
            // đọC dữ liệu
            SqlDataReader reader = cm.ExecuteReader(); // reader thực thi phương thức vaf tra vè danh sahcs
            List<modeSanPham> listSP = new List<modeSanPham>();
            while (reader.Read())
            {
                modeSanPham SP = new modeSanPham();
                SP.MaSP = int.Parse(reader["MaSP"].ToString());
                SP.TenSP = reader["TenSP"].ToString();
                SP.SoLuong = int.Parse(reader["SoLuong"].ToString());
                SP.GiaBan = int.Parse(reader["GiaBan"].ToString());
                SP.GiaVon = int.Parse(reader["GiaVon"].ToString());
                SP.MoTaSP = reader["MoTaSP"].ToString();
                SP.DanhMucSP = reader["DanhMucSP"].ToString();
                SP.TrinhTrangSP = reader["TrinhTrangSP"].ToString();
                SP.NhaCungCap = reader["NhaCungCap"].ToString();
                SP.HinhAnh = reader["HinhAnh"].ToString();
                SP.IDDanhMuc = reader["IDDanhMuc"].ToString();
           


                listSP.Add(SP);
            }
            con.Close();
            return listSP;
        }
        public bool DeleteSP(int id)
        {
            SqlConnection con = DALSP.ketnoi(); // tao doi tuong
            con.Open(); // mở connect
            SqlCommand cm = new SqlCommand(); // khoi tao doi tuong sql conmand
            // gọi thủ tục đã xây dựng trong sql sever
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_XoaSP";
            cm.Connection = con;
            SqlParameter paID = new SqlParameter();
            paID.ParameterName = "@MaSP";
            paID.Value = id;
            cm.Parameters.Add(paID);
            try
            {
                cm.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public modeSanPham getSPID(int id)
        {
            SqlConnection con = DALSP.ketnoi(); // tao doi tuong
            con.Open(); // mở connect
            SqlCommand cm = new SqlCommand(); // khoi tao doi tuong sql conmand
            // gọi thủ tục đã xây dựng trong sql sever
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_GetIDSP";
            cm.Connection = con;

            SqlParameter paID = new SqlParameter();
            paID.ParameterName = "@MaSP";
            paID.Value = id;

            cm.Parameters.Add(paID);
            // đọC dữ liệu
            SqlDataReader reader = cm.ExecuteReader(); // reader thực thi phương thức vaf tra vè danh sahcs
            modeSanPham SP = new modeSanPham();
            while (reader.Read())
            {

                SP.MaSP = int.Parse(reader["MaSP"].ToString());
                SP.TenSP = reader["TenSP"].ToString();
                SP.SoLuong = int.Parse(reader["SoLuong"].ToString());
                SP.GiaBan = int.Parse(reader["GiaBan"].ToString());
                SP.GiaVon = int.Parse(reader["GiaVon"].ToString());
                SP.MoTaSP = reader["MoTaSP"].ToString();
                SP.DanhMucSP = reader["IDDanhMuc"].ToString();
                SP.TrinhTrangSP = reader["IDTinhTrang"].ToString();
                SP.NhaCungCap = reader["IDNhaCungCap"].ToString();
                SP.HinhAnh = reader["HinhAnh"].ToString();

            }
            con.Close();
            return SP;
        }
        public bool updateSP(modeSanPham sp)
        {
            SqlConnection con = DALSP.ketnoi(); // tao doi tuong
            con.Open(); // mở connect
            SqlCommand cm = new SqlCommand(); // khoi tao doi tuong sql conmand
            // gọi thủ tục đã xây dựng trong sql sever
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_SuaSP";
            cm.Connection = con;

            SqlParameter MaSP = new SqlParameter("@MaSP", sp.MaSP);
            SqlParameter tensp = new SqlParameter("@TenSP", sp.TenSP);
            SqlParameter SoLuong = new SqlParameter("@SoLuong", sp.SoLuong);
            SqlParameter TrinhTrangSP = new SqlParameter("@IDTinhTrang", sp.TrinhTrangSP);
            SqlParameter DanhMucSP = new SqlParameter("@IDDanhMuc", sp.DanhMucSP);
            SqlParameter NhaCungCap = new SqlParameter("@IDNhaCungCap", sp.NhaCungCap);
            SqlParameter GiaBan = new SqlParameter("@GiaBan", sp.GiaBan);
            SqlParameter GiaVon = new SqlParameter("@GiaVon", sp.GiaVon);
            SqlParameter MoTaSP = new SqlParameter("@MoTaSP", sp.MoTaSP);
            SqlParameter HinhAnh = new SqlParameter("@HinhAnh", sp.HinhAnh);



            cm.Parameters.Add(MaSP);
            cm.Parameters.Add(tensp);
            cm.Parameters.Add(SoLuong);
            cm.Parameters.Add(TrinhTrangSP);
            cm.Parameters.Add(DanhMucSP);
            cm.Parameters.Add(NhaCungCap);
            cm.Parameters.Add(GiaBan);
            cm.Parameters.Add(GiaVon);
            cm.Parameters.Add(MoTaSP);
            cm.Parameters.Add(HinhAnh);
            cm.ExecuteNonQuery();
            try
            {
                
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool AddSP(modeSanPham sp)
        {
            SqlConnection con = DALSP.ketnoi(); // tao doi tuong
            con.Open(); // mở connect
            SqlCommand cm = new SqlCommand(); // khoi tao doi tuong sql conmand
            // gọi thủ tục đã xây dựng trong sql sever
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_ThemSP";

            cm.Connection = con;

            SqlParameter tensp = new SqlParameter("@TenSP", sp.TenSP);
            SqlParameter SoLuong = new SqlParameter("@SoLuong", sp.SoLuong);
            SqlParameter TrinhTrangSP = new SqlParameter("@IDTinhTrang", sp.TrinhTrangSP);
            SqlParameter DanhMucSP = new SqlParameter("@IDDanhMuc", sp.DanhMucSP);
            SqlParameter NhaCungCap = new SqlParameter("@IDNhaCungCap", sp.NhaCungCap);
            SqlParameter GiaBan = new SqlParameter("@GiaBan", sp.GiaBan);
            SqlParameter GiaVon = new SqlParameter("@GiaVon", sp.GiaVon);
            SqlParameter MoTaSP = new SqlParameter("@MoTaSP", sp.MoTaSP);
            SqlParameter HinhAnh = new SqlParameter("@HinhAnh", sp.HinhAnh);


            

            cm.Parameters.Add(tensp);
            cm.Parameters.Add(SoLuong);
            cm.Parameters.Add(TrinhTrangSP);
            cm.Parameters.Add(DanhMucSP);
            cm.Parameters.Add(NhaCungCap);
            cm.Parameters.Add(GiaBan);
            cm.Parameters.Add(GiaVon);
            cm.Parameters.Add(MoTaSP);
            cm.Parameters.Add(HinhAnh);
               cm.ExecuteNonQuery();
            try
            {
                
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
    }
}