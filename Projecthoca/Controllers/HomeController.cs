using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projecthoca.Data;
using Projecthoca.Models;
using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;
using System.Diagnostics;


namespace Projecthoca.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbcontext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(MyDbcontext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin,Staff,Customer")]
        public IActionResult Index()
        {
            
            return View();
        }
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult Quanlytaikhoan()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Dangnhap()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Staff,Customer")]
        public async Task<IActionResult> Hocau()
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            if (User.IsInRole("Staff"))
            {
                var data1 = await _context.Hoca
                        .Where(h => h.Id == user.IdCustomer)
                        .Select(h => new HocaVM
                        {
                            Ten_hoca = h.Ten_hoca,
                            Id = h.Id,
                            Kieuhoca = h.Kieuhoca,
                            Ma_hoca = h.Ma_hoca
                        })
                        .FirstOrDefaultAsync();
                return View(data1);
            }
            else
            {
                var data = await _context.Hoca
                      .Where(h => h.Id == userId)
                      .Select(h => new HocaVM
                      {
                          Ten_hoca = h.Ten_hoca,
                          Id = h.Id,
                          Kieuhoca = h.Kieuhoca,
                          Ma_hoca = h.Ma_hoca
                      })
                      .FirstOrDefaultAsync();
                return View(data);

            }

        }

        [Authorize(Roles = "Admin,Staff,Customer")]
        public IActionResult Hoadonbanle()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Customer")]
        public IActionResult Quanlydanhmuc()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult Quanlygia()
        {
            return View();
        }
        public IActionResult Quanlythongbao()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult Quanlyphieuxuatkho()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Staff,Customer")]
        public IActionResult PrintBill()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult Quanlynhapkho()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult Quanlydonvitinh()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult Quanlymathang()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult Baocaoxuathang()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult Baocaonhapxuatton()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult Quanlynhacungcap()
        {
            return View();
        }

        // GET: Quanlyhanghoa
        [Authorize(Roles = "Admin,Customer")]
        public async Task<IActionResult> Quanlyhanghoa()
        {
            try
            {
                // Lấy danh sách sản phẩm từ cơ sở dữ liệu
                var products = await _context.Quanlyhanghoa.ToListAsync();

                // Chuyển đổi danh sách sản phẩm thành danh sách QuanlyhanghoaVM
                var productVMs = products.Select(p => new QuanlyhanghoaVM
                {
                    Ma_sanpham = p.Ma_sanpham,
                    Ten_sanpham = p.Ten_sanpham,
                    Ten_donvitinh = p.Ten_donvitinh,
                    Giaban = p.Giaban
                }).ToList();

                if (productVMs == null)
                {
                    return View();
                }
                return View(productVMs);
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                // Example: _logger.LogError(ex, "An error occurred while retrieving products.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult Quanlynhanvien()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Customer,Staff")]
        public IActionResult Loi404()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult Quanlyphanquyen()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult Quanlynhapkhonew()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Customer,Staff")]
        public IActionResult Quanlyxuatkhonew()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult Quanlykhachhang()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult Quanlytonkho()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult Nhapxuatton()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult Doanhthubanhang()
        {
            return View();
        }       
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult Baocaodoanhthuct()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
