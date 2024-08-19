using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_36 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add the new column first
            migrationBuilder.AddColumn<string>(
                name: "Ma_mathang",
                table: "Danhmuc",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            // Ensure all existing records have valid Ma_mathang values
            migrationBuilder.Sql("DELETE FROM Danhmuc WHERE Ma_mathang NOT IN (SELECT Ma_mathang FROM Mathang)");

            // Other migration commands
            migrationBuilder.DropForeignKey(
                name: "FK_Danhmuc_AspNetUsers_NguoidungId",
                table: "Danhmuc");

            migrationBuilder.DropIndex(
                name: "IX_Danhmuc_NguoidungId",
                table: "Danhmuc");

            migrationBuilder.DropColumn(
                name: "Mieuta",
                table: "Danhmuc");

            migrationBuilder.DropColumn(
                name: "NguoidungId",
                table: "Danhmuc");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Danhmuc",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Danhmuc_Id",
                table: "Danhmuc",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Danhmuc_Ma_mathang",
                table: "Danhmuc",
                column: "Ma_mathang");

            migrationBuilder.AddForeignKey(
                name: "FK_Danhmuc_AspNetUsers_Id",
                table: "Danhmuc",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Danhmuc_Mathang_Ma_mathang",
                table: "Danhmuc",
                column: "Ma_mathang",
                principalTable: "Mathang",
                principalColumn: "Ma_mathang",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Danhmuc_AspNetUsers_Id",
                table: "Danhmuc");

            migrationBuilder.DropForeignKey(
                name: "FK_Danhmuc_Mathang_Ma_mathang",
                table: "Danhmuc");

            migrationBuilder.DropIndex(
                name: "IX_Danhmuc_Id",
                table: "Danhmuc");

            migrationBuilder.DropIndex(
                name: "IX_Danhmuc_Ma_mathang",
                table: "Danhmuc");

            migrationBuilder.DropColumn(
                name: "Ma_mathang",
                table: "Danhmuc");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Danhmuc",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mieuta",
                table: "Danhmuc",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NguoidungId",
                table: "Danhmuc",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Danhmuc_NguoidungId",
                table: "Danhmuc",
                column: "NguoidungId");

            migrationBuilder.AddForeignKey(
                name: "FK_Danhmuc_AspNetUsers_NguoidungId",
                table: "Danhmuc",
                column: "NguoidungId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
