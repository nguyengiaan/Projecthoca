﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projecthoca.Models.Enitity;

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
        public DbSet<Hoca> Hoca { get; set;}
        public DbSet<Thuehoca> Thuehoca { get; set; }

        public DbSet<Khuvuccau> Khuvuccau { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
            modelBuilder.Entity<Hoadondanhmuc>().Property(e => e.Giachothue).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Hoadondanhmuc>().HasOne(x => x.Thuehoca).WithMany(x => x.Hoadondanhmucs).HasForeignKey(x => x.Ma_thuehoca);

            // Table Danhmuchoadon
            modelBuilder.Entity<Danhmuchoadon>().ToTable("Danhmuchoadon").HasKey(x => x.Ma_danhmuchoadon);
            modelBuilder.Entity<Danhmuchoadon>().Property(e => e.Gia).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Danhmuchoadon>().Property(e => e.Soluong).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Danhmuchoadon>().Property(e => e.DVT).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Danhmuchoadon>().HasOne(x => x.Hoadondanhmuc).WithMany(x => x.Danhmuchoadons).HasForeignKey(x => x.Ma_hddm);
            modelBuilder.Entity<Danhmuchoadon>().HasOne(x => x.Danhmuc).WithMany(x => x.Danhmuchoadons).HasForeignKey(x => x.Ma_danhmuc);

            // Table Danhmuc
            modelBuilder.Entity<Danhmuc>().ToTable("Danhmuc").HasKey(x => x.Ma_danhmuc);
            modelBuilder.Entity<Danhmuc>().Property(e => e.Ten_danhmuc).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Danhmuc>().Property(e => e.Gia).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Danhmuc>().Property(e => e.Donvitinh).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Danhmuc>().Property(e => e.soluong).HasMaxLength(int.MaxValue);

            // Table Danhmucgia
            modelBuilder.Entity<Danhmucgia>().ToTable("Danhmucgia").HasKey(x => x.Ma_danhmucgia);
            modelBuilder.Entity<Danhmucgia>().Property(e => e.Tieude).HasMaxLength(int.MaxValue);
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

        }

    }
}
