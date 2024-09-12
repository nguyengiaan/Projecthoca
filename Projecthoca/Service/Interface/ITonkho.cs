using Projecthoca.Models.EnitityVM;

namespace Projecthoca.Service.Interface
{
    public interface ITonkho
    {
      public   Task<(Dictionary<string, List<DailyInventory>> dailyInventories,int totalpages)> TinhTonKhoNhieuNgay(int page, int pagesize,int endDate);

        public Task<(List<XuatnhaptonVM>ds,int totalpages)> Xuatnhapton(int page, int pagesize); 

        public Task<(List<ChiTietPhieuNhapVM>ds, int totalpages)>dspnck(int page, int pagesize,string ma_hanghoa);

        
        public Task<(List<ChiTietPhieuXuatVM>ds, int totalpages)>dspxck(int page, int pagesize,string ma_hanghoa);

    }
}
