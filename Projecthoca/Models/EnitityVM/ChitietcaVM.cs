﻿using System.ComponentModel.DataAnnotations;

namespace Projecthoca.Models.EnitityVM
{
    public class ChitietcaVM
    {
        public string ?Ma_chitietlancau { get; set; }
        [Required(ErrorMessage ="Hãy thêm giờ câu")]
        public TimeSpan giocau { get; set; }
        [Required(ErrorMessage = "Hãy thêm số kg")]

        public float sokg { get; set; }
        public float ?Thanhtien { get; set; }
        public int ?Ma_haisan { get; set; }
        public string ?Ten_haisan { get; set; }  
        public string ?Ma_thuehoca { get; set; }
    }
}
