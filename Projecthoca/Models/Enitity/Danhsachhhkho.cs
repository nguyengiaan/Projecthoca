namespace Projecthoca.Models.Enitity
{
    public class Danhsachhhkho
    {
        public int Ma_hanghoa { get; set; }
        public string Ma_danhmuc { get; set; }
        public string Ma_phieunhapkho { get; set; }
        public int Soluong { get; set; }
        public int Thanhtien { get; set; }
        public Danhmuc Danhmuc { get; set; }
        public Phieunhapkho Phieunhapkho { get; set; }
    }
}