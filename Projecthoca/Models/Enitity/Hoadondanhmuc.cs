namespace Projecthoca.Models.Enitity
{
    public class Hoadondanhmuc
    {
        public string Ma_hddm { get; set; }
        public int Tongthanhtoan { get; set; }
        public string Ma_thuehoca { get; set; }
        public Thuehoca Thuehoca { get; set; }
    }
}
