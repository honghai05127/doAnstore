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
        //===================NHÂN VIÊN =========================
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
            if (!ktTenDangNhap(nv.TenDangNhap))
            {
                return 0;
            }
            else
            {
                if (!ktNgayVL(nv.NgaySinh, nv.NgayVL))
                {
                    return 1;
                }
                else
                {
                        taoTaiKhoan(new TaiKhoan() { TenDangNhap = nv.TenDangNhap, MatKhau = "" });
                        xuLyTaoNhanVien(nv);
                        count++;
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
        //===================END NHÂN VIÊN =========================


        //===================TÀI KHOẢN =============================
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

        //===================END TÀI KHOẢN =============================

        //===================HÓA ĐƠN ===================================
        public List<HoaDon> layHoaDon()
        {
            List<HoaDon> dsHoaDon = new List<HoaDon>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "Select * from HOADON";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dsHoaDon.Add(new HoaDon()
                            {
                                MaHD = reader["mahd"].ToString(),
                                MaKH = reader["makh"].ToString(),
                                MaNV = reader["manv"].ToString(),
                                MaSK = reader["mask"].ToString(),
                                NgayHD = (DateTime)reader["ngayhd"],
                                DiaChiGiaoHang = reader["diachigiaohang"].ToString(),
                                TongTien = int.Parse(reader["tongtien"].ToString()),
                                ThanhTien = int.Parse(reader["thanhtien"].ToString()),

                            });

                        }
                    }
                }
            }
            return dsHoaDon;
        }
        public bool ktNgayHoaDon(DateTime nghd)
        {
            DateTime dateNow = DateTime.Now;
            int compare = DateTime.Compare(nghd, dateNow);
            if (compare > 0) return false;
            return true;
        }
       
        public int taoHoaDon(HoaDon hd)
        {
            int count = 0;
            if (!ktNgayHoaDon(hd.NgayHD))
            {
                return 0;
            }
            else
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO `laptop`.`hoadon`(`MAKH`,`MANV`,`MASK`,`NGAYHD`,`DIACHIGIAOHANG`,`TONGTIEN`,`THANHTIEN`)
                                    VALUES (@makh,@manv,@mask,@ngayhd,@diachigiaohang,@tongtien,@thanhtien);";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@makh", hd.MaKH.ToString());
                    cmd.Parameters.AddWithValue("@manv", hd.MaNV.ToString());
                    cmd.Parameters.AddWithValue("@mask", hd.MaSK.ToString());
                    cmd.Parameters.AddWithValue("@ngayhd", hd.NgayHD);
                    cmd.Parameters.AddWithValue("@diachigiaohang", hd.DiaChiGiaoHang.ToString());
                    cmd.Parameters.AddWithValue("@tongtien", hd.TongTien);
                    cmd.Parameters.AddWithValue("@thanhtien", hd.ThanhTien);
                    cmd.ExecuteNonQuery();
                    count++;
                }
            }

            return count;

        }

        public HoaDon layThongTinHD(string mahd)
        {
            HoaDon hd = new HoaDon();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from HoaDon where mahd =@mahd";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mahd", mahd);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        hd.MaHD = reader["mahd"].ToString();
                        hd.MaKH = reader["makh"].ToString();
                        hd.MaNV = reader["manv"].ToString();
                        hd.MaSK = reader["mask"].ToString();
                        hd.NgayHD = (DateTime)reader["ngayhd"];
                        hd.DiaChiGiaoHang = reader["diachigiaohang"].ToString();
                        hd.TongTien = long.Parse(reader["tongtien"].ToString());
                        hd.ThanhTien = long.Parse(reader["thanhtien"].ToString());
                    };

                }
            }
            return hd;
        }
        public int capNhatHoaDon(HoaDon hd)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"UPDATE `laptop`.`hoadon`
                                SET
                                `MAKH` = @makh,
                                `MANV` = @manv,
                                `MASK` = @mask,
                                `NGAYHD` = @ngayhd,
                                `DIACHIGIAOHANG` = @diachigiaohang,
                                `TONGTIEN` = @tongtien,
                                `THANHTIEN` = @thanhtien
                                WHERE `MAHD` = @mahd;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@makh", hd.MaKH.ToString());
                cmd.Parameters.AddWithValue("@manv", hd.MaNV.ToString());
                cmd.Parameters.AddWithValue("@mask", hd.MaSK.ToString());
                cmd.Parameters.AddWithValue("@ngayhd", hd.NgayHD);
                cmd.Parameters.AddWithValue("@diachigiaohang", hd.DiaChiGiaoHang.ToString());
                cmd.Parameters.AddWithValue("@tongtien", hd.TongTien);
                cmd.Parameters.AddWithValue("@thanhtien", hd.ThanhTien);
                cmd.Parameters.AddWithValue("@mahd", hd.MaHD);
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

        public void xoaHoaDon(string mahd)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "delete from hoadon where mahd = @mahd; ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("mahd", mahd);
                cmd.ExecuteNonQuery();

            }
        }

        //===================END HÓA ĐƠN ===============================

        //===================CTHD ======================================
        public List<CTHD> layCTHD()
        {
            List<CTHD> dsCTHD = new List<CTHD>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "Select * from CTHD";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dsCTHD.Add(new CTHD()
                            {
                                MaHD = reader["mahd"].ToString(),
                                MaSP = reader["masp"].ToString(),
                                SoLuong = int.Parse(reader["soluong"].ToString()),
                            });

                        }
                    }
                }
            }
            return dsCTHD;
        }

        public int taoCTHD(CTHD cthd)
        {
            int count = 0;


            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO `laptop`.`CTHD`(`MAHD`,`MASP`,`SOLUONG`)
                                    VALUES (@mahd,@masp,@soluong);";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mahd", cthd.MaHD.ToString());
                cmd.Parameters.AddWithValue("@masp", cthd.MaSP.ToString());
                cmd.Parameters.AddWithValue("@soluong", cthd.SoLuong);
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;

        }
        public CTHD layThongTinCTHD(string mahd,string masp)
        {
            CTHD cthd = new CTHD();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from CTHD where mahd =@mahd and masp = @masp";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mahd", mahd);
                cmd.Parameters.AddWithValue("@masp", masp);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cthd.MaHD = reader["mahd"].ToString();
                        cthd.MaSP = reader["masp"].ToString();
                        cthd.SoLuong = int.Parse(reader["soluong"].ToString());
                    };

                }
            }
            return cthd;
        }
        public int capNhatCTHD(CTHD cthd)
        {
            int count = 0;
            if(cthd.SoLuong == 0)
            {
                xoaCTHD(cthd.MaHD, cthd.MaSP);
            }
            else
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE `laptop`.`cthd`
                                    SET
                                    `SOLUONG` = @soluong,
                                   WHERE `MAHD` = @mahd and masp = @masp ;";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@mahd", cthd.MaHD.ToString());
                    cmd.Parameters.AddWithValue("@masp", cthd.MaSP.ToString());
                    cmd.Parameters.AddWithValue("@soluong", cthd.SoLuong);
                    cmd.ExecuteNonQuery();
                    count++;
                }
            }
            return count;
        }

        public void xoaCTHD(string mahd, string masp)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "delete from cthd where mahd = @mahd and masp = @masp; ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("mahd", mahd);
                cmd.Parameters.AddWithValue("@masp", masp);
                cmd.ExecuteNonQuery();

            }
        }
        //===================END CTHD ===================================


    }
}
