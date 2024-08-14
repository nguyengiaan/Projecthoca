namespace Projecthoca.Models.Enitity
{
    public class Chitietlancau
    {
        public Chitietlancau() { }
        public string Ma_chitietlancau { get; set; }
        public TimeSpan giocau { get; set; }
        public float sokg { get; set; }
        public string Ma_danhmuc { get; set; }
        public float Thanhtien { get; set; }
        public string Ma_thuehoca { get; set; }
        public Thuehoca Thuehoca { get; set; }
        public Danhmuc Danhmuc { get; set; }    
    }
}
