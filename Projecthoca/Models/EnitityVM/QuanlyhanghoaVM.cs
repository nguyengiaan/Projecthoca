using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Projecthoca.Models.EnitityVM
{
public class QuanlyhanghoaVM
    {
         [Required(ErrorMessage = "Mã sản phẩm là bắt buộc.")]
        public string Ma_sanpham { get; set; }
        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc.")]
        public string Ten_sanpham { get; set; }

        [Required(ErrorMessage = "Đơn vị tính là bắt buộc.")]
        public string Ten_donvitinh { get; set; }

        [Required(ErrorMessage = "Giá bán là bắt buộc.")]
        [Range(0, int.MaxValue, ErrorMessage = "Giá bán phải là một số nguyên dương.")]
        public int Giaban { get; set; }
    }
}