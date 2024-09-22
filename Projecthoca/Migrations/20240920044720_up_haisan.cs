using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_haisan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Haisan",
                columns: table => new
                {
                    Ma_haisan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten_haisan = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    sokg = table.Column<int>(type: "int", maxLength: 450, nullable: false),
                    Gia = table.Column<int>(type: "int", maxLength: 450, nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haisan", x => x.Ma_haisan);
                    table.ForeignKey(
                        name: "FK_Haisan_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Haisan_Id",
                table: "Haisan",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Haisan");
        }
    }
}
