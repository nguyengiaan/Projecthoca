using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class it : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ma_nhacungcap",
                table: "Danhmuc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ma_nhacungcap",
                table: "Danhmuc",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
