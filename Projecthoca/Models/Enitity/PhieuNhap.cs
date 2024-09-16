using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projecthoca.Models.Enitity
{
    public class PhieuNhap
{
    public string SoPhieu { get; set; } // Primary Key
    public DateTime NgayPhieu { get; set; }
    public string Khachhang { get; set; } 
    public string NhanVien { get; set; }
    public int TongTien { get; set; }
    public int NoCu { get; set; }
    public int ThanhToan { get; set; }
    public int ConLai { get; set; }
    public DateTime? HanThanhToan { get; set; }
    public string GhiChu { get; set; }

    [ForeignKey("nguoidung")]
    public string Id { get; set; }

    public virtual ApplicationUser nguoidung { get; set; }
    // Navigation property for ChiTietPhieuNhap
    public ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
}

}