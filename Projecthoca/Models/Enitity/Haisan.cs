using Projecthoca.Models.Enitity;

namespace Projecthoca.Models.Entity
{
    public class Haisan
    {
        public int Ma_haisan { get; set; }
        public string Ten_haisan { get; set; }
        public int sokg { get; set; }
        public int Gia { get; set; }
        public string Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public List<Chitietlancau> Chitietlancaus { get; set; }
        public Haisan()
        {
            Chitietlancaus = new List<Chitietlancau>();
        }
    }
}