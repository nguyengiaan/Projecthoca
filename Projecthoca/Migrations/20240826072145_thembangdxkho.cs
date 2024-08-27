using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class thembangdxkho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diadiem",
                table: "Phieunhapkho");

            migrationBuilder.DropColumn(
                name: "Dongia",
                table: "Phieunhapkho");

            migrationBuilder.DropColumn(
                name: "Donvitinh",
                table: "Phieunhapkho");

            migrationBuilder.DropColumn(
                name: "Soluong",
                table: "Phieunhapkho");

            migrationBuilder.DropColumn(
                name: "Ten_danhmuc",
                table: "Phieunhapkho");

            migrationBuilder.DropColumn(
                name: "Tenkho",
                table: "Phieunhapkho");

            migrationBuilder.DropColumn(
                name: "Thanhtien",
                table: "Phieunhapkho");

            migrationBuilder.CreateTable(
                name: "Danhsachhhkho",
                columns: table => new
                {
                    Ma_hanghoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_danhmuc = table.Column<string>(type: "nvarchar(450)", maxLength: 100, nullable: false),
                    Ma_phieunhapkho = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Soluong = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Thanhtien = table.Column<int>(type: "int", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Danhsachhhkho", x => x.Ma_hanghoa);
                    table.ForeignKey(
                        name: "FK_Danhsachhhkho_Danhmuc_Ma_danhmuc",
                        column: x => x.Ma_danhmuc,
                        principalTable: "Danhmuc",
                        principalColumn: "Ma_danhmuc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Danhsachhhkho_Phieunhapkho_Ma_phieunhapkho",
                        column: x => x.Ma_phieunhapkho,
                        principalTable: "Phieunhapkho",
                        principalColumn: "Ma_phieunhapkho",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Danhsachhhkho_Ma_danhmuc",
                table: "Danhsachhhkho",
                column: "Ma_danhmuc");

            migrationBuilder.CreateIndex(
                name: "IX_Danhsachhhkho_Ma_phieunhapkho",
                table: "Danhsachhhkho",
                column: "Ma_phieunhapkho");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Danhsachhhkho");

            migrationBuilder.AddColumn<string>(
                name: "Diadiem",
                table: "Phieunhapkho",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Dongia",
                table: "Phieunhapkho",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Donvitinh",
                table: "Phieunhapkho",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Soluong",
                table: "Phieunhapkho",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Ten_danhmuc",
                table: "Phieunhapkho",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tenkho",
                table: "Phieunhapkho",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Thanhtien",
                table: "Phieunhapkho",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);
        }
    }
}
