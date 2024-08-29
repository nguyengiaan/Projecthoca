using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class initt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ma_nhacungcap",
                table: "Danhmuc",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Nhacungcap",
                columns: table => new
                {
                    Ma_nhacungcap = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Nhacungcap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhacungcap", x => x.Ma_nhacungcap);
                    table.ForeignKey(
                        name: "FK_Nhacungcap_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nhacungcap_Id",
                table: "Nhacungcap",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nhacungcap");

            migrationBuilder.DropColumn(
                name: "Ma_nhacungcap",
                table: "Danhmuc");
        }
    }
}
