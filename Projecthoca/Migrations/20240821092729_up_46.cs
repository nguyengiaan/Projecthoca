using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_46 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quanlyhanghoa",
                columns: table => new
                {
                    Ma_sanpham = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten_sanpham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ten_donvitinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true), // Cập nhật kiểu dữ liệu và độ dài
                    Giaban = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quanlyhanghoa", x => x.Ma_sanpham);
                    table.ForeignKey(
                        name: "FK_Quanlyhanghoa_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quanlyhanghoa_Id",
                table: "Quanlyhanghoa",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quanlyhanghoa");
        }
    }
}
