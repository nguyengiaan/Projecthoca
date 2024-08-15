using Projecthoca.Models.EnitityVM;

namespace Projecthoca.Service.Interface
{
    public interface IDanhmuchoadon
    {
        public Task<Boolean> Themdanhmuchoadon(DanhmuchoadonVM danhmuchoadon);
        public Task<List<DanhmucVM>> Danhsachdanhmucdv();

        public  Task<List<DanhmuchoadonVM>> Dsdmhd(string Ma_thuehoca);
    }
}
