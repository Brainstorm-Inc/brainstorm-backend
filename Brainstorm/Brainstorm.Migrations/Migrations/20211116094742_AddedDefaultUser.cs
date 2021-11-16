using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.Migrations.Migrations
{
    public partial class AddedDefaultUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppVersions",
                keyColumn: "Id",
                keyValue: new Guid("ef42a592-4e5b-4808-80ab-3c042b7594ec"));

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Users");

            migrationBuilder.InsertData(
                table: "AppVersions",
                columns: new[] { "Id", "MajorVersion", "MinorVersion" },
                values: new object[] { new Guid("4541747f-1608-4836-9bc3-ac01cae1c53a"), 0, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { new Guid("01143f01-7b4a-4aad-8e87-6de87e34d9cc"), "test@test.ro", "test", "test", "password" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppVersions",
                keyColumn: "Id",
                keyValue: new Guid("4541747f-1608-4836-9bc3-ac01cae1c53a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("01143f01-7b4a-4aad-8e87-6de87e34d9cc"));

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AppVersions",
                columns: new[] { "Id", "MajorVersion", "MinorVersion" },
                values: new object[] { new Guid("ef42a592-4e5b-4808-80ab-3c042b7594ec"), 0, 1 });
        }
    }
}
