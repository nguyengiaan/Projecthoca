using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Giahoca_AspNetUsers_Id",
                table: "Giahoca");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Giahoca",
                table: "Giahoca");

            migrationBuilder.AlterColumn<string>(
                name: "Ma_giahoca",
                table: "Giahoca",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Giahoca",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Giahoca",
                table: "Giahoca",
                column: "Ma_giahoca");

            migrationBuilder.CreateIndex(
                name: "IX_Giahoca_Id",
                table: "Giahoca",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Giahoca_AspNetUsers_Id",
                table: "Giahoca",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
