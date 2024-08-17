using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;

namespace Projecthoca.Service.Interface
{
    public interface IDanhmuchoadon
    {
        public Task<Boolean> Themdanhmuchoadon(DanhmuchoadonVM danhmuchoadon);
        public Task<List<DanhmucVM>> Danhsachdanhmucdv();

        public  Task<List<DanhmuchoadonVM>> Dsdmhd(string Ma_thuehoca);

        public Task<Boolean> Xoadichvu(int Ma_danhmuc);

        public Task<Boolean> Themthoigian(GiachothuehcVM giachothuehc);

        public Task<List<GiahocaVM>> Danhsachgiahoca();

        public Task<List<GiachothuehcVM>> Danhsachthoigian(string KhuvucId);
        public Task<Boolean> Xoathoigian(int Ma_giachothuehc);
        public Task<(Boolean,int)> Tongthanhtoan(string KhuvucId);
        public Task<HoadondanhmucVM>Laytongthangtoan(string KhuvucId);

        public Task<Boolean> Giamgia(GiamgiaVM giamgia );
    }
}
