using Microsoft.AspNetCore.Mvc;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;

namespace Projecthoca.Controllers
{
    public class ChitietcaController : Controller
    {
        private readonly IChitietca _ctc;

        public ChitietcaController(IChitietca ctc)
        {
            _ctc = ctc;
        }
        [HttpPost]
        public async Task<IActionResult> ThemCa(ChitietcaVM chitietca)
        {
            try
            {
                var errorList = ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList();
                if (!ModelState.IsValid)
                {
                    return Json(new { status = false, message = errorList });
                }
                
                var data = await _ctc.ThemCa(chitietca);
                if (data)
                {
                    return Json(new { success = true, messege="Thêm thành công" }); 
                }
                else
                {
                    return Json(new { success = true, messege = "Thêm thất bại" });
                }
            }
            catch(Exception ex)
            {
                return Json(new { success = true, messege = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Danhsachhs()
        {
            try
            {
                var data = await _ctc.Danhsachdanhmuchs();
                return Json(new { success = true, data = data });
            }
            catch (Exception ex)
            {
                return Json(new { success = true, messege = ex.Message });
            }
        }

    }
}
