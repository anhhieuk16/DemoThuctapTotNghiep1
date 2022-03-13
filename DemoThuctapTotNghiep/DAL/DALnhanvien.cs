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
    public class DALnhanvien
    {
        public static SqlConnection ketnoi()
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["dataConnectionString"].ConnectionString); // tao đối tượng connecttion
            

            return con1;
        }
        public List<modeNhanVien> getListNV()
        {
            SqlConnection con = DALnhanvien.ketnoi(); // tao doi tuong
            con.Open(); // mở connect
            SqlCommand cm = new SqlCommand(); // khoi tao doi tuong sql conmand
            // gọi thủ tục đã xây dựng trong sql sever
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_hienthiNhanVien";
            cm.Connection = con;
            // đọC dữ liệu
            SqlDataReader reader = cm.ExecuteReader(); // reader thực thi phương thức vaf tra vè danh sahcs
            List<modeNhanVien> listNV = new List<modeNhanVien>();
            
            while (reader.Read())
            {
                modeNhanVien NV = new modeNhanVien();
                NV.IDNhanVien = int.Parse(reader["IDNhanVien"].ToString());               
                NV.HoTen = reader["HoTen"].ToString();
                NV.HinhAnh = reader["HinhAnh"].ToString();               
                NV.SDT = int.Parse(reader["SDT"].ToString());
                NV.SoCMND = int.Parse(reader["SoCMND"].ToString());               
                NV.GioiTinh = reader["GioiTinh"].ToString();
                NV.BangCap = reader["TenBangCap"].ToString();
                NV.ChucVu = reader["TenChucVu"].ToString();
                NV.TRHonNhan = reader["TinhTranghonNhan"].ToString();
                listNV.Add(NV);
            }
            con.Close();
            return listNV;
        }

        public bool DeleteNV(int id)
        {

            SqlConnection con = DALnhanvien.ketnoi(); // tao doi tuong
            con.Open(); // mở connect
            SqlCommand cm = new SqlCommand(); // khoi tao doi tuong sql conmand
            // gọi thủ tục đã xây dựng trong sql sever
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_XoaNV";
            cm.Connection = con;

            SqlParameter paID = new SqlParameter();
            SqlParameter paUS = new SqlParameter();
            SqlParameter paIDN = new SqlParameter();
            paID.ParameterName = "@IDNhanVien";
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
        public modeNhanVien getNVID(int id)
        {
            SqlConnection con = DALnhanvien.ketnoi(); // tao doi tuong
            con.Open(); // mở connect
            SqlCommand cm = new SqlCommand(); // khoi tao doi tuong sql conmand
            // gọi thủ tục đã xây dựng trong sql sever
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_GetIDNV";
            cm.Connection = con;

            SqlParameter paID = new SqlParameter();
            paID.ParameterName = "@IDNhanVien";
            paID.Value = id;

            cm.Parameters.Add(paID);
            // đọC dữ liệu
            SqlDataReader reader = cm.ExecuteReader(); // reader thực thi phương thức vaf tra vè danh sahcs
            modeNhanVien NV = new modeNhanVien();
            while (reader.Read())
            {

                NV.IDNhanVien = int.Parse(reader["IDNhanVien"].ToString());
                NV.HoTen = reader["HoTen"].ToString();
                NV.HinhAnh = reader["HinhAnh"].ToString();
                NV.SDT = int.Parse(reader["SDT"].ToString());
                NV.SoCMND = int.Parse(reader["SoCMND"].ToString());
                NV.GioiTinh = reader["GioiTinh"].ToString();
                NV.BangCap = reader["BangCap"].ToString();
                NV.ChucVu = reader["ChucVu"].ToString();
                NV.TRHonNhan = reader["TinhTrangHN"].ToString();

            }
            con.Close();
            return NV;
        }
        public bool updateNV(modeNhanVien nv)
        {
            SqlConnection con = DALnhanvien.ketnoi(); // tao doi tuong
            con.Open(); // mở connect
            SqlCommand cm = new SqlCommand(); // khoi tao doi tuong sql conmand
            // gọi thủ tục đã xây dựng trong sql sever
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_SuaNV";
            cm.Connection = con;
            SqlParameter IDNhanVien = new SqlParameter("@IDNhanVien", nv.IDNhanVien);
            SqlParameter HoTen = new SqlParameter("@HoTen", nv.HoTen);
            SqlParameter HinhAnh = new SqlParameter("@HinhAnh", nv.HinhAnh);
            SqlParameter BangCap = new SqlParameter("@BangCap", nv.BangCap);
            SqlParameter ChucVu = new SqlParameter("@ChucVu", nv.ChucVu);
            SqlParameter GioiTinh = new SqlParameter("@GioiTinh", nv.GioiTinh);
            SqlParameter SoCMND = new SqlParameter("@SoCMND", nv.SoCMND);
            SqlParameter SDT = new SqlParameter("@SDT", nv.SDT);
            SqlParameter TRHonNhan = new SqlParameter("@TinhTrangHN", nv.TRHonNhan);




            cm.Parameters.Add(IDNhanVien);
            cm.Parameters.Add(HoTen);
            cm.Parameters.Add(HinhAnh);
            cm.Parameters.Add(BangCap);
            cm.Parameters.Add(ChucVu);
            cm.Parameters.Add(GioiTinh);
            cm.Parameters.Add(SoCMND);
            cm.Parameters.Add(SDT);
            cm.Parameters.Add(TRHonNhan);

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
        public bool AddNV(modeNhanVien nv)
        {
            SqlConnection con = DALnhanvien.ketnoi(); // tao doi tuong
            con.Open(); // mở connect
            SqlCommand cm = new SqlCommand(); // khoi tao doi tuong sql conmand
            // gọi thủ tục đã xây dựng trong sql sever
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_ThemNV";
            cm.Connection = con;
            
            SqlParameter HoTen = new SqlParameter("@HoTen", nv.HoTen);
            SqlParameter HinhAnh = new SqlParameter("@HinhAnh", nv.HinhAnh);
            SqlParameter BangCap = new SqlParameter("@BangCap", nv.BangCap);
            SqlParameter ChucVu = new SqlParameter("@ChucVu", nv.ChucVu);
            SqlParameter GioiTinh = new SqlParameter("@GioiTinh", nv.GioiTinh);
            SqlParameter SoCMND = new SqlParameter("@SoCMND", nv.SoCMND);
            SqlParameter SDT = new SqlParameter("@SDT", nv.SDT);
            SqlParameter TRHonNhan = new SqlParameter("@TinhTrangHN", nv.TRHonNhan);




            
            cm.Parameters.Add(HoTen);
            cm.Parameters.Add(HinhAnh);
            cm.Parameters.Add(BangCap);
            cm.Parameters.Add(ChucVu);
            cm.Parameters.Add(GioiTinh);
            cm.Parameters.Add(SoCMND);
            cm.Parameters.Add(SDT);
            cm.Parameters.Add(TRHonNhan);

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