using Projecthoca.Models.EnitityVM;


namespace Projecthoca.Service.Interface
{
    public interface IHaisan
    {
        public Task<Boolean>Themhaisan(HaisanVM haisan);
        public Task<Boolean> Suahaisan(HaisanVM haisan);
        public Task<Boolean> Xoahaisan(int Ma_haisan);

        public Task<(List<HaisanVM> ds,int totalPages)> Danhsachhaisan(int page, int pagesize);

        public Task<HaisanVM> Laythongtinhaisan(int Ma_haisan);

        
     
    }
}