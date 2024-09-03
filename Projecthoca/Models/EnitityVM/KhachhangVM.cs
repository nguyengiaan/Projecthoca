using System.ComponentModel.DataAnnotations;

namespace Projecthoca.Models.EnitityVM
{
    public class KhachhangVM
    {
        public string? Ma_khachhang { get; set; }
        [Required(ErrorMessage ="Không được để trống tên khách hàng")]
        public string Ten_khachhang { get; set; }

        [Required(ErrorMessage = "Không được để trống số điện thoại")]
        public string Sodienthoai { get; set; }
        [Required(ErrorMessage = "Không được để trống địa chỉ")]
        public string Diachi { get; set; }
        [Required(ErrorMessage = "Không được để trống ngày sinh")]
        public DateTime Ngaysinh { get; set; }
    }
}
