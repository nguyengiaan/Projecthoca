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
        [HttpPost]
        public async Task<IActionResult>Tinhxuatnhapton(int page,int pagesize,DateTime Ngaybd,DateTime Ngaykt)
        {
            try
            {
                var data=   await _tonkho.Xuatnhapton(page,pagesize,Ngaybd,Ngaykt);
                if(data.ds==null)
                {
                    return Json(new { success = false, messeger = "Không có dữ liệu" });
                }
                return Json(new { success = true, dsdm = data.ds, totalPages = data.totalpages, pageindex = page });
            }
            catch(Exception ex)
            {
                return Json(new { success = false, messeger = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Danhsachnhpck(int page, int pagesize, string ma_hanghoa,DateTime Ngaybd,DateTime Ngaykt)
        {
            try
            {
                var data = await _tonkho.dspnck(page, pagesize, ma_hanghoa,Ngaybd,Ngaykt);
                if (data.ds == null)
                {
                    return Json(new { success = false, messeger = "Không có dữ liệu" });
                }
                return Json(new { success = true, dsdm = data.ds, totalPages = data.totalpages, pageindex = page });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, messeger = ex.Message });
            }
        }
         [HttpPost]
        public async Task<IActionResult> Danhsachxtck(int page, int pagesize, string ma_hanghoa,DateTime Ngaybd,DateTime Ngaykt)
        {
            try
            {
                var data = await _tonkho.dspxck(page, pagesize, ma_hanghoa,Ngaybd,Ngaykt);
                if (data.ds == null)
                {
                    return Json(new { success = false, messeger = "Không có dữ liệu" });
                }
                return Json(new { success = true, dsdm = data.ds, totalPages = data.totalpages, pageindex = page });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, messeger = ex.Message });
            }
        }
        // báo cáo doanh thu
        [HttpGet]
        public async Task<IActionResult> Baocaodoanhthu()
        {
            try
            {
                var item=await _tonkho.baocaodt();
                return Json(new {doanhso=item.ds,doanhthu=item.dt,tongvon=item.tongvon,loinhuan=item.loinhuan});
            }
            catch(Exception ex)
            {
                return Json(new { success = false, messeger = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Baocaodoanhthuct(DateTime NgayBd, DateTime NgayKt,int page,int pagesize)
        {
            try
            {
                var item=await _tonkho.Baocaodoanhthuct(NgayBd,NgayKt,page,pagesize);
                if(item!=null)
                {
                    return Json(new { success = true, dsdm = item,page=page,totalpages=item.Count });
                }   
                return Json(new { success = false, messeger = "Không có dữ liệu" });
            }
            catch(Exception ex)
            {
                return Json(new { success = false, messeger = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Baocaodoanhthuct1(DateTime NgayBd, DateTime NgayKt)
        {
            try
            {
                var item=await _tonkho.Baocaodoanhthuct1(NgayBd,NgayKt);
                if(item!=null)
                {
                    return Json(new { success = true, dsdm = item });
                }   
                return Json(new { success = false, messeger = "Không có dữ liệu" });
            }
            catch(Exception ex)
            {
                return Json(new { success = false, messeger = ex.Message });
            }
        }

    }
}