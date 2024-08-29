using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class initl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quanlyhanghoa_AspNetUsers_Id",
                table: "Quanlyhanghoa");

            migrationBuilder.AddForeignKey(
                name: "FK_Quanlyhanghoa_AspNetUsers_Id",
                table: "Quanlyhanghoa",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quanlyhanghoa_AspNetUsers_Id",
                table: "Quanlyhanghoa");

            migrationBuilder.AddForeignKey(
                name: "FK_Quanlyhanghoa_AspNetUsers_Id",
                table: "Quanlyhanghoa",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
