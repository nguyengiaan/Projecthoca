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

        public Task<List<DonvitinhVM>> Laydanhsachdvt();
       

        public Task<bool> Xoadonvitinh(string madonvitinh);

        // hàm dùng để cài đặt mặt hàng
        public Task<bool> Themmathang(MathangVM mathang);

        //Hàm dùng để lấy tất cả mặt hàng
        public Task<List<MathangVM>> Laydanhsachmh();
        // hàm xóa mặt hàng
        public Task<bool> Xoamathang(string mamathang);
        // cập nhật số lượng hàng hóa
        public Task<bool> Capnhatsoluong(string ma_khuvuc);

        // hàm dùng để lấy tất cả danh mục trong phiếu nhập
        public Task<List<DanhmucVM>> Laydanhsachdanhmuc();
        public Task<List<NhacungcapVM>> Danhsachnhacungcap();
        public Task<bool> Themnhacungcap(NhacungcapVM nhacungcap);
        public Task<bool> Xoanhacungcap(string ma_nhacungcap);
    }
}
