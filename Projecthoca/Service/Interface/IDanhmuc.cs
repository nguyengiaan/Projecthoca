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
        // hàm dùng để cài đặt đơn vị tính
        public Task<bool> Themdonvitinh(DonvitinhVM donvitinh);

        public Task <List<DonvitinhVM>> Laydanhsachdvt() ;

        // hàm dùng để cài đặt mặt hàng
        public Task<bool> Themmathang(MathangVM mathang);

        //Hàm dùng để lấy tất cả mặt hàng
        public Task<List<MathangVM>> Laydanhsachmh();
    }
}
