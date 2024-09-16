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
                  var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var totalItems = _context.Danhmuc.Where(x=>x.Id==user.Id).Count();
                var totalpages = (int)Math.Ceiling(totalItems / (double)pagesize);
              
                var dm = await _context.Danhmuc
                        .Where(x => x.Id == user.Id && x.Ma_danhmuc != "DM0000")
                         .Select(x => new DanhmucVM
                         {
                             Ma_danhmuc = x.Ma_danhmuc,
                             Ten_danhmuc = x.Ten_danhmuc,
                             Gia = x.Gia,
                             Donvitinh = x.Donvitinh,
                             Id = x.Id,
                             Ma_mathang = x.Mathang.Ten_mathang,
                             Soluong = x.Soluong,
                             Nhacungcap = x.Nhacungcap,
                             Gianhap=x.Gianhap,
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
                    Nhacungcap = x.Nhacungcap,
                    Gianhap = x.Gianhap,
                    Ma_mathang = x.Mathang.Ten_mathang,
                  
                  

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
                    data.Ma_mathang = danhmuc.Ma_mathang;
                    data.Nhacungcap = danhmuc.Nhacungcap;
                    data.Gianhap = danhmuc.Gianhap;
                    data.Soluong = danhmuc.Soluong;
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
                _dm.Ma_danhmuc = madm;
                _dm.Ma_mathang = danhmuc.Ma_mathang;
                _dm.Ten_danhmuc = danhmuc.Ten_danhmuc;
                _dm.Gia = danhmuc.Gia;
                _dm.Donvitinh = danhmuc.Donvitinh;
                _dm.Nhacungcap = danhmuc.Nhacungcap;
                _dm.Gianhap = danhmuc.Gianhap;
                _dm.Soluong = danhmuc.Soluong;
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

        // hàm reponser đơn vị tính
        public async Task<bool> Themdonvitinh(DonvitinhVM donvitinh)
        {
            try
            {
                int nextNumber = 1;
                var lastMaDV = await _context.Donvitinhs
                              .OrderByDescending(x => x.Ma_donvitinh)
                              .Select(x => x.Ma_donvitinh)
                              .FirstOrDefaultAsync();

                if (lastMaDV != null)
                {
                    nextNumber = int.Parse(lastMaDV.Substring(2)) + 1;
                }
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var madv = "DV" + nextNumber.ToString("D4");
                var _dv = new Donvitinh();
                _dv.Ma_donvitinh = madv;
                _dv.Ten_donvitinh = donvitinh.Ten_donvitinh;
                _dv.Id = user.Id;
                await _context.Donvitinhs.AddAsync(_dv);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<List<DonvitinhVM>> Laydanhsachdvt()
        {
            try
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var data = await _context.Donvitinhs
                           .Where(x => x.Id == user.Id)
                           .Select(x => new DonvitinhVM
                           {
                               Ma_donvitinh = x.Ma_donvitinh,
                               Ten_donvitinh = x.Ten_donvitinh,
                               Id = x.Id
                           }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
           public async Task<bool> Themnhacungcap(NhacungcapVM nhacungcap)
        {
            try
            {
                int nextNumber = 1;
                var lastMaNCC = await _context.Nhacungcap
                              .OrderByDescending(x => x.Ma_nhacungcap)
                              .Select(x => x.Ma_nhacungcap)
                              .FirstOrDefaultAsync();

                if (lastMaNCC != null)
                {
                    nextNumber = int.Parse(lastMaNCC.Substring(2)) + 1;
                }
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var mancc = "CC" + nextNumber.ToString("D4");
                var _ncc = new Nhacungcaps();
                _ncc.Ma_nhacungcap = mancc;
                _ncc.Nhacungcap = nhacungcap.Nhacungcap;
                _ncc.Id = user.Id;
                await _context.Nhacungcap.AddAsync(_ncc);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<List<NhacungcapVM>>Danhsachnhacungcap()
                {
                    try
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var data = await _context.Nhacungcap
                           .Where(x => x.Id == user.Id)
                           .Select(x => new NhacungcapVM
                           {
                               Ma_nhacungcap = x.Ma_nhacungcap,
                               Nhacungcap = x.Nhacungcap,
                               Id = x.Id
                           }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
                }
  public async Task<bool> Xoanhacungcap(string ma_nhacungcap)
        {
            try
            {
                var data = await _context.Nhacungcap.FindAsync(ma_nhacungcap);
                if (data != null)
                {
                    _context.Nhacungcap.Remove(data);
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
        public async Task<bool> Xoadonvitinh(string madonvitinh)
        {
            try
            {
                var data = await _context.Donvitinhs.FindAsync(madonvitinh);
                if (data != null)
                {
                    _context.Donvitinhs.Remove(data);
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
        // hàm reponser mặt hàng
        public async Task<bool> Themmathang(MathangVM mathang)
        {
            try
            {
                int nextNumber = 1;
                var lastMaDV = await _context.Mathangs
                              .OrderByDescending(x => x.Ma_mathang)
                              .Select(x => x.Ma_mathang)
                              .FirstOrDefaultAsync();
                if (lastMaDV != null)
                {
                    nextNumber = int.Parse(lastMaDV.Substring(2)) + 1;
                }
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var mamh = "MH" + nextNumber.ToString("D4");
                var _mh = new Mathang();
                _mh.Ma_mathang = mamh;
                _mh.Ten_mathang = mathang.Ten_mathang;
                _mh.Id = user.Id;
                await _context.Mathangs.AddAsync(_mh);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        // hàm lấy danh sách mặt hàng
        public async Task<List<MathangVM>> Laydanhsachmh()
        {
            try
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var data = await _context.Mathangs.Where(x => x.Id == user.Id).Select(x => new MathangVM
                {
                    Ma_mathang = x.Ma_mathang,
                    Ten_mathang = x.Ten_mathang,

                }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> Xoamathang(string mamathang)
        {
            try
            {
                var data = await _context.Mathangs.FindAsync(mamathang);
                if (data != null)
                {
                    _context.Mathangs.Remove(data);
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
        // cập nhật số lượng hàng hóa
      public async Task<bool> Capnhatsoluong(string ma_khuvuc)
{
    try
    {
        if (string.IsNullOrEmpty(ma_khuvuc))
        {
            Console.WriteLine("Mã khu vực cầu trống hoặc null.");
            return false;
        }

        // Truy vấn dữ liệu liên quan
        var data = await (from kvc in _context.Khuvuccau
                          join nt in _context.Thuehoca on kvc.Ma_Khuvuccau equals nt.Khuvuccau.Ma_Khuvuccau
                          join dmhd in _context.danhmuchoadons on nt.Ma_thuehoca equals dmhd.Ma_thuehoca
                          join dm in _context.Danhmuc on dmhd.Ma_danhmuc equals dm.Ma_danhmuc
                          where kvc.Ma_Khuvuccau == ma_khuvuc
                          select new
                          {
                              dm.Ma_danhmuc,
                              SoluongGiam = dmhd.Soluong // Số lượng cần giảm, lấy từ bảng danhmuchoadons
                          }).ToListAsync();

        if (data != null && data.Count > 0)
        {
            // Cập nhật số lượng trong bảng `Danhmuc`
            foreach (var item in data)
            {
                var dm = await _context.Danhmuc.FindAsync(item.Ma_danhmuc);
                if (dm != null && item.SoluongGiam > 0)
                {
                    Console.WriteLine($"Cập nhật số lượng cho danh mục: {dm.Ma_danhmuc}, Số lượng giảm: {item.SoluongGiam}");
                    dm.Soluong -= item.SoluongGiam; // Giảm số lượng theo số lượng cần giảm

                    // Đảm bảo số lượng không âm
                    if (dm.Soluong < 0)
                    {
                        dm.Soluong = 0;
                    }

                    _context.Danhmuc.Update(dm); // Cập nhật trong context
                }
                 else
                {
                    Console.WriteLine($"Không tìm thấy danh mục hoặc số lượng giảm không hợp lệ: {item.Ma_danhmuc}");
                }

            }


            // Lưu thay đổi vào database
            await _context.SaveChangesAsync();
            return true;
        }

         Console.WriteLine("Không có dữ liệu để cập nhật.");
        return false; // Trả về false nếu không có dữ liệu để cập nhật
    }
    catch (Exception ex)
    {

        Console.WriteLine($"Lỗi xảy ra khi cập nhật số lượng: {ex.Message}");
        throw; // Ném lại ngoại lệ để controller có thể bắt và trả về thông tin lỗi chi tiết
    }
}




        public async Task<List<DanhmucVM>> Laydanhsachdanhmuc()
        {
            try
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var data = await _context.Danhmuc
                .Where(x => x.Id == user.Id && x.Ma_danhmuc != "DM0000")
                .Select(x => new DanhmucVM
                {
                    Ma_danhmuc = x.Ma_danhmuc,
                    Ten_danhmuc = x.Ten_danhmuc,
                    Gia = x.Gia,
                    Donvitinh = x.Donvitinh,
                    Id = x.Id,
                    Ma_mathang = x.Mathang.Ten_mathang,
                    Soluong = x.Soluong,
                    Nhacungcap = x.Nhacungcap,
                    Gianhap = x.Gianhap,

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
