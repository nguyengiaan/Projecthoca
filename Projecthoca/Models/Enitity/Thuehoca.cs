namespace Projecthoca.Models.Enitity
{
    public class Thuehoca
    {
        public string Ma_thuehoca { get; set; }
        public string Ma_khuvuccau { get; set; }
        public string Ten_khachhang { get; set; }
        public string Ngaycau { get; set; }
        public TimeSpan Thoigianbatdau { get; set; }
        public TimeSpan?Thoigianketthuc { get; set; }
        public TimeSpan Timeout { get; set; }
        public string trangthai { get; set; }
        public List<Hoadondanhmuc> Hoadondanhmucs { get; set; }
        public Khuvuccau Khuvuccau { get; set; }
        public Thuehoca()
        {
            Hoadondanhmucs = new List<Hoadondanhmuc>();
        }
    }
}
