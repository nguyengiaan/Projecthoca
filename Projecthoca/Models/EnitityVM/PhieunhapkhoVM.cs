using System.ComponentModel.DataAnnotations;

namespace Projecthoca.Models.EnitityVM
{
    public class PhieunhapkhoVM
    {
        public string ?Ma_phieunhapkho { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập ngày nhập")]
        public DateTime Ngaynhap { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập người nhập")]
        public string Nguoinhap { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên danh mục")]
        public string Ten_danhmuc { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên kho")]
        public string Tenkho { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa diểm")]
        public string Diadiem { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập đơn vị tính")]
        public string Donvitinh { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số lượng")]
        public int Soluong { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập đơn giá")]
        public int Dongia { get; set; }
        public int ?Thanhtien { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mặt hàng")]
        public string Ma_mathang { get; set; }


    }
}
