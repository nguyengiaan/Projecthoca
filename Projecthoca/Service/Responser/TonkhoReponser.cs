using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projecthoca.Data;
using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;

namespace Projecthoca.Service.Responser
{
    public class TonkhoReponser : ITonkho
    {
        private readonly MyDbcontext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TonkhoReponser(MyDbcontext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<(Dictionary<string, List<DailyInventory>> dailyInventories, int totalpages)> TinhTonKhoNhieuNgay(int page, int pagesize, int endDate)
        {
            try
            {
                List<ChiTietPhieuNhap> chiTietPhieuNhaps;
                List<ChiTietPhieuXuat> chiTietPhieuXuats;
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var totalItems = _context.Danhmuc.Where(x=>x.Id==user.Id).Count();
                var totalpages = (int)Math.Ceiling(totalItems / (double)pagesize);
                var danhMucs=await _context.Danhmuc.Where(x=>x.Id==user.Id).Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
                if(danhMucs==null)
                {
                    return (null,0);    
                }
                var dailyInventories = new Dictionary<string, List<DailyInventory>>();
                DateTime currentDate = DateTime.Now;
                for (var i = 1; i <= endDate; i++)
                {
                    var compareDate1 = new DateTime(currentDate.Year, currentDate.Month, i);
                    var compareDate = new DateTime(currentDate.Year, currentDate.Month, 1);
                    var compareDate2 = new DateTime(currentDate.Year, currentDate.Month, endDate);
                    foreach (var item in danhMucs)
                    {
                        // Lọc chi tiết phiếu nhập theo ngày
                        chiTietPhieuNhaps = await _context.ChiTietPhieuNhaps
                             .Where(x => x.Ma_sanpham == item.Ma_danhmuc
                            && x.Ngaynhap.Date >= compareDate.Date
                            && x.Ngaynhap.Date <= compareDate1.Date)
                            .ToListAsync();
                        // Lọc chi tiết phiếu xuất theo ngày
                        chiTietPhieuXuats = await _context.ChiTietPhieuXuats
                            .Where(x => x.Ma_sanpham == item.Ma_danhmuc
                            && x.Ngayxuat.Date >= compareDate.Date
                            && x.Ngayxuat.Date <= compareDate1.Date)
                            .ToListAsync();
                        var tongphieunhap=chiTietPhieuNhaps.Sum(x=>x.SoLuong);
                        var tongphieuxuat=chiTietPhieuXuats.Sum(x=>x.SoLuong);
                        var tonkho=tongphieunhap-tongphieuxuat;
                        if (dailyInventories.ContainsKey(i.ToString()))
                        {
                            dailyInventories[i.ToString()].Add(new DailyInventory
                            {
                                Ma_danhmuc = item.Ma_danhmuc,
                                Ten_danhmuc = item.Ten_danhmuc,
                                SoLuongTon = tonkho,
                                Date = compareDate
                            });
                        }
                        else
                        {
                            dailyInventories.Add(i.ToString(), new List<DailyInventory>
                            {
                                new DailyInventory
                                {
                                Ma_danhmuc = item.Ma_danhmuc,
                                Ten_danhmuc = item.Ten_danhmuc,
                                SoLuongTon = tonkho,
                                Date = compareDate
                                }
                            });
                        }
                    }
                }
                return (dailyInventories,totalpages);  
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}