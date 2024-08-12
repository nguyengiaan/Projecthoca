namespace Projecthoca.Models.Enitity
{
    public class Hoca
    {
        public string Ma_hoca { get; set; }
        public string Ten_hoca { get; set; }
        public string Kieuhoca { get; set; } 
        public string Id { get; set; }
        public ApplicationUser Nguoidung { get; set; }
        public List<Khuvuccau> Khuvuccaus { get; set; }
    }
}
