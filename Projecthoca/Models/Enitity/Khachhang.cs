namespace Projecthoca.Models.Enitity
{
    public class Khachhang
    {
        public string Ma_khachhang { get; set; }

        public string Ten_khachhang { get; set; }

        public string Sodienthoai { get; set; }

        public string Diachi { get; set; }

        public DateTime Ngaysinh { get; set; }

        public string Id { get; set; }

        public ApplicationUser Nguoidung { get; set; }

    }
}
