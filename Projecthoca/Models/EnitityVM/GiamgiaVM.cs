using System.ComponentModel.DataAnnotations;

namespace Projecthoca.Models.EnitityVM
{
    public class GiamgiaVM
    {
        [Required(ErrorMessage = "Vui lòng nhập mã giảm giá")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giảm giá phải lớn hơn 0")]
        public float Giamgia { get; set; }
        public string Ma_khuvuc { get; set; }
    }
}
