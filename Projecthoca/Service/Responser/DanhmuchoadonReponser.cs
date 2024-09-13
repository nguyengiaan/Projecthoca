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
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Themdanhmuchoadon(DanhmuchoadonVM danhmuchoadon)
        {
            try
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var roles = await _userManager.GetRolesAsync(user);
                var danhmuc = await _context.Danhmuc.Where(x => x.Ma_danhmuc == danhmuchoadon.Ma_danhmuc).FirstOrDefaultAsync();
                var kvc = await _context.Khuvuccau.Where(x => x.Ma_Khuvuccau == danhmuchoadon.Ma_khuvuc).FirstOrDefaultAsync();
                
                if (danhmuc == null)
                {
                    return false;
                }
                var _dmhd = new Danhmuchoadon();
                _dmhd.Ma_thuehoca = danhmuchoadon.Ma_thuehoca;
                _dmhd.Ma_danhmuc = danhmuchoadon.Ma_danhmuc;
                _dmhd.Soluong = danhmuchoadon.Soluong;
                _dmhd.thanhtien = danhmuc.Gia * danhmuchoadon.Soluong;
                await _context.danhmuchoadons.AddAsync(_dmhd);
                var _thongbao = new Thongbao();
                _thongbao.NgayDang = DateTime.Now.ToString();
                _thongbao.NoiDung = user.Hovaten+ " đã thêm dịch vụ " + danhmuc.Ten_danhmuc + " vào hóa đơn" + " tại khu vực " + kvc.Ten_Khuvuccau;
                if(roles.Contains("Staff"))
                {
                    _thongbao.Id = user.IdCustomer;
                }
                else
                {
                    _thongbao.Id = user.Id;
                }
             
                _thongbao.Trangthai = false;
                await _context.Thongbaos.AddAsync(_thongbao);
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
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Staff"))
                {
                    var data = await _context.Danhmuc.Where(x => x.Id == user.IdCustomer).Select(x => new DanhmucVM
                    {
                        Ma_danhmuc = x.Ma_danhmuc,
                        Ten_danhmuc = x.Ten_danhmuc,
                        Nhacungcap = x.Nhacungcap,

                    }).ToListAsync();
                    return data;
                }
                else
                {
                    var data = await _context.Danhmuc.Where(x => x.Id == user.Id).Select(x => new DanhmucVM
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

        public async Task<List<DanhmuchoadonVM>> Dsdmhd(string Ma_khuvuc)
        {
            try
            {
                var data1 = await _context.Thuehoca.Where(x => x.Ma_khuvuccau == Ma_khuvuc).FirstOrDefaultAsync();
                var data = await _context.danhmuchoadons.Where(x => x.Ma_thuehoca == data1.Ma_thuehoca).Select(x => new DanhmuchoadonVM
                {
                    Ma_thuehoca = x.Ma_thuehoca,
                    Ma_danhmuc = x.Ma_danhmuc,
                    Soluong = x.Soluong,
                    Thanhtien = x.thanhtien,
                    DVT = x.Danhmuc.Donvitinh,
                    Gia = x.Danhmuc.Gia,
                    
                    Ten_danhmuc = x.Danhmuc.Ten_danhmuc,
                    Ma_danhmuchoadon = x.Ma_danhmuchoadon
                }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> Xoadichvu(int Ma_danhmuchoadon)
        {
            try
            {
                var data = await _context.danhmuchoadons.FindAsync(Ma_danhmuchoadon);
                if (data == null)
                {
                    return false;
                }
                else
                {
                    _context.danhmuchoadons.Remove(data);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Themthoigian(GiachothuehcVM giachothuehc)
        {
            try
            {
                var data = await _context.Giahocas.FindAsync(giachothuehc.Ma_giahoca);
                var gct = new Giachothuehc();
                gct.Ma_giahoca = giachothuehc.Ma_giahoca;
                gct.Ma_thuehoca = giachothuehc.Ma_thuehoca;
                gct.Soluong = giachothuehc.Soluong;
                gct.Trangthai = giachothuehc.Trangthai;
                if (giachothuehc.Trangthai == "Coca")
                {
                    gct.Thanhtien = giachothuehc.Soluong * data.Gia_coca;

                }
                else
                {
                    gct.Thanhtien = giachothuehc.Soluong * data.Gia_khongca;
                }
                await _context.Giachothuehcs.AddAsync(gct);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<GiahocaVM>> Danhsachgiahoca()
        {
            try
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var roles = await _userManager.GetRolesAsync(user);
                if(roles.Contains("Staff"))
                {
                    var data = await _context.Giahocas.Where(x => x.Id == user.IdCustomer).Select(x => new GiahocaVM
                    {
                        Ma_giahoca = x.Ma_giahoca,
                        Ca = x.Ca,
                    }).ToListAsync();
                    return data;
                }
                else
                {
                    var data = await _context.Giahocas.Where(x => x.Id == user.Id).Select(x => new GiahocaVM
                    {
                        Ma_giahoca = x.Ma_giahoca,
                        Ca = x.Ca,
                    }).ToListAsync();
                    return data;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<GiachothuehcVM>> Danhsachthoigian(string KhuvucId)
        {
            try
            {
                var nguoidung = await _context.Thuehoca.Where(x => x.Ma_khuvuccau == KhuvucId).FirstOrDefaultAsync();
                var data = await _context.Giachothuehcs.Where(x => x.Ma_thuehoca == nguoidung.Ma_thuehoca).Select(x => new GiachothuehcVM
                {
                    Ma_giachothuehc = x.Ma_giachothuehc,
                    Ma_thuehoca = x.Ma_thuehoca,
                    Soluong = x.Soluong,
                    Trangthai = x.Trangthai,
                    Thanhtien = x.Thanhtien,
                    Ca = x.Giahoca.Ca,
                    Giaca = x.Trangthai == "Coca" ? x.Giahoca.Gia_coca : x.Giahoca.Gia_khongca,
                }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> Xoathoigian(int Ma_giachothuehc)
        {
            try
            {
                var data = await _context.Giachothuehcs.FindAsync(Ma_giachothuehc);
                if (data == null)
                {
                    return false;
                }
                else
                {
                    _context.Giachothuehcs.Remove(data);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<(bool, int)> Tongthanhtoan(string ma_khuvuc)
        {
            try
            {
                var thuehoca = await _context.Thuehoca
                    .FirstOrDefaultAsync(x => x.Ma_khuvuccau == ma_khuvuc);
                if (thuehoca == null)
                {
                    return (false, 0); // Không tìm thấy Thuehoca
                }

                // Xóa Hoadondanhmuc hiện có cho Thuehoca này
                var existingHoadondanhmuc = await _context.Hoadondanhmuc
                    .FirstOrDefaultAsync(x => x.Ma_thuehoca == thuehoca.Ma_thuehoca);
                if (existingHoadondanhmuc != null)
                {
                    _context.Hoadondanhmuc.Remove(existingHoadondanhmuc);
                }

                // Tính tổng thanh toán
                var totalSum = await _context.danhmuchoadons
                    .Where(x => x.Ma_thuehoca == thuehoca.Ma_thuehoca)
                    .SumAsync(x => (decimal?)x.thanhtien) ?? 0;

                totalSum += await _context.Giachothuehcs
                    .Where(x => x.Ma_thuehoca == thuehoca.Ma_thuehoca)
                    .SumAsync(x => (decimal?)x.Thanhtien) ?? 0;

                totalSum -= await _context.Tongsokg
                    .Where(x => x.Ma_thuehoca == thuehoca.Ma_thuehoca)
                    .SumAsync(x => (decimal?)x.Tongsotien) ?? 0;

                // Tạo Hoadondanhmuc mới
                var tong = new Hoadondanhmuc
                {
                    Tongthanhtoan = Convert.ToInt32(totalSum),
                    Ma_thuehoca = thuehoca.Ma_thuehoca,
                    Ma_hddm = Guid.NewGuid().ToString()
                };
                await _context.Hoadondanhmuc.AddAsync(tong);
                await _context.SaveChangesAsync();

                return (true, tong.Tongthanhtoan);
            }
            catch (Exception)
            {
                // Xử lý ngoại lệ một cách thích hợp
                return (false, 0);
            }
        }

        public async Task<HoadondanhmucVM> Laytongthangtoan(string KhuvucId)
        {
            try
            {
                var data = await _context.Thuehoca.Where(x => x.Ma_khuvuccau == KhuvucId).FirstOrDefaultAsync();
                if (data != null)
                {
                    var hoadon = await _context.Hoadondanhmuc.Where(x => x.Ma_thuehoca == data.Ma_thuehoca).Select(x => new HoadondanhmucVM
                    {
                        Ma_hddm = x.Ma_hddm,
                        Tongthanhtoan = x.Tongthanhtoan,

                    }).FirstOrDefaultAsync();
                    return hoadon;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> Giamgia(GiamgiaVM giamgia)
        {
            try
            {
                var data = await _context.Thuehoca.Where(x => x.Ma_khuvuccau == giamgia.Ma_khuvuc).FirstOrDefaultAsync();
                var hoadon = await _context.Hoadondanhmuc.Where(x => x.Ma_thuehoca == data.Ma_thuehoca).FirstOrDefaultAsync();
                if (hoadon == null)
                {
                    return false;
                }
                if (giamgia.Giamgiatien > 0 && giamgia.Giamgiatien <= 100)
                {
                    var discountAmount = hoadon.Tongthanhtoan * (giamgia.Giamgiatien / 100.0);
                    hoadon.Tongthanhtoan = hoadon.Tongthanhtoan - (int)discountAmount;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    hoadon.Tongthanhtoan = Convert.ToInt32(hoadon.Tongthanhtoan - giamgia.Giamgiatien);
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
        // thêm danh mục hóa đơn theo list danh mục trong hóa đơn

        public async Task<bool> Themdanhmuchoadonlst(DanhmuchdVM danhmuchoadon)
        {
            try
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var roles = await _userManager.GetRolesAsync(user);
                var danhmuc = await _context.Danhmuc.Where(x => x.Ma_danhmuc == danhmuchoadon.Ma_danhmuc).FirstOrDefaultAsync();
                var kvc = await _context.Khuvuccau.Where(x => x.Ma_Khuvuccau == danhmuchoadon.Ma_khuvuccau).FirstOrDefaultAsync();
                if (danhmuc == null)
                {
                    return false;
                }
                if (kvc == null)
                    {
                    return false;
                }
                var _dmhd = new Danhmuchoadon();
                _dmhd.Ma_thuehoca = danhmuchoadon.Ma_nguoithue;
                _dmhd.Ma_danhmuc = danhmuchoadon.Ma_danhmuc;
                _dmhd.Soluong = 1;
                _dmhd.thanhtien = danhmuc.Gia * _dmhd.Soluong;
                await _context.danhmuchoadons.AddAsync(_dmhd);
                var _thongbao = new Thongbao();
                _thongbao.NgayDang = DateTime.Now.ToString();
                _thongbao.NoiDung = user.Hovaten+ " thêm dịch vụ " + danhmuc.Ten_danhmuc + " vào hóa đơn" + " tại khu vực " + kvc.Ten_Khuvuccau;
                if(roles.Contains("Staff"))
                {
                    _thongbao.Id = user.IdCustomer;
                }
                else
                {
                    _thongbao.Id = user.Id;
                }
              
                _thongbao.Trangthai = false;
                await _context.Thongbaos.AddAsync(_thongbao);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Capnhatgiatien(int danhmuchanghoa,int Soluong)
        {
            try
            {
                var data=await _context.danhmuchoadons.Where(x => x.Ma_danhmuchoadon == danhmuchanghoa).FirstOrDefaultAsync();
                var dm = await _context.Danhmuc.Where(x => x.Ma_danhmuc == data.Ma_danhmuc).FirstOrDefaultAsync();
                if (data == null )
                {
                    return false;
                }
                data.Soluong= Soluong;
                data.thanhtien = dm.Gia * Soluong;
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
