using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class phieuxuat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhieuXuats",
                columns: table => new
                {
                    SoPhieu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayPhieu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Khachhang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhanVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NoCu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThanhToan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConLai = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HanThanhToan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuXuats", x => x.SoPhieu);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuXuats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoPhieu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ma_sanpham = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuXuats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuXuats_Danhmuc_Ma_sanpham",
                        column: x => x.Ma_sanpham,
                        principalTable: "Danhmuc",
                        principalColumn: "Ma_danhmuc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuXuats_PhieuXuats_SoPhieu",
                        column: x => x.SoPhieu,
                        principalTable: "PhieuXuats",
                        principalColumn: "SoPhieu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuXuats_Ma_sanpham",
                table: "ChiTietPhieuXuats",
                column: "Ma_sanpham");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuXuats_SoPhieu",
                table: "ChiTietPhieuXuats",
                column: "SoPhieu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietPhieuXuats");

            migrationBuilder.DropTable(
                name: "PhieuXuats");
        }
    }
}
