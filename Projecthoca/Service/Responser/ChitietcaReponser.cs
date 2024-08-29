using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projecthoca.Data;
using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;

namespace Projecthoca.Service.Responser
{
    public class ChitietcaReponser : IChitietca
    {
        private readonly MyDbcontext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public ChitietcaReponser(MyDbcontext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<DanhmucVM>> Danhsachdanhmuchs()
        {
            try
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var roles = await _userManager.GetRolesAsync(user);
                if(roles.Contains("Staff"))
                {
                    var data = await _context.Danhmuc.Where(x => x.Mathang.Ten_mathang == "Hải sản" && x.Id == user.IdCustomer).Select(x => new DanhmucVM
                    {
                        Ma_danhmuc = x.Ma_danhmuc,
                        Ten_danhmuc = x.Ten_danhmuc,
                        Nhacungcap = x.Nhacungcap,
                    }).ToListAsync();
                    return data;
                }
                else
                {
                    var data = await _context.Danhmuc.Where(x => x.Mathang.Ten_mathang == "Hải sản" && x.Id == user.Id).Select(x => new DanhmucVM
                    {
                        Ma_danhmuc = x.Ma_danhmuc,
                        Ten_danhmuc = x.Ten_danhmuc,
                        Nhacungcap = x.Nhacungcap,
                    }).ToListAsync();
                    return data;
                }
       
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ChitietcaVM>> Laychitietca(string khuvucId)
        {
            try
            {
                var nguoithue = await _context.Thuehoca.Where(x => x.Ma_khuvuccau == khuvucId).FirstOrDefaultAsync();
                if (nguoithue == null)
                {
                    return null;
                }
                var data = await _context.chitietlancaus.Where(x => x.Ma_thuehoca == nguoithue.Ma_thuehoca).Select(x => new ChitietcaVM
                {
                    Ma_chitietlancau = x.Ma_chitietlancau,
                    giocau = x.giocau,
                    Ma_danhmuc = x.Ma_danhmuc,
                    Ma_thuehoca = x.Ma_thuehoca,
                    sokg = x.sokg,
                    Thanhtien = x.Thanhtien,
                    Tendanhmuc = x.Danhmuc.Ten_danhmuc,
                   
                }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> ThemCa(ChitietcaVM chitietca)
        {
            try
            {
                int nextNumber1 = 1;
                var lastMaDV = await _context.chitietlancaus
                              .OrderByDescending(x => x.Ma_chitietlancau)
                              .Select(x => x.Ma_chitietlancau)
                              .FirstOrDefaultAsync();
                int nextNumber = 1;
                if (lastMaDV != null)
                {
                    nextNumber = int.Parse(lastMaDV.Substring(2)) + 1;
                }
                var gia = await _context.Danhmuc.Where(x => x.Ma_danhmuc == chitietca.Ma_danhmuc).FirstOrDefaultAsync();
                string macc = "CT" + nextNumber.ToString("D4");
                var data = new Chitietlancau();
                data.giocau = chitietca.giocau;
                data.Ma_chitietlancau = macc;
                data.Ma_danhmuc = chitietca.Ma_danhmuc;
                data.Ma_thuehoca = chitietca.Ma_thuehoca;
                data.sokg = chitietca.sokg;
                data.Thanhtien = gia.Gia * chitietca.sokg;
                await _context.chitietlancaus.AddAsync(data);
                await _context.SaveChangesAsync();
                var data1 = new Tongsokg();
                var tt = await _context.chitietlancaus.Where(x => x.Ma_thuehoca == chitietca.Ma_thuehoca).ToListAsync();
                data1.sokg = tt.Sum(x => x.sokg);
                data1.soluong = tt.Count;
                data1.Ma_thuehoca = chitietca.Ma_thuehoca;
                data1.Tongsotien = tt.Sum(x => x.Thanhtien);
                var tongkg = await _context.Tongsokg.Where(x => x.Ma_thuehoca == chitietca.Ma_thuehoca).FirstOrDefaultAsync();
                if (tongkg != null)
                {
                    _context.Tongsokg.Remove(tongkg);
                }
                await _context.Tongsokg.AddAsync(data1);
                await _context.SaveChangesAsync();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<TongsokgVM> Tongsokg(string khuvucid)
        {
            try
            {
                var data = await _context.Thuehoca.Where(x => x.Ma_khuvuccau == khuvucid).FirstOrDefaultAsync();
                if (data == null)
                {
                    return null;
                }
                else
                {
                    var tongsokg = await _context.Tongsokg.Where(x => x.Ma_thuehoca == data.Ma_thuehoca).Select(x => new TongsokgVM
                    {
                        Ma_tongsokg = x.Ma_tongsokg,
                        sokg = x.sokg,
                        soluong = x.soluong,
                        Tongsotien = x.Tongsotien,

                    }).FirstOrDefaultAsync();
                    return tongsokg;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> Xoaca(string machitietca)
        {
            try
            {
                var data = await _context.chitietlancaus.Where(x => x.Ma_chitietlancau == machitietca).FirstOrDefaultAsync();
                if (data == null)
                {
                    return false;
                }
                else
                {
                    _context.chitietlancaus.Remove(data);
                    await _context.SaveChangesAsync();
                    var data1 = new Tongsokg();
                    var tt = await _context.chitietlancaus.Where(x => x.Ma_thuehoca == data.Ma_thuehoca).ToListAsync();
                    data1.sokg = tt.Sum(x => x.sokg);
                    data1.soluong = tt.Count;
                    data1.Ma_thuehoca = data.Ma_thuehoca;
                    data1.Tongsotien = tt.Sum(x => x.Thanhtien);
                    var tongkg = await _context.Tongsokg.Where(x => x.Ma_thuehoca == data.Ma_thuehoca).FirstOrDefaultAsync();
                    if (tongkg != null)
                    {
                        _context.Tongsokg.Remove(tongkg);
                    }
                    await _context.Tongsokg.AddAsync(data1);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }



    }
}
