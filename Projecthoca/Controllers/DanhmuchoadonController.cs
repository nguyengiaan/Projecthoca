using Microsoft.AspNetCore.Mvc;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;

namespace Projecthoca.Controllers
{
    public class DanhmuchoadonController : Controller
    {
        private readonly IDanhmuchoadon _dmhd;

        public DanhmuchoadonController(IDanhmuchoadon dmhd)
        {
            _dmhd = dmhd;
        }
        [HttpPost]
        public async Task< IActionResult> Themdanhmuchd(DanhmuchoadonVM danhmuchoadon)
        {
            try
            {
                var data=await _dmhd.Themdanhmuchoadon(danhmuchoadon);
                if(data)
                {
                   return Json(new { success = true, message = "Thêm danh mục hóa đơn thành công" });
                }
                else
                {
                    return Json(new { success = false, message = "Thêm danh mục hóa đơn không thành công" });
                }
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult>Danhmucdv()
        {
            try
            {
                var data = await _dmhd.Danhsachdanhmucdv();
                return Json(new { success = true, data = data });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Dsdmhd(string Ma_khuvuc)
        {
            try
            {
                var data = await _dmhd.Dsdmhd(Ma_khuvuc);
                return Json(new { success = true, data = data });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult>Xoadichvu(int Ma_danhmuchoadon)
        {
            try
            {
                var data= await _dmhd.Xoadichvu(Ma_danhmuchoadon);
                if(data)
                {
                    return Json(new { success = true, message = "Xóa dịch vụ thành công" });
                }else
                {
                    return Json(new { success = false, message = "Xóa dịch vụ thất bại" });
                }
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult>Danhsachca()
        {
            try
            {
                var data= await _dmhd.Danhsachgiahoca();
                if(data != null)
                {
                    return Json(new { success = true, data = data });
                }
                else
                {
                    return Json(new { success = false, message = "Không có dữ liệu" });
                }
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult>Themthoigian(GiachothuehcVM giachothuehc)
        {
            try
            {
                var data= await _dmhd.Themthoigian(giachothuehc);
                if(data)
                {
                    return Json(new { success = true, message = "Thêm ca thành công" });
                }else
                {
                    return Json(new { success = false, message = "Thêm ca thất bại" });
                }
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult>Danhsachthoigian(string KhuvucId)
        {
            try
            {
                var data = await _dmhd.Danhsachthoigian(KhuvucId);  
                if(data !=null)
                {
                    return Json(new { success = true, data = data });
                }else
                {
                    return Json(new { success = false, data = "Kho có data" });
                }
            }
            catch(Exception ex)
            {
                return Json(new { success = false, data =ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult>Xoathoigian(int Ma_giachothuehc)
        {
            try
            {
                var data= await _dmhd.Xoathoigian(Ma_giachothuehc);
                if(data)
                {
                    return Json(new { success = true, message = "Xóa ca thành công" });
                }else
                {
                    return Json(new { success = false, message = "Xóa ca thất bại" });
                }
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Tongtienhd(string khuVucId)
        {
            try
            {
                var data= await _dmhd.Tongthanhtoan(khuVucId);
                if(data.Item1 )
                {
                    return Json(new { success = true ,tongthanhtoan=data.Item2});
                }else
                {
                    return Json(new { success = false });
                }
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Laytongthanhtoan(string khuVucId)
        {
            try
            {
                var data = await _dmhd.Laytongthangtoan(khuVucId);
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
        public async Task<IActionResult>Giamgia(GiamgiaVM giamgia)

        {
            try
            {
                var data= await _dmhd.Giamgia(giamgia);
                if(data)
                {
                    return Json(new { success = true }) ;
                }else
                {
                    return Json(new { success = false, message = "Giảm giá thất bại" });
                }
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Themdanhmuchdlst(DanhmuchdVM danhmuchoadon)
        {
            try
            {
                var data = await _dmhd.Themdanhmuchoadonlst(danhmuchoadon);
                if (data)
                {
                    return Json(new { success = true, message = "Thêm danh mục hóa đơn thành công" });
                }
                else
                {
                    return Json(new { success = false, message = "Thêm danh mục hóa đơn không thành công" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        // cập nhật số lượng hợp đồng

        [HttpPost]
        public async Task<IActionResult>Capnhatsoluonghd(int ma_danhmuchoadon,int soluong)
        {
            try
            {
                var data = await _dmhd.Capnhatgiatien(ma_danhmuchoadon,soluong);
                if (data)
                {
                    return Json(new { success = true, message = "Cập nhật số lượng thành công" });
                }
                else
                {
                    return Json(new { success = false, message = "Cập nhật số lượng thất bại" });
                }
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    
        
        
    
    }
   
}
