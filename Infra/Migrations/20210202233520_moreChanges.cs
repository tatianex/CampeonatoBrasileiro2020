using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class moreChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b8e49a53-b64b-4085-b737-4440b0e1100f"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Profile" },
                values: new object[] { new Guid("07b6c56c-77c7-4e73-9d6c-2564300eb927"), "admin@email.com", "System Admin", "0192023A7BBD73250516F069DF18B500", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("07b6c56c-77c7-4e73-9d6c-2564300eb927"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Profile" },
                values: new object[] { new Guid("b8e49a53-b64b-4085-b737-4440b0e1100f"), "admin@email.com", "System Admin", "0192023A7BBD73250516F069DF18B500", 0 });
        }
    }
}
