﻿using Microsoft.AspNetCore.Mvc;
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
            catch(Exception ex )
            {
                return Json(new { success = false ,});
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
                    return Json(new { success = true ,messeger="Xóa thành công"});
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
    }
}
