using System.ComponentModel.DataAnnotations;

namespace Projecthoca.Models.EnitityVM
{
    public class ThuehocaVM
    {
        public string?Ma_thuehoca { get; set; }
        public string? Ma_khuvuccau { get; set; }
        [Required(ErrorMessage = "Tên khách hàng không được để trống")]
        public string Ten_khachhang { get; set; }

        [Required(ErrorMessage = "Ngày cầu không được để trống")]
        public string Ngaycau { get; set; }
        [Required(ErrorMessage = "Thời gian bắt đầu không được để trống")]
        public TimeSpan Thoigianbatdau { get; set; }
        public TimeSpan? Timeout { get; set; }

        public string? Ten_Khuvuccau { get; set; }

    }

}
