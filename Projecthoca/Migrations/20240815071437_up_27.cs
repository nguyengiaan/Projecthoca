using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Giachothuehc",
                columns: table => new
                {
                    Ma_giachothuehc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_giahoca = table.Column<int>(type: "int", nullable: false),
                    Ma_thuehoca = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Soluong = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Thanhtien = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Trangthai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giachothuehc", x => x.Ma_giachothuehc);
                    table.ForeignKey(
                        name: "FK_Giachothuehc_Giahoca_Ma_giahoca",
                        column: x => x.Ma_giahoca,
                        principalTable: "Giahoca",
                        principalColumn: "Ma_giahoca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Giachothuehc_Thuehoca_Ma_thuehoca",
                        column: x => x.Ma_thuehoca,
                        principalTable: "Thuehoca",
                        principalColumn: "Ma_thuehoca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Giachothuehc_Ma_giahoca",
                table: "Giachothuehc",
                column: "Ma_giahoca");

            migrationBuilder.CreateIndex(
                name: "IX_Giachothuehc_Ma_thuehoca",
                table: "Giachothuehc",
                column: "Ma_thuehoca");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Giachothuehc");
        }
    }
}
