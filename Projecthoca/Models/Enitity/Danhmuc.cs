using Projecthoca.Models.EnitityVM;

namespace Projecthoca.Models.Enitity
{
    public class Danhmuc
    {
        public string Ma_danhmuc { get; set; }
        public string Ten_danhmuc { get; set; }
        public int Gia { get; set; }
        public string Donvitinh { get; set; }

         public string Nhacungcap { get; set; }
         public int Gianhap { get; set; }
        public string Id { get; set; }
        public string Ma_mathang { get; set; }

        public int Soluong { get; set; }
        public ApplicationUser Nguoidung { get; set; }
        public Mathang Mathang { get; set; }
        public List<Danhmuchoadon> Danhmuchoadons { get; set; }
        public List<Chitietlancau> Chitietlancaus { get; set; }

        public List<Danhsachhhkho> Danhsachhhkhos { get; set; }

        public List<Hoadonxuatban> Hoadonxuatbans { get; set; }

        public ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public ICollection<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
        public Danhmuc()
        {
            Danhmuchoadons = new List<Danhmuchoadon>();
            Danhsachhhkhos = new List<Danhsachhhkho>();
            Hoadonxuatbans = new List<Hoadonxuatban>();
           
        }
    }
}
