using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.Migrations.Migrations
{
    public partial class AddedUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppVersions",
                keyColumn: "Id",
                keyValue: 1m);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AppVersions",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(20,0)");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false, defaultValue: "FirstName"),
                    LastName = table.Column<string>(type: "text", nullable: false, defaultValue: "LastName"),
                    Email = table.Column<string>(type: "text", nullable: false, defaultValue: "first-last@mail.com"),
                    ProfilePicture = table.Column<string>(type: "text", nullable: true, defaultValue: "https://robohash.org/first-last")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AppVersions",
                columns: new[] { "Id", "MajorVersion", "MinorVersion" },
                values: new object[] { new Guid("6c374925-24d0-467a-b65a-7e4ba4323fad"), 0, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "ProfilePicture" },
                values: new object[] { new Guid("0327f807-486c-4c8f-906b-891a9f8586b1"), "Fname-Lname@mail.com", "Fname", "Lname", "https://robohash.org/Fname-Lname.png" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "AppVersions",
                keyColumn: "Id",
                keyValue: new Guid("6c374925-24d0-467a-b65a-7e4ba4323fad"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Id",
                table: "AppVersions",
                type: "numeric(20,0)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "AppVersions",
                columns: new[] { "Id", "MajorVersion", "MinorVersion" },
                values: new object[] { 1m, 0, 1 });
        }
    }
}
