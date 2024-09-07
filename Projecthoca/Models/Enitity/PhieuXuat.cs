using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecthoca.Models.Enitity
{
    public class PhieuXuat
    {
    public string SoPhieu { get; set; } // Primary Key
    public DateTime NgayPhieu { get; set; }
    public string Khachhang { get; set; } 
    public string NhanVien { get; set; }
    public decimal TongTien { get; set; }
    public decimal NoCu { get; set; }
    public decimal ThanhToan { get; set; }
    public decimal ConLai { get; set; }
    public DateTime? HanThanhToan { get; set; }
    public string GhiChu { get; set; }

    // Navigation property for ChiTietPhieuNhap
    public ICollection<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
    }
}