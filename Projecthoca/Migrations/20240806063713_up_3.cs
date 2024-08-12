using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thuehoca_Hoca_Ma_hoca",
                table: "Thuehoca");

            migrationBuilder.RenameColumn(
                name: "Ma_hoca",
                table: "Thuehoca",
                newName: "Ma_khuvuccau");

            migrationBuilder.RenameIndex(
                name: "IX_Thuehoca_Ma_hoca",
                table: "Thuehoca",
                newName: "IX_Thuehoca_Ma_khuvuccau");

            migrationBuilder.AddColumn<int>(
                name: "Kieuhoca",
                table: "Hoca",
                type: "int",
                maxLength: 2147483647,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Khuvuccau",
                columns: table => new
                {
                    Ma_Khuvuccau = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten_Khuvuccau = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Trangthai = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Ghichu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ma_hoca = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khuvuccau", x => x.Ma_Khuvuccau);
                    table.ForeignKey(
                        name: "FK_Khuvuccau_Hoca_Ma_hoca",
                        column: x => x.Ma_hoca,
                        principalTable: "Hoca",
                        principalColumn: "Ma_hoca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Khuvuccau_Ma_hoca",
                table: "Khuvuccau",
                column: "Ma_hoca");

            migrationBuilder.AddForeignKey(
                name: "FK_Thuehoca_Khuvuccau_Ma_khuvuccau",
                table: "Thuehoca",
                column: "Ma_khuvuccau",
                principalTable: "Khuvuccau",
                principalColumn: "Ma_Khuvuccau",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thuehoca_Khuvuccau_Ma_khuvuccau",
                table: "Thuehoca");

            migrationBuilder.DropTable(
                name: "Khuvuccau");

            migrationBuilder.DropColumn(
                name: "Kieuhoca",
                table: "Hoca");

            migrationBuilder.RenameColumn(
                name: "Ma_khuvuccau",
                table: "Thuehoca",
                newName: "Ma_hoca");

            migrationBuilder.RenameIndex(
                name: "IX_Thuehoca_Ma_khuvuccau",
                table: "Thuehoca",
                newName: "IX_Thuehoca_Ma_hoca");

            migrationBuilder.AddForeignKey(
                name: "FK_Thuehoca_Hoca_Ma_hoca",
                table: "Thuehoca",
                column: "Ma_hoca",
                principalTable: "Hoca",
                principalColumn: "Ma_hoca",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
