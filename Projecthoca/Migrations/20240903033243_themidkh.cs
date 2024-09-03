using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class themidkh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Khachhang",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Khachhang_Id",
                table: "Khachhang",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Khachhang_AspNetUsers_Id",
                table: "Khachhang",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Khachhang_AspNetUsers_Id",
                table: "Khachhang");

            migrationBuilder.DropIndex(
                name: "IX_Khachhang_Id",
                table: "Khachhang");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Khachhang");
        }
    }
}
