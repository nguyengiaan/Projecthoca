using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class thembangid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "PhieuXuats",
                type: "nvarchar(450)",
                nullable: true);


            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "PhieuNhaps",
                type: "nvarchar(450)",
                nullable: true);



            migrationBuilder.CreateIndex(
                name: "IX_PhieuXuats_nguoidungId",
                table: "PhieuXuats",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhaps_nguoidungId",
                table: "PhieuNhaps",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhaps_AspNetUsers_nguoidungId",
                table: "PhieuNhaps",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuXuats_AspNetUsers_nguoidungId",
                table: "PhieuXuats",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Id",
                table: "PhieuXuats");

            migrationBuilder.DropColumn(
                name: "nguoidungId",
                table: "PhieuXuats");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PhieuNhaps");

            migrationBuilder.DropColumn(
                name: "nguoidungId",
                table: "PhieuNhaps");
        }
    }
}
