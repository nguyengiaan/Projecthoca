using System.ComponentModel.DataAnnotations;

namespace Projecthoca.Models.EnitityVM
{
    public class DangnhapVM
    {
        [Required(ErrorMessage = "Tài khoản không được để trống")]
        public string Taikhoan { get; set; }
        [Required(ErrorMessage = "Mật khẩu  không được để trống")]
        public string Matkhau { get; set; }
    }
}
