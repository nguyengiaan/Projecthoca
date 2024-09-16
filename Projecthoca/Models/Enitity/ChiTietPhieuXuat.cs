using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecthoca.Models.Enitity
{
    public class ChiTietPhieuXuat
    {
    public int Id { get; set; } // Primary Key
    public string SoPhieu { get; set; } // Foreign Key
    public PhieuXuat PhieuXuat { get; set; } // Liên kết đến Phiếu Xuất
    public string Ma_sanpham { get; set; } // Foreign Key từ bảng Quanlyhanghoa
    public Danhmuc Danhmuc { get; set; } // Liên kết đến bảng quản lý hàng hóa
    public int SoLuong { get; set; }
    public decimal DonGia { get; set; }
    public string DonViTinh { get; set; }
    public decimal ThanhTien { get; set; }

    public DateTime Ngayxuat { get; set; }

        internal int Sum(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}