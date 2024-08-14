using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tieude",
                table: "Danhmucgia",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 2147483647);

            migrationBuilder.AddColumn<string>(
                name: "Mieuta",
                table: "Danhmuc",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Chitietlancau",
                columns: table => new
                {
                    Ma_chitietlancau = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    giocau = table.Column<TimeSpan>(type: "time", maxLength: 15, nullable: false),
                    sokg = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    Ma_danhmuc = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chitietlancau", x => x.Ma_chitietlancau);
                    table.ForeignKey(
                        name: "FK_Chitietlancau_Danhmuc_Ma_danhmuc",
                        column: x => x.Ma_danhmuc,
                        principalTable: "Danhmuc",
                        principalColumn: "Ma_danhmuc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chitietlancau_Ma_danhmuc",
                table: "Chitietlancau",
                column: "Ma_danhmuc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chitietlancau");

            migrationBuilder.DropColumn(
                name: "Mieuta",
                table: "Danhmuc");

            migrationBuilder.AlterColumn<string>(
                name: "Tieude",
                table: "Danhmucgia",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);
        }
    }
}
