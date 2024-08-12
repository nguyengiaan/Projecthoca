using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecthoca.Migrations
{
    public partial class up_9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Timeout",
                table: "Thuehoca",
                type: "time",
                maxLength: 2147483647,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 2147483647);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Thoigianketthuc",
                table: "Thuehoca",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Thoigianbatdau",
                table: "Thuehoca",
                type: "time",
                maxLength: 2147483647,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 2147483647);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Timeout",
                table: "Thuehoca",
                type: "datetime2",
                maxLength: 2147483647,
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldMaxLength: 2147483647);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Thoigianketthuc",
                table: "Thuehoca",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Thoigianbatdau",
                table: "Thuehoca",
                type: "datetime2",
                maxLength: 2147483647,
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldMaxLength: 2147483647);
        }
    }
}
