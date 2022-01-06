using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Migrations.Migrations
{
    public partial class AddedUserSalt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppVersions",
                keyColumn: "Id",
                keyValue: new Guid("b4537261-2ede-4af5-95fc-ea54706a987b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0e212db6-8185-4955-b7cf-ffb1c31b39b2"));

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AppVersions",
                columns: new[] { "Id", "MajorVersion", "MinorVersion" },
                values: new object[] { new Guid("fea15911-f7f7-4635-b8c8-e8fbd05a3b56"), 0, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "OrgId", "Password", "Salt" },
                values: new object[] { new Guid("e64d2b68-8759-4db4-81bb-743b7a1e618a"), "test@test.ro", "test", "test", null, "password", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppVersions",
                keyColumn: "Id",
                keyValue: new Guid("fea15911-f7f7-4635-b8c8-e8fbd05a3b56"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e64d2b68-8759-4db4-81bb-743b7a1e618a"));

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Users");

            migrationBuilder.InsertData(
                table: "AppVersions",
                columns: new[] { "Id", "MajorVersion", "MinorVersion" },
                values: new object[] { new Guid("b4537261-2ede-4af5-95fc-ea54706a987b"), 0, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "OrgId", "Password" },
                values: new object[] { new Guid("0e212db6-8185-4955-b7cf-ffb1c31b39b2"), "test@test.ro", "test", "test", null, "password" });
        }
    }
}
