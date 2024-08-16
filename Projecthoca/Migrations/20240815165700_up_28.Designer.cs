﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projecthoca.Data;

#nullable disable

namespace Projecthoca.Migrations
{
    [DbContext(typeof(MyDbcontext))]
    [Migration("20240815165700_up_28")]
    partial class up_28
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diachi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Hovaten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Ma_user")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Ngaysinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Chitietlancau", b =>
                {
                    b.Property<string>("Ma_chitietlancau")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Ma_danhmuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Ma_thuehoca")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Thanhtien")
                        .HasColumnType("real");

                    b.Property<TimeSpan>("giocau")
                        .HasMaxLength(100)
                        .HasColumnType("time");

                    b.Property<float>("sokg")
                        .HasMaxLength(100)
                        .HasColumnType("real");

                    b.HasKey("Ma_chitietlancau");

                    b.HasIndex("Ma_danhmuc");

                    b.HasIndex("Ma_thuehoca");

                    b.ToTable("Chitietlancau", (string)null);
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Danhmuc", b =>
                {
                    b.Property<string>("Ma_danhmuc")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Donvitinh")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gia")
                        .HasMaxLength(2147483647)
                        .HasColumnType("int");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mieuta")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NguoidungId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Ten_danhmuc")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("soluong")
                        .HasMaxLength(2147483647)
                        .HasColumnType("int");

                    b.HasKey("Ma_danhmuc");

                    b.HasIndex("NguoidungId");

                    b.ToTable("Danhmuc", (string)null);
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Danhmucgia", b =>
                {
                    b.Property<string>("Ma_danhmucgia")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Ca")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Tieude")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Ma_danhmucgia");

                    b.HasIndex("Id");

                    b.ToTable("Danhmucgia", (string)null);
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Danhmuchoadon", b =>
                {
                    b.Property<int>("Ma_danhmuchoadon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ma_danhmuchoadon"), 1L, 1);

                    b.Property<string>("Ma_danhmuc")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ma_thuehoca")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Soluong")
                        .HasMaxLength(2147483647)
                        .HasColumnType("int");

                    b.Property<int>("thanhtien")
                        .HasMaxLength(2147483647)
                        .HasColumnType("int");

                    b.HasKey("Ma_danhmuchoadon");

                    b.HasIndex("Ma_danhmuc");

                    b.HasIndex("Ma_thuehoca");

                    b.ToTable("Danhmuchoadon", (string)null);
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Giachothue", b =>
                {
                    b.Property<int>("Ma_giachothue")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ma_giachothue"), 1L, 1);

                    b.Property<int>("Gia")
                        .HasMaxLength(2147483647)
                        .HasColumnType("int");

                    b.Property<string>("Ma_danhmucgia")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Ma_giachothue");

                    b.HasIndex("Ma_danhmucgia");

                    b.ToTable("Giachothue", (string)null);
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Giachothuehc", b =>
                {
                    b.Property<int>("Ma_giachothuehc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ma_giachothuehc"), 1L, 1);

                    b.Property<int>("Ma_giahoca")
                        .HasColumnType("int");

                    b.Property<string>("Ma_thuehoca")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Soluong")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<int>("Thanhtien")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<string>("Trangthai")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Ma_giachothuehc");

                    b.HasIndex("Ma_giahoca");

                    b.HasIndex("Ma_thuehoca");

                    b.ToTable("Giachothuehc", (string)null);
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Giahoca", b =>
                {
                    b.Property<int>("Ma_giahoca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ma_giahoca"), 1L, 1);

                    b.Property<int>("Ca")
                        .HasMaxLength(2147483647)
                        .HasColumnType("int");

                    b.Property<int>("Gia_coca")
                        .HasMaxLength(2147483647)
                        .HasColumnType("int");

                    b.Property<int>("Gia_khongca")
                        .HasMaxLength(2147483647)
                        .HasColumnType("int");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Ma_giahoca");

                    b.HasIndex("Id");

                    b.ToTable("Giahoca", (string)null);
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Hoadondanhmuc", b =>
                {
                    b.Property<string>("Ma_hddm")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Ma_thuehoca")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Tongthanhtoan")
                        .HasMaxLength(2147483647)
                        .HasColumnType("int");

                    b.HasKey("Ma_hddm");

                    b.HasIndex("Ma_thuehoca");

                    b.ToTable("Hoadondanhmuc", (string)null);
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Hoca", b =>
                {
                    b.Property<string>("Ma_hoca")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Kieuhoca")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten_hoca")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Ma_hoca");

                    b.HasIndex("Id");

                    b.ToTable("Hoca", (string)null);
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Khuvuccau", b =>
                {
                    b.Property<string>("Ma_Khuvuccau")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Idkhuvuccau")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ma_hoca")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Ten_Khuvuccau")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trangthai")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Ma_Khuvuccau");

                    b.HasIndex("Ma_hoca");

                    b.ToTable("Khuvuccau", (string)null);
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Thongbao", b =>
                {
                    b.Property<int>("Ma_thongbao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ma_thongbao"), 1L, 1);

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NgayDang")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("Trangthai")
                        .HasMaxLength(50)
                        .HasColumnType("bit");

                    b.HasKey("Ma_thongbao");

                    b.HasIndex("Id");

                    b.ToTable("Thongbao", (string)null);
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Thuehoca", b =>
                {
                    b.Property<string>("Ma_thuehoca")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Ma_khuvuccau")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Ngaycau")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten_khachhang")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Thoigianbatdau")
                        .HasMaxLength(2147483647)
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("Thoigianketthuc")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("Timeout")
                        .HasMaxLength(2147483647)
                        .HasColumnType("time");

                    b.Property<string>("trangthai")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Ma_thuehoca");

                    b.HasIndex("Ma_khuvuccau");

                    b.ToTable("Thuehoca", (string)null);
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Tongsokg", b =>
                {
                    b.Property<int>("Ma_tongsokg")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ma_tongsokg"), 1L, 1);

                    b.Property<string>("Ma_thuehoca")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Tongsotien")
                        .HasColumnType("real");

                    b.Property<float>("sokg")
                        .HasMaxLength(100)
                        .HasColumnType("real");

                    b.Property<int>("soluong")
                        .HasColumnType("int");

                    b.HasKey("Ma_tongsokg");

                    b.HasIndex("Ma_thuehoca");

                    b.ToTable("Tongsokg", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Projecthoca.Models.Enitity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Projecthoca.Models.Enitity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projecthoca.Models.Enitity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Projecthoca.Models.Enitity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Chitietlancau", b =>
                {
                    b.HasOne("Projecthoca.Models.Enitity.Danhmuc", "Danhmuc")
                        .WithMany("Chitietlancaus")
                        .HasForeignKey("Ma_danhmuc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projecthoca.Models.Enitity.Thuehoca", "Thuehoca")
                        .WithMany("Chitietlancaus")
                        .HasForeignKey("Ma_thuehoca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Danhmuc");

                    b.Navigation("Thuehoca");
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Danhmuc", b =>
                {
                    b.HasOne("Projecthoca.Models.Enitity.ApplicationUser", "Nguoidung")
                        .WithMany("Danhmucs")
                        .HasForeignKey("NguoidungId");

                    b.Navigation("Nguoidung");
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Danhmucgia", b =>
                {
                    b.HasOne("Projecthoca.Models.Enitity.ApplicationUser", "Nguoidung")
                        .WithMany("Danhmucgias")
                        .HasForeignKey("Id");

                    b.Navigation("Nguoidung");
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Danhmuchoadon", b =>
                {
                    b.HasOne("Projecthoca.Models.Enitity.Danhmuc", "Danhmuc")
                        .WithMany("Danhmuchoadons")
                        .HasForeignKey("Ma_danhmuc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projecthoca.Models.Enitity.Thuehoca", "Thuehoca")
                        .WithMany("Danhmuchoadons")
                        .HasForeignKey("Ma_thuehoca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Danhmuc");

                    b.Navigation("Thuehoca");
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Giachothue", b =>
                {
                    b.HasOne("Projecthoca.Models.Enitity.Danhmucgia", "Danhmucgia")
                        .WithMany("Giachothues")
                        .HasForeignKey("Ma_danhmucgia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Danhmucgia");
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Giachothuehc", b =>
                {
                    b.HasOne("Projecthoca.Models.Enitity.Giahoca", "Giahoca")
                        .WithMany("Giachothuehcs")
                        .HasForeignKey("Ma_giahoca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projecthoca.Models.Enitity.Thuehoca", "Thuehoca")
                        .WithMany("Giachothuehcs")
                        .HasForeignKey("Ma_thuehoca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Giahoca");

                    b.Navigation("Thuehoca");
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Giahoca", b =>
                {
                    b.HasOne("Projecthoca.Models.Enitity.ApplicationUser", "Nguoidung")
                        .WithMany("Giahocas")
                        .HasForeignKey("Id");

                    b.Navigation("Nguoidung");
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Hoadondanhmuc", b =>
                {
                    b.HasOne("Projecthoca.Models.Enitity.Thuehoca", "Thuehoca")
                        .WithMany("Hoadondanhmucs")
                        .HasForeignKey("Ma_thuehoca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Thuehoca");
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Hoca", b =>
                {
                    b.HasOne("Projecthoca.Models.Enitity.ApplicationUser", "Nguoidung")
                        .WithMany("Hoccas")
                        .HasForeignKey("Id");

                    b.Navigation("Nguoidung");
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Khuvuccau", b =>
                {
                    b.HasOne("Projecthoca.Models.Enitity.Hoca", "Hoca")
                        .WithMany("Khuvuccaus")
                        .HasForeignKey("Ma_hoca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hoca");
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Thongbao", b =>
                {
                    b.HasOne("Projecthoca.Models.Enitity.ApplicationUser", "ApplicationUser")
                        .WithMany("Thongbaos")
                        .HasForeignKey("Id");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Thuehoca", b =>
                {
                    b.HasOne("Projecthoca.Models.Enitity.Khuvuccau", "Khuvuccau")
                        .WithMany("Thuehocas")
                        .HasForeignKey("Ma_khuvuccau")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Khuvuccau");
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Tongsokg", b =>
                {
                    b.HasOne("Projecthoca.Models.Enitity.Thuehoca", "Thuehoca")
                        .WithMany("Tongsokgs")
                        .HasForeignKey("Ma_thuehoca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Thuehoca");
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.ApplicationUser", b =>
                {
                    b.Navigation("Danhmucgias");

                    b.Navigation("Danhmucs");

                    b.Navigation("Giahocas");

                    b.Navigation("Hoccas");

                    b.Navigation("Thongbaos");
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Danhmuc", b =>
                {
                    b.Navigation("Chitietlancaus");

                    b.Navigation("Danhmuchoadons");
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Danhmucgia", b =>
                {
                    b.Navigation("Giachothues");
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Giahoca", b =>
                {
                    b.Navigation("Giachothuehcs");
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Hoca", b =>
                {
                    b.Navigation("Khuvuccaus");
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Khuvuccau", b =>
                {
                    b.Navigation("Thuehocas");
                });

            modelBuilder.Entity("Projecthoca.Models.Enitity.Thuehoca", b =>
                {
                    b.Navigation("Chitietlancaus");

                    b.Navigation("Danhmuchoadons");

                    b.Navigation("Giachothuehcs");

                    b.Navigation("Hoadondanhmucs");

                    b.Navigation("Tongsokgs");
                });
#pragma warning restore 612, 618
        }
    }
}
