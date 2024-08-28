using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;

namespace Projecthoca.Service.Interface
{
    public interface IBanle
    {
        public Task<(bool kq,string ma_kvc, string ma_thc, string ten_kh,string ngay_mua)> Themkhachhang(ThuehocaVM thuehoca);
    }
}
