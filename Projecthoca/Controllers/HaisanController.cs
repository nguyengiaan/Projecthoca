
using Microsoft.AspNetCore.Mvc;
using Projecthoca.Migrations;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;
using System.Collections.Generic;

namespace Projecthoca.Controllers
{
 
    public class HaisanController : Controller
    {
        private readonly IHaisan _haisan;

        public HaisanController(IHaisan haisan)
        {
            _haisan = haisan;
        }
        [HttpPost]
       
        public  async Task <IActionResult> Danhsachhaisan(int page,int pagesize)
        {
           try
           {
                var pageindex = page;
                var result = await _haisan.Danhsachhaisan(page, pagesize);
                if (result.ds != null && result.ds.Count > 0)
                {
                    var totalItems = result.ds.Count;
                    return Json(new { success = true, dsdm = result.ds, totalPages = result.totalPages, totalItems = totalItems, pageindex = pageindex });
                }
                else
                {
                    return Json(new { success = false, message = "Không có dữ liệu." });
                }
           }
           catch(Exception ex)
           {
               return Json(new { success = false, message = ex.Message });
           }    
        }
        [HttpPost]   
        public async Task <IActionResult> Themhaisan(HaisanVM hs)
        {
            try
            {
                 if(ModelState.IsValid)
                 {
                     var result = await _haisan.Themhaisan(hs);
                     if(result)
                     {
                         return Json(new { success = true, message = "Thêm thành công" });
                     }
                     else
                     {
                         return Json(new { success = false, message = "Thêm thất bại" });
                     }
                 }
                 else
                 {
                     var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                     return Json(new { success = false, message = "Thêm thất bại", errors });
                 }
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }   
        }
        [HttpPost]
        public async Task<IActionResult> Laythongtinhaisan(int Ma_haisan)
        {
            try
            {
                var result = await _haisan.Laythongtinhaisan(Ma_haisan);
                if(result != null)
                {
                    return Json(new { success = true, data = result });
                }
                else
                {
                    return Json(new { success = false, message = "Không có dữ liệu." });
                }
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }   
        [HttpPost]
        public async Task<IActionResult> Suahaisan(HaisanVM hs)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var result = await _haisan.Suahaisan(hs);
                    if(result)
                    {
                        return Json(new { success = true, message = "Sửa thành công" });
                    }
                    else
                    {
                        return Json(new { success = false, message = "Sửa thất bại" });
                    }
                }
                else
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return Json(new { success = false, message = "Sửa thất bại", errors });
                }
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Xoahaisan(int Ma_haisan)
        {
            try
            {
                var result = await _haisan.Xoahaisan(Ma_haisan);
                if(result)
                {
                    return Json(new { success = true, message = "Xóa thành công" });
                }
                else
                {
                    return Json(new { success = false, message = "Xóa thất bại" });
                }
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}