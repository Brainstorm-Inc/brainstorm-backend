using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Migrations.Migrations
{
    public partial class FixedOrgUsersNavIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("3bfba075-e736-456e-b818-883c8579d3c0"), 0, 1 });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "LogoLink", "Name" },
                values: new object[] { new Guid("5b649d60-d379-474d-9fd3-ca16dd9277d9"), "https://robohash.org/test-org", "Test Organization" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "OrgId", "Password" },
                values: new object[] { new Guid("5cb0c1de-a77a-461c-a68d-003c240a0573"), "test@test.ro", "test", "test", null, "password" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppVersions",
                keyColumn: "Id",
                keyValue: new Guid("3bfba075-e736-456e-b818-883c8579d3c0"));

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("5b649d60-d379-474d-9fd3-ca16dd9277d9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5cb0c1de-a77a-461c-a68d-003c240a0573"));

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
    }
}
