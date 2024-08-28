using Microsoft.AspNetCore.Mvc;
using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;

namespace Projecthoca.Controllers
{
    public class PhieuxuatkhoController : Controller
    {
        private readonly IPhieuxuatkho _phieuxuatkho;

        public PhieuxuatkhoController(IPhieuxuatkho phieuxuatkho)
        {
            _phieuxuatkho = phieuxuatkho;
        }
        [HttpPost]
        public async Task<IActionResult> Themphieuxuatkho(PhieuxuatkhoVM pxk)
        {
            try
            {
                var data = await _phieuxuatkho.Themphieuxuatkho(pxk);
                if (data)
                {
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Danhsachphieu(int page, int pagesize)
        {
            try
            {
                var pageindex = page;
                var data = await _phieuxuatkho.Danhsachphieu(page, pagesize);



                if (data.ds != null)
                {
                    var totalItems = data.ds.Count;
                    return Json(new { success = true, dsdm = data.ds, totalPages = data.totalpages, totalItems = totalItems, pageindex = page });
                }
                else
                {
                    return Json(new { success = false });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Xoaphieuxuat(string Ma_phieuxuatkho)
        {
            try
            {
                var data = await _phieuxuatkho.Xoaphieuxuat(Ma_phieuxuatkho);
                if (data)
                {
                    return Json(new { success = true, messeger = "Xóa thành công" });
                }
                else
                {
                    return Json(new { success = false, messeger = "Xóa thất bại" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, messeger = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Tongtientatcapx()
        {
            try
            {
                var data = await _phieuxuatkho.Tongtientatca();
                if (data.ckeck)
                {
                    return Json(new { success = true, tongtienck = data.tongtienchk, tongtienmat = data.tongtienmat, tongthanhtien = data.tongthanhtien, tongtien = data.tongtatca });
                }
                else
                {
                    return Json(new { success = false });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, messeger = ex.Message });
            }



        }
        // Contronller mã nhập

        [HttpPost]
        public async Task<IActionResult> Themphieunhapkho(List<DanhsachhhkhoVM> pnk)
        {
            try
            {
                var errorList = ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList();
                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, message = errorList });
                }
                var data = await _phieuxuatkho.Themphieunhapkho(pnk);
                if (data)
                {
                    return Json(new { success = true, message = "Thêm thành công" });
                }
                else
                {
                    return Json(new { success = false, message = "Thêm thất bại" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Danhsachphieunhapkho(int page, int pagesize)
        {
            try
            {
                var data = await _phieuxuatkho.Danhsachphieunhap(page, pagesize);
                if (data.ds != null)
                {
                    var totalItems = data.ds.Count;
                    return Json(new { success = true, dsdm = data.ds, totalPages = data.totalpages, totalItems = totalItems, pageindex = page });
                }
                else
                {
                    return Json(new { success = false });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }
        }

        [HttpPost] 
        public async Task<IActionResult> Xoaphieunhap(string Ma_phieunhapkho)
        {
            try
            {
                var data = await _phieuxuatkho.Xoaphieunhapkho(Ma_phieunhapkho);
                if (data)
                {
                    return Json(new { success = true, messeger = "Xóa thành công" });
                }
                else
                {
                    return Json(new { success = false, messeger = "Xóa thất bại" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, messeger = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Xemphieukho(string Ma_phieukho)
        {
            try
            {
                var data = await _phieuxuatkho.Xemphieukho(Ma_phieukho);
                if (data.Count > 0)
                {
                    return Json(new { success = true, data = data });
                }
                else
                {
                    return Json(new { success = false, });
                }
            }
            catch(Exception ex)
            {
                return Json(new { success = false, ex = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Suaphieuxuatkho(PhieuxuatkhoVM pxk)
        {
            try
            {
                var data = await _phieuxuatkho.Suaphieuxuatkho(pxk);
                if (data)
                {
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, });
            }
        }
    
[HttpGet]
public async Task<IActionResult> Xemphieuxuatkho(string Ma_phieuxuatkho)
{
    if (string.IsNullOrWhiteSpace(Ma_phieuxuatkho))
    {
        return Json(new { success = false, message = "Parameter Ma_phieuxuatkho is null or empty." });
    }

    try
    {
        var data = await _phieuxuatkho.Xemphieuxuatkho(Ma_phieuxuatkho);
        if (data != null)
        {
            return Json(new { success = true, data = data });
        }
        else
        {
            return Json(new { success = false, message = "No data found." });
        }
    }
    catch (Exception ex)
    {
        return Json(new { success = false, message = ex.Message });
    }
}  
    }
}
