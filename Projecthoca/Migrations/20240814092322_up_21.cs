using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chitietlancau_Thuehoca_Ma_danhmuc",
                table: "Chitietlancau");

     



            migrationBuilder.DropColumn(
                name: "TongsokgMa_tongsokg",
                table: "Chitietlancau");

            migrationBuilder.AlterColumn<string>(
                name: "Ma_thuehoca",
                table: "Chitietlancau",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Chitietlancau_Ma_thuehoca",
                table: "Chitietlancau",
                column: "Ma_thuehoca");

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietlancau_Thuehoca_Ma_thuehoca",
                table: "Chitietlancau",
                column: "Ma_thuehoca",
                principalTable: "Thuehoca",
                principalColumn: "Ma_thuehoca",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chitietlancau_Thuehoca_Ma_thuehoca",
                table: "Chitietlancau");

            migrationBuilder.DropIndex(
                name: "IX_Chitietlancau_Ma_thuehoca",
                table: "Chitietlancau");

            migrationBuilder.AlterColumn<string>(
                name: "Ma_thuehoca",
                table: "Chitietlancau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "TongsokgMa_tongsokg",
                table: "Chitietlancau",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chitietlancau_TongsokgMa_tongsokg",
                table: "Chitietlancau",
                column: "TongsokgMa_tongsokg");

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietlancau_Thuehoca_Ma_danhmuc",
                table: "Chitietlancau",
                column: "Ma_danhmuc",
                principalTable: "Thuehoca",
                principalColumn: "Ma_thuehoca",
                onDelete: ReferentialAction.Cascade);

        
        }
    }
}
