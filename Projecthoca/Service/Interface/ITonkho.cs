using Projecthoca.Models.EnitityVM;

namespace Projecthoca.Service.Interface
{
    public interface ITonkho
    {
      public   Task<(Dictionary<string, List<DailyInventory>> dailyInventories,int totalpages)> TinhTonKhoNhieuNgay(int page, int pagesize,int endDate);
    }
}
