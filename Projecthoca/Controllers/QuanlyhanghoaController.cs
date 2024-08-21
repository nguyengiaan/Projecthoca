using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projecthoca.Data;
using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Projecthoca.Controllers
{
    public class QuanlyhanghoaController : Controller
    {
        private readonly MyDbcontext _context;
         private readonly UserManager<ApplicationUser> _userManager;
           private readonly IHttpContextAccessor _httpContextAccessor;

        public QuanlyhanghoaController(MyDbcontext context,UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Quanlyhanghoa
        public async Task<IActionResult> Quanlyhanghoa()
        {
            try
            {
                var products = await _context.Quanlyhanghoa
                    .Select(p => new QuanlyhanghoaVM
                    {
                        Ten_sanpham = p.Ten_sanpham,
                        Ten_donvitinh = p.Ten_donvitinh,
                        Giaban = p.Giaban
                    })
                    .ToListAsync();

                return View(products);
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                // Example: _logger.LogError(ex, "An error occurred while retrieving products.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

       


        [HttpPost]
        public async Task<IActionResult> Create(QuanlyhanghoaVM productVM)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return Json(new { success = false, message = "Dữ liệu không hợp lệ.", errors });
            }

            try
            {
                 int nextNumber1 = 1;
                var lastMaSP = await _context.Quanlyhanghoa
                              .OrderByDescending(x => x.Ma_sanpham)
                              .Select(x => x.Ma_sanpham)
                              .FirstOrDefaultAsync();
                int nextNumber = 1;
                if (lastMaSP != null)
                {
                    nextNumber = int.Parse(lastMaSP.Substring(2)) + 1;
                }
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var masp = "SP" + nextNumber.ToString("D4");
                var product = new Quanlyhanghoa
                {
                    Ma_sanpham = masp,
                    Ten_sanpham = productVM.Ten_sanpham,
                    Ten_donvitinh = productVM.Ten_donvitinh,
                    Giaban = productVM.Giaban,
                    Id = user.Id
                };

                _context.Add(product);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Sản phẩm đã được thêm thành công." });
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                // Example: _logger.LogError(ex, "An error occurred while creating a product.");
                return StatusCode(500, "Đã xảy ra lỗi trong khi tạo sản phẩm. Vui lòng thử lại sau.");
            }
        }

    }
}
