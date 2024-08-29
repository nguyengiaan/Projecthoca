using Projecthoca.Models.EnitityVM;

namespace Projecthoca.Service.Interface
{
    public interface IKhuvuccau
    {
        public Task<bool> Themkhuvuccau(KhuvuccauVM khuvuccau);
        public Task<List<KhuvuccauVM>> Danhsachkhuvuccau(string Ma_hocau);
        public Task<bool> Themkhachthue(ThuehocaVM thc);
        public Task<bool> Kiemtrakv(string Ma_khuvuc);
        public Task<TimeSpan> Laythoigian(string Ma_khuvuc);
        public Task<bool> CapnhatTg(string Ma_khuvuc, TimeSpan time);
        public Task<bool> Demthoigian(string Ma_khuvuc);
        public Task<bool> UpdateBamgio(string Ma_khuvuc);
        public Task<bool> KiemtraBamgio(string Ma_khuvuc);
        public Task<bool> Danhsachbamgio();
        public Task<bool> Dadungtg(string Ma_khuvuc);
        public Task<bool> Deletekvc(string Ma_khuvuc);
        public Task<bool> Xoakhachthue(string Ma_khuvuc);
        public Task<ThuehocaVM> Laykhachthue(string Ma_khuvuc);
        public Task<bool> Chuyenkhachthue(ChuyenbanVM chuyenban);
        // danh mục hiển thị trong hóa đơn
        public Task<List<DanhmucVM>> Danhmuchthd(string? Ma_mathang);

        // mặt hàng hiển thị trong hóa đơn thẻ select
        public Task<List<MathangVM>> Mathanghthd();
        public Task<List<KhuvuccauVM>> Danhsachkhuvucvang(string Ma_hocau);
    }

}
