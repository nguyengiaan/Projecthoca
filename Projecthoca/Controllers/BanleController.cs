using Microsoft.AspNetCore.Mvc;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;

namespace Projecthoca.Controllers
{
    public class BanleController : Controller
    {
        private readonly IBanle _bl;
        public BanleController(IBanle bl)
        {
            _bl = bl;
        }

        [HttpPost]
        public async Task<IActionResult> Themkhbanle(ThuehocaVM thuehocaVM)
        {
           try
            {
                var data=await _bl.Themkhachhang(thuehocaVM);
                if(data.kq)
                {
                   return Json(new { success = true, message = "Thêm khách hàng thành công" ,MaKhuvuc=data.ma_kvc, Mathuehoca= data.ma_thc , Tenkhachhang=data.ten_kh, Ngaymua=data.ngay_mua});
                }
                else
                {
                    return Json(new { success = false, message = "Thêm khách hàng không thành công" });
                }

            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
