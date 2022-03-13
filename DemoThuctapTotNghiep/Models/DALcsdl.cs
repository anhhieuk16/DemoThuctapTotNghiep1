using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DemoThuctapTotNghiep.Models
{
    public class DALcsdl
    {
        public static SqlConnection ketnoi()
        {
            SqlConnection con1 = new SqlConnection(); // tao đối tượng connecttion
            con1.ConnectionString = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QLbandonoithat;Integrated Security=True";
            return con1;
        }
        public List<ModeKhachHang> getListTour()
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
                khachHang.IDkhachHang = int.Parse(reader["IDkhachHang"].ToString());
                khachHang.Usename = reader["Usename"].ToString();
                khachHang.pass = int.Parse(reader["pass"].ToString());
                khachHang.IDNguoi = int.Parse(reader["IDNguoi"].ToString());
                khachHang.HoTen = reader["HoTen"].ToString();
                khachHang.HinhAnh = reader["HinhAnh"].ToString();
                khachHang.DiaChi = reader["DiaChi"].ToString();
                khachHang.NgaySinh = reader["NgaySinh"].ToString();
                khachHang.SDT = int.Parse(reader["SDT"].ToString());
                khachHang.NoiSinh = reader["NoiSinh"].ToString();
                khachHang.SoCMND = int.Parse(reader["SoCMND"].ToString());
                khachHang.NgayCap = reader["NgayCap"].ToString();
                khachHang.NoiCap = reader["NoiCap"].ToString();
                listKH.Add(khachHang);
            }
            con.Close();
            return listKH;
        }

        public bool updateTour(ModeKhachHang s)
        {
            SqlConnection con = DALcsdl.ketnoi(); // tao doi tuong
            con.Open(); // mở connect
            SqlCommand cm = new SqlCommand(); // khoi tao doi tuong sql conmand
            // gọi thủ tục đã xây dựng trong sql sever
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_SuaTour";
            cm.Connection = con;

            SqlParameter IDkhachHang = new SqlParameter("@IDkhachHang", s.IDkhachHang);
            SqlParameter Usename = new SqlParameter("@Usename", s.Usename);
            SqlParameter pass = new SqlParameter("@pass", s.pass);
            SqlParameter IDNguoi = new SqlParameter("@IDNguoi", s.IDNguoi);
            SqlParameter HoTen = new SqlParameter("@HoTen", s.HoTen);
            SqlParameter HinhAnh = new SqlParameter("@HinhAnh", s.HinhAnh);
            SqlParameter DiaChi = new SqlParameter("@DiaChi", s.DiaChi);
            SqlParameter NgaySinh = new SqlParameter("@NgaySinh", s.NgaySinh);
            SqlParameter SDT = new SqlParameter("@SDT", s.SDT);
            SqlParameter SoCMND = new SqlParameter("@SoCMND", s.SoCMND);
            SqlParameter NgayCap = new SqlParameter("@NgayCap", s.NgayCap);
            SqlParameter NoiCap = new SqlParameter("@NoiCap", s.NoiCap);


            cm.Parameters.Add(IDkhachHang);
            cm.Parameters.Add(Usename);
            cm.Parameters.Add(pass);
            cm.Parameters.Add(IDNguoi);
            cm.Parameters.Add(HoTen);
            cm.Parameters.Add(HinhAnh);
            cm.Parameters.Add(DiaChi);
            cm.Parameters.Add(NgaySinh);
            cm.Parameters.Add(SDT);
            cm.Parameters.Add(SoCMND);
            cm.Parameters.Add(NgayCap);
            cm.Parameters.Add(NoiCap);


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

        //ko đc
        public bool AddTour(ModeKhachHang s)
        {
            SqlConnection con = DALcsdl.ketnoi(); // tao doi tuong
            con.Open(); // mở connect
            SqlCommand cm = new SqlCommand(); // khoi tao doi tuong sql conmand
            // gọi thủ tục đã xây dựng trong sql sever
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_ThemKhachHang";
            cm.Connection = con;

            SqlParameter IDkhachHang = new SqlParameter("@IDkhachHang", s.IDkhachHang);
            SqlParameter Usename = new SqlParameter("@Usename", s.Usename);
            SqlParameter pass = new SqlParameter("@pass", s.pass);
            SqlParameter IDNguoi = new SqlParameter("@IDNguoi", s.IDNguoi);
            SqlParameter HoTen = new SqlParameter("@HoTen", s.HoTen);
            SqlParameter HinhAnh = new SqlParameter("@HinhAnh", s.HinhAnh);
            SqlParameter DiaChi = new SqlParameter("@DiaChi", s.DiaChi);
            SqlParameter NgaySinh = new SqlParameter("@NgaySinh", s.NgaySinh);
            SqlParameter SDT = new SqlParameter("@SDT", s.SDT);
            SqlParameter SoCMND = new SqlParameter("@SoCMND", s.SoCMND);
            SqlParameter NgayCap = new SqlParameter("@NgayCap", s.NgayCap);
            SqlParameter NoiCap = new SqlParameter("@NoiCap", s.NoiCap);


            cm.Parameters.Add(IDkhachHang);
            cm.Parameters.Add(Usename);
            cm.Parameters.Add(pass);
            cm.Parameters.Add(IDNguoi);
            cm.Parameters.Add(HoTen);
            cm.Parameters.Add(HinhAnh);
            cm.Parameters.Add(DiaChi);
            cm.Parameters.Add(NgaySinh);
            cm.Parameters.Add(SDT);
            cm.Parameters.Add(SoCMND);
            cm.Parameters.Add(NgayCap);
            cm.Parameters.Add(NoiCap);

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
        public bool DeleteTour(int id)
        {

            SqlConnection con = DALcsdl.ketnoi(); // tao doi tuong
            con.Open(); // mở connect
            SqlCommand cm = new SqlCommand(); // khoi tao doi tuong sql conmand
            // gọi thủ tục đã xây dựng trong sql sever
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_XoaKhachHang";
            cm.Connection = con;

            SqlParameter paID = new SqlParameter();
            paID.ParameterName = "@IDKhachHang";
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

        public ModeKhachHang getTourID(int id)
        {
            SqlConnection con = DALcsdl.ketnoi(); // tao doi tuong
            con.Open(); // mở connect
            SqlCommand cm = new SqlCommand(); // khoi tao doi tuong sql conmand
            // gọi thủ tục đã xây dựng trong sql sever
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_layKhachHang";
            cm.Connection = con;

            SqlParameter paID = new SqlParameter();
            paID.ParameterName = "@IDKhachHang";
            paID.Value = id;

            cm.Parameters.Add(paID);
            // đọC dữ liệu
            SqlDataReader reader = cm.ExecuteReader(); // reader thực thi phương thức vaf tra vè danh sahcs

            ModeKhachHang khachHang = new ModeKhachHang();

            while (reader.Read())
            {
                khachHang.IDkhachHang = int.Parse(reader["IDkhachHang"].ToString());
                khachHang.Usename = reader["Usename"].ToString();
                khachHang.pass = int.Parse(reader["pass"].ToString());
                khachHang.IDNguoi = int.Parse(reader["IDNguoi"].ToString());
                khachHang.HoTen = reader["HoTen"].ToString();
                khachHang.HinhAnh = reader["HinhAnh"].ToString();
                khachHang.DiaChi = reader["DiaChi"].ToString();
                khachHang.NgaySinh = reader["NgaySinh"].ToString();
                khachHang.SDT = int.Parse(reader["SDT"].ToString());
                khachHang.NoiSinh = reader["NoiSinh"].ToString();
                khachHang.SoCMND = int.Parse(reader["SoCMND"].ToString());
                khachHang.NgayCap = reader["NgayCap"].ToString();
                khachHang.NoiCap = reader["NoiCap"].ToString();

            }
            con.Close();
            return khachHang;
        }
    }
}