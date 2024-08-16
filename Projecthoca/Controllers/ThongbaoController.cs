using Microsoft.AspNetCore.Mvc;
using Projecthoca.Migrations;
using Projecthoca.Service.Interface;

namespace Projecthoca.Controllers
{
    public class ThongbaoController : Controller
    {
        private readonly IThongbao _thongbao;

        public ThongbaoController(IThongbao thongbao)
        {
            _thongbao=thongbao;
        }
        [HttpGet]
        public async Task< IActionResult> dsthongbao()
        {
           try
            {
                var data=await _thongbao.danhsachtb();
                if (data.ds !=null )
                {
                    return Json(new { success = true ,data=data.ds,total=data.total });
                }else
                {
                    return Json(new { success = false });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, messeger=ex.Message });
            }   
        }
    }
}
