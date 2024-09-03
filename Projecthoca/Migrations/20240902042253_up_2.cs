using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Khachhang",
                columns: table => new
                {
                    Ma_khachhang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten_khachhang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sodienthoai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ngaysinh = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khachhang", x => x.Ma_khachhang);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Khachhang");
        }
    }
}
