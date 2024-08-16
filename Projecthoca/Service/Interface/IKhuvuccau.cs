using Projecthoca.Models.EnitityVM;

namespace Projecthoca.Service.Interface
{
    public interface IKhuvuccau
    {
        public Task<Boolean> Themkhuvuccau(KhuvuccauVM khuvuccau);
        public Task<List<KhuvuccauVM>> Danhsachkhuvuccau(string Ma_hocau);
        public Task<Boolean> Themkhachthue(ThuehocaVM thc);
        public Task<Boolean> Kiemtrakv(string Ma_khuvuc);
        public Task<TimeSpan> Laythoigian(string Ma_khuvuc);
        public Task<Boolean> CapnhatTg(string Ma_khuvuc,TimeSpan time);
        public Task<Boolean> Demthoigian(string Ma_khuvuc);
        public Task<Boolean> UpdateBamgio(string Ma_khuvuc);
        public Task<Boolean > KiemtraBamgio(string Ma_khuvuc);
        public Task<List<BamgioVM>> Danhsachbamgio();
        public Task<Boolean>Dadungtg(string Ma_khuvuc);
        public Task<Boolean> Deletekvc(string Ma_khuvuc);
        public Task<Boolean> Xoakhachthue(string Ma_khuvuc);
        public Task<ThuehocaVM>Laykhachthue(string Ma_khuvuc);

    }

}
