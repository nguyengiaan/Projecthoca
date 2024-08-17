using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phieuxuatkho",
                columns: table => new
                {
                    Ma_phieuxuatkho = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ngayxuat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Thanhtien = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    giamgia = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    Tienmat = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    Chuyenkhoan = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    Tongtien = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phieuxuatkho", x => x.Ma_phieuxuatkho);
                    table.ForeignKey(
                        name: "FK_Phieuxuatkho_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phieuxuatkho_Id",
                table: "Phieuxuatkho",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phieuxuatkho");
        }
    }
}
