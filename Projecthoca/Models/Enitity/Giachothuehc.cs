namespace Projecthoca.Models.Enitity
{
    public class Giachothuehc
    {
        public int Ma_giachothuehc { get; set; }
        public int Ma_giahoca { get; set; }

        public string Ma_thuehoca { get; set; }

        public int Soluong { get; set; }

        public int Thanhtien { get; set; }

        public string Trangthai { get; set; }
        public Thuehoca Thuehoca { get; set; }
        public Giahoca Giahoca { get; set; }

    }
}
