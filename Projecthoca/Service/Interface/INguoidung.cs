using Projecthoca.Models.EnitityVM;

namespace Projecthoca.Service.Interface
{
    public interface INguoidung
    {
        public Task<Status> Dangkynguoidung(NguoidungVM Nguoidung);
        public Task<(List<NguoidungVM> ds, int totalpages)> Laydanhsachnguoidung(int page, int pagesize);

        public Task<Status> Dangnhap(DangnhapVM user);

        public Task LogoutAsync();
    }
}
