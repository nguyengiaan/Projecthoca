using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.AddColumn<int>(
                               name: "Ca",
                                              table: "Giahoca",
                                                             type: "int",
                                                                            nullable: false,
                                                                                           defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ca",
                table: "Giahoca");

            migrationBuilder.AlterColumn<int>(
                name: "Ma_giahoca",
                table: "Giahoca",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
