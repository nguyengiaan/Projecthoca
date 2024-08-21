using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projecthoca.Models.Enitity
{
    public class Quanlyhanghoa
    {
        [Key]
        public string Ma_sanpham { get; set; }

        [Required]
        public string Ten_sanpham { get; set; }

        [Required]
        public string Ten_donvitinh { get; set; }

        [Required]
        public string Id { get; set; }
        public ApplicationUser Nguoidung { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Giaban { get; set; }
    }

}