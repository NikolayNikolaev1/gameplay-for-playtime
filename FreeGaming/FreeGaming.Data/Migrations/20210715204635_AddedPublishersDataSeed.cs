namespace FreeGaming.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddedPublishersDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "2", "Publisher", "Publisher" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "Image", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rating", "RegistrationDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "06f3dd53-f820-48a8-820b-6841dffb03c8", 0, null, "c63f4c04-1852-4e0f-a841-452d580ea8b0", null, "blizzard@freegaming.test", false, null, null, null, false, null, null, null, null, null, false, null, new DateTime(2021, 7, 15, 20, 46, 34, 664, DateTimeKind.Utc).AddTicks(2728), "3f6fae16-cbe1-40f9-b6df-0dc3c3f3974b", false, "Blizzard Entertainment" },
                    { "827c261d-3f89-4ccc-be47-59ab57373a05", 0, null, "eb85a982-013d-4fd6-95e1-eca06585053e", null, "rockstargames@freegaming.test", false, null, null, null, false, null, null, null, null, null, false, null, new DateTime(2021, 7, 15, 20, 46, 34, 664, DateTimeKind.Utc).AddTicks(3526), "7a93fc71-1ab4-42c8-a430-292a1cc5bcf5", false, "Rockstar Games" },
                    { "ddba3758-c519-4485-ad66-19e2bd194760", 0, null, "280597e9-f948-40ec-803f-ca43ab1f76f4", null, "capcom@freegaming.test", false, null, null, null, false, null, null, null, null, null, false, null, new DateTime(2021, 7, 15, 20, 46, 34, 664, DateTimeKind.Utc).AddTicks(3544), "f2e7c633-7423-44a6-960c-3e99014880fa", false, "Capcom" }
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a14da6895711");

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
        }
    }
}
