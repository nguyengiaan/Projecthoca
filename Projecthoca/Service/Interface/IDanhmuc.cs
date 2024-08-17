using Projecthoca.Models.EnitityVM;

namespace Projecthoca.Service.Interface
{
    public interface IDanhmuc
    {
        public Task<bool> Themdanhmuc(DanhmucVM danhmuc);

        public Task<(List<DanhmucVM> ds, int totalpages)> Danhsachdanhmuc(int page, int pagesize);

        public Task<bool> Xoadanhmuc(string madanhmuc);

        public Task<bool> Suadanhmuc(DanhmucVM danhmuc);

        public Task<DanhmucVM> Laytheomadm(string madanhmuc);



    }
}
