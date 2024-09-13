using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecthoca.Models.EnitityVM
{
     public class ChiTietPhieuNhapVM
    {
        public int Id { get; set; }
        public string SoPhieu { get; set; }
        public string Ma_sanpham { get; set; }
        public string TenSanPham { get; set; } // Tên sản phẩm lấy từ model Danhmuc
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public string DonViTinh { get; set; }
        public decimal ThanhTien { get; set; }

        public DateTime NgayNhap { get; set; }
        
    }
}