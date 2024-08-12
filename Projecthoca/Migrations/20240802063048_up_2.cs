using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Danhmuc",
                columns: table => new
                {
                    Ma_danhmuc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten_danhmuc = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Gia = table.Column<int>(type: "int", maxLength: 2147483647, nullable: false),
                    Donvitinh = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    soluong = table.Column<int>(type: "int", maxLength: 2147483647, nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoidungId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Danhmuc", x => x.Ma_danhmuc);
                    table.ForeignKey(
                        name: "FK_Danhmuc_AspNetUsers_NguoidungId",
                        column: x => x.NguoidungId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Danhmucgia",
                columns: table => new
                {
                    Ma_danhmucgia = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tieude = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
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
                name: "Hoca",
                columns: table => new
                {
                    Ma_hoca = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten_hoca = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Trangthai = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
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
                name: "Thuehoca",
                columns: table => new
                {
                    Ma_thuehoca = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ma_thoigian = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Ma_hoca = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten_khachhang = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Sodienthoai = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Ngaycau = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Thoigianbatdau = table.Column<DateTime>(type: "datetime2", maxLength: 2147483647, nullable: false),
                    Thoigianketthuc = table.Column<DateTime>(type: "datetime2", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thuehoca", x => x.Ma_thuehoca);
                    table.ForeignKey(
                        name: "FK_Thuehoca_Hoca_Ma_hoca",
                        column: x => x.Ma_hoca,
                        principalTable: "Hoca",
                        principalColumn: "Ma_hoca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hoadondanhmuc",
                columns: table => new
                {
                    Ma_hddm = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tongthanhtoan = table.Column<int>(type: "int", maxLength: 2147483647, nullable: false),
                    Ma_thuehoca = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Giachothue = table.Column<int>(type: "int", maxLength: 2147483647, nullable: false)
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
                name: "Danhmuchoadon",
                columns: table => new
                {
                    Ma_danhmuchoadon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gia = table.Column<int>(type: "int", maxLength: 2147483647, nullable: false),
                    Soluong = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    DVT = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Ma_hddm = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ma_danhmuc = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                        name: "FK_Danhmuchoadon_Hoadondanhmuc_Ma_hddm",
                        column: x => x.Ma_hddm,
                        principalTable: "Hoadondanhmuc",
                        principalColumn: "Ma_hddm",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Danhmuc_NguoidungId",
                table: "Danhmuc",
                column: "NguoidungId");

            migrationBuilder.CreateIndex(
                name: "IX_Danhmucgia_Id",
                table: "Danhmucgia",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Danhmuchoadon_Ma_danhmuc",
                table: "Danhmuchoadon",
                column: "Ma_danhmuc");

            migrationBuilder.CreateIndex(
                name: "IX_Danhmuchoadon_Ma_hddm",
                table: "Danhmuchoadon",
                column: "Ma_hddm");

            migrationBuilder.CreateIndex(
                name: "IX_Giachothue_Ma_danhmucgia",
                table: "Giachothue",
                column: "Ma_danhmucgia");

            migrationBuilder.CreateIndex(
                name: "IX_Hoadondanhmuc_Ma_thuehoca",
                table: "Hoadondanhmuc",
                column: "Ma_thuehoca");

            migrationBuilder.CreateIndex(
                name: "IX_Hoca_Id",
                table: "Hoca",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Thuehoca_Ma_hoca",
                table: "Thuehoca",
                column: "Ma_hoca");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Danhmuchoadon");

            migrationBuilder.DropTable(
                name: "Giachothue");

            migrationBuilder.DropTable(
                name: "Danhmuc");

            migrationBuilder.DropTable(
                name: "Hoadondanhmuc");

            migrationBuilder.DropTable(
                name: "Danhmucgia");

            migrationBuilder.DropTable(
                name: "Thuehoca");

            migrationBuilder.DropTable(
                name: "Hoca");
        }
    }
}
