using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> Docthongbao(int Ma_thongbao)
        {
            try
            {
                var data= await _thongbao.docthongbao(Ma_thongbao);
                if(data)
                {
                    return Json(new { success = true, messeger = "Bạn đã đọc thông báo " });
                }
                return Json(new { success = false, messeger = "Bạn chưa đọc thông báo  " });
            }
            catch(Exception ex)
            {
                return Json(new { success = false, messeger = ex.Message });
            }
        }
    }
}
