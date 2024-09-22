using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_chitietlancau : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chitietlancau_Danhmuc_Ma_danhmuc",
                table: "Chitietlancau");

            migrationBuilder.DropIndex(
                name: "IX_Chitietlancau_Ma_danhmuc",
                table: "Chitietlancau");

            migrationBuilder.DropColumn(
                name: "Ma_danhmuc",
                table: "Chitietlancau");



            migrationBuilder.AddColumn<int>(
                name: "Ma_haisan",
                table: "Chitietlancau",
                type: "int",
                nullable: false,
                defaultValue: 0);


            migrationBuilder.CreateIndex(
                name: "IX_Chitietlancau_Ma_haisan",
                table: "Chitietlancau",
                column: "Ma_haisan");


            migrationBuilder.AddForeignKey(
                name: "FK_Chitietlancau_Haisan_Ma_haisan",
                table: "Chitietlancau",
                column: "Ma_haisan",
                principalTable: "Haisan",
                principalColumn: "Ma_haisan",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chitietlancau_Danhmuc_DanhmucMa_danhmuc",
                table: "Chitietlancau");

            migrationBuilder.DropForeignKey(
                name: "FK_Chitietlancau_Haisan_Ma_haisan",
                table: "Chitietlancau");

            migrationBuilder.DropIndex(
                name: "IX_Chitietlancau_DanhmucMa_danhmuc",
                table: "Chitietlancau");

            migrationBuilder.DropIndex(
                name: "IX_Chitietlancau_Ma_haisan",
                table: "Chitietlancau");

            migrationBuilder.DropColumn(
                name: "DanhmucMa_danhmuc",
                table: "Chitietlancau");

            migrationBuilder.DropColumn(
                name: "Ma_haisan",
                table: "Chitietlancau");

            migrationBuilder.AddColumn<string>(
                name: "Ma_danhmuc",
                table: "Chitietlancau",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Chitietlancau_Ma_danhmuc",
                table: "Chitietlancau",
                column: "Ma_danhmuc");

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietlancau_Danhmuc_Ma_danhmuc",
                table: "Chitietlancau",
                column: "Ma_danhmuc",
                principalTable: "Danhmuc",
                principalColumn: "Ma_danhmuc",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
