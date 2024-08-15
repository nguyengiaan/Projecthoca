using Microsoft.AspNetCore.Mvc;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;

namespace Projecthoca.Controllers
{
    public class DanhmuchoadonController : Controller
    {
        private readonly IDanhmuchoadon _dmhd;

        public DanhmuchoadonController(IDanhmuchoadon dmhd)
        {
            _dmhd = dmhd;
        }
        [HttpPost]
        public async Task< IActionResult> Themdanhmuchd(DanhmuchoadonVM danhmuchoadon)
        {
            try
            {
                var data=await _dmhd.Themdanhmuchoadon(danhmuchoadon);
                if(data)
                {
                   return Json(new { success = true, message = "Thêm danh mục hóa đơn thành công" });
                }
                else
                {
                    return Json(new { success = false, message = "Thêm danh mục hóa đơn không thành công" });
                }
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult>Danhmucdv()
        {
            try
            {
                var data = await _dmhd.Danhsachdanhmucdv();
                return Json(new { success = true, data = data });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Dsdmhd(string Ma_thuehoca)
        {
            try
            {
                var data = await _dmhd.Dsdmhd(Ma_thuehoca);
                return Json(new { success = true, data = data });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
