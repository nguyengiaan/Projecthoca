using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phieunhapkho",
                columns: table => new
                {
                    Ma_phieunhapkho = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ngaynhap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nguoinhap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tenkho = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Diadiem = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Donvitinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Soluong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dongia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Thanhtien = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phieunhapkho", x => x.Ma_phieunhapkho);
                    table.ForeignKey(
                        name: "FK_Phieunhapkho_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phieunhapkho_Id",
                table: "Phieunhapkho",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phieunhapkho");
        }
    }
}
