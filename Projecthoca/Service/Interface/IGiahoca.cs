using Projecthoca.Models.EnitityVM;

namespace Projecthoca.Service.Interface
{
    public interface IGiahoca
    {
        public Task<bool> Themgiahoca(GiahocaVM giahoca);

        public Task<(List<GiahocaVM> ds, int totalpages)> Danhsachhoca(int page, int pagesize);

        public Task<bool> Xoagia(int Ma_giahoca);

        public Task<GiahocaVM> Laytheomagia(int Ma_giahoca);

        public Task<bool> Capnhatgia(GiahocaVM giahoca);
    }
}
