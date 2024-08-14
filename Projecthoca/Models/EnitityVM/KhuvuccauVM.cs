using System.ComponentModel.DataAnnotations;

namespace Projecthoca.Models.EnitityVM
{
    public class KhuvuccauVM
    {
        public string?Ma_Khuvuccau { get; set; }
        [Required(ErrorMessage = "Tên khu vực cấu không được để trống")]
        public string Ten_Khuvuccau { get; set; }
        [Required(ErrorMessage = "Trạng thái cấu không được để trống")]
        public string Trangthai { get; set; }
        public TimeSpan? Timeout { get; set; }
        public string?Ma_hoca { get; set; }
        public string?Idkhuvuccau { get; set; }
    }
}
