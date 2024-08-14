using System.ComponentModel.DataAnnotations;

namespace Projecthoca.Models.EnitityVM
{
    public class GiahocaVM
    {

        public int?Ma_giahoca { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Ca")]
        public int Ca { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giá không có cá")]
        public int Gia_khongca { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giá có cá")]
        public int Gia_coca { get; set; }

        public string?Id { get; set; }
    }
}
