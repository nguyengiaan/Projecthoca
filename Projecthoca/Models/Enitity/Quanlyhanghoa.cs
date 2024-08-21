using System.ComponentModel.DataAnnotations;

namespace Projecthoca.Models.Enitity
{
    public class Quanlyhanghoa
    {
        public string Ma_sanpham { get; set; }
        public string Ten_sanpham { get; set; }
        public string Ten_donvitinh { get; set; }
        public string Id { get; set; }
        public int Giaban { get; set; }
        public ApplicationUser Nguoidung { get; set; }

    }
}

