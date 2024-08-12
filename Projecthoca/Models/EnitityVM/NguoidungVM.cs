﻿using System.ComponentModel.DataAnnotations;

namespace Projecthoca.Models.EnitityVM
{
    public class NguoidungVM
    {
        public string? Id { get; set; }

        public string ? Ma_user { get; set; }   
        [Required(ErrorMessage = "Họ và tên không dược để trống")]
        public string hovaten { get; set; }
        [Required(ErrorMessage = "Tên đăng nhập không dược để trống")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password không dược để trống")]
        [StringLength(100, ErrorMessage = "Mật khẩu ít nhất 6 ký tự", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$", ErrorMessage = "Password phải ít nhất 1 chữ hoa,1 chữ thường,1 ký tự đặc biệt")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email không dược để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Quyền không dược để trống")]
        public string Role { get; set; }
        [Phone(ErrorMessage = "Số điện thoại không được để trống")]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "Địa chỉ không dược để trống")]

        public string diachi { get; set; }
        [Required(ErrorMessage = "Xác nhận mật khẩu không dược để trống")]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp")]

        public string xacnhanmatkhau { get; set; }
        [Required(ErrorMessage = "Ngày sinh không dược để trống")]
        public DateTime Ngaysinh { get; set; }
    }
}
