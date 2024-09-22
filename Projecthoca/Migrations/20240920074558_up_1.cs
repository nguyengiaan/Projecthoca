using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
       
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DanhmucMa_danhmuc",
                table: "Chitietlancau",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chitietlancau_DanhmucMa_danhmuc",
                table: "Chitietlancau",
                column: "DanhmucMa_danhmuc");

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietlancau_Danhmuc_DanhmucMa_danhmuc",
                table: "Chitietlancau",
                column: "DanhmucMa_danhmuc",
                principalTable: "Danhmuc",
                principalColumn: "Ma_danhmuc");
        }
    }
}
