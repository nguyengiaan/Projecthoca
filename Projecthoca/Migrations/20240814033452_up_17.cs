using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "sokg",
                table: "Chitietlancau",
                type: "real",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 15);

            migrationBuilder.AddColumn<string>(
                name: "Ma_thuehoca",
                table: "Chitietlancau",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Ma_tongsokg",
                table: "Chitietlancau",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ThuehocaMa_thuehoca",
                table: "Chitietlancau",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Tongsokg",
                columns: table => new
                {
                    Ma_tongsokg = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sokg = table.Column<float>(type: "real", maxLength: 100, nullable: false),
                    Ma_thuehoca = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tongsokg", x => x.Ma_tongsokg);
                    table.ForeignKey(
                        name: "FK_Tongsokg_Thuehoca_Ma_thuehoca",
                        column: x => x.Ma_thuehoca,
                        principalTable: "Thuehoca",
                        principalColumn: "Ma_thuehoca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chitietlancau_Ma_tongsokg",
                table: "Chitietlancau",
                column: "Ma_tongsokg");

            migrationBuilder.CreateIndex(
                name: "IX_Chitietlancau_ThuehocaMa_thuehoca",
                table: "Chitietlancau",
                column: "ThuehocaMa_thuehoca");

            migrationBuilder.CreateIndex(
                name: "IX_Tongsokg_Ma_thuehoca",
                table: "Tongsokg",
                column: "Ma_thuehoca");

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietlancau_Thuehoca_ThuehocaMa_thuehoca",
                table: "Chitietlancau",
                column: "ThuehocaMa_thuehoca",
                principalTable: "Thuehoca",
                principalColumn: "Ma_thuehoca",
                onDelete: ReferentialAction.Cascade);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chitietlancau_Thuehoca_ThuehocaMa_thuehoca",
                table: "Chitietlancau");

            migrationBuilder.DropForeignKey(
                name: "FK_Chitietlancau_Tongsokg_Ma_tongsokg",
                table: "Chitietlancau");

            migrationBuilder.DropTable(
                name: "Tongsokg");

            migrationBuilder.DropIndex(
                name: "IX_Chitietlancau_Ma_tongsokg",
                table: "Chitietlancau");

            migrationBuilder.DropIndex(
                name: "IX_Chitietlancau_ThuehocaMa_thuehoca",
                table: "Chitietlancau");

            migrationBuilder.DropColumn(
                name: "Ma_thuehoca",
                table: "Chitietlancau");

            migrationBuilder.DropColumn(
                name: "Ma_tongsokg",
                table: "Chitietlancau");

            migrationBuilder.DropColumn(
                name: "ThuehocaMa_thuehoca",
                table: "Chitietlancau");

            migrationBuilder.AlterColumn<int>(
                name: "sokg",
                table: "Chitietlancau",
                type: "int",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldMaxLength: 100);
        }
    }
}
