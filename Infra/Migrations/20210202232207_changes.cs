using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b9ef90ef-b659-49c8-b32d-6b7826d4ef1f"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Profile" },
                values: new object[] { new Guid("b8e49a53-b64b-4085-b737-4440b0e1100f"), "admin@email.com", "System Admin", "0192023A7BBD73250516F069DF18B500", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b8e49a53-b64b-4085-b737-4440b0e1100f"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Profile" },
                values: new object[] { new Guid("b9ef90ef-b659-49c8-b32d-6b7826d4ef1f"), "admin@email.com", "System Admin", "0192023A7BBD73250516F069DF18B500", 0 });
        }
    }
}
