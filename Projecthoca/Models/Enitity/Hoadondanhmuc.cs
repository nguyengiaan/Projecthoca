namespace Projecthoca.Models.Enitity
{
    public class Hoadondanhmuc
    {
        public string Ma_hddm { get; set; }
        public int Tongthanhtoan { get; set; }
        public string Ma_thuehoca { get; set; }
        public int Giachothue { get; set; }
        public Thuehoca Thuehoca { get; set; }
        public List<Danhmuchoadon> Danhmuchoadons { get; set; }
        public Hoadondanhmuc() 
        {
            Danhmuchoadons = new List<Danhmuchoadon>();  
        }
    }
}
