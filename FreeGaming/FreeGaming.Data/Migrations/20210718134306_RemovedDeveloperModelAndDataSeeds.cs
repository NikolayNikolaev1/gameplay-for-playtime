namespace FreeGaming.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RemovedDeveloperModelAndDataSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Developers_DeveloperId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropIndex(
                name: "IX_Games_DeveloperId",
                table: "Games");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "06f3dd53-f820-48a8-820b-6841dffb03c8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "827c261d-3f89-4ccc-be47-59ab57373a05" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "ddba3758-c519-4485-ad66-19e2bd194760" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06f3dd53-f820-48a8-820b-6841dffb03c8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "827c261d-3f89-4ccc-be47-59ab57373a05");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddba3758-c519-4485-ad66-19e2bd194760");

            migrationBuilder.DropColumn(
                name: "DeveloperId",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "TrailerId",
                table: "Games",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Developer",
                table: "Games",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Developer",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "TrailerId",
                table: "Games",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AddColumn<int>(
                name: "DeveloperId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "Image", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rating", "RegistrationDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "06f3dd53-f820-48a8-820b-6841dffb03c8", 0, null, "c63f4c04-1852-4e0f-a841-452d580ea8b0", null, "blizzard@freegaming.test", false, null, null, null, false, null, null, null, null, null, false, null, new DateTime(2021, 7, 15, 20, 46, 34, 664, DateTimeKind.Utc).AddTicks(2728), "3f6fae16-cbe1-40f9-b6df-0dc3c3f3974b", false, "Blizzard Entertainment" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "Image", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rating", "RegistrationDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "827c261d-3f89-4ccc-be47-59ab57373a05", 0, null, "eb85a982-013d-4fd6-95e1-eca06585053e", null, "rockstargames@freegaming.test", false, null, null, null, false, null, null, null, null, null, false, null, new DateTime(2021, 7, 15, 20, 46, 34, 664, DateTimeKind.Utc).AddTicks(3526), "7a93fc71-1ab4-42c8-a430-292a1cc5bcf5", false, "Rockstar Games" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "Image", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rating", "RegistrationDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ddba3758-c519-4485-ad66-19e2bd194760", 0, null, "280597e9-f948-40ec-803f-ca43ab1f76f4", null, "capcom@freegaming.test", false, null, null, null, false, null, null, null, null, null, false, null, new DateTime(2021, 7, 15, 20, 46, 34, 664, DateTimeKind.Utc).AddTicks(3544), "f2e7c633-7423-44a6-960c-3e99014880fa", false, "Capcom" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "06f3dd53-f820-48a8-820b-6841dffb03c8" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "827c261d-3f89-4ccc-be47-59ab57373a05" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "ddba3758-c519-4485-ad66-19e2bd194760" });

            migrationBuilder.CreateIndex(
                name: "IX_Games_DeveloperId",
                table: "Games",
                column: "DeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Developers_DeveloperId",
                table: "Games",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
