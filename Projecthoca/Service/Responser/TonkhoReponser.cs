using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projecthoca.Data;
using Projecthoca.Migrations;
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
                var totalItems = _context.Danhmuc.Where(x=>x.Id==user.Id && x.Ma_danhmuc != "DM0000").Count();
                var totalpages = (int)Math.Ceiling(totalItems / (double)pagesize);
                var danhMucs=await _context.Danhmuc.Where(x=>x.Id==user.Id && x.Ma_danhmuc != "DM0000").Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
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

        public async Task<(List<XuatnhaptonVM>ds,int totalpages)> Xuatnhapton(int page, int pagesize,DateTime Ngaybd,DateTime Ngaykt)
        {
            try
            {
                List<ChiTietPhieuNhap> chiTietPhieuNhapdk;
                List<ChiTietPhieuXuat> chiTietPhieuxuadk;
                List<ChiTietPhieuNhap> chiTietPhieuNhapck;
                List<ChiTietPhieuXuat> chiTietPhieuXuatsck;
                List<XuatnhaptonVM> xuatnhaptonVMs = new List<XuatnhaptonVM>();
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var totalItems = _context.Danhmuc.Where(x => x.Id == user.Id && x.Ma_danhmuc != "DM0000").Count();
                var totalpages = (int)Math.Ceiling(totalItems / (double)pagesize);
                var danhMucs = await _context.Danhmuc.Where(x => x.Id == user.Id && x.Ma_danhmuc != "DM0000").Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
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
                            && x.Ngaynhap.Date >= Ngaybd.Date && x.Ngaynhap.Date <=Ngaykt.Date)
                        .ToListAsync();
                    chiTietPhieuXuatsck = await _context.ChiTietPhieuXuats
                        .Where(x => x.Ma_sanpham == item.Ma_danhmuc
                            && x.Ngayxuat.Date >= Ngaybd.Date && x.Ngayxuat.Date <=Ngaykt.Date)
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
        public async Task<(List<ChiTietPhieuNhapVM> ds, int totalpages)> dspnck(int page, int pagesize, string ma_hanghoa,DateTime Ngaybd,DateTime Ngaykt)
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
                var totalItems = _context.ChiTietPhieuNhaps.Where(x => x.Ma_sanpham == ma_hanghoa && x.Ma_sanpham != "DM0000").Count();
                var totalpages = (int)Math.Ceiling(totalItems / (double)pagesize);
                var chiTietPhieuNhaps = await _context.ChiTietPhieuNhaps
                    .Where(x => x.Ma_sanpham == ma_hanghoa && x.Ngaynhap.Date >= Ngaybd.Date && x.Ngaynhap.Date <= Ngaykt.Date)
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

        public async Task<(List<ChiTietPhieuXuatVM> ds, int totalpages)> dspxck(int page, int pagesize, string ma_hanghoa,DateTime Ngaybd,DateTime Ngaykt)
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
                var totalItems = _context.ChiTietPhieuXuats.Where(x => x.Ma_sanpham == ma_hanghoa && x.Ma_sanpham != "DM0000").Count();
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
        public async Task<(List<long> ds, long dt, long tongvon, long loinhuan)> baocaodt()
        {
          try
    {
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        DateTime lastDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

        List<long> dsdt = new List<long>();
        long doanhthu = 0;
        long tongvon = 0;
        long loinhuan = 0;

        // Truy vấn tất cả các phiếu nhập và phiếu xuất trong khoảng thời gian cần thiết
        var dsphieunhap = await _context.PhieuNhaps
            .Where(x => x.Id == user.Id && x.NgayPhieu.Date >= firstDayOfMonth.Date && x.NgayPhieu.Date <= lastDayOfMonth.Date)
            .Include(x => x.ChiTietPhieuNhaps)
            .AsNoTracking()
            .ToListAsync();

        var dsphieuxuat = await _context.PhieuXuats
            .Where(x => x.Id == user.Id && x.NgayPhieu.Date >= firstDayOfMonth.Date && x.NgayPhieu.Date <= lastDayOfMonth.Date)
            .Include(x => x.ChiTietPhieuXuats)
            .AsNoTracking()
            .ToListAsync();

        // Tạo từ điển để nhóm các phiếu theo ngày
        var nhapTheoNgay = dsphieunhap
            .GroupBy(x => x.NgayPhieu.Date)
            .ToDictionary(g => g.Key, g => g.Sum(x => x.ChiTietPhieuNhaps.Sum(ct => ct.ThanhTien)));

        var xuatTheoNgay = dsphieuxuat
            .GroupBy(x => x.NgayPhieu.Date)
            .ToDictionary(g => g.Key, g => g.Sum(x => x.ChiTietPhieuXuats.Sum(ct => ct.ThanhTien)));

        for (DateTime date = firstDayOfMonth; date <= lastDayOfMonth; date = date.AddDays(1))
        {
            long tt = (long)(xuatTheoNgay.ContainsKey(date.Date) ? xuatTheoNgay[date.Date] : 0);
            long tv = (long)(nhapTheoNgay.ContainsKey(date.Date) ? nhapTheoNgay[date.Date] : 0);

            dsdt.Add(tt);
            doanhthu += tt;
            tongvon += tv;
        }

        loinhuan = doanhthu - tongvon;

        return (dsdt, doanhthu, tongvon, loinhuan);
    }
    catch (Exception ex)
    {
        return (null, 0, 0, 0);
    }
}

        public async Task<List<Baocaodoanhthuct>> Baocaodoanhthuct(DateTime NgayBd, DateTime NgayKt,int page,int pagesize)
        {
            try
            {

                    var date=new DateTime(0001,01,01);
                    var data=await _context.PhieuXuats.Join(_context.ChiTietPhieuXuats,px=>px.SoPhieu,ct=>ct.SoPhieu,(px,ct)=>new {px,ct})
                    .Join(_context.Danhmuc,pxct=>pxct.ct.Ma_sanpham,dm=>dm.Ma_danhmuc,(pxct,dm)=>new {pxct, dm}).Select(x=>new Baocaodoanhthuct
                    {
                        SoPhieu=x.pxct.px.SoPhieu,
                        Ngayphieu=x.pxct.px.NgayPhieu,
                        Tenkhachhang=x.pxct.px.Khachhang,
                        Masanpham=x.dm.Ma_danhmuc,
                        Tensanpham=x.dm.Ten_danhmuc,
                        Soluong=x.pxct.ct.SoLuong,
                        DonGia= (int)x.pxct.ct.DonGia,
                        Tongcong= (int)x.pxct.ct.ThanhTien,
                        TenNV=x.pxct.px.NhanVien,
                        Donvitinh=x.dm.Donvitinh,
                    }).ToListAsync();
                    if(data.Count<0)
                    {
                        return null;
                    }
                    if(NgayBd!= date && NgayKt!=date)
                    {
                        data=data.Where(x=>x.Ngayphieu.Date>=NgayBd.Date && x.Ngayphieu.Date<=NgayKt.Date).ToList();
                    }
                    var totalItems = data.Count();
                    var totalpages = (int)Math.Ceiling(totalItems / (double)pagesize);
                    data=data.Skip((page - 1) * pagesize).Take(pagesize).ToList();
                    return data;
                   
            }
            catch(Exception ex)
            {
                    return null;
            }
        }

        public async Task<List<Baocao>> Baocaodoanhthuct1(DateTime NgayBd, DateTime NgayKt)
        {
           try
           {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var date=new DateTime(0001,01,01);
                var Baocao =new List<Baocao>(); 
         
                if(NgayBd==date && NgayKt==date)
                {
                    NgayBd=new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
                    NgayKt=new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.DaysInMonth(DateTime.Now.Year,DateTime.Now.Month));
                }
                for(DateTime a =NgayBd.Date ; a<=NgayKt.Date;a=a.AddDays(1))
                {
                  var data = await _context.PhieuXuats
    .Where(x => x.NgayPhieu.Date == a.Date && x.Id == user.Id && x.ChiTietPhieuXuats != null)
    .Include(x => x.ChiTietPhieuXuats)
    .SelectMany(x => x.ChiTietPhieuXuats)
    .Where(ct => ct != null) // Lọc các chi tiết phiếu xuất không null
    .ToListAsync();

                if (data.Count > 0)
             {
            var Baocao1 = new Baocao
            {
            Ngayphieu = a.Date,
    Doanhthu = (int)data.Sum(ct => ct.ThanhTien),
    Tienmat = (int)data.Sum(ct => ct.ThanhTien), // Giả sử tất cả đều là tiền mặt, bạn có thể thay đổi nếu cần
    Chuyenkhoan = 0 // Bạn có thể cập 
            };

            Baocao.Add(Baocao1);
        }
                   
                }
                 return Baocao;
           }
           catch(Exception e)
           {
               return null;
            }
    }
}
}