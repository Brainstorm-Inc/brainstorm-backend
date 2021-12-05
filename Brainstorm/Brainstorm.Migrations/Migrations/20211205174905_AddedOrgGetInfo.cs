using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.Migrations.Migrations
{
    public partial class AddedOrgGetInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppVersions",
                keyColumn: "Id",
                keyValue: new Guid("7ffb69b0-d990-4b18-b0ba-3619acf18669"));

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("0ea4c1e7-0452-4d4f-aa8e-4eabafca7ee6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ba95e4a8-635d-4211-962c-755e861a0239"));

            migrationBuilder.InsertData(
                table: "AppVersions",
                columns: new[] { "Id", "MajorVersion", "MinorVersion" },
                values: new object[] { new Guid("2433633d-4d57-4928-b2b0-f7d14ef9aa87"), 0, 1 });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "LogoLink", "Name" },
                values: new object[] { new Guid("fa33109a-406d-47e4-9b61-101d25daa2fc"), "https://robohash.org/test-org", "Test Organization" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "OrgId", "Password" },
                values: new object[] { new Guid("ddf2245e-2b75-4343-ae31-516ab6b1c218"), "test@test.ro", "test", "test", null, "password" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppVersions",
                keyColumn: "Id",
                keyValue: new Guid("2433633d-4d57-4928-b2b0-f7d14ef9aa87"));

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("fa33109a-406d-47e4-9b61-101d25daa2fc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ddf2245e-2b75-4343-ae31-516ab6b1c218"));

            migrationBuilder.InsertData(
                table: "AppVersions",
                columns: new[] { "Id", "MajorVersion", "MinorVersion" },
                values: new object[] { new Guid("7ffb69b0-d990-4b18-b0ba-3619acf18669"), 0, 1 });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "LogoLink", "Name" },
                values: new object[] { new Guid("0ea4c1e7-0452-4d4f-aa8e-4eabafca7ee6"), "https://robohash.org/test-org", "Test Organization" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "OrgId", "Password" },
                values: new object[] { new Guid("ba95e4a8-635d-4211-962c-755e861a0239"), "test@test.ro", "test", "test", null, "password" });
        }
    }
}
