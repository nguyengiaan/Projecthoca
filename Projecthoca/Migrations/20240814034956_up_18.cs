using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chitietlancau_Thuehoca_ThuehocaMa_thuehoca",
                table: "Chitietlancau");


            migrationBuilder.DropIndex(
                name: "IX_Chitietlancau_Ma_tongsokg",
                table: "Chitietlancau");

            migrationBuilder.DropIndex(
                name: "IX_Chitietlancau_ThuehocaMa_thuehoca",
                table: "Chitietlancau");

            migrationBuilder.DropColumn(
                name: "Ma_tongsokg",
                table: "Chitietlancau");

            migrationBuilder.DropColumn(
                name: "ThuehocaMa_thuehoca",
                table: "Chitietlancau");

            migrationBuilder.AddColumn<int>(
                name: "TongsokgMa_tongsokg",
                table: "Chitietlancau",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietlancau_Thuehoca_Ma_danhmuc",
                table: "Chitietlancau",
                column: "Ma_danhmuc",
                principalTable: "Thuehoca",
                principalColumn: "Ma_thuehoca",
                onDelete: ReferentialAction.Cascade);

 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chitietlancau_Thuehoca_Ma_danhmuc",
                table: "Chitietlancau");

            migrationBuilder.DropForeignKey(
                name: "FK_Chitietlancau_Tongsokg_TongsokgMa_tongsokg",
                table: "Chitietlancau");

            migrationBuilder.DropIndex(
                name: "IX_Chitietlancau_TongsokgMa_tongsokg",
                table: "Chitietlancau");

            migrationBuilder.DropColumn(
                name: "TongsokgMa_tongsokg",
                table: "Chitietlancau");

            migrationBuilder.AddColumn<int>(
                name: "Ma_tongsokg",
                table: "Chitietlancau",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ThuehocaMa_thuehoca",
                table: "Chitietlancau",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Chitietlancau_Ma_tongsokg",
                table: "Chitietlancau",
                column: "Ma_tongsokg");

            migrationBuilder.CreateIndex(
                name: "IX_Chitietlancau_ThuehocaMa_thuehoca",
                table: "Chitietlancau",
                column: "ThuehocaMa_thuehoca");

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietlancau_Thuehoca_ThuehocaMa_thuehoca",
                table: "Chitietlancau",
                column: "ThuehocaMa_thuehoca",
                principalTable: "Thuehoca",
                principalColumn: "Ma_thuehoca",
                onDelete: ReferentialAction.Cascade);

     
        }
    }
}
