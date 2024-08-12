using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;
using System.Security.Claims;

namespace Projecthoca.Controllers
{
    public class Quanlyhoca : Controller
    {
        private readonly IHoca _hc;
        private readonly UserManager<ApplicationUser> _userManager;

        public Quanlyhoca(IHoca hc, UserManager<ApplicationUser> userManager)
        {
            _hc = hc;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> themhoca(HocaVM hoca)
        {

            try
            {
                var errorList = ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList();
                if (!ModelState.IsValid)
                {
                    TempData["ErrorMessage"] = string.Join("; ", errorList); 
                    return RedirectToAction("Hocau", "Home");
                }
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    hoca.Id = user.Id;
                    var data = await _hc.Themhoca(hoca);
                    if (data)
                    {
                        return RedirectToAction("Hocau", "Home");
                    }
                }
                TempData["ErrorMessage"] = "Thêm hồ cá thất bại";
                return RedirectToAction("Hocau", "Home");

            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Hocau", "Home");
            }
        }


    }
}
