using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;

namespace Projecthoca.Service.Interface
{
    public interface ITonkho
    {
      public   Task<(Dictionary<string, List<DailyInventory>> dailyInventories,int totalpages)> TinhTonKhoNhieuNgay(int page, int pagesize,int endDate);

        public Task<(List<XuatnhaptonVM>ds,int totalpages)> Xuatnhapton(int page, int pagesize,DateTime Ngaybd,DateTime Ngaykt); 

        public Task<(List<ChiTietPhieuNhapVM>ds, int totalpages)>dspnck(int page, int pagesize,string ma_hanghoa,DateTime Ngaybd,DateTime Ngaykt);
        
        public Task<(List<ChiTietPhieuXuatVM>ds, int totalpages)>dspxck(int page, int pagesize,string ma_hanghoa,DateTime Ngaybd,DateTime Ngaykt);
        // báo cáo doanh thu
        public Task<(List<long>ds,long dt,long tongvon,long loinhuan)> baocaodt();

        public Task<List<Baocaodoanhthuct>> Baocaodoanhthuct(DateTime NgayBd, DateTime NgayKt,int page,int pagesize);

        public Task<List<Baocao>> Baocaodoanhthuct1(DateTime NgayBd, DateTime NgayKt);

    }
}
