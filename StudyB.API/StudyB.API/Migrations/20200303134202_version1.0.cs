using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyB.API.Migrations
{
    public partial class version10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chatrooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ChatroomName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chatrooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
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
                    Text = table.Column<string>(nullable: true),
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
                name: "Rewards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rewards_Users_UserId",
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

            migrationBuilder.InsertData(
                table: "Chatrooms",
                columns: new[] { "Id", "ChatroomName" },
                values: new object[,]
                {
                    { new Guid("1acf8e02-9be4-428a-bd6b-8dce083bfac3"), "Cs 492" },
                    { new Guid("ce446daa-5e35-4f2a-ab83-cf75cac4837e"), "Cs 453" },
                    { new Guid("c25ed015-3e14-440d-a7c0-7eeedc0cf32b"), "Cs 491" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Adam", "Çocuk", "123", "Ateşli çocuk" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Kadın", "Adam", "159", "Why are you gay?" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ChatroomId", "DateOfPost", "FileAddress", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("9bcfa927-179d-4346-a34e-e09928450456"), new Guid("1acf8e02-9be4-428a-bd6b-8dce083bfac3"), new DateTimeOffset(new DateTime(1690, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), null, "What is up?", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") },
                    { new Guid("0936b9d0-c45a-4112-9306-fad95e9c07c7"), new Guid("1acf8e02-9be4-428a-bd6b-8dce083bfac3"), new DateTimeOffset(new DateTime(1988, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), null, "Mavi Tik", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") }
                });

            migrationBuilder.InsertData(
                table: "UserChatrooms",
                columns: new[] { "ChatroomId", "UserId" },
                values: new object[,]
                {
                    { new Guid("ce446daa-5e35-4f2a-ab83-cf75cac4837e"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") },
                    { new Guid("ce446daa-5e35-4f2a-ab83-cf75cac4837e"), new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96") }
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
                name: "IX_Rewards_UserId",
                table: "Rewards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChatrooms_UserId",
                table: "UserChatrooms",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Rewards");

            migrationBuilder.DropTable(
                name: "UserChatrooms");

            migrationBuilder.DropTable(
                name: "Chatrooms");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
