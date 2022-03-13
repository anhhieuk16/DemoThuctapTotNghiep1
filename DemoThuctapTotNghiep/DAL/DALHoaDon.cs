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
    public class DALHoaDon
    {
        public static SqlConnection ketnoi()
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["dataConnectionString"].ConnectionString); // tao đối tượng connecttion
            

            return con1;
        }

        public List<ModelHoaDon> getListHD()
        {
            SqlConnection con = DALHoaDon.ketnoi(); // tao doi tuong
            con.Open(); // mở connect
            SqlCommand cm = new SqlCommand(); // khoi tao doi tuong sql conmand
            // gọi thủ tục đã xây dựng trong sql sever
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_hienthiHD";
            cm.Connection = con;
            // đọC dữ liệu
            SqlDataReader reader = cm.ExecuteReader(); // reader thực thi phương thức vaf tra vè danh sahcs
            List<ModelHoaDon> listHD = new List<ModelHoaDon>();
            
            while (reader.Read())
            {
                ModelHoaDon HD = new ModelHoaDon();
                HD.MaHD = int.Parse(reader["MaHD"].ToString());
                HD.GiasP = int.Parse(reader["GiaBan"].ToString());
                HD.SLsP = int.Parse(reader["SLsp"].ToString());
                HD.TenSP = reader["TenSP"].ToString();
                HD.HoTen = reader["HoTen"].ToString();
                HD.HinhThucTT = reader["HinhThuc"].ToString();
                HD.NoiNhan = reader["NoiNhan"].ToString();
                HD.Trangthai = reader["TenTrangThai"].ToString();
               

                listHD.Add(HD);
            }
            con.Close();
            return listHD;
        }

        public bool DeleteHD(int id)
        {

            SqlConnection con = DALHoaDon.ketnoi(); // tao doi tuong
            con.Open(); // mở connect
            SqlCommand cm = new SqlCommand(); // khoi tao doi tuong sql conmand
            // gọi thủ tục đã xây dựng trong sql sever
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_XoaHD";
            cm.Connection = con;

            SqlParameter paID = new SqlParameter();
          
            paID.ParameterName = "@MaHD";
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
        public ModelHoaDon getIDHD(int id)
        {
            SqlConnection con = DALHoaDon.ketnoi(); // tao doi tuong
            con.Open(); // mở connect
            SqlCommand cm = new SqlCommand(); // khoi tao doi tuong sql conmand
            // gọi thủ tục đã xây dựng trong sql sever
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_GetIDHD";
            cm.Connection = con;

            SqlParameter paID = new SqlParameter();
            paID.ParameterName = "@MaHD";
            paID.Value = id;

            cm.Parameters.Add(paID);
            // đọC dữ liệu
            SqlDataReader reader = cm.ExecuteReader(); // reader thực thi phương thức vaf tra vè danh sahcs
            ModelHoaDon HD = new ModelHoaDon();
            while (reader.Read())
            {
                HD.MaHD = int.Parse(reader["MaHD"].ToString());
                HD.SLsP = int.Parse(reader["SLsp"].ToString());
                HD.TenSP = reader["MaSP"].ToString();
                HD.HoTen = reader["UseName"].ToString();
                
                HD.HinhThucTT = reader["IDHinhThucTT"].ToString();
                HD.NoiNhan = reader["NoiNhan"].ToString();
                HD.Trangthai = reader["TrangThai"].ToString();

            }
            con.Close();
            return HD;
        }
        public bool updateHD(ModelHoaDon hd)
        {
            SqlConnection con = DALHoaDon.ketnoi(); // tao doi tuong
            con.Open(); // mở connect
            SqlCommand cm = new SqlCommand(); // khoi tao doi tuong sql conmand
            // gọi thủ tục đã xây dựng trong sql sever
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_SuaHD";
            cm.Connection = con;
            SqlParameter MaHD = new SqlParameter("@MaHD", hd.MaHD);
            SqlParameter HoTen = new SqlParameter("@UseName", hd.HoTen);
            SqlParameter TenSP = new SqlParameter("@MaSP", hd.TenSP);
            SqlParameter slSP = new SqlParameter("@SLsp", hd.SLsP);
            SqlParameter Trangthai = new SqlParameter("@Trangthai", hd.Trangthai);
            SqlParameter NoiNhan = new SqlParameter("@NoiNhan", hd.NoiNhan);
            SqlParameter HinhThucTT = new SqlParameter("@IDHinhThucTT", hd.HinhThucTT);
          
            

            cm.Parameters.Add(MaHD);
            cm.Parameters.Add(HoTen);
            cm.Parameters.Add(slSP);
            cm.Parameters.Add(TenSP);
            cm.Parameters.Add(Trangthai);
            cm.Parameters.Add(NoiNhan);
            cm.Parameters.Add(HinhThucTT);
            
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
        public bool AddHD(ModelHoaDon hd)
        {
            SqlConnection con = DALHoaDon.ketnoi(); // tao doi tuong
            con.Open(); // mở connect
            SqlCommand cm = new SqlCommand(); // khoi tao doi tuong sql conmand
            // gọi thủ tục đã xây dựng trong sql sever
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_ThemHD";
            cm.Connection = con;
            SqlParameter TenSP = new SqlParameter("@MaSP", hd.TenSP);
            SqlParameter HoTen = new SqlParameter("@UseName", hd.HoTen);            
            SqlParameter slSP = new SqlParameter("@SLsp", hd.SLsP);            
            SqlParameter Trangthai = new SqlParameter("@Trangthai", hd.Trangthai);
            SqlParameter NoiNhan = new SqlParameter("@NoiNhan", hd.NoiNhan);
            SqlParameter HinhThucTT = new SqlParameter("@IDHinhThucTT", hd.HinhThucTT);



           
            cm.Parameters.Add(HoTen);
            cm.Parameters.Add(TenSP);
            cm.Parameters.Add(slSP);
            cm.Parameters.Add(Trangthai);
            cm.Parameters.Add(NoiNhan);
            cm.Parameters.Add(HinhThucTT);

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