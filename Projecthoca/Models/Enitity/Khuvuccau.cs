namespace Projecthoca.Models.Enitity
{
    public class Khuvuccau
    {
        public string Ma_Khuvuccau { get; set; }
        public string Ten_Khuvuccau { get; set; }
        public string Trangthai { get; set; }

        public string Ma_hoca { get; set; }
        public string Idkhuvuccau { get; set; }
        public Hoca Hoca { get; set; }
        public List<Thuehoca> Thuehocas { get; set; }
    }
}
