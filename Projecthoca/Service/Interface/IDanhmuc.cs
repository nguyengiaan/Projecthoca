using Projecthoca.Models.EnitityVM;

namespace Projecthoca.Service.Interface
{
    public interface IDanhmuc
    {
        public Task<Boolean> Themdanhmuc(DanhmucVM danhmuc);

        public Task<(List<DanhmucVM> ds, int totalpages)> Danhsachdanhmuc(int page, int pagesize);

        public Task<Boolean> Xoadanhmuc(string madanhmuc);

        public Task<Boolean> Suadanhmuc(DanhmucVM danhmuc);

        public Task<DanhmucVM> Laytheomadm(string madanhmuc);

    

    }
}
