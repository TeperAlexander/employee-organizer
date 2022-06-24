using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeOrganizer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rank",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuperiorId = table.Column<long>(type: "bigint", nullable: true),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: true),
                    RankId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_SuperiorId",
                        column: x => x.SuperiorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Rank_RankId",
                        column: x => x.RankId,
                        principalTable: "Rank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Active", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1L, true, "Budapest", "BP" },
                    { 2L, true, "Zalaegerszeg", "Zala" },
                    { 3L, true, "Szeged", "SZE" },
                    { 4L, true, "Szolnok", "SZO" }
                });

            migrationBuilder.InsertData(
                table: "Rank",
                columns: new[] { "Id", "Active", "Name" },
                values: new object[,]
                {
                    { 1L, true, "Architect" },
                    { 2L, true, "Software Engineer" },
                    { 3L, true, "Scrum Master" },
                    { 4L, true, "Project Owner" },
                    { 5L, true, "Tech Lead" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Active", "DepartmentId", "Name", "Password", "PhoneNumber", "RankId", "SuperiorId", "Username" },
                values: new object[] { 1L, true, 1L, "John Doe", "$2a$11$Hw8HEeR3LdWTrToo0FCTdeoowIWXw1N4KI8kD3hp40XODy4yuTGE6", "+36204567897", 1L, null, "JoDo" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Active", "DepartmentId", "Name", "Password", "PhoneNumber", "RankId", "SuperiorId", "Username" },
                values: new object[] { 2L, true, 2L, "Elizabeth Doe", "$2a$11$Hw8HEeR3LdWTrToo0FCTdeoowIWXw1N4KI8kD3hp40XODy4yuTGE6", "+36704563497", 2L, 1L, "ElDo" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Active", "DepartmentId", "Name", "Password", "PhoneNumber", "RankId", "SuperiorId", "Username" },
                values: new object[] { 3L, true, 1L, "Alice Doe", "$2a$11$Hw8HEeR3LdWTrToo0FCTdeoowIWXw1N4KI8kD3hp40XODy4yuTGE6", "+36204357297", 3L, 1L, "AlDo" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Active", "DepartmentId", "Name", "Password", "PhoneNumber", "RankId", "SuperiorId", "Username" },
                values: new object[] { 4L, true, 4L, "Steve Doe", "$2a$11$Hw8HEeR3LdWTrToo0FCTdeoowIWXw1N4KI8kD3hp40XODy4yuTGE6", "+36704542317", 5L, 1L, "StDo" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RankId",
                table: "Employees",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SuperiorId",
                table: "Employees",
                column: "SuperiorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Rank");
        }
    }
}
