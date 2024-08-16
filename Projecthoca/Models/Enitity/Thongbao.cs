namespace Projecthoca.Models.Enitity
{
    public class Thongbao
    {
        public int Ma_thongbao { get; set; }
        public string NoiDung { get; set; }
        public string NgayDang { get; set; }
        public bool Trangthai { get; set; }
        public string Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
