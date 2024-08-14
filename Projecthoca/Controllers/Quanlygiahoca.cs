using Microsoft.AspNetCore.Mvc;
using Projecthoca.Data;
using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;

namespace Projecthoca.Controllers
{
    public class Quanlygiahoca : Controller
    {
        private readonly IGiahoca _giahoca;

        public Quanlygiahoca(IGiahoca giahoca)
        {
            _giahoca= giahoca;
        }
        [HttpPost]
        public async Task<IActionResult> Themgia(GiahocaVM giahoca)
        {
            try
            {
                var data = await _giahoca.Themgiahoca(giahoca);
                if (data)
                {
                    return Json(new { success = true, message = "Thêm giá thành công" });
                }
                else
                {
                    return Json(new { success = false, message = "Thêm giá thất bại" });
                }
          

            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
                }
        }
        [HttpPost]
        public async Task<IActionResult> Danhsachgiahoca(int page, int pagesize)
        {
            try
            {
                var pageindex = page;
                var result = await _giahoca.Danhsachhoca(page, pagesize);
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
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost] 
        public async Task<IActionResult> Xoagia(int Ma_giahoca)
        {
            try
            {
                var data = await _giahoca.Xoagia(Ma_giahoca);
                if (data)
                {
                    return Json(new { success = true, message = "Xóa giá thành công" });
                }
                else
                {
                    return Json(new { success = false, message = "Xóa giá thất bại" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> Laygiatheoma(int Ma_giahoca)
        {
            try
            {
                var data = await _giahoca.Laytheomagia(Ma_giahoca);
                if (data != null)
                {
                    return Json(new { success = true, data = data });
                }
                else
                {
                    return Json(new { success = false, message = "Không tìm thấy giá" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Capnhatgia(GiahocaVM giahoca)
        {
            try
            {
                var data = await _giahoca.Capnhatgia(giahoca);
                if (data)
                {
                    return Json(new { success = true, message = "Cập nhật giá thành công" });
                }
                else
                {
                    return Json(new { success = false, message = "Cập nhật giá thất bại" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
