using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.Migrations.Migrations
{
    public partial class AddedOrgModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppVersions",
                keyColumn: "Id",
                keyValue: new Guid("4541747f-1608-4836-9bc3-ac01cae1c53a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("01143f01-7b4a-4aad-8e87-6de87e34d9cc"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrgId",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    LogoLink = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AppVersions",
                columns: new[] { "Id", "MajorVersion", "MinorVersion" },
                values: new object[] { new Guid("d8e2d1e9-7399-4cd6-9b68-456ab06223ce"), 0, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "OrgId", "Password" },
                values: new object[] { new Guid("d5c03d4f-ce30-403b-aa94-982a56c4d196"), "test@test.ro", "test", "test", null, "password" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrgId",
                table: "Users",
                column: "OrgId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organization_OrgId",
                table: "Users",
                column: "OrgId",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organization_OrgId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropIndex(
                name: "IX_Users_OrgId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "AppVersions",
                keyColumn: "Id",
                keyValue: new Guid("d8e2d1e9-7399-4cd6-9b68-456ab06223ce"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5c03d4f-ce30-403b-aa94-982a56c4d196"));

            migrationBuilder.DropColumn(
                name: "OrgId",
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
    }
}
