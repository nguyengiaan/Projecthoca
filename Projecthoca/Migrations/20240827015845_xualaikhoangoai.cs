using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class xualaikhoangoai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Xóa các ràng buộc khóa ngoại
            migrationBuilder.DropForeignKey(
                name: "FK_Danhsachhhkho_Phieunhapkho_Ma_phieunhapkho",
                table: "Danhsachhhkho");

            // Xóa khóa chính hiện tại
            migrationBuilder.DropPrimaryKey(
                name: "PK_Phieunhapkho",
                table: "Phieunhapkho");

            // Xóa chỉ mục hiện tại
            migrationBuilder.DropIndex(
                name: "IX_Danhsachhhkho_Ma_phieunhapkho",
                table: "Danhsachhhkho");

            // Thay đổi cột trong bảng Danhsachhhkho
            migrationBuilder.DropColumn(
                name: "Ma_phieunhapkho",
                table: "Danhsachhhkho");
            migrationBuilder.AddColumn<string>(
                name: "Ma_phieunhapkho",
                table: "Danhsachhhkho",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            // Tạo cột tạm thời trong Phieunhapkho
            migrationBuilder.AddColumn<string>(
                name: "Temp_Ma_phieunhapkho",
                table: "Phieunhapkho",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            // Sao chép dữ liệu từ cột hiện tại sang cột tạm thời
            migrationBuilder.Sql("UPDATE Phieunhapkho SET Temp_Ma_phieunhapkho = Ma_phieunhapkho");

            // Xóa cột hiện tại
            migrationBuilder.DropColumn(
                name: "Ma_phieunhapkho",
                table: "Phieunhapkho");

            // Tạo lại cột với thuộc tính mới, cho phép null và gán giá trị mặc định tạm thời
            migrationBuilder.AddColumn<string>(
                name: "Ma_phieunhapkho",
                table: "Phieunhapkho",
                type: "nvarchar(450)",
                nullable: true,
                defaultValue: "");

            // Sao chép dữ liệu từ cột tạm thời trở lại cột mới
            migrationBuilder.Sql("UPDATE Phieunhapkho SET Ma_phieunhapkho = Temp_Ma_phieunhapkho");

            // Thiết lập lại cột Ma_phieunhapkho không cho phép giá trị null
            migrationBuilder.Sql("UPDATE Phieunhapkho SET Ma_phieunhapkho = '' WHERE Ma_phieunhapkho IS NULL");

            migrationBuilder.AlterColumn<string>(
                name: "Ma_phieunhapkho",
                table: "Phieunhapkho",
                type: "nvarchar(450)",
                nullable: false);

            // Xóa cột tạm thời
            migrationBuilder.DropColumn(
                name: "Temp_Ma_phieunhapkho",
                table: "Phieunhapkho");

            // Tạo lại khóa chính
            migrationBuilder.AddPrimaryKey(
                name: "PK_Phieunhapkho",
                table: "Phieunhapkho",
                column: "Ma_phieunhapkho");

            // Tạo lại khóa ngoại
            migrationBuilder.AddForeignKey(
                name: "FK_Danhsachhhkho_Phieunhapkho_Ma_phieunhapkho",
                table: "Danhsachhhkho",
                column: "Ma_phieunhapkho",
                principalTable: "Phieunhapkho",
                principalColumn: "Ma_phieunhapkho",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Logic to reverse the migration if necessary
        }
    }
}