using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeOrganizer.Migrations
{
    public partial class activity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$11$k/s5NQdFWpLNYuoXCuQC.e2BapG/hd3SdlxVXBeKDu/xqebqqEAvS");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$11$k/s5NQdFWpLNYuoXCuQC.e2BapG/hd3SdlxVXBeKDu/xqebqqEAvS");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$11$k/s5NQdFWpLNYuoXCuQC.e2BapG/hd3SdlxVXBeKDu/xqebqqEAvS");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$11$k/s5NQdFWpLNYuoXCuQC.e2BapG/hd3SdlxVXBeKDu/xqebqqEAvS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$11$Hw8HEeR3LdWTrToo0FCTdeoowIWXw1N4KI8kD3hp40XODy4yuTGE6");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$11$Hw8HEeR3LdWTrToo0FCTdeoowIWXw1N4KI8kD3hp40XODy4yuTGE6");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$11$Hw8HEeR3LdWTrToo0FCTdeoowIWXw1N4KI8kD3hp40XODy4yuTGE6");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$11$Hw8HEeR3LdWTrToo0FCTdeoowIWXw1N4KI8kD3hp40XODy4yuTGE6");
        }
    }
}
