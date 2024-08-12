namespace Projecthoca.Models.Enitity
{
    public class Danhmuchoadon
    {
        public int Ma_danhmuchoadon { get; set; }
        public int Gia { get; set; }
        public string Soluong { get; set; }
        public string DVT { get; set; }
        public string Ma_hddm { get; set; }
        public string Ma_danhmuc { get; set; }

        public Danhmuc Danhmuc { get; set; }
        public Hoadondanhmuc Hoadondanhmuc { get; set; }


    }
}

