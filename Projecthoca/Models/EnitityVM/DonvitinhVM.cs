using System.ComponentModel.DataAnnotations;

namespace Projecthoca.Models.EnitityVM
{
    public class DonvitinhVM
    {
        public string ?Ma_donvitinh { get; set; }
        [Required(ErrorMessage = "Tên đơn vị tính không được để trống")]

        public string Ten_donvitinh { get; set; }

        public string ?Id { get; set; }

    }
}
