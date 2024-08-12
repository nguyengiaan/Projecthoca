namespace Projecthoca.Models.Enitity
{
    public class Danhmuc
    {
        public string Ma_danhmuc { get; set; }
        public string Ten_danhmuc { get; set; }
        public int Gia { get; set; }
        public string Donvitinh { get; set; }
        public int soluong { get; set; }

        public string Id { get; set; }

        public ApplicationUser Nguoidung { get; set; }

        public List<Danhmuchoadon> Danhmuchoadons { get; set; }

      
    }
}
