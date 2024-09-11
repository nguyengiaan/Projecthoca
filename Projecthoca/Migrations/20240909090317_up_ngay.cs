using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_ngay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
    
            migrationBuilder.AddColumn<DateTime>(
                name: "Ngayxuat",
                table: "ChiTietPhieuXuats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Ngaynhap",
                table: "ChiTietPhieuNhaps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));


  
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuNhaps_Danhmuc_Ma_sanpham",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuNhaps_PhieuNhaps_SoPhieu",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuXuats_Danhmuc_Ma_sanpham",
                table: "ChiTietPhieuXuats");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuXuats_PhieuXuats_SoPhieu",
                table: "ChiTietPhieuXuats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietPhieuXuats",
                table: "ChiTietPhieuXuats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietPhieuNhaps",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropColumn(
                name: "Ngayxuat",
                table: "ChiTietPhieuXuats");

            migrationBuilder.DropColumn(
                name: "Ngaynhap",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.RenameTable(
                name: "ChiTietPhieuXuats",
                newName: "ChiTietPhieuXuat");

            migrationBuilder.RenameTable(
                name: "ChiTietPhieuNhaps",
                newName: "ChiTietPhieuNhap");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietPhieuXuats_SoPhieu",
                table: "ChiTietPhieuXuat",
                newName: "IX_ChiTietPhieuXuat_SoPhieu");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietPhieuXuats_Ma_sanpham",
                table: "ChiTietPhieuXuat",
                newName: "IX_ChiTietPhieuXuat_Ma_sanpham");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietPhieuNhaps_SoPhieu",
                table: "ChiTietPhieuNhap",
                newName: "IX_ChiTietPhieuNhap_SoPhieu");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietPhieuNhaps_Ma_sanpham",
                table: "ChiTietPhieuNhap",
                newName: "IX_ChiTietPhieuNhap_Ma_sanpham");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietPhieuXuat",
                table: "ChiTietPhieuXuat",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietPhieuNhap",
                table: "ChiTietPhieuNhap",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhap_Danhmuc_Ma_sanpham",
                table: "ChiTietPhieuNhap",
                column: "Ma_sanpham",
                principalTable: "Danhmuc",
                principalColumn: "Ma_danhmuc",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhap_PhieuNhaps_SoPhieu",
                table: "ChiTietPhieuNhap",
                column: "SoPhieu",
                principalTable: "PhieuNhaps",
                principalColumn: "SoPhieu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuXuat_Danhmuc_Ma_sanpham",
                table: "ChiTietPhieuXuat",
                column: "Ma_sanpham",
                principalTable: "Danhmuc",
                principalColumn: "Ma_danhmuc",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuXuat_PhieuXuats_SoPhieu",
                table: "ChiTietPhieuXuat",
                column: "SoPhieu",
                principalTable: "PhieuXuats",
                principalColumn: "SoPhieu",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
