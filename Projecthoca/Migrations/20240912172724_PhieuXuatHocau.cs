using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class PhieuXuatHocau : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ChuyenKhoan",
                table: "PhieuXuats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GiamGia",
                table: "PhieuXuats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TenKhuvuc",
                table: "PhieuXuats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TienMat",
                table: "PhieuXuats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChuyenKhoan",
                table: "PhieuXuats");

            migrationBuilder.DropColumn(
                name: "GiamGia",
                table: "PhieuXuats");

            migrationBuilder.DropColumn(
                name: "TenKhuvuc",
                table: "PhieuXuats");

            migrationBuilder.DropColumn(
                name: "TienMat",
                table: "PhieuXuats");
        }
    }
}
