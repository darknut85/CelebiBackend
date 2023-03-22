using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class exposedpassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a255df5-eef9-4bc7-b0bf-c8191b11c645");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b398e832-5ddd-4a60-8191-d0ec5299421d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b659c4a6-4bf4-4117-a983-5ef74ace9ad8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7aa34caf-f2f2-44ac-99f6-2a7d57633892", "1", "Admin", "Admin" },
                    { "ce915472-b097-407d-8a4e-a0d030a96f0e", "2", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b5c4c1c6-0503-4b04-a280-fc707a1b9cb9", 0, "ec092c78-772a-461e-95c1-92bb8e9b65ed", "new.user@newUser.com", true, false, null, "new.user@newUser.com", "NewUser", "password", null, false, "6bc92c8f-b292-4dbf-af74-ea641ac55c7c", false, "NewUser" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7aa34caf-f2f2-44ac-99f6-2a7d57633892");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce915472-b097-407d-8a4e-a0d030a96f0e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5c4c1c6-0503-4b04-a280-fc707a1b9cb9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8a255df5-eef9-4bc7-b0bf-c8191b11c645", "2", "User", "User" },
                    { "b398e832-5ddd-4a60-8191-d0ec5299421d", "1", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b659c4a6-4bf4-4117-a983-5ef74ace9ad8", 0, "2434aede-c732-4cbb-880f-e2dedddc0dd3", "new.user@newUser.com", true, false, null, "new.user@newUser.com", "NewUser", "password", null, false, "f8433505-0e26-44bc-becf-43c05e95677f", false, "NewUser" });
        }
    }
}
