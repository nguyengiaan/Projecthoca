using Projecthoca.Models.EnitityVM;

namespace Projecthoca.Service.Interface
{
    public interface IThongbao
    {
        public Task<(List<ThongbaoVM> ds, int total)> danhsachtb();

        public Task<bool> docthongbao(int Ma_thongbao);



    }
}
