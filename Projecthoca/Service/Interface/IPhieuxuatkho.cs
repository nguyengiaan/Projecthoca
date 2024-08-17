using Projecthoca.Models.EnitityVM;

namespace Projecthoca.Service.Interface
{
    public interface IPhieuxuatkho
    {
        public Task<bool> Themphieuxuatkho(PhieuxuatkhoVM phieuxuatkho);

        public Task<(List<PhieuxuatkhoVM> ds, int totalpages)> Danhsachphieu(int page, int pagesize);

        public Task<bool> Xoaphieuxuat(string Ma_phieuxuatkho);

    }
}
