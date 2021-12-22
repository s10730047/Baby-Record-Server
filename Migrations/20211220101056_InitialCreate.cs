using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BabyRecords_Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "familyGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    familyGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_familyGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    account = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BabyInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersID = table.Column<int>(type: "int", nullable: false),
                    familGroupID = table.Column<int>(type: "int", nullable: false),
                    babyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    babyBirthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BabyInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BabyInfo_familyGroup_familGroupID",
                        column: x => x.familGroupID,
                        principalTable: "familyGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BabyInfo_Users_UsersID",
                        column: x => x.UsersID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "familyGroupMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    familyGroupID = table.Column<int>(type: "int", nullable: false),
                    usersID = table.Column<int>(type: "int", nullable: false),
                    authority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_familyGroupMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_familyGroupMember_familyGroup_familyGroupID",
                        column: x => x.familyGroupID,
                        principalTable: "familyGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_familyGroupMember_Users_usersID",
                        column: x => x.usersID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TempAndHumidity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersID = table.Column<int>(type: "int", nullable: false),
                    temp = table.Column<int>(type: "int", nullable: false),
                    humidity = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempAndHumidity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TempAndHumidity_Users_UsersID",
                        column: x => x.UsersID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "babyArea",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BabyID = table.Column<int>(type: "int", nullable: false),
                    Event = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_babyArea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_babyArea_BabyInfo_BabyID",
                        column: x => x.BabyID,
                        principalTable: "BabyInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "babyFaceCover",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BabyID = table.Column<int>(type: "int", nullable: false),
                    Event = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_babyFaceCover", x => x.Id);
                    table.ForeignKey(
                        name: "FK_babyFaceCover_BabyInfo_BabyID",
                        column: x => x.BabyID,
                        principalTable: "BabyInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "babyRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BabyID = table.Column<int>(type: "int", nullable: false),
                    height = table.Column<float>(type: "real", nullable: false),
                    weight = table.Column<float>(type: "real", nullable: false),
                    head = table.Column<float>(type: "real", nullable: false),
                    milkingMl = table.Column<int>(type: "int", nullable: false),
                    diaper = table.Column<int>(type: "int", nullable: false),
                    healthWay = table.Column<int>(type: "int", nullable: false),
                    sleep = table.Column<int>(type: "int", nullable: false),
                    babyTempWay = table.Column<int>(type: "int", nullable: false),
                    babyTemp = table.Column<int>(type: "int", nullable: false),
                    feeding = table.Column<int>(type: "int", nullable: false),
                    milkMl = table.Column<int>(type: "int", nullable: false),
                    spoon = table.Column<int>(type: "int", nullable: false),
                    temp = table.Column<int>(type: "int", nullable: false),
                    humidity = table.Column<int>(type: "int", nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    recordClass = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_babyRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_babyRecord_BabyInfo_BabyID",
                        column: x => x.BabyID,
                        principalTable: "BabyInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_babyArea_BabyID",
                table: "babyArea",
                column: "BabyID");

            migrationBuilder.CreateIndex(
                name: "IX_babyFaceCover_BabyID",
                table: "babyFaceCover",
                column: "BabyID");

            migrationBuilder.CreateIndex(
                name: "IX_BabyInfo_familGroupID",
                table: "BabyInfo",
                column: "familGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_BabyInfo_UsersID",
                table: "BabyInfo",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_babyRecord_BabyID",
                table: "babyRecord",
                column: "BabyID");

            migrationBuilder.CreateIndex(
                name: "IX_familyGroupMember_familyGroupID",
                table: "familyGroupMember",
                column: "familyGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_familyGroupMember_usersID",
                table: "familyGroupMember",
                column: "usersID");

            migrationBuilder.CreateIndex(
                name: "IX_TempAndHumidity_UsersID",
                table: "TempAndHumidity",
                column: "UsersID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "babyArea");

            migrationBuilder.DropTable(
                name: "babyFaceCover");

            migrationBuilder.DropTable(
                name: "babyRecord");

            migrationBuilder.DropTable(
                name: "familyGroupMember");

            migrationBuilder.DropTable(
                name: "TempAndHumidity");

            migrationBuilder.DropTable(
                name: "BabyInfo");

            migrationBuilder.DropTable(
                name: "familyGroup");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
