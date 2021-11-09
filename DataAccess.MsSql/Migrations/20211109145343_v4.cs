using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.MsSql.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfBirth", "Salary" },
                values: new object[] { new DateTime(2021, 11, 9, 16, 53, 43, 262, DateTimeKind.Local).AddTicks(8759), 30.23m });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "DateOfBirth", "Married", "Name", "Phone", "Salary" },
                values: new object[] { 3, new DateTime(2021, 11, 9, 16, 53, 43, 264, DateTimeKind.Local).AddTicks(6997), true, "Ivan", "0523673293", 12.23m });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "DateOfBirth", "Married", "Name", "Phone", "Salary" },
                values: new object[] { 2, new DateTime(2004, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Oleg", "0500653293", 41.23m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfBirth", "Salary" },
                values: new object[] { new DateTime(2021, 11, 9, 16, 49, 48, 516, DateTimeKind.Local).AddTicks(6353), 0m });
        }
    }
}
