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
    public class DALcsdl
    {
        public static SqlConnection ketnoi()
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["dataConnectionString"].ConnectionString); // tao đối tượng connecttion
            

            return con1;
        }
        //Khách hàng
        public List<ModeKhachHang> getListKH()
        {
            SqlConnection con = DALcsdl.ketnoi(); // tao doi tuong
            con.Open(); // mở connect
            SqlCommand cm = new SqlCommand(); // khoi tao doi tuong sql conmand
            // gọi thủ tục đã xây dựng trong sql sever
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_hienthiKhachHang";
            cm.Connection = con;
            // đọC dữ liệu
            SqlDataReader reader = cm.ExecuteReader(); // reader thực thi phương thức vaf tra vè danh sahcs
            List<ModeKhachHang> listKH = new List<ModeKhachHang>();
            while (reader.Read())
            {
                ModeKhachHang khachHang = new ModeKhachHang();
               
                khachHang.Usename = reader["Usename"].ToString();
                khachHang.pass = reader["pass"].ToString();                
                khachHang.HoTen = reader["HoTen"].ToString();
                //khachHang.HinhAnh =reader["HinhAnh"].ToString();
                khachHang.DiaChi = reader["NoiSinh"].ToString();
                khachHang.NgaySinh =DateTime.Parse( reader["NgaySinh"].ToString());
                khachHang.SDT = int.Parse(reader["SDT"].ToString());               
                khachHang.SoCMND = int.Parse(reader["SoCMND"].ToString());
                
                khachHang.NoiCap = reader["TenNoiCap"].ToString();
                khachHang.GioiTinh = reader["GioiTinh"].ToString();
                khachHang.Chucvu= reader["TenChucVu"].ToString();
                listKH.Add(khachHang);
            }
            con.Close();
            return listKH;
        }

        public bool updateTTKH(ModeKhachHang s)
        {
            SqlConnection con = DALcsdl.ketnoi(); // tao doi tuong
            con.Open(); // mở connect
            SqlCommand cm = new SqlCommand(); // khoi tao doi tuong sql conmand
            // gọi thủ tục đã xây dựng trong sql sever
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_SuaKH";
            cm.Connection = con;

            SqlParameter Usename = new SqlParameter("@Usename", s.Usename);
            SqlParameter pass = new SqlParameter("@pass", s.pass);
            SqlParameter HoTen = new SqlParameter("@HoTen", s.HoTen);
            //SqlParameter HinhAnh = new SqlParameter("@HinhAnh", s.HinhAnh);
            SqlParameter DiaChi = new SqlParameter("@DiaChi", s.DiaChi);
            SqlParameter NgaySinh = new SqlParameter("@NgaySinh", s.NgaySinh);
            SqlParameter SDT = new SqlParameter("@SDT", s.SDT);
            SqlParameter SoCMND = new SqlParameter("@SoCMND", s.SoCMND);
            
            SqlParameter NoiCap = new SqlParameter("@NoiCap", s.NoiCap);
            SqlParameter GioiTinh = new SqlParameter("@GioiTinh", s.GioiTinh);
            SqlParameter ChucVu = new SqlParameter("@Chucvu", s.Chucvu);



            cm.Parameters.Add(Usename);
            cm.Parameters.Add(pass);
            cm.Parameters.Add(HoTen);
            //cm.Parameters.Add(HinhAnh);
            cm.Parameters.Add(DiaChi);
            cm.Parameters.Add(NgaySinh);
            cm.Parameters.Add(SDT);
            cm.Parameters.Add(SoCMND);
           
            cm.Parameters.Add(NoiCap);
            cm.Parameters.Add(GioiTinh);
            cm.Parameters.Add(ChucVu);
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

       
        public bool AddKH(ModeKhachHang s)
        {
            SqlConnection con = DALcsdl.ketnoi(); // tao doi tuong
            con.Open(); // mở connect
            SqlCommand cm = new SqlCommand(); // khoi tao doi tuong sql conmand
            // gọi thủ tục đã xây dựng trong sql sever
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_ThemKH";
            cm.Connection = con;

            
            SqlParameter Usename = new SqlParameter("@Usename", s.Usename);
            SqlParameter pass = new SqlParameter("@pass", s.pass);  
            SqlParameter HoTen = new SqlParameter("@HoTen", s.HoTen);
            //SqlParameter HinhAnh = new SqlParameter("@HinhAnh", s.HinhAnh);
            SqlParameter DiaChi = new SqlParameter("@DiaChi", s.DiaChi);
            SqlParameter NgaySinh = new SqlParameter("@NgaySinh", s.NgaySinh);
            SqlParameter SDT = new SqlParameter("@SDT", s.SDT);            
            SqlParameter SoCMND = new SqlParameter("@SoCMND", s.SoCMND);
            
            SqlParameter NoiCap = new SqlParameter("@NoiCap", s.NoiCap);
            SqlParameter GioiTinh = new SqlParameter("@GioiTinh", s.GioiTinh);
            SqlParameter ChucVu = new SqlParameter("@Chucvu", s.Chucvu);


            
            cm.Parameters.Add(Usename);
            cm.Parameters.Add(pass);           
            cm.Parameters.Add(HoTen);         
            //cm.Parameters.Add(HinhAnh);
            cm.Parameters.Add(DiaChi);
            cm.Parameters.Add(NgaySinh);
            cm.Parameters.Add(SDT);           
            cm.Parameters.Add(SoCMND);
            
            cm.Parameters.Add(NoiCap);
            cm.Parameters.Add(GioiTinh);
            cm.Parameters.Add(ChucVu);
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
        public bool DeleteKH(string id)
        {

            SqlConnection con = DALcsdl.ketnoi(); // tao doi tuong
            con.Open(); // mở connect
            SqlCommand cm = new SqlCommand(); // khoi tao doi tuong sql conmand
            // gọi thủ tục đã xây dựng trong sql sever
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_XoaKH";
            cm.Connection = con;

            
            SqlParameter paUS = new SqlParameter();
           
           
            paUS.ParameterName = "@UseName";
            paUS.Value = id;
           

           
            cm.Parameters.Add(paUS);
            

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

        public ModeKhachHang getKHID(string id)
        {
            SqlConnection con = DALcsdl.ketnoi(); // tao doi tuong
            con.Open(); // mở connect
            SqlCommand cm = new SqlCommand(); // khoi tao doi tuong sql conmand
            // gọi thủ tục đã xây dựng trong sql sever
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_layIDKhachHang";
            cm.Connection = con;

            SqlParameter paID = new SqlParameter();
            paID.ParameterName = "@UseName";
            paID.Value = id;

            cm.Parameters.Add(paID);
            // đọC dữ liệu
            SqlDataReader reader = cm.ExecuteReader(); // reader thực thi phương thức vaf tra vè danh sahcs

            ModeKhachHang khachHang = new ModeKhachHang();

            while (reader.Read())
            {

                khachHang.Usename = reader["Usename"].ToString();
                khachHang.pass = reader["pass"].ToString();
                khachHang.HoTen = reader["HoTen"].ToString();
                //khachHang.HinhAnh =reader["HinhAnh"].ToString();
                khachHang.DiaChi = reader["DiaChi"].ToString();
                khachHang.NgaySinh = DateTime.Parse(reader["NgaySinh"].ToString());
                khachHang.SDT = int.Parse(reader["SDT"].ToString());
                khachHang.SoCMND = int.Parse(reader["SoCMND"].ToString());
               
                khachHang.NoiCap = reader["NoiCap"].ToString();
                khachHang.GioiTinh = reader["GioiTinh"].ToString();
                khachHang.Chucvu = reader["Chucvu"].ToString();

            }
            con.Close();
            return khachHang;
        }
        //nhân viên
        
       
        
    }
}