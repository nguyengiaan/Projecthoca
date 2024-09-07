using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecthoca.Models.EnitityVM
{
   public class PhieuNhapVM
    {
        public string SoPhieu { get; set; }
        public DateTime NgayPhieu { get; set; }
        public string TenKhachhang { get; set; } // Tên khách hàng lấy từ model Khachhang
        public string TenNVKD { get; set; } // Tên nhân viên lấy từ model NhanVien
        public decimal TongTien { get; set; }
        public decimal NoCu { get; set; }
        public decimal ThanhToan { get; set; }
        public decimal ConLai { get; set; }
        public DateTime? HanThanhToan { get; set; }
        public string GhiChu { get; set; }

        // List of ChiTietPhieuNhapVM
        public List<ChiTietPhieuNhapVM> ChiTietPhieuNhaps { get; set; }
    }
}