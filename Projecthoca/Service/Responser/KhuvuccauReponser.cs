using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Projecthoca.Data;
using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;
using System.Xml.Linq;

namespace Projecthoca.Service.Responser
{
    public class KhuvuccauReponser : IKhuvuccau
    {
        private readonly MyDbcontext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMemoryCache _cache;

        public KhuvuccauReponser(MyDbcontext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor, IMemoryCache cache)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _cache = cache;
        }
        public async Task<bool> Themkhuvuccau(KhuvuccauVM khuvuccau)
        {
            try
            {
                int nextNumber1 = 1;
                var lastMaDV = await _context.Khuvuccau
                              .OrderByDescending(x => x.Ma_Khuvuccau)
                              .Select(x => x.Ma_Khuvuccau)
                              .FirstOrDefaultAsync();
                int nextNumber = 1;
                if (lastMaDV != null)
                {
                    nextNumber = int.Parse(lastMaDV.Substring(2)) + 1;
                }
                var makv = "KV" + nextNumber.ToString("D4");
                Khuvuccau kv = new Khuvuccau();
                kv.Ma_Khuvuccau = makv;
                kv.Ten_Khuvuccau = khuvuccau.Ten_Khuvuccau;
                kv.Idkhuvuccau = khuvuccau.Idkhuvuccau;
                kv.Ma_hoca = khuvuccau.Ma_hoca;
                kv.Trangthai = khuvuccau.Trangthai;
                await _context.Khuvuccau.AddAsync(kv);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<KhuvuccauVM>> Danhsachkhuvuccau(string Ma_hocau)
        {
            try
            {
                var data = await _context.Khuvuccau.Where(x => x.Ma_hoca == Ma_hocau).Select(x => new KhuvuccauVM
                {
                    Ma_Khuvuccau = x.Ma_Khuvuccau,
                    Ten_Khuvuccau = x.Ten_Khuvuccau,
                    Idkhuvuccau = x.Idkhuvuccau,
                    Ma_hoca = x.Ma_hoca,
                    Trangthai = x.Trangthai,
                    Timeout = x.Thuehocas.Select(th => th.Timeout).FirstOrDefault(),

                }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> Themkhachthue(ThuehocaVM thc)
        {
            try
            {
                var kvc = await _context.Khuvuccau.FindAsync(thc.Ma_khuvuccau);
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
                Thuehoca ct = new Thuehoca();
                ct.Ma_thuehoca = mact;
                ct.Ma_khuvuccau = thc.Ma_khuvuccau;
                ct.Ten_khachhang = thc.Ten_khachhang;
                ct.Ngaycau = thc.Ngaycau;
                ct.Thoigianbatdau = thc.Thoigianbatdau;
                ct.Timeout = new TimeSpan(0, 0, 0);
                ct.trangthai = "Chuabamgio";
                kvc.Trangthai = "Cokhach";
                await _context.Thuehoca.AddAsync(ct);
                await _context.SaveChangesAsync();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Kiemtrakv(string Ma_khuvuc)
        {
            try
            {
                var data = await _context.Thuehoca.Where(x => x.Ma_khuvuccau == Ma_khuvuc).FirstOrDefaultAsync();
                if (data != null)
                {
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

        public async Task<TimeSpan> Laythoigian(string Ma_khuvuc)
        {
            try
            {
                var data = await _context.Thuehoca.Where(x => x.Ma_khuvuccau == Ma_khuvuc).FirstOrDefaultAsync();
                if (data != null)
                {
                    return data.Timeout;
                }
                else
                {
                    return TimeSpan.Zero;
                }
            }
            catch (Exception ex)
            {
                return TimeSpan.Zero;
            }
        }

        public async Task<bool> CapnhatTg(string Ma_khuvuc, TimeSpan time)

        {
            try
            {
                var data = await _context.Thuehoca.Where(x => x.Ma_khuvuccau == Ma_khuvuc).FirstOrDefaultAsync();
                if (data != null)
                {
                    data.Timeout = time;
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

        public async Task<bool> Demthoigian(string maKhuvuc)
        {
            try
            {
                var time = new TimeSpan(23, 59, 50);

                var data = await _context.Thuehoca.FirstOrDefaultAsync(x => x.Ma_khuvuccau == maKhuvuc);
                if (data.Timeout  == time)
                {
                    data.Timeout = new TimeSpan(0, 0, 0);
                    await _context.SaveChangesAsync();
                    return false;
                }
                data.Timeout = data.Timeout.Add(TimeSpan.FromSeconds(1));

                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateBamgio(string Ma_khuvuc)
        {
            try
            {
                var cachekey = "Danhsachbamgiolist";
                var data = await _context.Thuehoca.Where(x => x.Ma_khuvuccau == Ma_khuvuc).FirstOrDefaultAsync();
                if (data != null)
                {
                    data.trangthai = "Dabamgio";
                    await _context.SaveChangesAsync();
                    await Danhsachbamgio();
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

        public async Task<bool> KiemtraBamgio(string Ma_khuvuc)
        {
            try
            {
                var data = await _context.Thuehoca.Where(x => x.Ma_khuvuccau == Ma_khuvuc).FirstOrDefaultAsync();
                if (data != null)
                {
                    if (data.trangthai == "Dabamgio")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Danhsachbamgio()
        {
            try
            {
                var _key = "Danhsachbamgiolist_1";
                var data = await _context.Thuehoca.Where(x => x.trangthai == "Dabamgio").ToListAsync();
                _cache.Set(_key, data);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Dadungtg(string Ma_khuvuc)
        {
            try
            {
                var data = await _context.Thuehoca.Where(x => x.Ma_khuvuccau == Ma_khuvuc).FirstOrDefaultAsync();
                if (data != null)
                {
                    data.trangthai = "Dungthoigian";
                    await _context.SaveChangesAsync();
                    await Danhsachbamgio();
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

        public async Task<bool> Deletekvc(string Ma_khuvuc)
        {
            try
            {
                var data = await _context.Khuvuccau.FindAsync(Ma_khuvuc);
                if (data != null)
                {
                    _context.Khuvuccau.Remove(data);
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

        public async Task<bool> Xoakhachthue(string Ma_khuvuc)
        {
            try
            {
                var data = await _context.Thuehoca.Where(x => x.Ma_khuvuccau == Ma_khuvuc).FirstAsync();
                var data1 = await _context.Khuvuccau.FindAsync(Ma_khuvuc);
                if (data != null)
                {

                    _context.Thuehoca.Remove(data);
                    data1.Trangthai = "Chuacokhach";
                    _context.SaveChanges();
                    await Danhsachbamgio();
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

        public async Task<ThuehocaVM> Laykhachthue(string Ma_khuvuc)
        {
            try
            {
                var data = await _context.Thuehoca.Where(x => x.Ma_khuvuccau == Ma_khuvuc).Select(x => new ThuehocaVM
                {
                    Ma_thuehoca = x.Ma_thuehoca,
                    Ma_khuvuccau = x.Ma_khuvuccau,
                    Ten_khachhang = x.Ten_khachhang,
                    Ngaycau = x.Ngaycau,
                    Thoigianbatdau = x.Thoigianbatdau,
                    Timeout = x.Timeout,
                    Ten_Khuvuccau = x.Khuvuccau.Ten_Khuvuccau,
                }).FirstOrDefaultAsync();
                if (data != null)
                {
                    return data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> Chuyenkhachthue(ChuyenbanVM chuyenban)
        {
            try
            {
                var data = await _context.Thuehoca.Where(x => x.Ma_khuvuccau == chuyenban.Ma_khuvuc).FirstOrDefaultAsync();
                var kvmoi = await _context.Khuvuccau.FindAsync(chuyenban.Ma_khuvucmoi);
                var kvcu = await _context.Khuvuccau.FindAsync(chuyenban.Ma_khuvuc);
                if (data != null)
                {
                    kvmoi.Trangthai = "Cokhach";
                    kvcu.Trangthai = "Chuacokhach";
                    data.Ma_khuvuccau = chuyenban.Ma_khuvucmoi;
                    await _context.SaveChangesAsync();
                    await Danhsachbamgio();
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
        // danh mục hiển thị trong hóa đơn

        public async Task<List<DanhmucVM>> Danhmuchthd(string? Timkiem)
        {

            try
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var Roles =await _userManager.GetRolesAsync(user);
                if (Timkiem == null)
                {
                    if(Roles.Contains("Staff"))
                    {
                        var data = await _context.Danhmuc.Where(x => x.Id == user.IdCustomer && x.Ma_danhmuc != "DM0000")
                        .Select(x => new DanhmucVM
                        {
                            Ma_danhmuc = x.Ma_danhmuc,
                            Ten_danhmuc = x.Ten_danhmuc,
                            Gia = x.Gia,
                            Soluong = x.Soluong,
                            Donvitinh = x.Donvitinh,
                            Nhacungcap = x.Nhacungcap

                        }).ToListAsync();
                        return data;
                    }
                    else
                    {
                        var data = await _context.Danhmuc.Where(x => x.Id == user.Id && x.Ma_danhmuc != "DM0000")
                        .Select(x => new DanhmucVM
                        {
                            Ma_danhmuc = x.Ma_danhmuc,
                            Ten_danhmuc = x.Ten_danhmuc,
                            Gia = x.Gia,
                            Soluong = x.Soluong,
                            Donvitinh = x.Donvitinh,
                            Nhacungcap = x.Nhacungcap

                        }).ToListAsync();
                        return data;
                    }
                   
                }
                else
                {
                    var data = await _context.Danhmuc.Where(x => x.Ten_danhmuc.Contains(Timkiem) && x.Id == user.Id && x.Ma_danhmuc != "DM0000")
                    .Select(x => new DanhmucVM
                    {
                        Ma_danhmuc = x.Ma_danhmuc,
                        Ten_danhmuc = x.Ten_danhmuc,
                        Gia = x.Gia,
                        Donvitinh = x.Donvitinh,
                        Nhacungcap = x.Nhacungcap
                    }).ToListAsync();
                    return data;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //mặt hàng hiển thị trong hóa đơn

        public async Task<List<MathangVM>> Mathanghthd()
        {
            try
            {
                
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var Roles = await _userManager.GetRolesAsync(user);
                if(Roles.Contains("Staff"))
                {
                    var data = await _context.Mathangs.Where(x => x.Id == user.IdCustomer).Select(x => new MathangVM
                    {
                        Ma_mathang = x.Ma_mathang,
                        Ten_mathang = x.Ten_mathang
                    }).ToListAsync();
                    return data;
                }
                else
                {
                    var data = await _context.Mathangs.Where(x => x.Id == user.Id).Select(x => new MathangVM
                    {
                        Ma_mathang = x.Ma_mathang,
                        Ten_mathang = x.Ten_mathang
                    }).ToListAsync();
                    return data;
                }
          
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<KhuvuccauVM>> Danhsachkhuvucvang(string Ma_hocau)
        {
            try
            {
                var data = await _context.Khuvuccau.Where(x => x.Ma_hoca == Ma_hocau && x.Trangthai == "Chuacokhach").Select(x => new KhuvuccauVM
                {
                    Ma_Khuvuccau = x.Ma_Khuvuccau,
                    Ten_Khuvuccau = x.Ten_Khuvuccau,
                    Idkhuvuccau = x.Idkhuvuccau,
                    Ma_hoca = x.Ma_hoca,
                    Trangthai = x.Trangthai,
                    Timeout = x.Thuehocas.Select(th => th.Timeout).FirstOrDefault(),
                }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
