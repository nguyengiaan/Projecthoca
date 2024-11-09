using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.VisualBasic;
using Projecthoca.Data;
using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;

namespace Projecthoca.Service.Responser
{
    public class KhachhangReponser : IKhachhang
    {
        private readonly MyDbcontext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public KhachhangReponser(MyDbcontext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor) 
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Capnhatkhachhang(KhachhangVM kh)
        {
            try
            {
                var data = await _context.Khachhangs.FindAsync(kh.Ma_khachhang);
                if(data!=null)
                {
                    data.Ten_khachhang = kh.Ten_khachhang;
                    data.Diachi = kh.Diachi;
                    data.Ngaysinh = kh.Ngaysinh;
                    data.Sodienthoai = kh.Sodienthoai;
                    _context.Khachhangs.Update(data);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<(List<KhachhangVM> ds, int totalpages)> Danhsachkh(int page, int pagesize)
        {
            try
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                if (user == null)
                {
                    return (null, 0);
                }

                var roles = await _userManager.GetRolesAsync(user);
                IQueryable<Khachhang> query = _context.Khachhangs;

                // Nếu là Staff, lấy theo IdCustomer
                if (roles.Contains("Staff"))
                {
                    query = query.Where(x => x.Id == user.IdCustomer);
                }
                // Nếu là Customer, lấy theo Id của user
                else if (roles.Contains("Customer"))
                {
                    query = query.Where(x => x.Id == user.Id);
                }
                // Nếu là Admin, lấy tất cả
                // else if (!roles.Contains("Admin"))
                // {
                //     return (null, 0);
                // }

                var totalItems = await query.CountAsync();
                var totalpages = (int)Math.Ceiling(totalItems / (double)pagesize);

                var dm = await query
                    .Select(x => new KhachhangVM
                    {
                        Ma_khachhang = x.Ma_khachhang,
                        Ten_khachhang = x.Ten_khachhang,
                        Diachi = x.Diachi,
                        Sodienthoai = x.Sodienthoai,
                        Ngaysinh = x.Ngaysinh,
                    })
                    .OrderByDescending(x => x.Ma_khachhang)
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

        public async Task<KhachhangVM> Laykhachhang(string ma_khachhang)
        {
            try
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                if (user == null)
                {
                    return null;
                }

                var roles = await _userManager.GetRolesAsync(user);
                IQueryable<Khachhang> query = _context.Khachhangs;

                // Nếu là Staff, lấy theo IdCustomer
                if (roles.Contains("Staff"))
                {
                    query = query.Where(x => x.Id == user.IdCustomer);
                }
                // Nếu là Customer, lấy theo Id của user
                else if (roles.Contains("Customer"))
                {
                    query = query.Where(x => x.Id == user.Id);
                }
                // Nếu là Admin, không cần thêm điều kiện
                // else if (!roles.Contains("Admin"))
                // {
                //     return null;
                // }

                var data = await query
                    .Where(x => x.Ma_khachhang == ma_khachhang)
                    .Select(x => new KhachhangVM
                    {
                        Ma_khachhang = x.Ma_khachhang,
                        Ten_khachhang = x.Ten_khachhang,
                        Diachi = x.Diachi,
                        Ngaysinh = x.Ngaysinh,
                        Sodienthoai = x.Sodienthoai,
                    })
                    .FirstOrDefaultAsync();

                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<bool> Suakhachhang(KhachhangVM khachhang)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Themkhachhang(KhachhangVM khachhang)
        {
            try
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                int nextNumber1 = 1;
                var lastMaDV = await _context.Khachhangs
                              .OrderByDescending(x => x.Ma_khachhang)
                              .Select(x => x.Ma_khachhang)
                              .FirstOrDefaultAsync();
                int nextNumber = 1;
                if (lastMaDV != null)
                {
                    nextNumber = int.Parse(lastMaDV.Substring(2)) + 1;
                }
                var mact = "KH" + nextNumber.ToString("D4");
                var kh=new Khachhang
                {
                    Ma_khachhang = mact,
                    Ten_khachhang = khachhang.Ten_khachhang,
                    Diachi = khachhang.Diachi,
                    Sodienthoai = khachhang.Sodienthoai,
                    Ngaysinh = khachhang.Ngaysinh,
                    Id = user.Id
                };
                await _context.Khachhangs.AddAsync(kh);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Xoakhachhang(string ma_khachhang)
        {
            try
            {
                var data = await _context.Khachhangs.FindAsync(ma_khachhang);
                if(data!=null)
                {
                    _context.Khachhangs.Remove(data);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
