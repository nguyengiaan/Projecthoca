using Microsoft.AspNetCore.Mvc;
using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;

namespace Projecthoca.Controllers
{
    public class KhachhangController : Controller
    {
        private readonly IKhachhang _khachhang;

        public KhachhangController(IKhachhang khachhang)
        {
            _khachhang= khachhang;
        }
        [HttpPost]
        public async Task< IActionResult> Themkhachhang(KhachhangVM kh)
        {
            try
            {
                var errorList = ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList();
                if (!ModelState.IsValid)
                {
                    return Json(new { status = false, message = errorList });
                }
                var result = await _khachhang.Themkhachhang(kh);
                if (result)
                {
                    return Json(new { status = true, message = "Thêm khách hàng thành công" });
                }
                return Json(new { status = false, message = "Thêm khách hàng thất bại" });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult>Danhsachkh(int page,int pagesize)
        {
            try
            {
                var pageindex = page;
                var result = await _khachhang.Danhsachkh(page, pagesize);
                if (result.ds != null && result.ds.Count > 0)
                {
                    var totalItems = result.ds.Count;
                    return Json(new { success = true, dsdm = result.ds, totalPages = result.totalpages, totalItems = totalItems, pageindex = pageindex });
                }
                else
                {
                    return Json(new { success = false, message = "Không có dữ liệu." });
                }
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = "Không có dữ liệu." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Laykhachhang(string ma_khachhang)
        {
            try
            {
                var data = await _khachhang.Laykhachhang(ma_khachhang);
                if(data!=null)
                {
                    return Json(new { success = true , data=data});
                }
                return Json(new { success = false, data = data });
            }
            catch(Exception ex)
            {
                return Json(new { success = false, data = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult>Capnhatkh(KhachhangVM kh)
        {
           try
            {
                var data = await _khachhang.Capnhatkhachhang(kh);
                if(data)
                {
                    return Json(new { success = true ,messege="Cập nhật thành công" }); 
                }
                else
                {
                    return Json(new { success = true, messege = "Sửa thất bại" });
                }
            }
            catch(Exception ex)
            {
                return Json(new { success = true, messege = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult>Xoakhachhang(string ma_kh)
        {
            try
            {
                var data = await _khachhang.Xoakhachhang(ma_kh);
                if(data)
                {
                    return Json(new { success = true  ,messege="Xóa thành công"});
                }
                return Json(new { success = false, messege = "Xóa thất bại" });
            }
            catch(Exception ex)
            {
                return Json(new { success = false, messege = ex.Message});
            }
        }
    }
}
