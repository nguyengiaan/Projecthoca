﻿namespace Projecthoca.Models.Enitity
{
    public class Phieuxuatkho
    {
        public string Ma_phieuxuatkho { get; set; }

        public string Ten_khuvuc { get; set; }
        public DateTime Ngayxuat { get; set; }

        public int Thanhtien { get; set; }

        public int giamgia{ get; set; }
        public int Tienmat { get; set; }

        public int Chuyenkhoan { get; set; }

        public int Tongtien { get; set; }

        public string Id { get; set; }
        public ApplicationUser Nguoidung { get; set; }

    }
}
