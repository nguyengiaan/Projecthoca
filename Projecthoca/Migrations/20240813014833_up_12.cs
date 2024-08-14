using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Giahoca",
                columns: table => new
                {
                    Ma_giahoca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gia_khongca = table.Column<int>(type: "int", maxLength: 2147483647, nullable: false),
                    Gia_coca = table.Column<int>(type: "int", maxLength: 2147483647, nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giahoca", x => x.Ma_giahoca);
                    table.ForeignKey(
                        name: "FK_Giahoca_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Giahoca_Id",
                table: "Giahoca",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Giahoca");
        }
    }
}
