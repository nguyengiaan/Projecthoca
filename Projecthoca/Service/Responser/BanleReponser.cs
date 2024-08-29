using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projecthoca.Data;
using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;

namespace Projecthoca.Service.Responser
{
    public class BanleReponser : IBanle
    {
        public readonly MyDbcontext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BanleReponser(MyDbcontext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager=userManager;
            _httpContextAccessor=httpContextAccessor;
        }
        public async Task<(bool kq, string ma_kvc, string ma_thc,string ten_kh, string ngay_mua)> Themkhachhang(ThuehocaVM thc)
        {
            try
            {
              
                int nextNumber1 = 1;
                var lastMaDV = await _context.Thuehoca
                              .OrderByDescending(x => x.Ma_thuehoca)
                              .Select(x => x.Ma_thuehoca)
                              .FirstOrDefaultAsync();
                int nextNumber = 1;
                if (lastMaDV != null)
                {
                    nextNumber = int.Parse(lastMaDV.Substring(2)) + 1;
                }
                var mact = "CT" + nextNumber.ToString("D4");
                
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var roles = await _userManager.GetRolesAsync(user);
                if(roles.Contains("Staff"))
                {
                    var hc1 = await _context.Hoca.FirstOrDefaultAsync(x => x.Id == user.IdCustomer);
                    Khuvuccau kv1 = new Khuvuccau();
                    kv1.Ma_Khuvuccau = Guid.NewGuid().ToString();
                    kv1.Ten_Khuvuccau = "Không";
                    kv1.Idkhuvuccau = "9999";
                    kv1.Ma_hoca = hc1.Ma_hoca;
                    kv1.Trangthai = "Hdl";
                    await _context.Khuvuccau.AddAsync(kv1);
                    await _context.SaveChangesAsync();
                    Thuehoca ct1 = new Thuehoca();
                    //ct.Ma_thuehoca = Guid.NewGuid().ToString();
                    ct1.Ma_thuehoca = mact;
                    ct1.Ma_khuvuccau = kv1.Ma_Khuvuccau;
                    ct1.Ten_khachhang = thc.Ten_khachhang;
                    ct1.Ngaycau = DateTime.Now.ToString();
                    ct1.Thoigianbatdau = new TimeSpan(0, 0, 0);
                    ct1.Timeout = new TimeSpan(0, 0, 0);
                    ct1.trangthai = "Khong";
                    await _context.Thuehoca.AddAsync(ct1);
                    await _context.SaveChangesAsync();
                    return (true, kv1.Ma_Khuvuccau, ct1.Ma_thuehoca, ct1.Ten_khachhang, ct1.Ngaycau);
                }
                var hc=await _context.Hoca.FirstOrDefaultAsync(x=>x.Id==user.Id);
                Khuvuccau kv = new Khuvuccau();
                kv.Ma_Khuvuccau = Guid.NewGuid().ToString();
                kv.Ten_Khuvuccau = "Không";
                kv.Idkhuvuccau = "9999";
                kv.Ma_hoca = hc.Ma_hoca;
                kv.Trangthai = "Hdl";
                await _context.Khuvuccau.AddAsync(kv);
                await _context.SaveChangesAsync();
                Thuehoca ct = new Thuehoca();
                //ct.Ma_thuehoca = Guid.NewGuid().ToString();
                ct.Ma_thuehoca =mact;
                ct.Ma_khuvuccau = kv.Ma_Khuvuccau;
                ct.Ten_khachhang = thc.Ten_khachhang;
                ct.Ngaycau = DateTime.Now.ToString();
                ct.Thoigianbatdau = new TimeSpan(0, 0, 0);
                ct.Timeout = new TimeSpan(0, 0, 0);
                ct.trangthai = "Khong";
                await _context.Thuehoca.AddAsync(ct);
                await _context.SaveChangesAsync();
                return (true,kv.Ma_Khuvuccau, ct.Ma_thuehoca, ct.Ten_khachhang, ct.Ngaycau);


            }
            catch (Exception ex)
            {
                return (false,null,null,null,null);

            }
        }
    }
}
