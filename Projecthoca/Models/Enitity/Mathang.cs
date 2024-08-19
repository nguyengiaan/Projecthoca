namespace Projecthoca.Models.Enitity
{
    public class Mathang
    {
        public string Ma_mathang { get; set; }
        public string Ten_mathang { get; set; }
        public string Id { get; set; }
        public ApplicationUser Nguoidung { get; set; }
        public List<Danhmuc> Danhmucs { get; set; }
        public Mathang ()
        {
            Danhmucs=new List<Danhmuc>();
        }
    }
}
