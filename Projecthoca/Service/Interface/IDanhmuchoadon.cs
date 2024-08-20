using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;

namespace Projecthoca.Service.Interface
{
    public interface IDanhmuchoadon
    {
        public Task<bool> Themdanhmuchoadon(DanhmuchoadonVM danhmuchoadon);
        public Task<List<DanhmucVM>> Danhsachdanhmucdv();

        public Task<List<DanhmuchoadonVM>> Dsdmhd(string Ma_thuehoca);

        public Task<bool> Xoadichvu(int Ma_danhmuc);

        public Task<bool> Themthoigian(GiachothuehcVM giachothuehc);

        public Task<List<GiahocaVM>> Danhsachgiahoca();

        public Task<List<GiachothuehcVM>> Danhsachthoigian(string KhuvucId);
        public Task<bool> Xoathoigian(int Ma_giachothuehc);
        public Task<(bool, int)> Tongthanhtoan(string KhuvucId);
        public Task<HoadondanhmucVM> Laytongthangtoan(string KhuvucId);

        public Task<bool> Giamgia(GiamgiaVM giamgia);
        // thêm danh mục hóa đơn theo list danh mục trong hóa đơn
        public Task<bool> Themdanhmuchoadonlst(DanhmuchdVM danhmuchoadon);
        // Cập nhật số lượng giá tiền danh mục hàng hóa
        public Task<bool> Capnhatgiatien(int danhmuchanghoa,int soluong);

    }
}
