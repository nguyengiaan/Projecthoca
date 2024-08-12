namespace Projecthoca.Models.Enitity
{
    public class Danhmucgia
    {

        public string Ma_danhmucgia { get; set; }
        public string Tieude { get; set; }
        public string Ca { get; set; }

        public string Id { get; set; }
        public ApplicationUser Nguoidung { get; set; }  

        public List<Giachothue> Giachothues { get; set; }

        public Danhmucgia()
        {
            Giachothues = new List<Giachothue>();
        }
    }
}
