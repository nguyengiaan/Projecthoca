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
        public int TongTien { get; set; }
        public int NoCu { get; set; }
        public int ThanhToan { get; set; }
        public int ConLai { get; set; }
        public DateTime? HanThanhToan { get; set; }
        public string GhiChu { get; set; }

        // List of ChiTietPhieuNhapVM
        public List<ChiTietPhieuNhapVM> ChiTietPhieuNhaps { get; set; }
    }
}