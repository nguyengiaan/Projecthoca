using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_45 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Step 1: Drop the primary key constraint
            migrationBuilder.DropPrimaryKey(
                name: "PK_Phieunhapkho",
                table: "Phieunhapkho");

            // Step 2: Create a temporary column
            migrationBuilder.AddColumn<int>(
                name: "Temp_Ma_phieunhapkho",
                table: "Phieunhapkho",
                nullable: false,
                defaultValue: 0);

            // Step 3: Copy data from the original column to the temporary column
            migrationBuilder.Sql("UPDATE Phieunhapkho SET Temp_Ma_phieunhapkho = Ma_phieunhapkho");

            // Step 4: Drop the original column
            migrationBuilder.DropColumn(
                name: "Ma_phieunhapkho",
                table: "Phieunhapkho");

            // Step 5: Recreate the original column with the IDENTITY property
            migrationBuilder.AddColumn<int>(
                name: "Ma_phieunhapkho",
                table: "Phieunhapkho",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            // Step 6: Copy data back from the temporary column to the new identity column
            migrationBuilder.Sql("SET IDENTITY_INSERT Phieunhapkho ON");
            migrationBuilder.Sql("INSERT INTO Phieunhapkho (Ma_phieunhapkho) SELECT Temp_Ma_phieunhapkho FROM Phieunhapkho");
            migrationBuilder.Sql("SET IDENTITY_INSERT Phieunhapkho OFF");

            // Step 7: Drop the temporary column
            migrationBuilder.DropColumn(
                name: "Temp_Ma_phieunhapkho",
                table: "Phieunhapkho");

            // Step 8: Recreate the primary key constraint
            migrationBuilder.AddPrimaryKey(
                name: "PK_Phieunhapkho",
                table: "Phieunhapkho",
                column: "Ma_phieunhapkho");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert the changes by dropping the identity column and recreating the original column
            migrationBuilder.DropColumn(
                name: "Ma_phieunhapkho",
                table: "Phieunhapkho");

            migrationBuilder.AddColumn<string>(
                name: "Ma_phieunhapkho",
                table: "Phieunhapkho",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");
        }
    }
}
