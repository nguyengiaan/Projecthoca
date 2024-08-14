namespace Projecthoca.Models.Enitity
{
    public class Danhmuchoadon
    {
        public int Ma_danhmuchoadon { get; set; }
        public string Ma_thuehoca { get; set; }
        public int Soluong { get; set; }
        public string Ma_danhmuc { get; set; }
        public int thanhtien { get; set; }  
        public Danhmuc Danhmuc { get; set; }
        public Thuehoca Thuehoca { get; set; }

       

        

    }
}

