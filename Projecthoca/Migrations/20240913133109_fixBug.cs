using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class fixBug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhaps_AspNetUsers_nguoidungId",
                table: "PhieuNhaps");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuXuats_AspNetUsers_nguoidungId",
                table: "PhieuXuats");

            migrationBuilder.DropIndex(
                name: "IX_PhieuXuats_nguoidungId",
                table: "PhieuXuats");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhaps_nguoidungId",
                table: "PhieuNhaps");

            migrationBuilder.DropColumn(
                name: "nguoidungId",
                table: "PhieuXuats");

            migrationBuilder.DropColumn(
                name: "nguoidungId",
                table: "PhieuNhaps");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "PhieuXuats",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "PhieuNhaps",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuXuats_Id",
                table: "PhieuXuats",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhaps_Id",
                table: "PhieuNhaps",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhaps_AspNetUsers_Id",
                table: "PhieuNhaps",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuXuats_AspNetUsers_Id",
                table: "PhieuXuats",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhaps_AspNetUsers_Id",
                table: "PhieuNhaps");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuXuats_AspNetUsers_Id",
                table: "PhieuXuats");

            migrationBuilder.DropIndex(
                name: "IX_PhieuXuats_Id",
                table: "PhieuXuats");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhaps_Id",
                table: "PhieuNhaps");

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

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "PhieuXuats",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "nguoidungId",
                table: "PhieuXuats",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "PhieuNhaps",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "nguoidungId",
                table: "PhieuNhaps",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuXuats_nguoidungId",
                table: "PhieuXuats",
                column: "nguoidungId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhaps_nguoidungId",
                table: "PhieuNhaps",
                column: "nguoidungId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhaps_AspNetUsers_nguoidungId",
                table: "PhieuNhaps",
                column: "nguoidungId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuXuats_AspNetUsers_nguoidungId",
                table: "PhieuXuats",
                column: "nguoidungId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
