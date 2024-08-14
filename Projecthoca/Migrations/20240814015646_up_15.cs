using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Danhmuchoadon_Hoadondanhmuc_Ma_hddm",
                table: "Danhmuchoadon");

            migrationBuilder.DropForeignKey(
                name: "FK_Hoadondanhmuc_Thuehoca_Ma_thuehoca",
                table: "Hoadondanhmuc");

            migrationBuilder.DropIndex(
                name: "IX_Hoadondanhmuc_Ma_thuehoca",
                table: "Hoadondanhmuc");

            migrationBuilder.DropColumn(
                name: "Giachothue",
                table: "Hoadondanhmuc");

            migrationBuilder.DropColumn(
                name: "Ma_thuehoca",
                table: "Hoadondanhmuc");

            migrationBuilder.DropColumn(
                name: "DVT",
                table: "Danhmuchoadon");

            migrationBuilder.RenameColumn(
                name: "Ma_hddm",
                table: "Danhmuchoadon",
                newName: "Ma_thuehoca");

            migrationBuilder.RenameColumn(
                name: "Gia",
                table: "Danhmuchoadon",
                newName: "thanhtien");

            migrationBuilder.RenameIndex(
                name: "IX_Danhmuchoadon_Ma_hddm",
                table: "Danhmuchoadon",
                newName: "IX_Danhmuchoadon_Ma_thuehoca");

     

            migrationBuilder.AlterColumn<int>(
                name: "Soluong",
                table: "Danhmuchoadon",
                type: "int",
                maxLength: 2147483647,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 2147483647);
            migrationBuilder.AddForeignKey(
                name: "FK_Danhmuchoadon_Thuehoca_Ma_thuehoca",
                table: "Danhmuchoadon",
                column: "Ma_thuehoca",
                principalTable: "Thuehoca",
                principalColumn: "Ma_thuehoca",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hoadondanhmuc_Thuehoca_Ma_hddm",
                table: "Hoadondanhmuc",
                column: "Ma_hddm",
                principalTable: "Thuehoca",
                principalColumn: "Ma_thuehoca",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Danhmuchoadon_Thuehoca_Ma_thuehoca",
                table: "Danhmuchoadon");

            migrationBuilder.DropForeignKey(
                name: "FK_Giahoca_AspNetUsers_Id",
                table: "Giahoca");

            migrationBuilder.DropForeignKey(
                name: "FK_Hoadondanhmuc_Thuehoca_Ma_hddm",
                table: "Hoadondanhmuc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Giahoca",
                table: "Giahoca");

            migrationBuilder.DropIndex(
                name: "IX_Giahoca_Id",
                table: "Giahoca");

            migrationBuilder.RenameColumn(
                name: "thanhtien",
                table: "Danhmuchoadon",
                newName: "Gia");

            migrationBuilder.RenameColumn(
                name: "Ma_thuehoca",
                table: "Danhmuchoadon",
                newName: "Ma_hddm");

            migrationBuilder.RenameIndex(
                name: "IX_Danhmuchoadon_Ma_thuehoca",
                table: "Danhmuchoadon",
                newName: "IX_Danhmuchoadon_Ma_hddm");

            migrationBuilder.AddColumn<int>(
                name: "Giachothue",
                table: "Hoadondanhmuc",
                type: "int",
                maxLength: 2147483647,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Ma_thuehoca",
                table: "Hoadondanhmuc",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Giahoca",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ma_giahoca",
                table: "Giahoca",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Soluong",
                table: "Danhmuchoadon",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 2147483647);

       

  

            migrationBuilder.AddPrimaryKey(
                name: "PK_Giahoca",
                table: "Giahoca",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Hoadondanhmuc_Ma_thuehoca",
                table: "Hoadondanhmuc",
                column: "Ma_thuehoca");

            migrationBuilder.AddForeignKey(
                name: "FK_Danhmuchoadon_Hoadondanhmuc_Ma_hddm",
                table: "Danhmuchoadon",
                column: "Ma_hddm",
                principalTable: "Hoadondanhmuc",
                principalColumn: "Ma_hddm",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Giahoca_AspNetUsers_Id",
                table: "Giahoca",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hoadondanhmuc_Thuehoca_Ma_thuehoca",
                table: "Hoadondanhmuc",
                column: "Ma_thuehoca",
                principalTable: "Thuehoca",
                principalColumn: "Ma_thuehoca",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
