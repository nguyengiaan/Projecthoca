using Microsoft.AspNetCore.Identity;

namespace Projecthoca.Models.Enitity
{
    public class ApplicationUser : IdentityUser
    {
        public string Ma_user { get; set; }
        public string Hovaten { get; set; }
        public DateTime Ngaysinh { get; set;}
        public string Diachi { get; set;}

        public string ?IdCustomer { get; set; }
        public List<Hoca> Hoccas { get; set;}

        public List<Danhmuc> Danhmucs { get; set; }

        public List<Danhmucgia> Danhmucgias { get; set; }

        public List<Giahoca> Giahocas { get; set; }

        public List<Thongbao> Thongbaos { get; set; }

        public List<Phieuxuatkho> phieuxuatkhos { get; set; }

        public List<Phieunhapkho> phieunhapkhos { get; set; }

        public List<Quanlyhanghoa> Quanlyhanghoas { get; set; }
         public List<Nhacungcaps> Nhacungcaps { get; set; }
 
        public List<Donvitinh> Donvitinhs { get; set; }
        public List<Mathang> Mathangs { get; set; }

        public List<Khachhang> Khachhangs { get; set; }

        public List<PhieuNhap>PhieuNhaps {get;set;}

        public List<PhieuXuat>PhieuXuats {get;set;}
        public ApplicationUser()
        {
            Hoccas = new List<Hoca>();
            Danhmucs = new List<Danhmuc>();
            Danhmucgias = new List<Danhmucgia>();
            Giahocas = new List<Giahoca>();
            Thongbaos = new List<Thongbao>();
            phieuxuatkhos = new List<Phieuxuatkho>();
            phieunhapkhos = new List<Phieunhapkho>();
            Donvitinhs = new List<Donvitinh>();
            Mathangs = new List<Mathang>();
            Quanlyhanghoas = new List<Quanlyhanghoa>();
            Nhacungcaps = new List<Nhacungcaps>();
            Khachhangs= new List<Khachhang>();
            PhieuNhaps=new List<PhieuNhap>();
            PhieuXuats=new List<PhieuXuat>();

        }
    }
}
