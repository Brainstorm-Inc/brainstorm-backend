using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.Migrations.Migrations
{
    public partial class UpdatedUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppVersions",
                keyColumn: "Id",
                keyValue: new Guid("73f3221f-becb-4561-9e9b-35514c981c77"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("78c14057-e37a-42d3-9969-8064a3ca7f03"));

            migrationBuilder.InsertData(
                table: "AppVersions",
                columns: new[] { "Id", "MajorVersion", "MinorVersion" },
                values: new object[] { new Guid("5fd6ae6c-a973-45ab-81a1-ba561a892315"), 0, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "ProfilePicture" },
                values: new object[] { new Guid("d683bf29-4261-42e5-a44a-857cf44cd823"), "Fname-Lname@mail.com", "Fname", "Lname", "https://robohash.org/Fname-Lname.png" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppVersions",
                keyColumn: "Id",
                keyValue: new Guid("5fd6ae6c-a973-45ab-81a1-ba561a892315"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d683bf29-4261-42e5-a44a-857cf44cd823"));

            migrationBuilder.InsertData(
                table: "AppVersions",
                columns: new[] { "Id", "MajorVersion", "MinorVersion" },
                values: new object[] { new Guid("73f3221f-becb-4561-9e9b-35514c981c77"), 0, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "ProfilePicture" },
                values: new object[] { new Guid("78c14057-e37a-42d3-9969-8064a3ca7f03"), "Fname-Lname@mail.com", "Fname", "Lname", "https://robohash.org/Fname-Lname.png" });
        }
    }
}
