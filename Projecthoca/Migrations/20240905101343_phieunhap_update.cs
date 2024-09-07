using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class phieunhap_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuNhaps_Quanlyhanghoa_QuanlyhanghoaMa_sanpham",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietPhieuNhaps_QuanlyhanghoaMa_sanpham",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropColumn(
                name: "QuanlyhanghoaMa_sanpham",
                table: "ChiTietPhieuNhaps");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuanlyhanghoaMa_sanpham",
                table: "ChiTietPhieuNhaps",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_QuanlyhanghoaMa_sanpham",
                table: "ChiTietPhieuNhaps",
                column: "QuanlyhanghoaMa_sanpham");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhaps_Quanlyhanghoa_QuanlyhanghoaMa_sanpham",
                table: "ChiTietPhieuNhaps",
                column: "QuanlyhanghoaMa_sanpham",
                principalTable: "Quanlyhanghoa",
                principalColumn: "Ma_sanpham");
        }
    }
}
