using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projecthoca.Data;
using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;

namespace Projecthoca.Service.Responser
{
    public class DanhmuchoadonReponser : IDanhmuchoadon
    {
        private readonly MyDbcontext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DanhmuchoadonReponser(MyDbcontext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context=context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Themdanhmuchoadon(DanhmuchoadonVM danhmuchoadon)
        {
            try
            {
            
                var danhmuc = await _context.Danhmuc.Where(x => x.Ma_danhmuc == danhmuchoadon.Ma_danhmuc).FirstOrDefaultAsync();
                if (danhmuc == null)
                {
                    return false;
                }
                var _dmhd = new Danhmuchoadon();
                _dmhd.Ma_thuehoca = danhmuchoadon.Ma_thuehoca;
                _dmhd.Ma_danhmuc = danhmuchoadon.Ma_danhmuc;
                _dmhd.Soluong = danhmuchoadon.Soluong;
                _dmhd.thanhtien = danhmuc.Gia*danhmuchoadon.Soluong;
                await _context.danhmuchoadons.AddAsync(_dmhd);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<DanhmucVM>> Danhsachdanhmucdv()
        {
            try
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var data = await _context.Danhmuc.Where(x => x.Mieuta == "Dịch vụ" && x.Id == user.Id).Select(x => new DanhmucVM
                {
                    Ma_danhmuc = x.Ma_danhmuc,
                    Ten_danhmuc = x.Ten_danhmuc,

                }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<DanhmuchoadonVM>> Dsdmhd(string Ma_thuehoca)
        {
            try
            {

                var data= await _context.danhmuchoadons.Where(x => x.Ma_thuehoca == Ma_thuehoca).Select(x => new DanhmuchoadonVM
                {
                    Ma_thuehoca = x.Ma_thuehoca,
                    Ma_danhmuc = x.Ma_danhmuc,
                    Soluong = x.Soluong,
                    Thanhtien = x.thanhtien,
                    DVT=x.Danhmuc.Donvitinh,
                    Gia = x.Danhmuc.Gia,
                    Ten_danhmuc = x.Danhmuc.Ten_danhmuc,
                    Ma_danhmuchoadon = x.Ma_danhmuchoadon
                }).ToListAsync();
                return data;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
