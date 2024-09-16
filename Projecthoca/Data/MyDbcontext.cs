using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;

namespace Projecthoca.Data
{
    public class MyDbcontext : IdentityDbContext<ApplicationUser>
    {
        public MyDbcontext(DbContextOptions<MyDbcontext> options) : base(options)
        {
        }
        #region
        public DbSet<ApplicationUser> Nguoidung { get; set; }
        public DbSet<Danhmuc> Danhmuc { get; set; }
        public DbSet<Danhmucgia> Danhmucgia { get; set; }
        public DbSet<Hoadondanhmuc> Hoadondanhmuc { get; set; }
        public DbSet<Hoca> Hoca { get; set; }
        public DbSet<Thuehoca> Thuehoca { get; set; }

        public DbSet<Khuvuccau> Khuvuccau { get; set; }

        public DbSet<Giahoca> Giahocas { get; set; }

        public DbSet<Chitietlancau> chitietlancaus { get; set; }

        public DbSet<Tongsokg> Tongsokg { get; set; }

        public DbSet<Danhmuchoadon> danhmuchoadons { get; set; }

        public DbSet<Quanlyhanghoa> Quanlyhanghoa { get; set; }

        public DbSet<Giachothuehc> Giachothuehcs { get; set; }

        public DbSet<Thongbao> Thongbaos { get; set; }

        public DbSet<Phieuxuatkho> Phieuxuatkhos { get; set; }

        public DbSet<Phieunhapkho> Phieunhapkhos { get; set; }

        public DbSet<Mathang> Mathangs { get; set; }

        public DbSet<Donvitinh> Donvitinhs { get; set; }
        public DbSet<Nhacungcaps> Nhacungcap { get; set; }

        public DbSet<Quanlyhanghoa> Quanlyhanghoas { get; set; }

        public DbSet<Danhsachhhkho> Danhsachhhkhos { get; set; }

        public DbSet <Khachhang> Khachhangs {get;set;}
            
        public DbSet <PhieuNhap> PhieuNhaps { get; set; }

        public DbSet<PhieuXuat> PhieuXuats { get; set; }

        public DbSet<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
        public DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        #endregion




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<PhieuXuat>()
        .HasOne(p => p.nguoidung)
        .WithMany(u => u.PhieuXuats)
        .HasForeignKey(p => p.Id)
        .IsRequired();

            modelBuilder.Entity<PhieuNhap>()
        .HasOne(p => p.nguoidung)
        .WithMany(u => u.PhieuNhaps)
        .HasForeignKey(p => p.Id)
        .IsRequired();




            modelBuilder.Entity<PhieuXuat>()
            .HasKey(p => p.SoPhieu);

        modelBuilder.Entity<ChiTietPhieuXuat>()
            .HasKey(ct => ct.Id);

        modelBuilder.Entity<ChiTietPhieuXuat>()
            .HasOne(ct => ct.PhieuXuat)
            .WithMany(p => p.ChiTietPhieuXuats)
            .HasForeignKey(ct => ct.SoPhieu);

        modelBuilder.Entity<ChiTietPhieuXuat>()
            .HasOne(ct => ct.Danhmuc) // Sửa thành Danhmuc
            .WithMany(qh => qh.ChiTietPhieuXuats)
            .HasForeignKey(ct => ct.Ma_sanpham);
            

             modelBuilder.Entity<PhieuNhap>()
            .HasKey(p => p.SoPhieu);

        modelBuilder.Entity<ChiTietPhieuNhap>()
            .HasKey(ct => ct.Id);

        modelBuilder.Entity<ChiTietPhieuNhap>()
            .HasOne(ct => ct.PhieuNhap)
            .WithMany(p => p.ChiTietPhieuNhaps)
            .HasForeignKey(ct => ct.SoPhieu);

        modelBuilder.Entity<ChiTietPhieuNhap>()
            .HasOne(ct => ct.Danhmuc) // Sửa thành Danhmuc
            .WithMany(qh => qh.ChiTietPhieuNhaps)
            .HasForeignKey(ct => ct.Ma_sanpham);

      
        // modelBuilder.Entity<NhanVien>()
        //     .HasKey(nv => nv.MaNVKD);



            // Table Qunanlyhanghoa
            modelBuilder.Entity<Quanlyhanghoa>()
               .ToTable("Quanlyhanghoa")
               .HasKey(x => x.Ma_sanpham);

            modelBuilder.Entity<Quanlyhanghoa>()
                .HasOne(x => x.Nguoidung)
                .WithMany(x => x.Quanlyhanghoas)
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);

            // Table Hoca
            modelBuilder.Entity<Hoca>().ToTable("Hoca").HasKey(x => x.Ma_hoca);
            modelBuilder.Entity<Hoca>().Property(e => e.Ten_hoca).HasMaxLength(int.MaxValue);

            modelBuilder.Entity<Hoca>().Property(e => e.Kieuhoca).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Hoca>().HasOne(x => x.Nguoidung).WithMany(x => x.Hoccas).HasForeignKey(x => x.Id);

            // Table Thuehoca    
            modelBuilder.Entity<Thuehoca>().ToTable("Thuehoca").HasKey(x => x.Ma_thuehoca);

            modelBuilder.Entity<Thuehoca>().Property(e => e.Ten_khachhang).HasMaxLength(int.MaxValue);

            modelBuilder.Entity<Thuehoca>().Property(e => e.Ngaycau).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Thuehoca>().Property(e => e.Thoigianbatdau).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Thuehoca>().Property(e => e.Timeout).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Thuehoca>().Property(e => e.trangthai).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Thuehoca>().HasOne(x => x.Khuvuccau).WithMany(x => x.Thuehocas).HasForeignKey(x => x.Ma_khuvuccau);

            // Table Hoadondanhmuc
            modelBuilder.Entity<Hoadondanhmuc>().ToTable("Hoadondanhmuc").HasKey(x => x.Ma_hddm);
            modelBuilder.Entity<Hoadondanhmuc>().Property(e => e.Tongthanhtoan).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Hoadondanhmuc>().HasOne(x => x.Thuehoca).WithMany(x => x.Hoadondanhmucs).HasForeignKey(x => x.Ma_thuehoca);
            // Table Danhmuchoadon
            modelBuilder.Entity<Danhmuchoadon>().ToTable("Danhmuchoadon").HasKey(x => x.Ma_danhmuchoadon);
            modelBuilder.Entity<Danhmuchoadon>().Property(e => e.Soluong).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Danhmuchoadon>().Property(e => e.thanhtien).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Danhmuchoadon>().Property(e => e.Ma_danhmuc).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Danhmuchoadon>().HasOne(x => x.Thuehoca).WithMany(x => x.Danhmuchoadons).HasForeignKey(x => x.Ma_thuehoca);
            modelBuilder.Entity<Danhmuchoadon>().HasOne(x => x.Danhmuc).WithMany(x => x.Danhmuchoadons).HasForeignKey(x => x.Ma_danhmuc);
            // Table Danhmuc
            modelBuilder.Entity<Danhmuc>().ToTable("Danhmuc").HasKey(x => x.Ma_danhmuc);
            modelBuilder.Entity<Danhmuc>().Property(e => e.Ten_danhmuc).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Danhmuc>().Property(e => e.Nhacungcap).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Danhmuc>().Property(e => e.Gianhap).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Danhmuc>().Property(e => e.Gia).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Danhmuc>().Property(e => e.Donvitinh).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Danhmuc>().HasOne(x => x.Nguoidung).WithMany(x => x.Danhmucs).HasForeignKey(x => x.Id);

            modelBuilder.Entity<Danhmuc>().HasOne(x => x.Mathang).WithMany(x => x.Danhmucs).HasForeignKey(x => x.Ma_mathang);
            // Table Danhmucgia
            modelBuilder.Entity<Danhmucgia>().ToTable("Danhmucgia").HasKey(x => x.Ma_danhmucgia);
            modelBuilder.Entity<Danhmucgia>().Property(e => e.Tieude).HasMaxLength(1000);
            modelBuilder.Entity<Danhmucgia>().Property(e => e.Ca).HasMaxLength(int.MaxValue);

            modelBuilder.Entity<Danhmucgia>().HasOne(x => x.Nguoidung).WithMany(x => x.Danhmucgias).HasForeignKey(x => x.Id);

            // Table Giachothue
            modelBuilder.Entity<Giachothue>().ToTable("Giachothue").HasKey(x => x.Ma_giachothue);
            modelBuilder.Entity<Giachothue>().Property(e => e.Gia).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Giachothue>().HasOne(x => x.Danhmucgia).WithMany(x => x.Giachothues).HasForeignKey(x => x.Ma_danhmucgia);
            //table Khuvuccau
            modelBuilder.Entity<Khuvuccau>().ToTable("Khuvuccau").HasKey(x => x.Ma_Khuvuccau);
            modelBuilder.Entity<Khuvuccau>().Property(e => e.Ten_Khuvuccau).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Khuvuccau>().Property(e => e.Trangthai).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Khuvuccau>().Property(e => e.Idkhuvuccau).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Khuvuccau>().HasOne(x => x.Hoca).WithMany(x => x.Khuvuccaus).HasForeignKey(x => x.Ma_hoca);
            //table Giahoca
            modelBuilder.Entity<Giahoca>().ToTable("Giahoca").HasKey(x => x.Ma_giahoca);
            modelBuilder.Entity<Giahoca>().Property(e => e.Gia_khongca).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Giahoca>().Property(e => e.Gia_coca).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Giahoca>().Property(e => e.Ca).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Giahoca>().HasOne(x => x.Nguoidung).WithMany(x => x.Giahocas).HasForeignKey(x => x.Id);

            // table Chitietlancau
            modelBuilder.Entity<Chitietlancau>().ToTable("Chitietlancau").HasKey(x => x.Ma_chitietlancau);
            modelBuilder.Entity<Chitietlancau>().Property(e => e.giocau).HasMaxLength(100);
            modelBuilder.Entity<Chitietlancau>().Property(e => e.sokg).HasMaxLength(100);
            modelBuilder.Entity<Chitietlancau>().HasOne(x => x.Danhmuc).WithMany(x => x.Chitietlancaus).HasForeignKey(x => x.Ma_danhmuc);
            modelBuilder.Entity<Chitietlancau>().HasOne(x => x.Thuehoca).WithMany(x => x.Chitietlancaus).HasForeignKey(x => x.Ma_thuehoca);
            // table TongsoKG
            modelBuilder.Entity<Tongsokg>().ToTable("Tongsokg").HasKey(x => x.Ma_tongsokg);
            modelBuilder.Entity<Tongsokg>().Property(e => e.sokg).HasMaxLength(100);
            modelBuilder.Entity<Tongsokg>().HasOne(x => x.Thuehoca).WithMany(x => x.Tongsokgs).HasForeignKey(x => x.Ma_thuehoca);
            // table Giachothuehc
            modelBuilder.Entity<Giachothuehc>().ToTable("Giachothuehc").HasKey(x => x.Ma_giachothuehc);
            modelBuilder.Entity<Giachothuehc>().Property(e => e.Soluong).HasMaxLength(100);
            modelBuilder.Entity<Giachothuehc>().Property(e => e.Thanhtien).HasMaxLength(100);
            modelBuilder.Entity<Giachothuehc>().Property(e => e.Trangthai).HasMaxLength(100);
            modelBuilder.Entity<Giachothuehc>().HasOne(x => x.Thuehoca).WithMany(x => x.Giachothuehcs).HasForeignKey(x => x.Ma_thuehoca);
            modelBuilder.Entity<Giachothuehc>().HasOne(x => x.Giahoca).WithMany(x => x.Giachothuehcs).HasForeignKey(x => x.Ma_giahoca);
            // table Thongbao
            modelBuilder.Entity<Thongbao>().ToTable("Thongbao").HasKey(x => x.Ma_thongbao);
            modelBuilder.Entity<Thongbao>().Property(e => e.NoiDung).HasMaxLength(1000);
            modelBuilder.Entity<Thongbao>().Property(e => e.NgayDang).HasMaxLength(100);
            modelBuilder.Entity<Thongbao>().Property(e => e.Trangthai).HasMaxLength(50);
            modelBuilder.Entity<Thongbao>().HasOne(x => x.ApplicationUser).WithMany(x => x.Thongbaos).HasForeignKey(x => x.Id);
            // table Phieuxuatkho
            modelBuilder.Entity<Phieuxuatkho>().ToTable("Phieuxuatkho").HasKey(x => x.Ma_phieuxuatkho);
            modelBuilder.Entity<Phieuxuatkho>().Property(e => e.Ngayxuat).HasMaxLength(100);
            modelBuilder.Entity<Phieuxuatkho>().Property(e => e.Thanhtien).HasMaxLength(200);
            modelBuilder.Entity<Phieuxuatkho>().Property(e => e.giamgia).HasMaxLength(200);
            modelBuilder.Entity<Phieuxuatkho>().Property(e => e.Tienmat).HasMaxLength(200);
            modelBuilder.Entity<Phieuxuatkho>().Property(e => e.Chuyenkhoan).HasMaxLength(200);
            modelBuilder.Entity<Phieuxuatkho>().Property(e => e.Tongtien).HasMaxLength(200);
            modelBuilder.Entity<Phieuxuatkho>().HasOne(x => x.Nguoidung).WithMany(x => x.phieuxuatkhos).HasForeignKey(x => x.Id);
            // table Phieunhapkho
            modelBuilder.Entity<Phieunhapkho>().ToTable("Phieunhapkho").HasKey(x => x.Ma_phieunhapkho);
            modelBuilder.Entity<Phieunhapkho>().Property(e => e.Ngaynhap).HasMaxLength(100);
            modelBuilder.Entity<Phieunhapkho>().Property(e => e.Nguoinhap).HasMaxLength(100);
            modelBuilder.Entity<Phieunhapkho>().HasOne(x => x.Nguoidung).WithMany(x => x.phieunhapkhos).HasForeignKey(x => x.Id);
            //table Mathang
            modelBuilder.Entity<Mathang>().ToTable("Mathang").HasKey(x => x.Ma_mathang);
            modelBuilder.Entity<Mathang>().Property(e => e.Ten_mathang).HasMaxLength(100);
            modelBuilder.Entity<Mathang>().HasOne(x => x.Nguoidung).WithMany(x => x.Mathangs).HasForeignKey(x => x.Id);
            //table Donvitinh
            modelBuilder.Entity<Donvitinh>().ToTable("Donvitinh").HasKey(x => x.Ma_donvitinh);
            modelBuilder.Entity<Donvitinh>().Property(e => e.Ten_donvitinh).HasMaxLength(100);
            modelBuilder.Entity<Donvitinh>().HasOne(x => x.Nguoidung).WithMany(x => x.Donvitinhs).HasForeignKey(x => x.Id);
             //table Nhacungcap
            modelBuilder.Entity<Nhacungcaps>().ToTable("Nhacungcap").HasKey(x => x.Ma_nhacungcap);
            modelBuilder.Entity<Nhacungcaps>().Property(e => e.Nhacungcap).HasMaxLength(100);
            modelBuilder.Entity<Nhacungcaps>().HasOne(x => x.Nguoidung).WithMany(x => x.Nhacungcaps).HasForeignKey(x => x.Id);
            //table Quanlyhanghoa
            modelBuilder.Entity<Quanlyhanghoa>().ToTable("Quanlyhanghoa").HasKey(x => x.Ma_sanpham);
            modelBuilder.Entity<Quanlyhanghoa>().Property(e => e.Ten_sanpham).HasMaxLength(100);
            modelBuilder.Entity<Quanlyhanghoa>().Property(e => e.Ten_donvitinh).HasMaxLength(100);
            modelBuilder.Entity<Quanlyhanghoa>().Property(e => e.Id).HasMaxLength(100);
            modelBuilder.Entity<Quanlyhanghoa>().HasOne(x => x.Nguoidung).WithMany(x => x.Quanlyhanghoas).HasForeignKey(x => x.Id);
            // Danh sách hàng hóa kho
            modelBuilder.Entity<Danhsachhhkho>().ToTable("Danhsachhhkho").HasKey(x => x.Ma_hanghoa);
            modelBuilder.Entity<Danhsachhhkho>().Property(e => e.Ma_danhmuc).HasMaxLength(450);
            modelBuilder.Entity<Danhsachhhkho>().Property(e => e.Ma_phieunhapkho).HasMaxLength(100);
            modelBuilder.Entity<Danhsachhhkho>().Property(e => e.Soluong).HasMaxLength(100);
            modelBuilder.Entity<Danhsachhhkho>().Property(e => e.Thanhtien).HasMaxLength(100);
            modelBuilder.Entity<Danhsachhhkho>().HasOne(x => x.Danhmuc).WithMany(x => x.Danhsachhhkhos).HasForeignKey(x => x.Ma_danhmuc);
            modelBuilder.Entity<Danhsachhhkho>().HasOne(x => x.Phieunhapkho).WithMany(x => x.Danhsachhhkhos).HasForeignKey(x => x.Ma_phieunhapkho);
            // table khachhang
            modelBuilder.Entity<Khachhang>().ToTable("Khachhang").HasKey(x => x.Ma_khachhang);
            modelBuilder.Entity<Khachhang>().Property(e => e.Ten_khachhang).HasMaxLength(100);
            modelBuilder.Entity<Khachhang>().Property(e => e.Sodienthoai).HasMaxLength(100);
            modelBuilder.Entity<Khachhang>().Property(e => e.Diachi).HasMaxLength(100);
            modelBuilder.Entity<Khachhang>().Property(e => e.Ngaysinh).HasMaxLength(100);
            modelBuilder.Entity<Khachhang>().HasOne(x => x.Nguoidung).WithMany(x => x.Khachhangs).HasForeignKey(x => x.Id);
            // table Hoadonxuatban  
            modelBuilder.Entity<Hoadonxuatban>().ToTable("Hoadonxuatban").HasKey(x => x.Ma_hoadonxuatban);
            modelBuilder.Entity<Hoadonxuatban>().Property(e => e.Soluong).HasMaxLength(100);
            modelBuilder.Entity<Hoadonxuatban>().Property(e => e.Ma_danhmuc).HasMaxLength(100);
            modelBuilder.Entity<Hoadonxuatban>().Property(e => e.Ma_phieuxuatkho).HasMaxLength(100);
            modelBuilder.Entity<Hoadonxuatban>().HasOne(x => x.Danhmuc).WithMany(x => x.Hoadonxuatbans).HasForeignKey(x => x.Ma_danhmuc);
            modelBuilder.Entity<Hoadonxuatban>().HasOne(x => x.Phieuxuatkho).WithMany(x => x.Hoadonxuatbans).HasForeignKey(x => x.Ma_phieuxuatkho);
            

        }

    }
}
