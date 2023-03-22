using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ca5a619-98bc-4f5b-afa4-b1caca72adcf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b65b4356-9830-4a40-8d44-74548a58ac86");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9947e3f4-9eef-4318-aa8c-20d4fa2ac633", "1", "Admin", "Admin" },
                    { "9a7c89e3-eb93-43f0-9e73-78de40d79fc4", "2", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d719d2a3-e5b2-4b8a-9dc7-4071ac24fbb6", 0, "0da4598a-1470-41c8-85c8-3c5139eb6af1", "new.user@newUser.com", true, false, null, "new.user@newUser.com", "NewUser", "", null, false, "5e9599f9-25c8-4073-9424-0d1379faac81", false, "NewUser" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9947e3f4-9eef-4318-aa8c-20d4fa2ac633");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a7c89e3-eb93-43f0-9e73-78de40d79fc4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d719d2a3-e5b2-4b8a-9dc7-4071ac24fbb6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ca5a619-98bc-4f5b-afa4-b1caca72adcf", "2", "User", "User" },
                    { "b65b4356-9830-4a40-8d44-74548a58ac86", "1", "Admin", "Admin" }
                });
        }
    }
}
