using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecthoca.Models.Enitity
{
    public class ChiTietPhieuNhap
{
    public int Id { get; set; } // Primary Key
    public string SoPhieu { get; set; } // Foreign Key
    public PhieuNhap PhieuNhap { get; set; } // Liên kết đến Phiếu Nhập
    public string Ma_sanpham { get; set; } // Foreign Key từ bảng Quanlyhanghoa
    public Danhmuc Danhmuc { get; set; } // Liên kết đến bảng quản lý hàng hóa
    public int SoLuong { get; set; }
    public decimal DonGia { get; set; }
    public string DonViTinh { get; set; }
    public decimal ThanhTien { get; set; }
        public DateTime Ngaynhap { get; set; }

    }

}