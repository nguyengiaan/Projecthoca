using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecthoca.Models.Enitity
{
   public class NhanVien
{
    public string MaNVKD { get; set; } // Primary Key
    public string TenNhanVien { get; set; }

    // Navigation property for PhieuNhap
    public ICollection<PhieuNhap> PhieuNhaps { get; set; }
}

}