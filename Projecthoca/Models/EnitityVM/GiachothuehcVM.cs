using System.ComponentModel.DataAnnotations;

namespace Projecthoca.Models.EnitityVM
{
    public class GiachothuehcVM
    {
        public int ?Ma_giachothuehc { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn Ca")]
        public int Ma_giahoca { get; set; }
        public string ?Ma_thuehoca { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số lượng")]

        public int Soluong { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn trạng thái")]
        public string Trangthai { get; set; }

        public int ?Thanhtien { get; set; }

        public int ?Ca { get;set; }

        public int Giaca { get; set; }
    }
}
