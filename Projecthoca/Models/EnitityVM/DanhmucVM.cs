using System.ComponentModel.DataAnnotations;

namespace Projecthoca.Models.EnitityVM
{
    public class DanhmucVM
    {
        public string? Ma_danhmuc { get; set; }
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        public string Ten_danhmuc { get; set; }
        [Required(ErrorMessage = "Giá không được để trống")]
        public int Gia { get; set; }
        [Required(ErrorMessage = "Đơn vị tính không được để trống")]
        public string Donvitinh { get; set; }

        [Required(ErrorMessage = "Mặt hàng không được để trống")]
        public string Ma_mathang { get; set; }

        public string? Id { get; set; }

        public int Soluong { get; set; }
       
    
        public string Nhacungcap { get; set; }
        public int Gianhap { get; set; }
      
    }
       
        
}
