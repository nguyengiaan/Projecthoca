
using Microsoft.AspNetCore.Mvc;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;


namespace Projecthoca.Controllers
{
    public class DanhmucController : Controller
    {
        private readonly IDanhmuc _danhmuc;
        public DanhmucController(IDanhmuc danhmuc)
        {
            _danhmuc = danhmuc;
        }
        [HttpPost]
        public async Task<IActionResult> Themdanhmuc(DanhmucVM dm)
        {
            try
            {
                var errorList = ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList();
                if (!ModelState.IsValid)
                {
                    return Json(new { status = false, message = errorList });
                }
                var data = await _danhmuc.Themdanhmuc(dm);
                if (data)
                {
                    return Json(new { success = true, message = "Thêm danh mục thành công" });
                }
                else
                {
                    return Json(new { success = false, message = "Thêm danh mục không thành công" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Danhsachdanhmuc(int page, int pagesize)
        {
            try
            {
                var pageindex = page;
                var result = await _danhmuc.Danhsachdanhmuc(page, pagesize);
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
        public async Task<IActionResult> Xoadanhmuc(string Ma_danhmuc)
        {
            try
            {
                var data = await _danhmuc.Xoadanhmuc(Ma_danhmuc);
                if (data)
                {
                    return Json(new { success = true, message = "Xóa danh mục thành công" });
                }
                else
                {
                    return Json(new { success = false, message = "Xóa danh mục không thành công" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Suadanhmuc(DanhmucVM dm)
        {
            try
            {
                var data = await _danhmuc.Suadanhmuc(dm);
                if (data)
                {
                    return Json(new { success = true, message = "Sửa danh mục thành công" });
                }
                else
                {
                    return Json(new { success = false, message = "Sửa danh mục không thành công" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
       


        [HttpPost]
        public async Task<IActionResult> Laytheoma(string Ma_danhmuc)
        {
            try
            {
                var data = await _danhmuc.Laytheomadm(Ma_danhmuc);
                if (data != null)
                {
                    return Json(new { success = true, data = data });
                }
                else
                {
                    return Json(new { success = false, message = "Không tìm thấy danh mục" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // contronler đơn vị tính

        [HttpPost]
        public async Task<IActionResult> Themdvt(DonvitinhVM dvt)
        {
            try
            {
                var data = await _danhmuc.Themdonvitinh(dvt);
                if (data)
                {
                    return Json(new { success = true, message = "Thêm đơn vị tính thành công" });
                }
                else
                {
                    return Json(new { success = false, message = "Thêm đơn vị tính không thành công" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Danhsachdvt()
        {
            try
            {
                var data = await _danhmuc.Laydanhsachdvt();
                if (data != null)
                {
                    return Json(new { success = true, data = data });
                }
                else
                {
                    return Json(new { success = false, message = "Không có dữ liệu" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
 [HttpGet]
        public async Task<IActionResult> Danhsachnhacungcap()
        {
            try
            {
                var data = await _danhmuc.Danhsachnhacungcap();
                if (data != null)
                {
                    return Json(new { success = true, data = data });
                }
                else
                {
                    return Json(new { success = false, message = "Không có dữ liệu" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
         [HttpPost]
        public async Task<IActionResult> Themnhacungcap(NhacungcapVM ncc)
        {
            try
            {
                var data = await _danhmuc.Themnhacungcap(ncc);
                if (data)
                {
                    return Json(new { success = true, message = "Thêm nhà cung cấp thành công" });
                }
                else
                {
                    return Json(new { success = false, message = "Thêm nhà cung cấp không thành công" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
         [HttpPost]
        public async Task<IActionResult> Xoanhacungcap(string ma_nhacungcap)
        {
            try
            {
                var data = await _danhmuc.Xoanhacungcap(ma_nhacungcap);
                if (data)
                {
                    return Json(new { success = true, message = "Xóa nhà cung cấp thành công" });
                }
                else
                {
                    return Json(new { success = false, message = "Xóa nhà cung cấp không thành công" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Xoadonvitinh(string ma_donvitinh)
        {
            try
            {
                var data = await _danhmuc.Xoadonvitinh(ma_donvitinh);
                if (data)
                {
                    return Json(new { success = true, message = "Xóa đơn vị tính thành công" });
                }
                else
                {
                    return Json(new { success = false, message = "Xóa đơn vị tính không thành công" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        // [HttpPost]
        // public async Task<IActionResult> Capnhatsoluong(string ma_khuvuccau)
        // {
        //     try
        //     {
        //         var data = await _danhmuc.Capnhatsoluong(ma_khuvuccau);
        //         if (data)
        //         {
        //             return Json(new { success = true, message = "Cập nhật số lượng thành công" });
        //         }
        //         else
        //         {
        //             return Json(new { success = false, message = "Cập nhật số lượng không thành công" });
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         return Json(new { success = false, message = ex.Message });
        //     }
        // }

        [HttpPost]
public async Task<IActionResult> Capnhatsoluong(string ma_khuvuccau)
{
    try
    {
        // Gọi phương thức Capnhatsoluong từ repository hoặc service
        var isUpdated = await _danhmuc.Capnhatsoluong(ma_khuvuccau);

        if (isUpdated)
        {
            return Json(new { success = true, message = "Cập nhật số lượng thành công" });
        }
        else
        {
            return Json(new { success = false, message = "Cập nhật số lượng không thành công" });
        }
    }
    catch (Exception ex)
    {
        // Xử lý lỗi và trả về thông báo lỗi
        return Json(new { success = false, message = "Đã xảy ra lỗi: " + ex.Message });
    }
}

        // controller nhà cung cấp

        // controller mặt hàng
        [HttpPost]
        public async Task<IActionResult> Themmathang(MathangVM mh)
        {
            try
            {
                var data = await _danhmuc.Themmathang(mh);
                if (data)
                {
                    return Json(new { success = true, message = "Thêm mặt hàng thành công" });
                }
                else
                {
                    return Json(new { success = false, message = "Thêm mặt hàng không thành công" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Danhsachmh()
        {
            try
            {
                var data = await _danhmuc.Laydanhsachmh();
                if (data != null)
                {
                    return Json(new { success = true, data = data });
                }
                else
                {
                    return Json(new { success = false, message = "Không có dữ liệu" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Xoamathang(string ma_mathang)
        {
            try
            {
                var data = await _danhmuc.Xoamathang(ma_mathang);
                if (data)
                {
                    return Json(new { success = true, message = "Xóa mặt hàng thành công" });
                }
                else
                {
                    return Json(new { success = false, message = "Xóa mặt hàng không thành công" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> Laydanhsachhanghoa()
        {
            try
            {
                var data = await _danhmuc.Laydanhsachdanhmuc();
                if (data != null)
                {
                    return Json(new { success = true, data = data });
                }
                else
                {
                    return Json(new { success = false, message = "Không có dữ liệu" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
