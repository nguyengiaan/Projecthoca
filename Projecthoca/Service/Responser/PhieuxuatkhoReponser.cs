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

        public async Task<(bool ckeck,int tongtienchk, int tongtienmat, int tongthanhtien, int tongtatca)> Tongtientatca()
        {
            try
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var data= await _context.Phieuxuatkhos.Where(x=>x.Id==user.Id).ToListAsync();
                if (data == null)
                {
                    return (false,0, 0, 0, 0);
                }
                var tongtienchk = data.Sum(x => x.Chuyenkhoan);
                var tongtienmat = data.Sum(x => x.Tienmat);
                var tongthanhtien = data.Sum(x => x.Thanhtien);
                var tongthanhton = data.Sum(x => x.Tongtien);
                return (true,tongtienchk, tongtienmat, tongthanhtien, tongthanhton);
                
            }
            catch(Exception ex)
            {
                return (false,0, 0, 0, 0);
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


        public async Task<bool> Themphieuxuatkho(PhieuxuatkhoVM phieuxuatkho)
        {
            try
            {
                var kvc= await _context.Khuvuccau.FindAsync(phieuxuatkho.Ma_khuvuc);
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
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
                data.Id = user.Id;
                data.Thanhtien = phieuxuatkho.Thanhtien;
                data.giamgia = phieuxuatkho.giamgia;
                data.Tienmat = phieuxuatkho.Tienmat;
                data.Chuyenkhoan = phieuxuatkho.Chuyenkhoan;
                data.Tongtien = phieuxuatkho.Tongtien;
                data.Ten_khuvuc = kvc.Ten_Khuvuccau;
                await _context.Phieuxuatkhos.AddAsync(data);
                await _context.SaveChangesAsync();
                return true;


            }
            catch (Exception ex)
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


      //  reponxer phiếu nhập kho 
        // public Task<(List<PhieunhapkhoVM> ds, int totalpages)> Danhsachphieunhap(int page, int pagesize)
        // {
        //     throw new NotImplementedException();
        // }

        // public async Task<bool> Themphieunhapkho(PhieunhapkhoVM phieunhapkho)
        // {
        //     try
        //     {
        //         var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        //         // Id mã danh mục
        //         int nextNumber2 = 1;
        //         var lastMaDV2 = await _context.Danhmuc
        //                       .OrderByDescending(x => x.Ma_danhmuc)
        //                       .Select(x => x.Ma_danhmuc)
        //                       .FirstOrDefaultAsync();
        //         if (lastMaDV2 != null)
        //         {
        //             nextNumber2 = int.Parse(lastMaDV2.Substring(2)) + 1;
        //         }
        //         var madm1 = "DM" + nextNumber2.ToString("D4");
        //         var data = new Phieunhapkho();
        //         data.Ngaynhap = phieunhapkho.Ngaynhap;
        //         data.Id = user.Id;
        //         data.Nguoinhap = phieunhapkho.Nguoinhap;
        //         data.Ten_danhmuc = phieunhapkho.Ten_danhmuc;
        //         data.Tenkho = phieunhapkho.Tenkho;
        //         data.Diadiem = phieunhapkho.Diadiem;
        //         data.Donvitinh = phieunhapkho.Donvitinh;
        //         data.Soluong = phieunhapkho.Soluong;
        //         data.Dongia = phieunhapkho.Dongia;
        //         data.Thanhtien = data.Dongia*data.Soluong;
        //         var data1 = new Danhmuc();
        //         data1.Ma_danhmuc = madm1;
        //         data1.Ten_danhmuc = phieunhapkho.Ten_danhmuc;
        //         data1.Donvitinh = phieunhapkho.Donvitinh;
        //         data1.Soluong=phieunhapkho.Soluong;
        //         data1.Ma_mathang = phieunhapkho.Ma_mathang;
        //         data1.Gia = phieunhapkho.Dongia;
        //         data1.Id = user.Id;
        //         await _context.Phieunhapkhos.AddAsync(data);
        //         await _context.Danhmuc.AddAsync(data1);
        //         await _context.SaveChangesAsync();
        //         return true;
        //     }
        //     catch(Exception ex)
        //     {
        //         return false;
        //     }
        // }
    }
}
