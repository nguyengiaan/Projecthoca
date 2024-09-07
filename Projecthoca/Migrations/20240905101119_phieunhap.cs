using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class phieunhap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GiaNhap",
                table: "Quanlyhanghoa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Soluong",
                table: "Quanlyhanghoa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PhieuNhaps",
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
                    table.PrimaryKey("PK_PhieuNhaps", x => x.SoPhieu);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuNhaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoPhieu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ma_sanpham = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuanlyhanghoaMa_sanpham = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuNhaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhaps_Danhmuc_Ma_sanpham",
                        column: x => x.Ma_sanpham,
                        principalTable: "Danhmuc",
                        principalColumn: "Ma_danhmuc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhaps_PhieuNhaps_SoPhieu",
                        column: x => x.SoPhieu,
                        principalTable: "PhieuNhaps",
                        principalColumn: "SoPhieu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhaps_Quanlyhanghoa_QuanlyhanghoaMa_sanpham",
                        column: x => x.QuanlyhanghoaMa_sanpham,
                        principalTable: "Quanlyhanghoa",
                        principalColumn: "Ma_sanpham");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_Ma_sanpham",
                table: "ChiTietPhieuNhaps",
                column: "Ma_sanpham");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_QuanlyhanghoaMa_sanpham",
                table: "ChiTietPhieuNhaps",
                column: "QuanlyhanghoaMa_sanpham");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_SoPhieu",
                table: "ChiTietPhieuNhaps",
                column: "SoPhieu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietPhieuNhaps");

            migrationBuilder.DropTable(
                name: "PhieuNhaps");

            migrationBuilder.DropColumn(
                name: "GiaNhap",
                table: "Quanlyhanghoa");

            migrationBuilder.DropColumn(
                name: "Soluong",
                table: "Quanlyhanghoa");
        }
    }
}
