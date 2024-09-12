using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
                                Date = compareDate,
                                Donvitinh=item.Donvitinh
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
                                Date = compareDate,
                                    Donvitinh=item.Donvitinh,
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

        public async Task<(List<XuatnhaptonVM>ds,int totalpages)> Xuatnhapton(int page, int pagesize)
        {
            try
            {
                List<ChiTietPhieuNhap> chiTietPhieuNhapdk;
                List<ChiTietPhieuXuat> chiTietPhieuxuadk;
                List<ChiTietPhieuNhap> chiTietPhieuNhapck;
                List<ChiTietPhieuXuat> chiTietPhieuXuatsck;
                List<XuatnhaptonVM> xuatnhaptonVMs = new List<XuatnhaptonVM>();
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var totalItems = _context.Danhmuc.Where(x => x.Id == user.Id).Count();
                var totalpages = (int)Math.Ceiling(totalItems / (double)pagesize);
                var danhMucs = await _context.Danhmuc.Where(x => x.Id == user.Id).Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
                if (danhMucs == null)
                {
                    return (null, 0);
                }
                
                // Lấy ngày đầu tháng hiện tại
                DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

                // Lấy ngày đầu tháng của tháng trước
                DateTime firstDayOfLastMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);

                DateTime Trongky = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

                foreach (var item in danhMucs)
                {
                    chiTietPhieuNhapdk = await _context.ChiTietPhieuNhaps
                        .Where(x => x.Ma_sanpham == item.Ma_danhmuc
                            && x.Ngaynhap.Date <= firstDayOfMonth.Date && x.Ngaynhap.Date >= firstDayOfLastMonth.Date)
                        .ToListAsync();
                    chiTietPhieuxuadk=await _context.ChiTietPhieuXuats
                        .Where(x => x.Ma_sanpham == item.Ma_danhmuc
                            && x.Ngayxuat.Date <= firstDayOfMonth.Date && x.Ngayxuat.Date >= firstDayOfLastMonth.Date)
                        .ToListAsync();
                    chiTietPhieuNhapck = await _context.ChiTietPhieuNhaps
                        .Where(x => x.Ma_sanpham == item.Ma_danhmuc
                            && x.Ngaynhap.Date >= firstDayOfMonth.Date && x.Ngaynhap.Date <=Trongky.Date)
                        .ToListAsync();
                    chiTietPhieuXuatsck = await _context.ChiTietPhieuXuats
                        .Where(x => x.Ma_sanpham == item.Ma_danhmuc
                            && x.Ngayxuat.Date >= firstDayOfMonth.Date && x.Ngayxuat.Date <=Trongky.Date)
                        .ToListAsync();

                    var tongphieunhapdk = chiTietPhieuNhapdk.Sum(x => x.SoLuong);
                    var tongphieuxuatdk = chiTietPhieuxuadk.Sum(x => x.SoLuong);
                    var tonkhodk = tongphieunhapdk - tongphieunhapdk;
                    var tongphieunhapck = chiTietPhieuNhapck.Sum(x => x.SoLuong);
                    var tongphieuxuatck = chiTietPhieuXuatsck.Sum(x => x.SoLuong);
                    var tonkhock = tongphieunhapck - tongphieuxuatck;
                    xuatnhaptonVMs.Add(new XuatnhaptonVM
                    {
                        ma_hanghoa = item.Ma_danhmuc,
                        ten_hanghoa = item.Ten_danhmuc,
                        donvitinh = item.Donvitinh,
                        Tondauky = tonkhodk,
                        Nhaptrongky = tongphieunhapck,
                        Xuattrongky = tongphieuxuatck,
                        Toncuoiky = tonkhock
                    });
                }

                return (xuatnhaptonVMs, totalpages);
            }
            catch (Exception ex)
            {
                // Log the exception
                return (null, 0);
            }
        }
        public async Task<(List<ChiTietPhieuNhapVM> ds, int totalpages)> dspnck(int page, int pagesize, string ma_hanghoa)
        {
           try
           {
                DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime Trongky = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                var hanghoa=await _context.Danhmuc.FindAsync(ma_hanghoa);
                if(hanghoa==null)
                {
                    return (null,0);
                }
                var totalItems = _context.ChiTietPhieuNhaps.Where(x => x.Ma_sanpham == ma_hanghoa).Count();
                var totalpages = (int)Math.Ceiling(totalItems / (double)pagesize);
                var chiTietPhieuNhaps = await _context.ChiTietPhieuNhaps
                    .Where(x => x.Ma_sanpham == ma_hanghoa && x.Ngaynhap.Date >= firstDayOfMonth.Date && x.Ngaynhap.Date <= Trongky.Date)
                    .Skip((page - 1) * pagesize).Take(pagesize).Select(x=>new ChiTietPhieuNhapVM
                    {
                        Id=x.Id,
                        SoPhieu=x.SoPhieu,
                        Ma_sanpham=x.Ma_sanpham,
                        TenSanPham=hanghoa.Ten_danhmuc,
                        SoLuong=x.SoLuong,
                        DonGia=x.DonGia,
                        DonViTinh=x.DonViTinh,
                        ThanhTien=x.ThanhTien,
                        NgayNhap=x.Ngaynhap,    
                        
                    }).ToListAsync();
                return (chiTietPhieuNhaps,totalpages);
           }
           catch(Exception e)
           {
               throw e;
           }
        }

        public async Task<(List<ChiTietPhieuXuatVM> ds, int totalpages)> dspxck(int page, int pagesize, string ma_hanghoa)
        {
          try
           {
                DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime Trongky = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                var hanghoa=await _context.Danhmuc.FindAsync(ma_hanghoa);
                if(hanghoa==null)
                {
                    return (null,0);
                }
                var totalItems = _context.ChiTietPhieuXuats.Where(x => x.Ma_sanpham == ma_hanghoa).Count();
                var totalpages = (int)Math.Ceiling(totalItems / (double)pagesize);
                var chiTietPhieuNhaps = await _context.ChiTietPhieuXuats
                    .Where(x => x.Ma_sanpham == ma_hanghoa && x.Ngayxuat.Date >= firstDayOfMonth.Date && x.Ngayxuat.Date <= Trongky.Date)
                    .Skip((page - 1) * pagesize).Take(pagesize).Select(x=>new ChiTietPhieuXuatVM
                    {
                        Id=x.Id,
                        SoPhieu=x.SoPhieu,
                        Ma_sanpham=x.Ma_sanpham,
                        TenSanPham=hanghoa.Ten_danhmuc,
                        SoLuong=x.SoLuong,
                        DonGia=x.DonGia,
                        DonViTinh=x.DonViTinh,
                        ThanhTien=x.ThanhTien,
                        Ngayxuat=x.Ngayxuat,
                    }).ToListAsync();
                return (chiTietPhieuNhaps,totalpages);
           }
           catch(Exception e)
           {
               throw e;
           }

         }
}
}