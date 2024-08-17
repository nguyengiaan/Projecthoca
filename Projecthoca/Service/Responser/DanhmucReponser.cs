using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projecthoca.Data;
using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;

namespace Projecthoca.Service.Responser
{
    public class DanhmucReponser : IDanhmuc
    {
        private readonly MyDbcontext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DanhmucReponser(MyDbcontext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<(List<DanhmucVM> ds, int totalpages)> Danhsachdanhmuc(int page, int pagesize)
        {
            try
            {
                var totalItems = _context.Danhmuc.Count();
                var totalpages = (int)Math.Ceiling(totalItems / (double)pagesize);
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var dm = await _context.Danhmuc
                         .Select(x => new DanhmucVM
                         {
                             Ma_danhmuc = x.Ma_danhmuc,
                             Ten_danhmuc = x.Ten_danhmuc,
                             Gia = x.Gia,
                             Donvitinh = x.Donvitinh,
                             soluong = x.soluong,
                             Id = x.Id,
                             Mieuta = x.Mieuta,

                         }).Where(x => x.Id == user.Id)
                         .Skip((page - 1) * pagesize)
                         .Take(pagesize)
                         .ToListAsync();
                return (dm, totalpages);
            }
            catch (Exception ex)
            {
                return (null, 0);
            }
        }

        public async Task<DanhmucVM> Laytheomadm(string madanhmuc)
        {
            try
            {
                var data = await _context.Danhmuc.Where(x => x.Ma_danhmuc == madanhmuc).Select(x => new DanhmucVM
                {
                    Ma_danhmuc = x.Ma_danhmuc,
                    Ten_danhmuc = x.Ten_danhmuc,
                    Gia = x.Gia,
                    Donvitinh = x.Donvitinh,
                    soluong = x.soluong,
                    Id = x.Id
                }).FirstOrDefaultAsync();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> Suadanhmuc(DanhmucVM danhmuc)
        {
            try
            {
                var data = await _context.Danhmuc.FindAsync(danhmuc.Ma_danhmuc);
                if (data != null)
                {
                    data.Ten_danhmuc = danhmuc.Ten_danhmuc;
                    data.Gia = danhmuc.Gia;
                    data.Donvitinh = danhmuc.Donvitinh;
                    data.soluong = danhmuc.soluong;
                    data.Mieuta = danhmuc.Mieuta;
                    _context.Danhmuc.Update(data);
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

        public async Task<bool> Themdanhmuc(DanhmucVM danhmuc)
        {
            try
            {
                int nextNumber1 = 1;
                var lastMaDV = await _context.Danhmuc
                              .OrderByDescending(x => x.Ma_danhmuc)
                              .Select(x => x.Ma_danhmuc)
                              .FirstOrDefaultAsync();
                int nextNumber = 1;
                if (lastMaDV != null)
                {
                    nextNumber = int.Parse(lastMaDV.Substring(2)) + 1;
                }
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var madm = "DM" + nextNumber.ToString("D4");
                var _dm = new Danhmuc();
                _dm.Mieuta = danhmuc.Mieuta;
                _dm.Ma_danhmuc = madm;
                _dm.Ten_danhmuc = danhmuc.Ten_danhmuc;
                _dm.Gia = danhmuc.Gia;
                _dm.Donvitinh = danhmuc.Donvitinh;
                _dm.soluong = danhmuc.soluong;
                _dm.Id = user.Id;
                await _context.Danhmuc.AddAsync(_dm);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Xoadanhmuc(string madanhmuc)
        {
            try
            {
                var data = await _context.Danhmuc.FindAsync(madanhmuc);
                if (data != null)
                {
                    _context.Danhmuc.Remove(data);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
