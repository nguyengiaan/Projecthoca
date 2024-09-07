using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_xh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hoadonxuatban",
                columns: table => new
                {
                    Ma_hoadonxuatban = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Soluong = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Ma_danhmuc = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Ma_phieuxuatkho = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoadonxuatban", x => x.Ma_hoadonxuatban);
                    table.ForeignKey(
                        name: "FK_Hoadonxuatban_Danhmuc_Ma_danhmuc",
                        column: x => x.Ma_danhmuc,
                        principalTable: "Danhmuc",
                        principalColumn: "Ma_danhmuc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hoadonxuatban_Phieuxuatkho_Ma_phieuxuatkho",
                        column: x => x.Ma_phieuxuatkho,
                        principalTable: "Phieuxuatkho",
                        principalColumn: "Ma_phieuxuatkho",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hoadonxuatban_Ma_danhmuc",
                table: "Hoadonxuatban",
                column: "Ma_danhmuc");

            migrationBuilder.CreateIndex(
                name: "IX_Hoadonxuatban_Ma_phieuxuatkho",
                table: "Hoadonxuatban",
                column: "Ma_phieuxuatkho");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hoadonxuatban");
        }
    }
}
