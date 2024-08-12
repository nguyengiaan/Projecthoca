namespace Projecthoca.Models.Enitity
{
    public class Giachothue
    {
        public int Ma_giachothue { get; set; }
        public int  Gia { get; set; }

        public string Ma_danhmucgia { get; set; }

        public Danhmucgia Danhmucgia { get; set; }
    }
}
