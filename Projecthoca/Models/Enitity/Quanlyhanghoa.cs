using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Projecthoca.Models.Enitity
{
    public class Quanlyhanghoa
    {
        public string Ma_sanpham { get; set; }
        public string Ten_sanpham { get; set; }
        public string Ten_donvitinh { get; set; }

        
        public int Giaban { get; set; }
        public int GiaNhap { get; set; }
        public int Soluong { get; set; }

        [ForeignKey("nguoidung")]
        public string Id { get; set; }
        
        public virtual ApplicationUser Nguoidung { get; set; }


    }
}

