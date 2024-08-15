using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hoadondanhmuc_Thuehoca_Ma_hddm",
                table: "Hoadondanhmuc");

            migrationBuilder.AddColumn<string>(
                name: "Ma_thuehoca",
                table: "Hoadondanhmuc",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Hoadondanhmuc_Ma_thuehoca",
                table: "Hoadondanhmuc",
                column: "Ma_thuehoca");

            migrationBuilder.AddForeignKey(
                name: "FK_Hoadondanhmuc_Thuehoca_Ma_thuehoca",
                table: "Hoadondanhmuc",
                column: "Ma_thuehoca",
                principalTable: "Thuehoca",
                principalColumn: "Ma_thuehoca",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hoadondanhmuc_Thuehoca_Ma_thuehoca",
                table: "Hoadondanhmuc");

            migrationBuilder.DropIndex(
                name: "IX_Hoadondanhmuc_Ma_thuehoca",
                table: "Hoadondanhmuc");

            migrationBuilder.DropColumn(
                name: "Ma_thuehoca",
                table: "Hoadondanhmuc");

            migrationBuilder.AddForeignKey(
                name: "FK_Hoadondanhmuc_Thuehoca_Ma_hddm",
                table: "Hoadondanhmuc",
                column: "Ma_hddm",
                principalTable: "Thuehoca",
                principalColumn: "Ma_thuehoca",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
