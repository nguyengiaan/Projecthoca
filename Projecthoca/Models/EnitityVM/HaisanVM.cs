using System.ComponentModel.DataAnnotations;

namespace Projecthoca.Models.EnitityVM
{
    public class HaisanVM
    {
        public int? Ma_haisan { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên hải sản")]
        public string Ten_haisan { get; set; }
        public int sokg { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giá")]
        public int Gia { get; set; }
    }
}
