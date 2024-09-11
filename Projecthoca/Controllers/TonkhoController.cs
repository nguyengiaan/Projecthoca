using Microsoft.AspNetCore.Mvc;
using Projecthoca.Service.Interface;

namespace Projecthoca.Controllers
{

    public class TonkhoController : Controller
    {
        private readonly ITonkho _tonkho;

        public TonkhoController(ITonkho tonkho)
        {
            _tonkho = tonkho;
        }
        [HttpPost]
        public async Task<IActionResult> TinhTonKhoNhieuNgay(int page, int pagesize, int endDate)
        {
            try
            {
                var data = await _tonkho.TinhTonKhoNhieuNgay(page, pagesize, endDate);
                if (data.dailyInventories == null)
                {
                    return Json(new { success = false, messeger = "Không có dữ liệu" });
                }
                 return Json(new { success = true, dsdm = data.dailyInventories, totalPages = data.totalpages, pageindex = page });
                
            }
            catch (Exception ex)
            {
                return Json(new { success = false, messeger = ex.Message });
            }
        }
    }
}