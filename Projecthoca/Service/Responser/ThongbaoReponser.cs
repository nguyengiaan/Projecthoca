using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projecthoca.Data;
using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;

namespace Projecthoca.Service.Responser
{
    public class ThongbaoReponser : IThongbao
    {
        private readonly MyDbcontext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ThongbaoReponser(MyDbcontext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<(List<ThongbaoVM> ds, int total)> danhsachtb()
        {
            try
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var data = await _context.Thongbaos.Where(x => x.Id == user.Id && x.Trangthai == false).OrderByDescending(x => x.Ma_thongbao).Select(x => new ThongbaoVM
                {
                    Ma_thongbao = x.Ma_thongbao,
                    NoiDung = x.NoiDung,
                    NgayDang = x.NgayDang,
                    Trangthai = x.Trangthai
                }).ToListAsync();
                var dem = data.Count();
                return (data, dem);
            }
            catch (Exception)
            {
                return (null, 0);
            }
        }

        public async Task<bool> docthongbao(int Ma_thongbao)
        {
            try
            {
                var data = await _context.Thongbaos.FindAsync(Ma_thongbao);
                _context.Thongbaos.Remove(data);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
