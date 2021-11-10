using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace DoAn_CuaHangLaptop.Models
{
    public class LapTopContext 
    {
        readonly IConfiguration configuration;
        public string ConnectionString { get; set; }

        public LapTopContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<NhanVien> layNhanVien()
        {
            List<NhanVien> dsNhanVien = new List<NhanVien>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "Select * from NHANVIEN";
                MySqlCommand cmd = new MySqlCommand(query,conn);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dsNhanVien.Add(new NhanVien()
                            {
                                MaNV = reader["manv"].ToString(),
                                TenDangNhap = reader["tendangnhap"].ToString(),
                                TenNV = reader["tenNV"].ToString(),
                                NgaySinh = (DateTime)reader["ngaysinh"],
                                GioiTinh = reader["gioitinh"].ToString(),
                                ChucVu = reader["chucvu"].ToString(),
                                DiaChi = reader["diachi"].ToString(),
                                NgayVL = (DateTime)reader["ngayvl"],
                                SoDT = reader["sodt"].ToString(),

                            }) ;

                        }
                    }
                }
            }
                return dsNhanVien;
        }
        public bool ktNhanVien(string tendangnhap)
        {
            List<NhanVien> dsNV = new List<NhanVien>();
            dsNV = layNhanVien();
            foreach (NhanVien temp in dsNV)
            {
                if (temp.TenDangNhap == tendangnhap) return false;
            }
            return true; 
        }
        public void xuLyTaoNhanVien(NhanVien nv)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO nhanvien(TENDANGNHAP,TENNV,NGAYSINH,GIOITINH,CHUCVU,DIACHI,NGAYVL,SODT)
                                     VALUES
                                     (@tendangnhap,@tennv,@ngaysinh,@gioitinh,@chucvu,@diachi,@ngayvl,@sodt)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tenDangNhap", nv.TenDangNhap.ToString());
                cmd.Parameters.AddWithValue("@tennv", nv.TenNV.ToString());
                cmd.Parameters.AddWithValue("@ngaysinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@gioitinh", nv.GioiTinh.ToString());
                cmd.Parameters.AddWithValue("@chucvu", nv.ChucVu.ToString());
                cmd.Parameters.AddWithValue("@diachi", nv.DiaChi.ToString());
                cmd.Parameters.AddWithValue("@ngayvl", nv.NgayVL);
                cmd.Parameters.AddWithValue("@sodt", nv.SoDT.ToString());
                cmd.ExecuteNonQuery();
            }
        }
        public bool ktNgayVL(DateTime ngaySinh, DateTime ngayVL)
        {
            int namSinh = ngaySinh.Year;
            int namVL = ngayVL.Year;
            if(namSinh > namVL)
            {
                return false;
            }
            else
            {
                if (namVL - namSinh < 16) return false;
 
            }
            return true;
        }
        public int taoNhanVien(NhanVien nv)
        {
            int count = 3;
            if (!ktNhanVien(nv.TenDangNhap))
            {
                return 0;
            }
            else
            {
                if (!ktNgayVL(nv.NgaySinh, nv.NgayVL))
                {
                    return 2;
                }
                else
                {
                    if (ktTenDangNhap(nv.TenDangNhap))
                    {

                        taoTaiKhoan(new TaiKhoan() { TenDangNhap = nv.TenDangNhap, MatKhau = "" });
                        xuLyTaoNhanVien(nv);
                        count++;
                    }
                    else
                    {
                        xuLyTaoNhanVien(nv);
                        count = 1;
                    }
                }
                
            }
            return count;
        }

        public NhanVien layThongTinNV(string manv)
        {
            NhanVien nv = new NhanVien();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from Nhanvien where manv =@manv";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@manv", manv);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        nv.MaNV = reader["manv"].ToString();
                        nv.TenDangNhap = reader["tendangnhap"].ToString();
                        nv.TenNV = reader["tenNV"].ToString();
                        nv.NgaySinh = (DateTime)reader["ngaysinh"];
                        nv.GioiTinh = reader["gioitinh"].ToString();
                        nv.ChucVu = reader["chucvu"].ToString();
                        nv.DiaChi = reader["diachi"].ToString();
                        nv.NgayVL = (DateTime)reader["ngayvl"];
                        nv.SoDT = reader["sodt"].ToString();
                    };

                }
            }
            return nv;
        }

        public int capNhatNhanVien(NhanVien nv)
        {
            int count = 0;
            if (!ktNgayVL(nv.NgaySinh, nv.NgayVL))
            {
                return 0;
            }
            else
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE nhanvien
                                    SET
                                    TENNV = @tennv,
                                    NGAYSINH = @ngaysinh,
                                    GIOITINH = @gioitinh,
                                    CHUCVU = @chucvu,
                                    DIACHI = @diachi,
                                    NGAYVL = @ngayvl,
                                    SODT = @sodt
                                    WHERE MANV = @manv;";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("TENNV", nv.TenNV.ToString());
                    cmd.Parameters.AddWithValue("NGAYSINH", nv.NgaySinh);
                    cmd.Parameters.AddWithValue("GIOITINH", nv.GioiTinh.ToString());
                    cmd.Parameters.AddWithValue("CHUCVU", nv.ChucVu.ToString());
                    cmd.Parameters.AddWithValue("DIACHI", nv.DiaChi.ToString());
                    cmd.Parameters.AddWithValue("NGAYVL", nv.NgayVL);
                    cmd.Parameters.AddWithValue("SODT", nv.SoDT.ToString());
                    cmd.Parameters.AddWithValue("MANV", nv.MaNV.ToString());
                    cmd.ExecuteNonQuery();
                    count++;
                }
            }
            
                return count;
        }

        public void xoaNhanVien(string manv)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "delete from nhanvien where manv = @manv ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("manv", manv);
                cmd.ExecuteNonQuery();
            }
        }

        public List<TaiKhoan> layTaiKhoan()
        {
            List<TaiKhoan> dsTaiKhoan = new List<TaiKhoan>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "Select * from TAIKHOAN";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dsTaiKhoan.Add(new TaiKhoan()
                            {
                                TenDangNhap = reader["tendangnhap"].ToString(),
                                MatKhau = reader["matkhau"].ToString(),
                            }) ;

                        }
                    }
                }
            }
            return dsTaiKhoan;
        }
        public bool ktTenDangNhap(string tendangnhap)
        {

            List<TaiKhoan> list = new List<TaiKhoan>();
            list = layTaiKhoan();
            foreach (TaiKhoan temp in list)
            {
                if (temp.TenDangNhap == tendangnhap) return false;
            }
            return true;
        }
        public int taoTaiKhoan(TaiKhoan tk)
        {
            int count = 0;
            if (!ktTenDangNhap(tk.TenDangNhap)) return 0;
            else
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO TAIKHOAN VALUES (@tenDangNhap,@matKhau) ";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tenDangNhap", tk.TenDangNhap.ToString());
                    cmd.Parameters.AddWithValue("@matKhau", tk.MatKhau.ToString());
                    cmd.ExecuteNonQuery();
                    count++;
                }
                return count;
            }
            
        }
        public TaiKhoan layThongTinTK(string tendangnhap)
        {
            TaiKhoan tk = new TaiKhoan();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from TaiKhoan where tendangnhap =@tendangnhap";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tendangnhap", tendangnhap);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tk.TenDangNhap = reader["tendangnhap"].ToString();
                        tk.MatKhau = reader["matkhau"].ToString();
                    };

                }
            }
            return tk;
        }

        public int capNhatTaiKhoan(TaiKhoan tk)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"UPDATE taikhoan
                                    SET matkhau = @matkhau
                                    WHERE tendangnhap = @tendangnhap;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("tendangnhap",tk.TenDangNhap.ToString());
                cmd.Parameters.AddWithValue("matkhau", tk.MatKhau.ToString());
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

        public void xoaTaiKhoan(string tendangnhap)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "delete from taikhoan where tendangnhap = @tendangnhap; ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("tendangnhap", tendangnhap);
                cmd.ExecuteNonQuery();

            }
        }
    }
}
