using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bottlecaps.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Profile",
                schema: "dbo",
                columns: table => new
                {
                    ProfileId = table.Column<int>(nullable: false),
                    FName = table.Column<string>(fixedLength: true, maxLength: 30, nullable: true),
                    LName = table.Column<string>(fixedLength: true, maxLength: 30, nullable: true),
                    Email = table.Column<string>(fixedLength: true, maxLength: 30, nullable: true),
                    Phone = table.Column<string>(fixedLength: true, maxLength: 30, nullable: true),
                    Username = table.Column<string>(fixedLength: true, maxLength: 30, nullable: true),
                    Password = table.Column<string>(fixedLength: true, maxLength: 30, nullable: true),
                    LockedProfile = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true),
                    AuthorizedSpaceId = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true),
                    AuthorizedUser = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true),
                    ProfileCap = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.ProfileId);
                });

            migrationBuilder.CreateTable(
                name: "Bottlecap",
                schema: "dbo",
                columns: table => new
                {
                    BottlecapId = table.Column<int>(nullable: false),
                    Color = table.Column<string>(fixedLength: true, maxLength: 30, nullable: true),
                    PositionX = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true),
                    PositionY = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true),
                    ProfileId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bottlecap", x => x.BottlecapId);
                    table.ForeignKey(
                        name: "FK_Bottlecap_Profile",
                        column: x => x.ProfileId,
                        principalSchema: "dbo",
                        principalTable: "Profile",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Space",
                schema: "dbo",
                columns: table => new
                {
                    SpaceId = table.Column<int>(nullable: false),
                    SpaceName = table.Column<string>(fixedLength: true, maxLength: 30, nullable: true),
                    ActiveStatus = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true),
                    BackgroundImage = table.Column<string>(fixedLength: true, maxLength: 150, nullable: true),
                    DefaultBottlecapId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Space", x => x.SpaceId);
                    table.ForeignKey(
                        name: "FK_Space_Profile",
                        column: x => x.ProfileId,
                        principalSchema: "dbo",
                        principalTable: "Profile",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Link",
                schema: "dbo",
                columns: table => new
                {
                    LinkId = table.Column<int>(nullable: false),
                    LinkText = table.Column<string>(fixedLength: true, maxLength: 150, nullable: true),
                    BottlecapId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK_Link_Bottlecap",
                        column: x => x.BottlecapId,
                        principalSchema: "dbo",
                        principalTable: "Bottlecap",
                        principalColumn: "BottlecapId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                schema: "dbo",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false),
                    TagText = table.Column<string>(fixedLength: true, maxLength: 30, nullable: true),
                    BottlecapId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagId);
                    table.ForeignKey(
                        name: "FK_Tag_Bottlecap",
                        column: x => x.BottlecapId,
                        principalSchema: "dbo",
                        principalTable: "Bottlecap",
                        principalColumn: "BottlecapId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                schema: "dbo",
                columns: table => new
                {
                    SessionId = table.Column<int>(nullable: false),
                    SessionStart = table.Column<DateTime>(type: "datetime", nullable: true),
                    SessionEnd = table.Column<DateTime>(type: "datetime", nullable: true),
                    SuccessfulConnection = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ConnecteeId = table.Column<int>(nullable: true),
                    ConnectorId = table.Column<int>(nullable: true),
                    SpaceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_Session_Space",
                        column: x => x.SpaceId,
                        principalSchema: "dbo",
                        principalTable: "Space",
                        principalColumn: "SpaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                schema: "dbo",
                columns: table => new
                {
                    MessageId = table.Column<int>(nullable: false),
                    MessageDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Message = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true),
                    SessionId = table.Column<int>(nullable: true),
                    SenderId = table.Column<int>(nullable: true),
                    RecipientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Message_Profile",
                        column: x => x.SenderId,
                        principalSchema: "dbo",
                        principalTable: "Profile",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_Session",
                        column: x => x.SessionId,
                        principalSchema: "dbo",
                        principalTable: "Session",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bottlecap_ProfileId",
                schema: "dbo",
                table: "Bottlecap",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_BottlecapId",
                schema: "dbo",
                table: "Link",
                column: "BottlecapId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SenderId",
                schema: "dbo",
                table: "Message",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SessionId",
                schema: "dbo",
                table: "Message",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_SpaceId",
                schema: "dbo",
                table: "Session",
                column: "SpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Space_ProfileId",
                schema: "dbo",
                table: "Space",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_BottlecapId",
                schema: "dbo",
                table: "Tag",
                column: "BottlecapId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Link",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Message",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Tag",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Session",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Bottlecap",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Space",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Profile",
                schema: "dbo");
        }
    }
}
