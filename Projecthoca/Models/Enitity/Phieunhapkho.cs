namespace Projecthoca.Models.Enitity
{
    public class Phieunhapkho
    {
        public int Ma_phieunhapkho { get; set; }
        public DateTime Ngaynhap { get; set; }
        public string Nguoinhap { get; set; }
        public string Ten_danhmuc { get; set; }
        public string Tenkho { get; set; }
        public string Diadiem { get; set; }
        public string Donvitinh { get; set; }
        public int Soluong { get; set; }
        public int Dongia { get; set; }
        public int Thanhtien { get; set; }
        public string Id { get; set; }
        public ApplicationUser Nguoidung { get; set; }


    }
}
