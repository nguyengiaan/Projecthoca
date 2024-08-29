using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Projecthoca.Data;
using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;
using System.Runtime.CompilerServices;

namespace Projecthoca.Service.Responser
{
    public class PhieuxuatkhoReponser : IPhieuxuatkho
    {
        private readonly MyDbcontext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public PhieuxuatkhoReponser(MyDbcontext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<(bool ckeck, int tongtienchk, int tongtienmat, int tongthanhtien, int tongtatca)> Tongtientatca()
        {
            try
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var data = await _context.Phieuxuatkhos.Where(x => x.Id == user.Id).ToListAsync();
                if (data == null)
                {
                    return (false, 0, 0, 0, 0);
                }
                var tongtienchk = data.Sum(x => x.Chuyenkhoan);
                var tongtienmat = data.Sum(x => x.Tienmat);
                var tongthanhtien = data.Sum(x => x.Thanhtien);
                var tongthanhton = data.Sum(x => x.Tongtien);
                return (true, tongtienchk, tongtienmat, tongthanhtien, tongthanhton);

            }
            catch (Exception ex)
            {
                return (false, 0, 0, 0, 0);
            }
        }

        public async Task<(List<PhieuxuatkhoVM> ds, int totalpages)> Danhsachphieu(int page, int pagesize)
        {
            try
            {
                var totalItems = _context.Phieuxuatkhos.Count();
                var totalpages = (int)Math.Ceiling(totalItems / (double)pagesize);
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var px = await _context.Phieuxuatkhos
                         .Where(x => x.Id == user.Id) // Assuming UserId is the correct property
                         .Select(x => new PhieuxuatkhoVM
                         {
                             Ma_phieuxuatkho = x.Ma_phieuxuatkho,
                             Ngayxuat = x.Ngayxuat,
                             Thanhtien = x.Thanhtien,
                             giamgia = x.giamgia,
                             Tongtien = x.Tongtien,
                             Tienmat = x.Tienmat,
                             Chuyenkhoan = x.Chuyenkhoan,
                             Trangthai = x.Trangthai,
                             Chitiethoadon = x.Chitiethoadon,
                             Ma_khuvuc = x.Ten_khuvuc,
                         })
                         .Skip((page - 1) * pagesize)
                         .Take(pagesize)
                         .ToListAsync();
                return (px, totalpages);
            }
            catch (Exception ex)
            {
                return (null, 0);
            }
        }

        public async Task<PhieuxuatkhoVM> Xemphieuxuatkho(string Ma_phieuxuatkho)
{
    try
    {
            var data = await _context.Phieuxuatkhos
            .Where(x => x.Ma_phieuxuatkho == Ma_phieuxuatkho)
            .Select(x => new PhieuxuatkhoVM
            {
                Ma_phieuxuatkho = x.Ma_phieuxuatkho,
                Ngayxuat = x.Ngayxuat,
                Thanhtien = x.Thanhtien,
                giamgia = x.giamgia,
                Tongtien = x.Tongtien,
                Tienmat = x.Tienmat,
                Chuyenkhoan = x.Chuyenkhoan,
                Trangthai = x.Trangthai,
                Chitiethoadon = x.Chitiethoadon,
                Ma_khuvuc = x.Ten_khuvuc
            })
            .FirstOrDefaultAsync();

        return data;
    }
    catch (Exception)
    {
        return null;
    }
}

        public async Task<bool> Themphieuxuatkho(PhieuxuatkhoVM phieuxuatkho)
        {
            try
            {
                var kvc = await _context.Khuvuccau.FindAsync(phieuxuatkho.Ma_khuvuc);
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var roles = await _userManager.GetRolesAsync(user);
                int nextNumber1 = 1;
                var lastMaDV = await _context.Phieuxuatkhos
                              .OrderByDescending(x => x.Ma_phieuxuatkho)
                              .Select(x => x.Ma_phieuxuatkho)
                              .FirstOrDefaultAsync();
                int nextNumber = 1;
                if (lastMaDV != null)
                {
                    nextNumber = int.Parse(lastMaDV.Substring(2)) + 1;
                }
                var madm = "XK" + nextNumber.ToString("D4");
                var data = new Phieuxuatkho();
                data.Ma_phieuxuatkho = madm;
                data.Ngayxuat = DateTime.Now;
                if(roles.Contains("Staff"))
                {
                    data.Id = user.IdCustomer;
                }else
                {
                    data.Id = user.Id;
                }
           
                data.Thanhtien = phieuxuatkho.Thanhtien;
                data.giamgia = phieuxuatkho.giamgia;
                data.Tienmat = phieuxuatkho.Tienmat;
                data.Chuyenkhoan = phieuxuatkho.Chuyenkhoan;
                data.Tongtien = phieuxuatkho.Tongtien;
                data.Ten_khuvuc = kvc.Ten_Khuvuccau;
                data.Trangthai = phieuxuatkho.Trangthai;
                data.Chitiethoadon = phieuxuatkho.Chitiethoadon;
                await _context.Phieuxuatkhos.AddAsync(data);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
       
       public async Task<bool> Suaphieuxuatkho(PhieuxuatkhoVM phieuxuatkho)
    {
        try
        {
            var data = await _context.Phieuxuatkhos.FindAsync(phieuxuatkho.Ma_phieuxuatkho);
            var kvc = await _context.Khuvuccau.FindAsync(phieuxuatkho.Ma_khuvuc);
            if (data != null)
            {
                // Cập nhật các thuộc tính của phiếu xuất kho
                data.Ngayxuat = phieuxuatkho.Ngayxuat ?? DateTime.MinValue;
                data.Thanhtien = phieuxuatkho.Thanhtien;
                data.giamgia = phieuxuatkho.giamgia;
                data.Tienmat = phieuxuatkho.Tienmat;
                data.Chuyenkhoan = phieuxuatkho.Chuyenkhoan;
                data.Tongtien = phieuxuatkho.Tongtien;
                data.Ten_khuvuc = kvc.Ten_Khuvuccau; // Nếu cần, có thể tra cứu tên khu vực tương ứng
                data.Trangthai = phieuxuatkho.Trangthai;
                data.Chitiethoadon = phieuxuatkho.Chitiethoadon;
                _context.Phieuxuatkhos.Update(data);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
      
        public async Task<bool> Xoaphieuxuat(string Ma_phieuxuatkho)
        {
            try
            {
                var data = await _context.Phieuxuatkhos.FindAsync(Ma_phieuxuatkho);
                if (data != null)
                {
                    _context.Phieuxuatkhos.Remove(data);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        
        // reponxer phiếu nhập kho 
        public async Task<(List<PhieunhapkhoVM> ds, int totalpages)> Danhsachphieunhap(int page, int pagesize)
        {
            try
            {
                var totalItems = _context.Phieunhapkhos.Count();
                var totalpages = (int)Math.Ceiling(totalItems / (double)pagesize);
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var px = await _context.Phieunhapkhos
                         .Where(x => x.Id == user.Id) // Assuming UserId is the correct property
                         .Select(x => new PhieunhapkhoVM
                         {
                             Ma_phieunhapkho = x.Ma_phieunhapkho,
                             Ngaynhap = x.Ngaynhap,
                             Nguoinhap = x.Nguoinhap,

                         })
                         .Skip((page - 1) * pagesize)
                         .Take(pagesize)
                         .ToListAsync();
                return (px, totalpages);
            }
            catch (Exception ex)
            {
                return (null, 0);
            }
        }
        public async Task<bool> Themphieunhapkho(List<DanhsachhhkhoVM> hanghoa)
        {
            try
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                int nextNumber = 1;
                var lastMaDV = await _context.Phieunhapkhos
                              .OrderByDescending(x => x.Ma_phieunhapkho)
                              .Select(x => x.Ma_phieunhapkho)
                              .FirstOrDefaultAsync();
                if (lastMaDV != null)
                {
                    nextNumber = int.Parse(lastMaDV.Substring(2)) + 1;
                }
                var madm = "NK" + nextNumber.ToString("D4");
                var Phieunhapkho = new Phieunhapkho();
                Phieunhapkho.Ma_phieunhapkho = madm;
                Phieunhapkho.Nguoinhap = user.Hovaten;
                Phieunhapkho.Ngaynhap = DateTime.Now;
                Phieunhapkho.Id = user.Id;
                await _context.Phieunhapkhos.AddAsync(Phieunhapkho);
                foreach (var a in hanghoa)
                {
                    var hh = await _context.Danhmuc.FindAsync(a.Ma_danhmuc);
                    var dx = new Danhsachhhkho();
                    dx.Ma_phieunhapkho = Phieunhapkho.Ma_phieunhapkho;
                    dx.Ma_danhmuc = a.Ma_danhmuc;
                    dx.Soluong = a.Soluong;
                    hh.Soluong = a.Soluong;
                    dx.Thanhtien = a.Soluong * hh.Gia;
                    await _context.Danhsachhhkhos.AddAsync(dx);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> Xoaphieunhapkho(string Ma_phieunhapkho)
        {
            try
            {
                var data = await _context.Phieunhapkhos.FindAsync(Ma_phieunhapkho);
                if (data != null)
                {
                    _context.Phieunhapkhos.Remove(data);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<XemhanghoakhoVM>> Xemphieukho(string Ma_phieunhapkho)
        {
            try
            {
                var data = await _context.Danhsachhhkhos.Where(x => x.Ma_phieunhapkho == Ma_phieunhapkho)
                     .Select(x => new XemhanghoakhoVM
                     {
                         Ma_hanghoa = x.Ma_danhmuc,
                         Ten_hanghoa = x.Danhmuc.Ten_danhmuc,
                         Dvt = x.Danhmuc.Donvitinh,
                         Soluong = x.Soluong,
                         Gia = x.Danhmuc.Gia,
                         Thanhtien = x.Danhmuc.Gia * x.Soluong,
                         Nhapcungcap = x.Danhmuc.Nhacungcap,
                     }
                ).ToListAsync();


                return data;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        }
    }


