using Projecthoca.Models.Enitity;

namespace Projecthoca.Models.EnitityVM
{
    public class Hoadonxuatban
    {
        public int Ma_hoadonxuatban { get; set; }
        public int Soluong { get; set; }
        public string Ma_danhmuc { get; set; }
        public Danhmuc Danhmuc { get; set; }
        public string Ma_phieuxuatkho { get; set; }
        public Phieuxuatkho Phieuxuatkho { get; set; }
    }
}
