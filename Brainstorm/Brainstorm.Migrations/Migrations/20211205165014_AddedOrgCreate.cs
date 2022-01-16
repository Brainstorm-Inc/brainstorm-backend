using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.Migrations.Migrations
{
    public partial class AddedOrgCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organization_OrgId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organization",
                table: "Organization");

            migrationBuilder.DeleteData(
                table: "AppVersions",
                keyColumn: "Id",
                keyValue: new Guid("d8e2d1e9-7399-4cd6-9b68-456ab06223ce"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5c03d4f-ce30-403b-aa94-982a56c4d196"));

            migrationBuilder.RenameTable(
                name: "Organization",
                newName: "Organizations");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Organizations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LogoLink",
                table: "Organizations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_Name",
                table: "Organizations",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organizations_OrgId",
                table: "Users",
                column: "OrgId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organizations_OrgId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_Name",
                table: "Organizations");

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

            migrationBuilder.RenameTable(
                name: "Organizations",
                newName: "Organization");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Organization",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LogoLink",
                table: "Organization",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organization",
                table: "Organization",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AppVersions",
                columns: new[] { "Id", "MajorVersion", "MinorVersion" },
                values: new object[] { new Guid("d8e2d1e9-7399-4cd6-9b68-456ab06223ce"), 0, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "OrgId", "Password" },
                values: new object[] { new Guid("d5c03d4f-ce30-403b-aa94-982a56c4d196"), "test@test.ro", "test", "test", null, "password" });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organization_OrgId",
                table: "Users",
                column: "OrgId",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
