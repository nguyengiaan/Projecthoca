namespace Projecthoca.Models.Enitity
{
    public class Giahoca
    {
        public int Ma_giahoca { get; set; }
        public int Ca { get; set; }
        public int Gia_khongca { get; set; }
        public int Gia_coca { get; set; }
        public string Id { get; set; }
        public ApplicationUser Nguoidung { get; set; }
        public List<Giachothuehc> Giachothuehcs { get; set; }
        public Giahoca()
        {
            Giachothuehcs = new List<Giachothuehc>();
        }
    }
}
