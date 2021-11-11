using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.MsSql.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfBirth", "Married", "Salary" },
                values: new object[] { new DateTime(2004, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 500.23m });

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfBirth", "Name", "Phone", "Salary" },
                values: new object[] { new DateTime(2008, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xenia", "0669925380", 499.23m });

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2021, 11, 9, 23, 6, 4, 69, DateTimeKind.Local).AddTicks(3450));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfBirth", "Married", "Salary" },
                values: new object[] { new DateTime(2021, 11, 9, 16, 53, 43, 262, DateTimeKind.Local).AddTicks(8759), true, 30.23m });

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfBirth", "Name", "Phone", "Salary" },
                values: new object[] { new DateTime(2004, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oleg", "0500653293", 41.23m });

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2021, 11, 9, 16, 53, 43, 264, DateTimeKind.Local).AddTicks(6997));
        }
    }
}
