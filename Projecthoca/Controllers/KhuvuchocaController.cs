using Microsoft.AspNetCore.Mvc;
using Projecthoca.Helper;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;

namespace Projecthoca.Controllers
{
    public class KhuvuchocaController : Controller
    {
        private readonly IKhuvuccau _kvc;
        private readonly TimerBackgroundService _time;

        public KhuvuchocaController(IKhuvuccau kvc, TimerBackgroundService time)
        {
            _kvc = kvc;
            _time = time;
        }
        [HttpPost]
        public async Task<IActionResult> Themkhuvuc(KhuvuccauVM kv)
        {
            try
            {
                var errorList = ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList();
                if (!ModelState.IsValid)
                {
                    return Json(new { status = false, message = errorList });
                }
                if (ModelState.IsValid)
                {
                    var data = await _kvc.Themkhuvuccau(kv);
                    if (data)
                    {
                        return Json(new { success = true, message = "Thêm khu vực thành công" });
                    }
                    else
                    {
                        return Json(new { success = false, message = "Thêm khu vực không thành công" });
                    }
                }
                return Json(new { success = false, message = "Chúc bạn may mắn lần sau" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Danhsachkhuvuc(string Ma_hocau)
        {
            try
            {
                var data = await _kvc.Danhsachkhuvuccau(Ma_hocau);
                return Json(new { success = true, data = data });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Themkhachthue(ThuehocaVM th)
        {
            try
            {
                var errorList = ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList();
                if (!ModelState.IsValid)
                {
                    return Json(new { status = false, message = errorList });
                }
                if (ModelState.IsValid)
                {
                    var data = await _kvc.Themkhachthue(th);
                    if (data)
                    {
                        return Json(new { success = true, message = "Thêm người thuê thành công" });
                    }
                    else
                    {
                        return Json(new { success = false, message = "Thêm người thuê không thành công" });
                    }
                }
                return Json(new { success = false, message = "Chúc bạn may mắn lần sau" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Kiemtrakv(string Ma_khuvuc)
        {
            try
            {
                var data = await _kvc.Kiemtrakv(Ma_khuvuc);
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
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Laytoigian(string Ma_khuvvuc)
        {
            try
            {
                var data = await _kvc.Laythoigian(Ma_khuvvuc);
                if (data != null)
                {
                    return Json(new { success = true, Time = data });
                }
                else
                {
                    return Json(new { success = false });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBamgio(string Ma_khuvvuc)
        {
            try
            {
                var data = await _kvc.UpdateBamgio(Ma_khuvvuc);
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
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> KiemtraBamgio(string Ma_khuvvuc)
        {
            try
            {
                var data = await _kvc.KiemtraBamgio(Ma_khuvvuc);
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
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Dungthoigian(string Ma_khuvvuc)
        {
            try
            {
                var data = await _kvc.Dadungtg(Ma_khuvvuc);
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
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Xoakhuvuc(string Ma_khuvvuc)
        {
            try
            {
                var data = await _kvc.Deletekvc(Ma_khuvvuc);
                if (data)
                {
                    return Json(new { success = true, messeger = "Xóa thành công" });
                }
                else
                {
                    return Json(new { success = false, messeger = "Hãy thêm khu vực câu" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Xoakhachhang(string Ma_khuvvuc)
        {
            try
            {
                var data = await _kvc.Xoakhachthue(Ma_khuvvuc);
                if (data)
                {
                    return Json(new { success = true, messeger = "Xóa thành công" });
                }
                else
                {
                    return Json(new { success = false, messeger = "Hãy thêm khách hàng" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Laykhachthue(string Ma_khuvvuc)
        {
            try
            {
                var data = await _kvc.Laykhachthue(Ma_khuvvuc);
                if (data != null)
                {
                    return Json(new { success = true, data = data });
                }
                else
                {
                    return Json(new { success = false, messeger = "Hãy thêm khách hàng" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Chuyenbanthue(ChuyenbanVM chuyenban)
        {
            try
            {
                var data = await _kvc.Chuyenkhachthue(chuyenban);
                if (data)
                {
                    return Json(new { success = true, messeger = "Chuyển thành công" });
                }
                else
                {
                    return Json(new { success = false, messeger = "hãy thêm khách hàng" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // danh mục hiển thị trong hóa đơn
        [HttpPost]
        public async Task<IActionResult> Danhmuchthd(string Ma_mathang)
        {
            try
            {
                var data = await _kvc.Danhmuchthd(Ma_mathang);
                if (data != null)
                {
                    return Json(new { success = true, data = data });
                }
                else
                {
                    return Json(new { success = false, messeger = "Hãy thêm danh mục" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        //mặt hàng hiển thị trong hóa đơn
        [HttpGet]
        public async Task<IActionResult> Mathanghthd()
        {
            try
            {
                var data = await _kvc.Mathanghthd();
                if (data != null)
                {
                    return Json(new { success = true, data = data });
                }
                else
                {
                    return Json(new { success = false, messeger = "Hãy thêm mặt hàng" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Danhsachkhuvucvang(string Ma_hocau)
        {
            try
            {
                var data = await _kvc.Danhsachkhuvucvang(Ma_hocau);
                if (data != null)
                {
                    return Json(new { success = true, data = data });
                }
                else
                {
                    return Json(new { success = false, messeger = "Hãy thêm khu vực câu" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
