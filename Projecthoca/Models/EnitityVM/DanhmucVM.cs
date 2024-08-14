using System.ComponentModel.DataAnnotations;

namespace Projecthoca.Models.EnitityVM
{
    public class DanhmucVM
    {
        public string?Ma_danhmuc { get; set; }
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        public string Ten_danhmuc { get; set; }
        [Required(ErrorMessage = "Giá không được để trống")]
        public int Gia { get; set; }
        [Required(ErrorMessage = "Đơn vị tính không được để trống")]
        public string Donvitinh { get; set; }
        [Required(ErrorMessage = "Số lượng không được để trống")]
        public int soluong { get; set; }

        [Required(ErrorMessage = "Miêu tả không được để trống")]
        public string Mieuta { get; set; }

        public string ?Id { get; set; }
    }
}
