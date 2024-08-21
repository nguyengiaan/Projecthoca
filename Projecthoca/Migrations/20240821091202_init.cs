using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ma_user = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hovaten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ngaysinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Danhmucgia",
                columns: table => new
                {
                    Ma_danhmucgia = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tieude = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Ca = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Danhmucgia", x => x.Ma_danhmucgia);
                    table.ForeignKey(
                        name: "FK_Danhmucgia_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Donvitinh",
                columns: table => new
                {
                    Ma_donvitinh = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten_donvitinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donvitinh", x => x.Ma_donvitinh);
                    table.ForeignKey(
                        name: "FK_Donvitinh_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Giahoca",
                columns: table => new
                {
                    Ma_giahoca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ca = table.Column<int>(type: "int", maxLength: 2147483647, nullable: false),
                    Gia_khongca = table.Column<int>(type: "int", maxLength: 2147483647, nullable: false),
                    Gia_coca = table.Column<int>(type: "int", maxLength: 2147483647, nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giahoca", x => x.Ma_giahoca);
                    table.ForeignKey(
                        name: "FK_Giahoca_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hoca",
                columns: table => new
                {
                    Ma_hoca = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten_hoca = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Kieuhoca = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoca", x => x.Ma_hoca);
                    table.ForeignKey(
                        name: "FK_Hoca_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Mathang",
                columns: table => new
                {
                    Ma_mathang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten_mathang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mathang", x => x.Ma_mathang);
                    table.ForeignKey(
                        name: "FK_Mathang_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Phieunhapkho",
                columns: table => new
                {
                    Ma_phieunhapkho = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ngaynhap = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    Nguoinhap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ten_danhmuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tenkho = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Diadiem = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Donvitinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Soluong = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Dongia = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Thanhtien = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phieunhapkho", x => x.Ma_phieunhapkho);
                    table.ForeignKey(
                        name: "FK_Phieunhapkho_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Phieuxuatkho",
                columns: table => new
                {
                    Ma_phieuxuatkho = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten_khuvuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ngayxuat = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    Thanhtien = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    giamgia = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    Tienmat = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    Chuyenkhoan = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    Tongtien = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phieuxuatkho", x => x.Ma_phieuxuatkho);
                    table.ForeignKey(
                        name: "FK_Phieuxuatkho_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Quanlyhanghoa",
                columns: table => new
                {
                    Ma_sanpham = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten_sanpham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ten_donvitinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Giaban = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quanlyhanghoa", x => x.Ma_sanpham);
                    table.ForeignKey(
                        name: "FK_Quanlyhanghoa_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Thongbao",
                columns: table => new
                {
                    Ma_thongbao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoiDung = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    NgayDang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Trangthai = table.Column<bool>(type: "bit", maxLength: 50, nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thongbao", x => x.Ma_thongbao);
                    table.ForeignKey(
                        name: "FK_Thongbao_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Giachothue",
                columns: table => new
                {
                    Ma_giachothue = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gia = table.Column<int>(type: "int", maxLength: 2147483647, nullable: false),
                    Ma_danhmucgia = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giachothue", x => x.Ma_giachothue);
                    table.ForeignKey(
                        name: "FK_Giachothue_Danhmucgia_Ma_danhmucgia",
                        column: x => x.Ma_danhmucgia,
                        principalTable: "Danhmucgia",
                        principalColumn: "Ma_danhmucgia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Khuvuccau",
                columns: table => new
                {
                    Ma_Khuvuccau = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten_Khuvuccau = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Trangthai = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Ma_hoca = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Idkhuvuccau = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khuvuccau", x => x.Ma_Khuvuccau);
                    table.ForeignKey(
                        name: "FK_Khuvuccau_Hoca_Ma_hoca",
                        column: x => x.Ma_hoca,
                        principalTable: "Hoca",
                        principalColumn: "Ma_hoca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Danhmuc",
                columns: table => new
                {
                    Ma_danhmuc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten_danhmuc = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Gia = table.Column<int>(type: "int", maxLength: 2147483647, nullable: false),
                    Donvitinh = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Ma_mathang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Danhmuc", x => x.Ma_danhmuc);
                    table.ForeignKey(
                        name: "FK_Danhmuc_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Danhmuc_Mathang_Ma_mathang",
                        column: x => x.Ma_mathang,
                        principalTable: "Mathang",
                        principalColumn: "Ma_mathang",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Thuehoca",
                columns: table => new
                {
                    Ma_thuehoca = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ma_khuvuccau = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten_khachhang = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Ngaycau = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Thoigianbatdau = table.Column<TimeSpan>(type: "time", maxLength: 2147483647, nullable: false),
                    Thoigianketthuc = table.Column<TimeSpan>(type: "time", nullable: true),
                    Timeout = table.Column<TimeSpan>(type: "time", maxLength: 2147483647, nullable: false),
                    trangthai = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thuehoca", x => x.Ma_thuehoca);
                    table.ForeignKey(
                        name: "FK_Thuehoca_Khuvuccau_Ma_khuvuccau",
                        column: x => x.Ma_khuvuccau,
                        principalTable: "Khuvuccau",
                        principalColumn: "Ma_Khuvuccau",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chitietlancau",
                columns: table => new
                {
                    Ma_chitietlancau = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    giocau = table.Column<TimeSpan>(type: "time", maxLength: 100, nullable: false),
                    sokg = table.Column<float>(type: "real", maxLength: 100, nullable: false),
                    Ma_danhmuc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Thanhtien = table.Column<float>(type: "real", nullable: false),
                    Ma_thuehoca = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chitietlancau", x => x.Ma_chitietlancau);
                    table.ForeignKey(
                        name: "FK_Chitietlancau_Danhmuc_Ma_danhmuc",
                        column: x => x.Ma_danhmuc,
                        principalTable: "Danhmuc",
                        principalColumn: "Ma_danhmuc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chitietlancau_Thuehoca_Ma_thuehoca",
                        column: x => x.Ma_thuehoca,
                        principalTable: "Thuehoca",
                        principalColumn: "Ma_thuehoca",
                        onDelete: ReferentialAction.Cascade);
                });

          migrationBuilder.CreateTable(
    name: "Danhmuchoadon",
    columns: table => new
    {
        Ma_danhmuchoadon = table.Column<int>(type: "int", nullable: false)
            .Annotation("SqlServer:Identity", "1, 1"),
        Ma_thuehoca = table.Column<string>(type: "nvarchar(450)", nullable: false),
        Soluong = table.Column<int>(type: "int", maxLength: 2147483647, nullable: false),
        Ma_danhmuc = table.Column<string>(type: "nvarchar(450)", nullable: false), // Ensure this matches the type and length of Danhmuc.Ma_danhmuc
        thanhtien = table.Column<int>(type: "int", maxLength: 2147483647, nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_Danhmuchoadon", x => x.Ma_danhmuchoadon);
        table.ForeignKey(
            name: "FK_Danhmuchoadon_Danhmuc_Ma_danhmuc",
            column: x => x.Ma_danhmuc,
            principalTable: "Danhmuc",
            principalColumn: "Ma_danhmuc",
            onDelete: ReferentialAction.Cascade);
        table.ForeignKey(
            name: "FK_Danhmuchoadon_Thuehoca_Ma_thuehoca",
            column: x => x.Ma_thuehoca,
            principalTable: "Thuehoca",
            principalColumn: "Ma_thuehoca",
            onDelete: ReferentialAction.Cascade);
    });

            migrationBuilder.CreateTable(
                name: "Giachothuehc",
                columns: table => new
                {
                    Ma_giachothuehc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_giahoca = table.Column<int>(type: "int", nullable: false),
                    Ma_thuehoca = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Soluong = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Thanhtien = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Trangthai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giachothuehc", x => x.Ma_giachothuehc);
                    table.ForeignKey(
                        name: "FK_Giachothuehc_Giahoca_Ma_giahoca",
                        column: x => x.Ma_giahoca,
                        principalTable: "Giahoca",
                        principalColumn: "Ma_giahoca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Giachothuehc_Thuehoca_Ma_thuehoca",
                        column: x => x.Ma_thuehoca,
                        principalTable: "Thuehoca",
                        principalColumn: "Ma_thuehoca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hoadondanhmuc",
                columns: table => new
                {
                    Ma_hddm = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tongthanhtoan = table.Column<int>(type: "int", maxLength: 2147483647, nullable: false),
                    Ma_thuehoca = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoadondanhmuc", x => x.Ma_hddm);
                    table.ForeignKey(
                        name: "FK_Hoadondanhmuc_Thuehoca_Ma_thuehoca",
                        column: x => x.Ma_thuehoca,
                        principalTable: "Thuehoca",
                        principalColumn: "Ma_thuehoca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tongsokg",
                columns: table => new
                {
                    Ma_tongsokg = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sokg = table.Column<float>(type: "real", maxLength: 100, nullable: false),
                    Ma_thuehoca = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    soluong = table.Column<int>(type: "int", nullable: false),
                    Tongsotien = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tongsokg", x => x.Ma_tongsokg);
                    table.ForeignKey(
                        name: "FK_Tongsokg_Thuehoca_Ma_thuehoca",
                        column: x => x.Ma_thuehoca,
                        principalTable: "Thuehoca",
                        principalColumn: "Ma_thuehoca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Chitietlancau_Ma_danhmuc",
                table: "Chitietlancau",
                column: "Ma_danhmuc");

            migrationBuilder.CreateIndex(
                name: "IX_Chitietlancau_Ma_thuehoca",
                table: "Chitietlancau",
                column: "Ma_thuehoca");

            migrationBuilder.CreateIndex(
                name: "IX_Danhmuc_Id",
                table: "Danhmuc",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Danhmuc_Ma_mathang",
                table: "Danhmuc",
                column: "Ma_mathang");

            migrationBuilder.CreateIndex(
                name: "IX_Danhmucgia_Id",
                table: "Danhmucgia",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Danhmuchoadon_Ma_danhmuc",
                table: "Danhmuchoadon",
                column: "Ma_danhmuc");

            migrationBuilder.CreateIndex(
                name: "IX_Danhmuchoadon_Ma_thuehoca",
                table: "Danhmuchoadon",
                column: "Ma_thuehoca");

            migrationBuilder.CreateIndex(
                name: "IX_Donvitinh_Id",
                table: "Donvitinh",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Giachothue_Ma_danhmucgia",
                table: "Giachothue",
                column: "Ma_danhmucgia");

            migrationBuilder.CreateIndex(
                name: "IX_Giachothuehc_Ma_giahoca",
                table: "Giachothuehc",
                column: "Ma_giahoca");

            migrationBuilder.CreateIndex(
                name: "IX_Giachothuehc_Ma_thuehoca",
                table: "Giachothuehc",
                column: "Ma_thuehoca");

            migrationBuilder.CreateIndex(
                name: "IX_Giahoca_Id",
                table: "Giahoca",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Hoadondanhmuc_Ma_thuehoca",
                table: "Hoadondanhmuc",
                column: "Ma_thuehoca");

            migrationBuilder.CreateIndex(
                name: "IX_Hoca_Id",
                table: "Hoca",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Khuvuccau_Ma_hoca",
                table: "Khuvuccau",
                column: "Ma_hoca");

            migrationBuilder.CreateIndex(
                name: "IX_Mathang_Id",
                table: "Mathang",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Phieunhapkho_Id",
                table: "Phieunhapkho",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Phieuxuatkho_Id",
                table: "Phieuxuatkho",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Quanlyhanghoa_Id",
                table: "Quanlyhanghoa",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Thongbao_Id",
                table: "Thongbao",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Thuehoca_Ma_khuvuccau",
                table: "Thuehoca",
                column: "Ma_khuvuccau");

            migrationBuilder.CreateIndex(
                name: "IX_Tongsokg_Ma_thuehoca",
                table: "Tongsokg",
                column: "Ma_thuehoca");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Chitietlancau");

            migrationBuilder.DropTable(
                name: "Danhmuchoadon");

            migrationBuilder.DropTable(
                name: "Donvitinh");

            migrationBuilder.DropTable(
                name: "Giachothue");

            migrationBuilder.DropTable(
                name: "Giachothuehc");

            migrationBuilder.DropTable(
                name: "Hoadondanhmuc");

            migrationBuilder.DropTable(
                name: "Phieunhapkho");

            migrationBuilder.DropTable(
                name: "Phieuxuatkho");

            migrationBuilder.DropTable(
                name: "Quanlyhanghoa");

            migrationBuilder.DropTable(
                name: "Thongbao");

            migrationBuilder.DropTable(
                name: "Tongsokg");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Danhmuc");

            migrationBuilder.DropTable(
                name: "Danhmucgia");

            migrationBuilder.DropTable(
                name: "Giahoca");

            migrationBuilder.DropTable(
                name: "Thuehoca");

            migrationBuilder.DropTable(
                name: "Mathang");

            migrationBuilder.DropTable(
                name: "Khuvuccau");

            migrationBuilder.DropTable(
                name: "Hoca");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
