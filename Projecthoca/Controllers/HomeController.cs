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

        public IActionResult Index()
        {
            
            return View();
        }
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

        public IActionResult Hoadonbanle()
        {
            return View();
        }
        public IActionResult Quanlydanhmuc()
        {
            return View();
        }
        public IActionResult Quanlygia()
        {
            return View();
        }
        public IActionResult Quanlythongbao()
        {
            return View();
        }
        public IActionResult Quanlyphieuxuatkho()
        {
            return View();
        }
        public IActionResult PrintBill()
        {
            return View();
        }

        public IActionResult Quanlynhapkho()
        {
            return View();
        }
        public IActionResult Quanlydonvitinh()
        {
            return View();
        }
        public IActionResult Quanlymathang()
        {
            return View();
        }
        public IActionResult Baocaoxuathang()
        {
            return View();
        }
         public IActionResult Baocaonhapxuatton()
        {
            return View();
        }
        // GET: Quanlyhanghoa
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

        public IActionResult Quanlynhanvien()
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
