using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_nguoidungid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
       name: "nguoidungId",
       table: "PhieuXuats",
       type: "int",
       nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nguoidungId",
                table: "PhieuNhaps",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
