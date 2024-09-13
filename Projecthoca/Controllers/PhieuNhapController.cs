using System.Security.Claims;
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
    public class PhieuNhapController : ControllerBase
    {
        private readonly MyDbcontext _context;
         private readonly UserManager<ApplicationUser> _userManager;


        public PhieuNhapController(MyDbcontext context,UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager=userManager;
        }



        
        // GET: /api/PhieuNhap/LayTatCaPhieuNhap
[HttpGet("LayTatCaPhieuNhap")]
public async Task<IActionResult> LayTatCaPhieuNhap()
{

    var user = await _userManager.GetUserAsync(User);
    if (user == null)
    {
        return Unauthorized(new { success = false, message = "Người dùng chưa đăng nhập" });
    }

    var phieuNhaps = await _context.PhieuNhaps
        .Where(p => p.Id == user.Id)
        .Include(p => p.ChiTietPhieuNhaps) // Bao gồm chi tiết phiếu nhập
            .ThenInclude(c => c.Danhmuc) // Bao gồm Danhmuc trong chi tiết phiếu nhập
        .ToListAsync();

    // Sắp xếp theo số phiếu giảm dần
    var sortedPhieuNhaps = phieuNhaps
        .OrderByDescending(p => 
        {
            // Tách phần số từ soPhieu, ví dụ: "PH-0001" -> 1
            var parts = p.SoPhieu.Split('-');
            return int.TryParse(parts.Last(), out int number) ? number : 0;
        })
        .ToList();

    var result = sortedPhieuNhaps.Select(phieuNhap => new
    {
        soPhieu = phieuNhap.SoPhieu,
        ngayPhieu = phieuNhap.NgayPhieu.ToString("dd/MM/yyyy"),
        tenKhachHang = phieuNhap.Khachhang,
        tenNVKD = phieuNhap.NhanVien,
        tongTien = phieuNhap.TongTien,
        noCu = phieuNhap.NoCu,
        thanhToan = phieuNhap.ThanhToan,
        conLai = phieuNhap.ConLai,
        hanThanhToan = phieuNhap.HanThanhToan?.ToString("dd/MM/yyyy"),
        ghiChu = phieuNhap.GhiChu,
        chiTietPhieuNhaps = phieuNhap.ChiTietPhieuNhaps.Select(c => new
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
    [HttpPost("ThemPhieuNhap")]
public async Task<IActionResult> ThemPhieuNhap([FromBody] PhieuNhapVM model)
{
    if (ModelState.IsValid)
    {
        var user = await _userManager.GetUserAsync(User);
        // Sinh số phiếu tự động
        model.SoPhieu = GenerateSoPhieu();

        // Gán giá trị mặc định nếu các thuộc tính null
        model.TenNVKD = model.TenNVKD ?? "Chưa có NVKD";
        model.ChiTietPhieuNhaps = model.ChiTietPhieuNhaps ?? new List<ChiTietPhieuNhapVM>();
        //model.ConLai = model.TongTien - model.ThanhToan;

        // Map từ ViewModel sang Entity
        var phieuNhap = new PhieuNhap
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
            Id=user.Id,
            ChiTietPhieuNhaps = new List<ChiTietPhieuNhap>()
        };

        foreach (var chiTiet in model.ChiTietPhieuNhaps)
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
            danhMuc.Soluong += chiTiet.SoLuong; // Cộng thêm số lượng mới
            danhMuc.Gia = (int)chiTiet.DonGia; // Cập nhật giá mới

            // Thêm chi tiết phiếu nhập
            phieuNhap.ChiTietPhieuNhaps.Add(new ChiTietPhieuNhap
            {
                SoPhieu = chiTiet.SoPhieu,
                Ma_sanpham = chiTiet.Ma_sanpham,
                Danhmuc = danhMuc, // Gán đối tượng Danhmuc
                SoLuong = chiTiet.SoLuong,
                DonGia = chiTiet.DonGia,
                ThanhTien = chiTiet.ThanhTien,
                DonViTinh = chiTiet.DonViTinh,
                Ngaynhap=DateTime.Now,

            });

            // Cập nhật Danhmuc trong cơ sở dữ liệu
            _context.Danhmuc.Update(danhMuc);
        }

        _context.PhieuNhaps.Add(phieuNhap);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            success = true,
            soPhieu = phieuNhap.SoPhieu,
            ngayPhieu = phieuNhap.NgayPhieu.ToString("dd/MM/yyyy"),
            tenKhachHang = phieuNhap.Khachhang,
            tenNVKD = phieuNhap.NhanVien,
            tongTien = phieuNhap.TongTien,
            noCu = phieuNhap.NoCu,
            thanhToan = phieuNhap.ThanhToan,
            conLai = phieuNhap.ConLai,
            hanThanhToan = phieuNhap.HanThanhToan?.ToString("dd/MM/yyyy"),
            ghiChu = phieuNhap.GhiChu,
            chiTietPhieuNhaps = phieuNhap.ChiTietPhieuNhaps.Select(c => new
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

    return BadRequest(new { success = false, message = "Dữ liệu không hợp lệ" });
}


        // GET: /api/PhieuNhap/XemPhieuNhap?soPhieu={soPhieu}
        [HttpGet("XemPhieuNhap")]
        public async Task<IActionResult> XemPhieuNhap([FromQuery] string soPhieu)
        {
            var phieuNhap = await _context.PhieuNhaps
                .Include(p => p.ChiTietPhieuNhaps) // Đảm bảo rằng bạn cũng bao gồm chi tiết phiếu nhập
                    .ThenInclude(c => c.Danhmuc) // Bao gồm Danhmuc trong chi tiết phiếu nhập
                .FirstOrDefaultAsync(p => p.SoPhieu == soPhieu);

            if (phieuNhap == null)
            {
                return NotFound(new { success = false, message = "Phiếu nhập không tìm thấy" });
            }

            return Ok(new
            {
                success = true,
                soPhieu = phieuNhap.SoPhieu,
                ngayPhieu = phieuNhap.NgayPhieu.ToString("yyyy-MM-dd"),
                tenKhachHang = phieuNhap.Khachhang,
                tenNVKD = phieuNhap.NhanVien,
                tongTien = phieuNhap.TongTien,
                noCu = phieuNhap.NoCu,
                thanhToan = phieuNhap.ThanhToan,
                conLai = phieuNhap.ConLai,
                hanThanhToan = phieuNhap.HanThanhToan?.ToString("yyyy-MM-dd"),
                ghiChu = phieuNhap.GhiChu,
                chiTietPhieuNhaps = phieuNhap.ChiTietPhieuNhaps.Select(c => new
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
                var lastPhieuNhap = _context.PhieuNhaps
                    .Where(p => p.SoPhieu.StartsWith($"PN-{yearMonthPrefix}"))
                    .OrderByDescending(p => p.SoPhieu).Select(x=>x.SoPhieu)
                    .FirstOrDefault();

                if (lastPhieuNhap != null)
                {
                    var lastNumberPart = lastPhieuNhap.Substring(8); // Lấy phần số sau tiền tố YYYYMM
                    if (int.TryParse(lastNumberPart, out int lastNumber))
                    {
                        // Tăng số lên 1 và định dạng lại thành 4 chữ số
                        var newNumber = (lastNumber + 1) % 10000; // Đảm bảo không vượt quá 9999
                        return $"PN-{yearMonthPrefix}{newNumber:D4}";
                    }
                }

                // Nếu không có phiếu nhập nào trong tháng hiện tại, bắt đầu từ 0001
                return $"PN-{yearMonthPrefix}0001";
            }
            catch (Exception ex)
            {
                return "";
            }
        }


    
  // PUT: /api/PhieuNhap/CapNhatPhieuNhap
[HttpPut("CapNhatPhieuNhap")]
public async Task<IActionResult> CapNhatPhieuNhap([FromBody] PhieuNhapVM model)
{
    try
    {
        if (ModelState.IsValid)
        {
            var phieuNhap = await _context.PhieuNhaps
                .Include(p => p.ChiTietPhieuNhaps)
                .FirstOrDefaultAsync(p => p.SoPhieu == model.SoPhieu);

            if (phieuNhap == null)
            {
                return NotFound(new { success = false, message = "Phiếu nhập không tìm thấy" });
            }

            // Cập nhật thông tin phiếu nhập
            phieuNhap.NgayPhieu = model.NgayPhieu;
            phieuNhap.Khachhang = model.TenKhachhang;
            phieuNhap.NhanVien = model.TenNVKD;
            phieuNhap.TongTien = model.TongTien;
            phieuNhap.NoCu = model.NoCu;
            phieuNhap.ThanhToan = model.ThanhToan;
            phieuNhap.ConLai = model.ConLai;
            phieuNhap.HanThanhToan = model.HanThanhToan;
            phieuNhap.GhiChu = model.GhiChu;

            // Xóa các chi tiết phiếu nhập cũ
            _context.ChiTietPhieuNhaps.RemoveRange(phieuNhap.ChiTietPhieuNhaps);

            // Cập nhật các chi tiết phiếu nhập mới
            foreach (var chiTiet in model.ChiTietPhieuNhaps)
            {
                var danhMuc = await _context.Danhmuc
                    .FirstOrDefaultAsync(d => d.Ma_danhmuc == chiTiet.Ma_sanpham);

                if (danhMuc == null)
                {
                    return BadRequest(new { success = false, message = $"Danh mục với mã {chiTiet.Ma_sanpham} không tồn tại" });
                }

                danhMuc.Soluong += chiTiet.SoLuong; // Cập nhật số lượng
                danhMuc.Gia = (int)chiTiet.DonGia; // Cập nhật giá mới

                phieuNhap.ChiTietPhieuNhaps.Add(new ChiTietPhieuNhap
                {
                    SoPhieu = chiTiet.SoPhieu,
                    Ma_sanpham = chiTiet.Ma_sanpham,
                    Danhmuc = danhMuc,
                    SoLuong = chiTiet.SoLuong,
                    DonGia = chiTiet.DonGia,
                    ThanhTien = chiTiet.ThanhTien,
                    DonViTinh = chiTiet.DonViTinh,
                    Ngaynhap = DateTime.Now,
                });

                _context.Danhmuc.Update(danhMuc);
            }

            _context.PhieuNhaps.Update(phieuNhap);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                soPhieu = phieuNhap.SoPhieu,
                ngayPhieu = phieuNhap.NgayPhieu.ToString("dd/MM/yyyy"),
                tenKhachHang = phieuNhap.Khachhang,
                tenNVKD = phieuNhap.NhanVien,
                tongTien = phieuNhap.TongTien,
                noCu = phieuNhap.NoCu,
                thanhToan = phieuNhap.ThanhToan,
                conLai = phieuNhap.ConLai,
                hanThanhToan = phieuNhap.HanThanhToan?.ToString("dd/MM/yyyy"),
                ghiChu = phieuNhap.GhiChu,
                chiTietPhieuNhaps = phieuNhap.ChiTietPhieuNhaps.Select(c => new
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




// DELETE: /api/PhieuNhap/XoaPhieuNhap
[HttpDelete("XoaPhieuNhap")]
public async Task<IActionResult> XoaPhieuNhap([FromQuery] string soPhieu)
{
    var phieuNhap = await _context.PhieuNhaps
        .Include(p => p.ChiTietPhieuNhaps)
        .FirstOrDefaultAsync(p => p.SoPhieu == soPhieu);

    if (phieuNhap == null)
    {
        return NotFound(new { success = false, message = "Phiếu nhập không tìm thấy" });
    }

    // Cập nhật lại số lượng trong Danhmuc
    foreach (var chiTiet in phieuNhap.ChiTietPhieuNhaps)
    {
        var danhMuc = await _context.Danhmuc
            .FirstOrDefaultAsync(d => d.Ma_danhmuc == chiTiet.Ma_sanpham);

        if (danhMuc != null)
        {
            danhMuc.Soluong -= chiTiet.SoLuong; // Giảm số lượng
            _context.Danhmuc.Update(danhMuc);
        }
    }

    // Xóa các chi tiết phiếu nhập liên quan
    _context.ChiTietPhieuNhaps.RemoveRange(phieuNhap.ChiTietPhieuNhaps);

    // Xóa phiếu nhập
    _context.PhieuNhaps.Remove(phieuNhap);
    await _context.SaveChangesAsync();

    return Ok(new { success = true, message = "Phiếu nhập đã được xóa thành công" });
}








    }
}
