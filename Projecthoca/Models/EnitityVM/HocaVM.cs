using System.ComponentModel.DataAnnotations;

namespace Projecthoca.Models.EnitityVM
{
    public class HocaVM
    {

        [Required(ErrorMessage = "tên hồ cá không được để trống")]
        public string Ten_hoca { get; set; }
        [Required(ErrorMessage = "kiểu hồ cá không được để trống")]
        public string Kieuhoca { get; set; }
        public string ?Id { get; set; }

        public string ? Ma_hoca { get; set; }
    }
}
