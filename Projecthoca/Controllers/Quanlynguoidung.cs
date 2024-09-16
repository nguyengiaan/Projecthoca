using Microsoft.AspNetCore.Mvc;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;
using Microsoft.AspNetCore.Identity; // Thêm namespace này nếu bạn sử dụng Identity
using Microsoft.AspNetCore.Http; // Thêm namespace này để sử dụng HttpContext
namespace Projecthoca.Controllers
{
    public class Quanlynguoidung : Controller
    {
        
        private readonly INguoidung _nguoidung;
      
        public Quanlynguoidung(INguoidung nguoidung)
        {
            _nguoidung= nguoidung;
          
        }
        [HttpPost]
        public async Task<IActionResult> Dangkytaikhoan (NguoidungVM nguoidung)
        {
            try
            {
                var errorList = ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList();
                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, message = errorList });
                }
                var result = await _nguoidung.Dangkynguoidung(nguoidung);
                if (result.StatusCode == 1)
                {
                    return Json(new { success = true, message = "Đăng ký thành công" });
                }
                else
                {
                    return Json(new { success = false, message = result.Message });
                }
            }
            catch(Exception ex )
            {
                return Json(new { StatusCode = 0, Message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult>Danhsachtaikhoan(int page, int pagesize)
        {
            try
            {

                var pageindex = page;
                var result = await _nguoidung.Laydanhsachnguoidung(page, pagesize);
                if (result.ds != null && result.ds.Count > 0)
                {
                    var totalItems = result.ds.Count;
                    return Json(new { success = true, users = result.ds, totalPages = result.totalpages, totalItems = totalItems, pageindex = pageindex });
                }
                else
                {
                    return Json(new { success = false, message = "Không có dữ liệu." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Có lỗi xảy ra: {ex.Message}" });
            }
        }
        [HttpPost]
        public async Task<IActionResult>Dangnhaptaikhoan(DangnhapVM user)
        {
            try
            {
                var errorList = ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList();
                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, messeger = errorList });
                }

                var data= await _nguoidung.Dangnhap(user);
                if (data.StatusCode==1)
                {
                    
                    return Json(new { success = true ,messeger=data.Message });
                }
                else
                {
                    return Json(new { success = false, messeger = data.Message });
                }
            }
            catch(Exception ex)
            {
                return Json(new { success = false, messeger =ex.Message });
            }
        }

        public async Task<IActionResult> Dangxuat()
        {
            await _nguoidung.LogoutAsync();
            return RedirectToAction("Dangnhap", "Home");
        }

        // nhân viên 
        [HttpPost]
        public async Task<IActionResult>Dangkynhanvien(NhanvienVM nhanvien)
        {
            try
            {
                var errorList = ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList();
                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, message = errorList });
                }
                var data = await _nguoidung.Dangkynhanvien(nhanvien);
                if(data.StatusCode== 1)
                {
                    return Json(new { success = true, messege = data.Message });
                }
                else
                {
                    return Json(new { success = false, messege = data.Message });
                }
            }
            catch(Exception ex)
            {
                return Json(new { success = false, messege = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Danhsachnv(int page, int pagesize)
        {
            try
            {

                var pageindex = page;
                var result = await _nguoidung.Laydanhsachnv(page, pagesize);
                if (result.ds != null && result.ds.Count > 0)
                {
                    var totalItems = result.ds.Count;
                    return Json(new { success = true, users = result.ds, totalPages = result.totalpages, totalItems = totalItems, pageindex = pageindex });
                }
                else
                {
                    return Json(new { success = false, message = "Không có dữ liệu." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Có lỗi xảy ra: {ex.Message}" });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Xoanguoidung(string Id)
        {
            try
            {
                var data = await _nguoidung.Xoanhanvien(Id);
                if (data)
                {
                    return Json(new { success = true, messege = "Xóa thành công"});
                }
                else
                {
                    return Json(new { success = false, messege = "Xóa thất bại" });
                }

            }
            catch(Exception ex)
            {
                return Json(new { success = false, messege = ex.Message });
            }
        }


        // Phương thức mới để lấy thông tin người dùng đã đăng nhập
        [HttpGet]
        public async Task<IActionResult> LayThongTinNguoiDungDaDangNhap()
        {
            try
            {
                var user = await _nguoidung.LayThongTinNguoiDungDaDangNhap();
                if (user != null)
                {
                    return Json(new { success = true, users = user });
                }
                else
                {
                    return Json(new { success = false, message = "Không tìm thấy thông tin người dùng." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Có lỗi xảy ra: {ex.Message}" });
            }
        }
    }
}
