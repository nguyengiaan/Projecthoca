namespace Projecthoca.Models.Enitity
{
    public class Phieunhapkho
    {
        public string Ma_phieunhapkho { get; set; }
        public DateTime Ngaynhap { get; set; }
        public string Nguoinhap { get; set; }
        public string Id { get; set; }
        public ApplicationUser Nguoidung { get; set; }
        
        public List<Danhsachhhkho> Danhsachhhkhos { get; set; }
        public Phieunhapkho()
        {
            Danhsachhhkhos = new List<Danhsachhhkho>();
        }

    }
}
