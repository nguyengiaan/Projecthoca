
using Projecthoca.Models.EnitityVM;

namespace Projecthoca.Service.Interface
{
    public interface IKhachhang
    {
        public Task<Boolean> Themkhachhang(KhachhangVM khachhang);

        public Task<Boolean> Suakhachhang(KhachhangVM khachhang);

        public Task<Boolean> Xoakhachhang(string ma_khachhang);

        public Task<(List<KhachhangVM> ds,int totalpages)> Danhsachkh(int page, int pagesize);

        public Task<KhachhangVM> Laykhachhang(string ma_khachhang);

        public Task<Boolean> Capnhatkhachhang(KhachhangVM kh);

    }
}
