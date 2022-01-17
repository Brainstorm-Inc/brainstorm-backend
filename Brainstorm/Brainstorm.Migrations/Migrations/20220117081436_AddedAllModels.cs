using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Migrations.Migrations
{
    public partial class AddedAllModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "TopicId",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    OrgId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Organizations_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Ones = table.Column<int>(type: "integer", nullable: false),
                    Twos = table.Column<int>(type: "integer", nullable: false),
                    Threes = table.Column<int>(type: "integer", nullable: false),
                    Fours = table.Column<int>(type: "integer", nullable: false),
                    Fives = table.Column<int>(type: "integer", nullable: false),
                    Avg = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Timeline",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timeline", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proposal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Files = table.Column<List<string>>(type: "text[]", nullable: true),
                    RatingId = table.Column<Guid>(type: "uuid", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: true),
                    TimelineId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposal_Rating_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Rating",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Proposal_Timeline_TimelineId",
                        column: x => x.TimelineId,
                        principalTable: "Timeline",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Proposal_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CurrentIterationId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: true),
                    HighlightedProposalId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topic_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Topic_Proposal_HighlightedProposalId",
                        column: x => x.HighlightedProposalId,
                        principalTable: "Proposal",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Topic_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Iteration",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Position = table.Column<long>(type: "bigint", nullable: false),
                    IsOpen = table.Column<bool>(type: "boolean", nullable: false),
                    Goal = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Files = table.Column<List<string>>(type: "text[]", nullable: true),
                    Deadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TimelineId = table.Column<Guid>(type: "uuid", nullable: true),
                    TopicId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iteration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Iteration_Timeline_TimelineId",
                        column: x => x.TimelineId,
                        principalTable: "Timeline",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Iteration_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: true),
                    ReplyToId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProposalId = table.Column<Guid>(type: "uuid", nullable: true),
                    IterationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Comment_ReplyToId",
                        column: x => x.ReplyToId,
                        principalTable: "Comment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_Iteration_IterationId",
                        column: x => x.IterationId,
                        principalTable: "Iteration",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_Proposal_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposal",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AppVersions",
                columns: new[] { "Id", "MajorVersion", "MinorVersion" },
                values: new object[] { new Guid("4a5a0def-653a-41ea-9a0f-dc49880d2e25"), 0, 1 });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "LogoLink", "Name" },
                values: new object[] { new Guid("2ded1149-87b6-4bd0-b1bb-050667c0caf3"), "https://robohash.org/test-org", "Test Organization" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "OrgId", "Password", "TopicId" },
                values: new object[] { new Guid("70e8f048-acfe-48a7-9b61-e1a0f967b7d8"), "test@test.ro", "test", "test", null, "password", null });

            migrationBuilder.CreateIndex(
                name: "IX_Users_TopicId",
                table: "Users",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AuthorId",
                table: "Comment",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_IterationId",
                table: "Comment",
                column: "IterationId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ProposalId",
                table: "Comment",
                column: "ProposalId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ReplyToId",
                table: "Comment",
                column: "ReplyToId");

            migrationBuilder.CreateIndex(
                name: "IX_Iteration_TimelineId",
                table: "Iteration",
                column: "TimelineId");

            migrationBuilder.CreateIndex(
                name: "IX_Iteration_TopicId",
                table: "Iteration",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_OrgId",
                table: "Project",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposal_AuthorId",
                table: "Proposal",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposal_RatingId",
                table: "Proposal",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposal_TimelineId",
                table: "Proposal",
                column: "TimelineId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_AuthorId",
                table: "Topic",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_HighlightedProposalId",
                table: "Topic",
                column: "HighlightedProposalId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_ProjectId",
                table: "Topic",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Topic_TopicId",
                table: "Users",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Topic_TopicId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Iteration");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Proposal");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Timeline");

            migrationBuilder.DropIndex(
                name: "IX_Users_TopicId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "AppVersions",
                keyColumn: "Id",
                keyValue: new Guid("4a5a0def-653a-41ea-9a0f-dc49880d2e25"));

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("2ded1149-87b6-4bd0-b1bb-050667c0caf3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("70e8f048-acfe-48a7-9b61-e1a0f967b7d8"));

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Users");

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
    }
}
