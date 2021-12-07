using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.Migrations.Migrations
{
    public partial class AddedOrgInfoGet : Migration
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
                values: new object[] { new Guid("5d0fb2ea-6855-4027-9008-9a802619e7ce"), 0, 1 });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "LogoLink", "Name" },
                values: new object[] { new Guid("ca69c6ff-2c15-4e77-ac96-cb04e0b8f258"), "https://robohash.org/test-org", "Test Organization" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "OrgId", "Password" },
                values: new object[] { new Guid("bed07283-bc1c-4179-bf6f-68bd7d6455e8"), "test@test.ro", "test", "test", null, "password" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppVersions",
                keyColumn: "Id",
                keyValue: new Guid("5d0fb2ea-6855-4027-9008-9a802619e7ce"));

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("ca69c6ff-2c15-4e77-ac96-cb04e0b8f258"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bed07283-bc1c-4179-bf6f-68bd7d6455e8"));

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
