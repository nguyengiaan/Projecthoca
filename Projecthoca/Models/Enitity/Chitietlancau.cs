using Projecthoca.Models.Entity;

namespace Projecthoca.Models.Enitity
{
    public class Chitietlancau
    {
        public Chitietlancau() { }
        public string Ma_chitietlancau { get; set; }
        public TimeSpan giocau { get; set; }
        public float sokg { get; set; }
        public int Ma_haisan { get; set; }
        public float Thanhtien { get; set; }
        public string Ma_thuehoca { get; set; }
        public Thuehoca Thuehoca { get; set; }
        public Haisan Haisan { get; set; }    
    }
}
