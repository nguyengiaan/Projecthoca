using Projecthoca.Models.EnitityVM;

namespace Projecthoca.Service.Interface
{
    public interface IGiahoca
    {
        public Task<Boolean> Themgiahoca(GiahocaVM giahoca);

        public Task<(List<GiahocaVM> ds, int totalpages)> Danhsachhoca(int page, int pagesize);

        public Task<Boolean>Xoagia(int Ma_giahoca);

        public Task<GiahocaVM> Laytheomagia(int Ma_giahoca);

        public Task<Boolean> Capnhatgia(GiahocaVM giahoca);
    }
}
