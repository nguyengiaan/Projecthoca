using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donvitinh",
                columns: table => new
                {
                    Ma_donvitinh = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten_donvitinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donvitinh", x => x.Ma_donvitinh);
                    table.ForeignKey(
                        name: "FK_Donvitinh_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Mathang",
                columns: table => new
                {
                    Ma_mathang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten_mathang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mathang", x => x.Ma_mathang);
                    table.ForeignKey(
                        name: "FK_Mathang_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donvitinh_Id",
                table: "Donvitinh",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mathang_Id",
                table: "Mathang",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donvitinh");

            migrationBuilder.DropTable(
                name: "Mathang");
        }
    }
}
