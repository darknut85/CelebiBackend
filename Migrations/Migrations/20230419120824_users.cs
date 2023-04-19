using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4f39a600-56e2-4204-80fd-d38cbf156eff", "aec62267-a49a-400e-b4cc-305a6f08a6f2", "Admin", "ADMIN" },
                    { "7fa21ea0-f11b-4c73-a54f-3f2527fd10e8", "b0c191f3-d89d-462e-8e7b-63afeffab947", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "84352829-2372-4460-a0c2-65d7f4509212", 0, "a58b460f-261e-4635-9e7c-9a90f06398ef", "new.user@newUser.com", true, false, null, "NEW.USER@NEWUSER.COM", "NEWUSER", "AQAAAAEAACcQAAAAEDwVLvLsPe2ydTBJ4DS5w+fMM9MX5pzjNRvjo/105TDE2LMp8rxKsrAAwc4Dh/yQFg==", null, false, "110ad665-500b-4350-bade-4a63fa975edd", false, "NewUser" },
                    { "e2066f3e-5cff-4c63-a389-468e9ca5358f", 0, "be4d8eab-e071-49a7-9c35-765d9aa73e2f", "reall.admin@admin.eal", true, false, null, "REALL.ADMIN@ADMIN.EAL", "REALADMIN", "AQAAAAEAACcQAAAAECB/+o448AU5IIFcCRY3zS4TONAqem2LTyezhBXOcUPu/FIgL4itYZmtRiUbxT4kgg==", null, false, "3f4ea29c-fb3b-496a-b966-db95c3ff8d7a", false, "RealAdmin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f39a600-56e2-4204-80fd-d38cbf156eff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fa21ea0-f11b-4c73-a54f-3f2527fd10e8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84352829-2372-4460-a0c2-65d7f4509212");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2066f3e-5cff-4c63-a389-468e9ca5358f");
        }
    }
}
