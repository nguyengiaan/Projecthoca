using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projecthoca.Data;
using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;

namespace Projecthoca.Service.Responser
{
    public class GiahocaReponser : IGiahoca
    {
        private readonly MyDbcontext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GiahocaReponser(MyDbcontext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Capnhatgia(GiahocaVM giahoca)
        {
            try
            {
                var data = await _context.Giahocas.FindAsync(giahoca.Ma_giahoca);
                if (data != null)
                {

                    data.Ca = giahoca.Ca;
                    data.Gia_coca = giahoca.Gia_coca;
                    data.Gia_khongca = giahoca.Gia_khongca;
                    _context.Giahocas.Update(data);
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

        public async Task<(List<GiahocaVM> ds, int totalpages)> Danhsachhoca(int page, int pagesize)
        {
            try
            {
                var totalItems = _context.Giahocas.Count();
                var totalpages = (int)Math.Ceiling(totalItems / (double)pagesize);
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var Giahoca = await _context.Giahocas
                         .Select(x => new GiahocaVM
                         {
                             Ma_giahoca = x.Ma_giahoca,
                             Ca = x.Ca,
                             Gia_coca = x.Gia_coca,
                             Gia_khongca = x.Gia_khongca,
                             Id = x.Id
                         }).Where(x => x.Id == user.Id)
                         .Skip((page - 1) * pagesize)
                         .Take(pagesize)
                         .ToListAsync();
                return (Giahoca, totalpages);
            }
            catch (Exception ex)
            {
                return (null, 0);
            }
        }

        public async Task<GiahocaVM> Laytheomagia(int Ma_giahoca)
        {
            try
            {
                var data = await _context.Giahocas.Where(x => x.Ma_giahoca == Ma_giahoca).Select(x => new GiahocaVM
                {
                    Ma_giahoca = x.Ma_giahoca,
                    Ca = x.Ca,
                    Gia_coca = x.Gia_coca,
                    Gia_khongca = x.Gia_khongca,
                    Id = x.Id
                }).FirstOrDefaultAsync();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> Themgiahoca(GiahocaVM giahoca)
        {
            try
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var _giahoca = new Giahoca();
                _giahoca.Ca = giahoca.Ca;
                _giahoca.Gia_coca = giahoca.Gia_coca;
                _giahoca.Gia_khongca = giahoca.Gia_khongca;
                _giahoca.Id = user.Id;
                await _context.Giahocas.AddAsync(_giahoca);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> Xoagia(int Ma_giahoca)
        {
            try
            {
                var data = await _context.Giahocas.FindAsync(Ma_giahoca);
                if (data != null)
                {
                    _context.Giahocas.Remove(data);
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
