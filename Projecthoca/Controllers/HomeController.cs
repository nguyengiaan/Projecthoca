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
            _context=context;
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
        public async Task <IActionResult> Hocau()
        {
            var userId = _userManager.GetUserId(User);
            var data = await _context.Hoca
                          .Where(h => h.Id == userId)
                          .Select(h => new HocaVM
                          {
                              Ten_hoca = h.Ten_hoca,
                              Id= h.Id,
                              Kieuhoca = h.Kieuhoca,
                              Ma_hoca = h.Ma_hoca
                          })
                          .FirstOrDefaultAsync();
  

            return View(data);
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

        public IActionResult Quanlynhapkho()
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
