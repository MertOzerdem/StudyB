using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyB.API.Migrations
{
    public partial class v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chatrooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ChatroomName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chatrooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rewards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RewardName = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Admin = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 30, nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    UpvoteCount = table.Column<int>(nullable: false),
                    MessageCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(maxLength: 1500, nullable: false),
                    FileAddress = table.Column<string>(nullable: true),
                    DateOfPost = table.Column<DateTimeOffset>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ChatroomId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Chatrooms_ChatroomId",
                        column: x => x.ChatroomId,
                        principalTable: "Chatrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserChatrooms",
                columns: table => new
                {
                    ChatroomId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChatrooms", x => new { x.ChatroomId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserChatrooms_Chatrooms_ChatroomId",
                        column: x => x.ChatroomId,
                        principalTable: "Chatrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserChatrooms_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRewards",
                columns: table => new
                {
                    RewardId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRewards", x => new { x.RewardId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRewards_Rewards_RewardId",
                        column: x => x.RewardId,
                        principalTable: "Rewards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRewards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Chatrooms",
                columns: new[] { "Id", "ChatroomName" },
                values: new object[,]
                {
                    { new Guid("1acf8e02-9be4-428a-bd6b-8dce083bfac3"), "Cs 492" },
                    { new Guid("ce446daa-5e35-4f2a-ab83-cf75cac4837e"), "Cs 453" },
                    { new Guid("c25ed015-3e14-440d-a7c0-7eeedc0cf32b"), "Morning Breeze" }
                });

            migrationBuilder.InsertData(
                table: "Rewards",
                columns: new[] { "Id", "RewardName" },
                values: new object[,]
                {
                    { new Guid("02b9e886-0291-45d9-8d97-6adc7e63babf"), "Best Admin Ever" },
                    { new Guid("e5d9f399-be62-4283-b7c6-81177f71a402"), "Worst Admin Ever" },
                    { new Guid("118fc971-0831-4207-9b1d-7237bc4271b2"), "Average User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Admin", "Email", "FirstName", "LastName", "MessageCount", "Password", "UpvoteCount", "UserName" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), false, "pasta@ug.bilkent.edu.tr", "Pasta", "Sempa", 0, "123", 0, "Pasta" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), false, "Pepe@ug.bilkent.edu.tr", "Pepe", "Julian Onziema", 0, "159", 0, "LGBT Right Activist" },
                    { new Guid("8ded4df7-4355-41b0-9b44-a9de574bcc48"), true, "Ismini@ug.bilkent.edu.tr", "Ismini", "bulamadım", 0, "159", 0, "The Host" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ChatroomId", "DateOfPost", "FileAddress", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("9bcfa927-179d-4346-a34e-e09928450456"), new Guid("1acf8e02-9be4-428a-bd6b-8dce083bfac3"), new DateTimeOffset(new DateTime(1690, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), null, "What is up?", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") },
                    { new Guid("0936b9d0-c45a-4112-9306-fad95e9c07c7"), new Guid("1acf8e02-9be4-428a-bd6b-8dce083bfac3"), new DateTimeOffset(new DateTime(1988, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), null, "Mavi Tik", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") },
                    { new Guid("74fa1016-b592-4948-b582-c163ddc8e5fa"), new Guid("c25ed015-3e14-440d-a7c0-7eeedc0cf32b"), new DateTimeOffset(new DateTime(2014, 12, 9, 22, 2, 10, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, "Who says I am gay?", new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96") },
                    { new Guid("eab75a96-544a-480d-98dd-e375abaac938"), new Guid("c25ed015-3e14-440d-a7c0-7eeedc0cf32b"), new DateTimeOffset(new DateTime(2014, 12, 9, 22, 5, 5, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, "I am not ... active right now.", new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96") },
                    { new Guid("9ca606d2-c909-46e6-ab6e-5f8616f083a6"), new Guid("c25ed015-3e14-440d-a7c0-7eeedc0cf32b"), new DateTimeOffset(new DateTime(2014, 12, 9, 22, 1, 5, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, "We are bringing the studio this morning one of the gay right activist, Mr... Should I call You Mista?", new Guid("8ded4df7-4355-41b0-9b44-a9de574bcc48") },
                    { new Guid("d9292237-ad99-4347-a6a5-9eb12669e789"), new Guid("c25ed015-3e14-440d-a7c0-7eeedc0cf32b"), new DateTimeOffset(new DateTime(2014, 12, 9, 22, 2, 5, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, "Pepe Julian Onziema thank you for coming. Why are you gay?", new Guid("8ded4df7-4355-41b0-9b44-a9de574bcc48") },
                    { new Guid("4cf3d108-2d49-4a76-a024-8a8d96fec24b"), new Guid("c25ed015-3e14-440d-a7c0-7eeedc0cf32b"), new DateTimeOffset(new DateTime(2014, 12, 9, 22, 3, 5, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, "You are Gay. You're Transgenda, and gay rights activist, and outspoken lesbian?, Homosexual?", new Guid("8ded4df7-4355-41b0-9b44-a9de574bcc48") },
                    { new Guid("176cdccd-5156-450a-b3ac-f7e33f1338bd"), new Guid("c25ed015-3e14-440d-a7c0-7eeedc0cf32b"), new DateTimeOffset(new DateTime(2014, 12, 9, 22, 4, 5, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, "Now we are looking at the debate. Why should someone be gay?", new Guid("8ded4df7-4355-41b0-9b44-a9de574bcc48") },
                    { new Guid("88990eac-0974-45f0-afd5-5c3dae5ada75"), new Guid("c25ed015-3e14-440d-a7c0-7eeedc0cf32b"), new DateTimeOffset(new DateTime(2014, 12, 9, 22, 6, 5, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, "Doesn't that make you gay?", new Guid("8ded4df7-4355-41b0-9b44-a9de574bcc48") }
                });

            migrationBuilder.InsertData(
                table: "UserChatrooms",
                columns: new[] { "ChatroomId", "UserId" },
                values: new object[,]
                {
                    { new Guid("ce446daa-5e35-4f2a-ab83-cf75cac4837e"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") },
                    { new Guid("ce446daa-5e35-4f2a-ab83-cf75cac4837e"), new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96") }
                });

            migrationBuilder.InsertData(
                table: "UserRewards",
                columns: new[] { "RewardId", "UserId" },
                values: new object[,]
                {
                    { new Guid("118fc971-0831-4207-9b1d-7237bc4271b2"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") },
                    { new Guid("02b9e886-0291-45d9-8d97-6adc7e63babf"), new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatroomId",
                table: "Messages",
                column: "ChatroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChatrooms_UserId",
                table: "UserChatrooms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRewards_UserId",
                table: "UserRewards",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "UserChatrooms");

            migrationBuilder.DropTable(
                name: "UserRewards");

            migrationBuilder.DropTable(
                name: "Chatrooms");

            migrationBuilder.DropTable(
                name: "Rewards");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
