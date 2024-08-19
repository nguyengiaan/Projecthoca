using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_40 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ten_khuvuc",
                table: "Phieuxuatkho",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ten_danhmuc",
                table: "Phieunhapkho",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ten_khuvuc",
                table: "Phieuxuatkho");

            migrationBuilder.DropColumn(
                name: "Ten_danhmuc",
                table: "Phieunhapkho");
        }
    }
}
