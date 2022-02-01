using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectStructure.DAL.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 10, 2, 7, 26, 20, 985, DateTimeKind.Local).AddTicks(8682), "Mertz - Rath" },
                    { 2, new DateTime(2021, 4, 17, 2, 5, 34, 253, DateTimeKind.Local).AddTicks(9217), "Osinski - Von" },
                    { 3, new DateTime(2020, 3, 20, 9, 28, 43, 463, DateTimeKind.Local).AddTicks(5550), "Spencer LLC" },
                    { 4, new DateTime(2017, 3, 22, 7, 12, 56, 695, DateTimeKind.Local).AddTicks(6353), "Wolff Inc" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[] { 1, new DateTime(2002, 4, 9, 0, 13, 54, 114, DateTimeKind.Local).AddTicks(5250), "Rita.Murphy@gmail.com", "Rita", "Murphy", new DateTime(2019, 6, 28, 1, 10, 32, 39, DateTimeKind.Local).AddTicks(6504), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[] { 2, new DateTime(2000, 1, 20, 8, 58, 59, 896, DateTimeKind.Local).AddTicks(7373), "Courtney.McGlynn13@yahoo.com", "Courtney", "McGlynn", new DateTime(2017, 10, 7, 10, 23, 29, 7, DateTimeKind.Local).AddTicks(4991), 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[] { 3, new DateTime(1966, 7, 14, 22, 56, 1, 944, DateTimeKind.Local).AddTicks(1854), "Danny_Bernier56@hotmail.com", "Danny", "Bernier", new DateTime(2017, 6, 20, 1, 57, 31, 862, DateTimeKind.Local).AddTicks(1513), 3 });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "AuthorId", "CreatedAt", "Deadline", "Description", "Name", "TeamId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 12, 16, 13, 15, 40, 482, DateTimeKind.Local).AddTicks(6415), new DateTime(2022, 2, 15, 9, 4, 40, 974, DateTimeKind.Local).AddTicks(3781), "Qui ex architecto qui.", "next generation", 1 },
                    { 2, 2, new DateTime(2020, 9, 19, 9, 56, 44, 51, DateTimeKind.Local).AddTicks(1154), new DateTime(2022, 5, 3, 7, 17, 15, 71, DateTimeKind.Local).AddTicks(8275), "Unde ullam voluptatem eligendi architecto.", "Data", 2 },
                    { 3, 3, new DateTime(2021, 7, 5, 11, 51, 26, 655, DateTimeKind.Local).AddTicks(8871), new DateTime(2022, 2, 18, 20, 19, 37, 300, DateTimeKind.Local).AddTicks(5625), "Et sunt recusandae et quo dolores.", "Liaison pricing structure Estates", 3 },
                    { 4, 3, new DateTime(2020, 12, 13, 6, 23, 25, 653, DateTimeKind.Local).AddTicks(7877), new DateTime(2022, 3, 9, 21, 41, 39, 936, DateTimeKind.Local).AddTicks(3081), "Porro reprehenderit aliquid quo enim enim.", "Arkansas e-tailers PNG", 3 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Description", "FinishedAt", "Name", "PerformerId", "ProjectId", "State" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 9, 1, 15, 5, 42, 999, DateTimeKind.Local).AddTicks(1778), "Magni fugit ut consequatur sit voluptatem eum.", null, "Generic Steel Towels", 1, 1, 0 },
                    { 2, new DateTime(2020, 4, 28, 8, 56, 35, 369, DateTimeKind.Local).AddTicks(5014), "Et omnis cumque dolorem qui cupiditate aperiam.", new DateTime(2021, 3, 30, 3, 51, 54, 362, DateTimeKind.Local).AddTicks(8103), "Lake Senior", 1, 1, 2 },
                    { 3, new DateTime(2020, 4, 28, 8, 56, 35, 369, DateTimeKind.Local).AddTicks(5014), "Incidunt nesciunt similique repudiandae pariatur dolorem pariatur rerum nihil voluptate.", new DateTime(2021, 5, 30, 3, 51, 54, 362, DateTimeKind.Local).AddTicks(8103), "hack Estonia invoice", 2, 2, 2 },
                    { 4, new DateTime(2019, 6, 19, 5, 34, 44, 205, DateTimeKind.Local).AddTicks(9796), "Sit doloribus accusantium blanditiis veniam eum.", new DateTime(2021, 4, 14, 20, 21, 23, 800, DateTimeKind.Local).AddTicks(8111), "solid state maximize", 3, 3, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
