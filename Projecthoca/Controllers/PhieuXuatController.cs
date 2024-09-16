using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projecthoca.Data;
using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;

namespace Projecthoca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhieuXuatController : ControllerBase
    {
        private readonly MyDbcontext _context;

      private readonly UserManager<ApplicationUser> _userManager;
        public PhieuXuatController(MyDbcontext context,UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager=userManager;
        }



        
        // GET: /api/PhieuNhap/LayTatCaPhieuNhap
[HttpGet("LayTatCaPhieuXuat")]
public async Task<IActionResult> LayTatCaPhieuXuat()
{

    var user = await _userManager.GetUserAsync(User);
    if (user == null)
    {
        return Unauthorized(new { success = false, message = "Người dùng chưa đăng nhập" });
    }


    var phieuXuats = await _context.PhieuXuats
        .Where(p => p.Id == user.Id)
        .Include(p => p.ChiTietPhieuXuats) // Bao gồm chi tiết phiếu nhập
            .ThenInclude(c => c.Danhmuc) // Bao gồm Danhmuc trong chi tiết phiếu nhập
        .ToListAsync();

    // Sắp xếp theo số phiếu giảm dần
    var sortedPhieuXuats = phieuXuats
        .OrderByDescending(p => 
        {
            // Tách phần số từ soPhieu, ví dụ: "PH-0001" -> 1
            var parts = p.SoPhieu.Split('-');
            return int.TryParse(parts.Last(), out int number) ? number : 0;
        })
        .ToList();

    var result = sortedPhieuXuats.Select(phieuXuat => new
    {
        soPhieu = phieuXuat.SoPhieu,
        ngayPhieu = phieuXuat.NgayPhieu.ToString("dd/MM/yyyy"),
        tenKhachHang = phieuXuat.Khachhang,
        tenNVKD = phieuXuat.NhanVien,
        tongTien = phieuXuat.TongTien,
        noCu = phieuXuat.NoCu,
        thanhToan = phieuXuat.ThanhToan,
        conLai = phieuXuat.ConLai,
        hanThanhToan = phieuXuat.HanThanhToan?.ToString("dd/MM/yyyy"),
        ghiChu = phieuXuat.GhiChu,
        chiTietPhieuXuats = phieuXuat.ChiTietPhieuXuats.Select(c => new
        {
            id = c.Id,
            soPhieu = c.SoPhieu,
            maSanPham = c.Ma_sanpham,
            tenSanPham = c.Danhmuc?.Ten_danhmuc,
            soLuong = c.SoLuong,
            donGia = c.DonGia,
            thanhTien = c.ThanhTien
        })
    });

    return Ok(new
    {
        success = true,
        data = result
    });
}





        // POST: /api/PhieuNhap/ThemPhieuNhap
    [HttpPost("ThemPhieuXuat")]
public async Task<IActionResult> ThemPhieuXuat([FromBody] PhieuXuatVM model)
{
            try
            {
                if (ModelState.IsValid)
                {
                      var user = await _userManager.GetUserAsync(User);
                    // Sinh số phiếu tự động
                    model.SoPhieu = GenerateSoPhieu();

                    // Gán giá trị mặc định nếu các thuộc tính null
                    model.TenNVKD = model.TenNVKD ?? "Chưa có NVKD";
                    model.ChiTietPhieuXuats = model.ChiTietPhieuXuats ?? new List<ChiTietPhieuXuatVM>();
                    //model.ConLai = model.TongTien - model.ThanhToan;

                    // Map từ ViewModel sang Entity
                    var phieuXuat = new PhieuXuat
                    {
                        SoPhieu = model.SoPhieu,
                        NgayPhieu = model.NgayPhieu,
                        Khachhang = model.TenKhachhang,
                        NhanVien = model.TenNVKD,
                        TongTien = model.TongTien,
                        NoCu = model.NoCu,
                        ThanhToan = model.ThanhToan,
                        ConLai = model.ConLai,
                        HanThanhToan = model.HanThanhToan,
                        GhiChu = model.GhiChu,
                        GiamGia = model.GiamGia,
                        TienMat = model.TienMat,
                        ChuyenKhoan = model.ChuyenKhoan,
                        TenKhuvuc = model.TenKhuvuc,
                        Id=user.Id,

                        ChiTietPhieuXuats = new List<ChiTietPhieuXuat>()
                    };

                    foreach (var chiTiet in model.ChiTietPhieuXuats)
                    {
                        // Tìm Danhmuc trong cơ sở dữ liệu
                        var danhMuc = await _context.Danhmuc
                            .FirstOrDefaultAsync(d => d.Ma_danhmuc == chiTiet.Ma_sanpham);

                        if (danhMuc == null)
                        {
                            // Xử lý khi không tìm thấy Danhmuc
                            return BadRequest(new { success = false, message = $"Danh mục với mã {chiTiet.Ma_sanpham} không tồn tại" });
                        }

                        // Cập nhật số lượng và giá của sản phẩm
                        danhMuc.Soluong -= chiTiet.SoLuong; // Cộng thêm số lượng mới
                                                            // danhMuc.Gia = (int)chiTiet.DonGia; // Cập nhật giá mới

                        // Thêm chi tiết phiếu nhập
                        phieuXuat.ChiTietPhieuXuats.Add(new ChiTietPhieuXuat
                        {
                            SoPhieu = chiTiet.SoPhieu,
                            Ma_sanpham = chiTiet.Ma_sanpham,
                            Danhmuc = danhMuc, // Gán đối tượng Danhmuc
                            SoLuong = chiTiet.SoLuong,
                            DonGia = chiTiet.DonGia,
                            ThanhTien = chiTiet.ThanhTien,
                            DonViTinh = chiTiet.DonViTinh,
                            Ngayxuat=DateTime.Now,
                        });

                        // Cập nhật Danhmuc trong cơ sở dữ liệu
                        _context.Danhmuc.Update(danhMuc);
                    }

                    _context.PhieuXuats.Add(phieuXuat);
                    await _context.SaveChangesAsync();

                    return Ok(new
                    {
                        success = true,
                        soPhieu = phieuXuat.SoPhieu,
                        ngayPhieu = phieuXuat.NgayPhieu.ToString("dd/MM/yyyy"),
                        tenKhachHang = phieuXuat.Khachhang,
                        tenNVKD = phieuXuat.NhanVien,
                        tongTien = phieuXuat.TongTien,
                        noCu = phieuXuat.NoCu,
                        thanhToan = phieuXuat.ThanhToan,
                        conLai = phieuXuat.ConLai,
                        hanThanhToan = phieuXuat.HanThanhToan?.ToString("dd/MM/yyyy"),
                        ghiChu = phieuXuat.GhiChu,
                        giamGia = phieuXuat.GiamGia,
                        tienMat = phieuXuat.TienMat,
                        chuyenKhoan = phieuXuat.ChuyenKhoan,
                        tenKhuvuc = phieuXuat.TenKhuvuc,
                        chiTietPhieuXuats = phieuXuat.ChiTietPhieuXuats.Select(c => new
                        {
                            id = c.Id,
                            soPhieu = c.SoPhieu,
                            maSanPham = c.Ma_sanpham,
                            tenSanPham = c.Danhmuc.Ten_danhmuc, // Ánh xạ tên danh mục từ đối tượng Danhmuc
                            soLuong = c.SoLuong,
                            donGia = c.DonGia,
                            donViTinh = c.DonViTinh,
                            thanhTien = c.ThanhTien
                        })
                    });
                }
            } catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Dữ liệu không hợp lệ" });
            }
            
            return BadRequest(new { success = false, message = "Dữ liệu không hợp lệ" });
            
 
}


        // GET: /api/PhieuNhap/XemPhieuNhap?soPhieu={soPhieu}
        [HttpGet("XemPhieuXuat")]
        public async Task<IActionResult> XemPhieuXuat([FromQuery] string soPhieu)
        {
            var phieuXuat = await _context.PhieuXuats
                .Include(p => p.ChiTietPhieuXuats) // Đảm bảo rằng bạn cũng bao gồm chi tiết phiếu nhập
                    .ThenInclude(c => c.Danhmuc) // Bao gồm Danhmuc trong chi tiết phiếu nhập
                .FirstOrDefaultAsync(p => p.SoPhieu == soPhieu);

            if (phieuXuat == null)
            {
                return NotFound(new { success = false, message = "Phiếu nhập không tìm thấy" });
            }

            return Ok(new
            {
                success = true,
                soPhieu = phieuXuat.SoPhieu,
                ngayPhieu = phieuXuat.NgayPhieu.ToString("yyyy-MM-dd"),
                tenKhachHang = phieuXuat.Khachhang,
                tenNVKD = phieuXuat.NhanVien,
                tongTien = phieuXuat.TongTien,
                noCu = phieuXuat.NoCu,
                thanhToan = phieuXuat.ThanhToan,
                conLai = phieuXuat.ConLai,
                hanThanhToan = phieuXuat.HanThanhToan?.ToString("yyyy-MM-dd"),
                ghiChu = phieuXuat.GhiChu,
                giamGia = phieuXuat.GiamGia,
                tienMat = phieuXuat.TienMat,
                chuyenKhoan = phieuXuat.ChuyenKhoan,
                tenKhuvuc = phieuXuat.TenKhuvuc,
                chiTietPhieuXuats = phieuXuat.ChiTietPhieuXuats.Select(c => new
                {
                    id = c.Id,
                    soPhieu = c.SoPhieu,
                    maSanPham = c.Ma_sanpham,
                    tenSanPham = c.Danhmuc?.Ten_danhmuc, // Ánh xạ tên danh mục từ đối tượng Danhmuc
                    soLuong = c.SoLuong,
                    donGia = c.DonGia,
                    donViTinh = c.DonViTinh,
                    thanhTien = c.ThanhTien
                })
            });
        }

    private string GenerateSoPhieu()
{
    try
    {
  var currentDate = DateTime.Now;
    var yearMonthPrefix = $"{currentDate:yyyyMM}"; // Tạo tiền tố YYYYMM

    // Tìm mã số phiếu mới nhất trong tháng và năm hiện tại
    var lastPhieuXuat = _context.PhieuXuats
        .Where(p => p.SoPhieu.StartsWith($"PX-{yearMonthPrefix}"))
        .OrderByDescending(p => p.SoPhieu).Select(x=>x.SoPhieu)
        .FirstOrDefault();

    if (lastPhieuXuat != null)
    {
        var lastNumberPart = lastPhieuXuat.Substring(8); // Lấy phần số sau tiền tố YYYYMM
        if (int.TryParse(lastNumberPart, out int lastNumber))
        {
            // Tăng số lên 1 và định dạng lại thành 4 chữ số
            var newNumber = (lastNumber + 1) % 10000; // Đảm bảo không vượt quá 9999
            return $"PX-{yearMonthPrefix}{newNumber:D4}";
        }
    }

    // Nếu không có phiếu nhập nào trong tháng hiện tại, bắt đầu từ 0001
    return $"PX-{yearMonthPrefix}0001";
    }
    catch(Exception ex)
    {
        return ex.Message;
    }
}


// PUT: /api/PhieuXuat/CapNhatPhieuXuat
[HttpPut("CapNhatPhieuXuat")]
public async Task<IActionResult> CapNhatPhieuXuat([FromBody] PhieuXuatVM model)
{
    try
    {
        if (ModelState.IsValid)
        {
            var phieuXuat = await _context.PhieuXuats
                .Include(p => p.ChiTietPhieuXuats)
                .FirstOrDefaultAsync(p => p.SoPhieu == model.SoPhieu);

            if (phieuXuat == null)
            {
                return NotFound(new { success = false, message = "Phiếu xuất không tìm thấy" });
            }

            // Cập nhật thông tin phiếu xuất
            phieuXuat.NgayPhieu = model.NgayPhieu;
            phieuXuat.Khachhang = model.TenKhachhang;
            phieuXuat.NhanVien = model.TenNVKD;
            phieuXuat.TongTien = model.TongTien;
            phieuXuat.NoCu = model.NoCu;
            phieuXuat.ThanhToan = model.ThanhToan;
            phieuXuat.ConLai = model.ConLai;
            phieuXuat.HanThanhToan = model.HanThanhToan;
            phieuXuat.GhiChu = model.GhiChu;
            phieuXuat.GiamGia = model.GiamGia;
            phieuXuat.TienMat = model.TienMat;
            phieuXuat.ChuyenKhoan = model.ChuyenKhoan;
            phieuXuat.TenKhuvuc = model.TenKhuvuc;

            // Xóa các chi tiết phiếu xuất cũ
            _context.ChiTietPhieuXuats.RemoveRange(phieuXuat.ChiTietPhieuXuats);

            // Cập nhật các chi tiết phiếu xuất mới
            foreach (var chiTiet in model.ChiTietPhieuXuats)
            {
                var danhMuc = await _context.Danhmuc
                    .FirstOrDefaultAsync(d => d.Ma_danhmuc == chiTiet.Ma_sanpham);

                if (danhMuc == null)
                {
                    return BadRequest(new { success = false, message = $"Danh mục với mã {chiTiet.Ma_sanpham} không tồn tại" });
                }

                danhMuc.Soluong -= chiTiet.SoLuong; // Cập nhật số lượng

                phieuXuat.ChiTietPhieuXuats.Add(new ChiTietPhieuXuat
                {
                    SoPhieu = chiTiet.SoPhieu,
                    Ma_sanpham = chiTiet.Ma_sanpham,
                    Danhmuc = danhMuc,
                    SoLuong = chiTiet.SoLuong,
                    DonGia = chiTiet.DonGia,
                    ThanhTien = chiTiet.ThanhTien,
                    DonViTinh = chiTiet.DonViTinh,
                    Ngayxuat = DateTime.Now,
                });

                _context.Danhmuc.Update(danhMuc);
            }

            _context.PhieuXuats.Update(phieuXuat);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                soPhieu = phieuXuat.SoPhieu,
                ngayPhieu = phieuXuat.NgayPhieu.ToString("dd/MM/yyyy"),
                tenKhachHang = phieuXuat.Khachhang,
                tenNVKD = phieuXuat.NhanVien,
                tongTien = phieuXuat.TongTien,
                noCu = phieuXuat.NoCu,
                thanhToan = phieuXuat.ThanhToan,
                conLai = phieuXuat.ConLai,
                hanThanhToan = phieuXuat.HanThanhToan?.ToString("dd/MM/yyyy"),
                ghiChu = phieuXuat.GhiChu,
                giamGia = phieuXuat.GiamGia,
                tienMat = phieuXuat.TienMat,
                chuyenKhoan = phieuXuat.ChuyenKhoan,
                tenKhuvuc = phieuXuat.TenKhuvuc,
                chiTietPhieuXuats = phieuXuat.ChiTietPhieuXuats.Select(c => new
                {
                    id = c.Id,
                    soPhieu = c.SoPhieu,
                    maSanPham = c.Ma_sanpham,
                    tenSanPham = c.Danhmuc.Ten_danhmuc,
                    soLuong = c.SoLuong,
                    donGia = c.DonGia,
                    donViTinh = c.DonViTinh,
                    thanhTien = c.ThanhTien
                })
            });
        }
    }
    catch (Exception ex)
    {
        return BadRequest(new { success = false, message = "Dữ liệu không hợp lệ" });
    }

    return BadRequest(new { success = false, message = "Dữ liệu không hợp lệ" });
}



// DELETE: /api/PhieuXuat/XoaPhieuXuat
[HttpDelete("XoaPhieuXuat")]
public async Task<IActionResult> XoaPhieuXuat([FromQuery] string soPhieu)
{
    var phieuXuat = await _context.PhieuXuats
        .Include(p => p.ChiTietPhieuXuats)
        .FirstOrDefaultAsync(p => p.SoPhieu == soPhieu);

    if (phieuXuat == null)
    {
        return NotFound(new { success = false, message = "Phiếu xuất không tìm thấy" });
    }

    // Xóa các chi tiết phiếu xuất liên quan
    _context.ChiTietPhieuXuats.RemoveRange(phieuXuat.ChiTietPhieuXuats);

    // Xóa phiếu xuất
    _context.PhieuXuats.Remove(phieuXuat);
    await _context.SaveChangesAsync();

    return Ok(new { success = true, message = "Phiếu xuất đã được xóa thành công" });
}


    }
}
