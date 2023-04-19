using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class charmeleon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dfd4bb2-52e0-4004-a7a4-1be27ce9a726");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea63ea47-b366-4982-bde3-06f0492d345a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f7e793e-b909-4ccb-b2f0-04452b49e25a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7691cc83-38f2-4f6b-8223-035a39b93079");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c589edb-69c5-4d6c-9604-2f7e52210ea1", "b0c191f3-d89d-462e-8e7b-63afeffab947", "User", "USER" },
                    { "f5ad1afe-ac28-43c0-86b6-2b237893fe3c", "aec62267-a49a-400e-b4cc-305a6f08a6f2", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5eec3216-3bfe-42e9-8086-86e2e76f93e8", 0, "82acdf7c-0f3e-4959-83d6-eb58628bcf15", "reall.admin@admin.eal", true, false, null, "REALL.ADMIN@ADMIN.EAL", "REALADMIN", "AQAAAAEAACcQAAAAECB/+o448AU5IIFcCRY3zS4TONAqem2LTyezhBXOcUPu/FIgL4itYZmtRiUbxT4kgg==", null, false, "ef4cfab3-5b91-4285-baba-7e18ce24f654", false, "RealAdmin" },
                    { "63eb3132-6f5e-4802-a08d-fffa7ed68368", 0, "118c8c65-5534-4bc2-b543-497bfc2ac33c", "new.user@newUser.com", true, false, null, "NEW.USER@NEWUSER.COM", "NEWUSER", "AQAAAAEAACcQAAAAEDwVLvLsPe2ydTBJ4DS5w+fMM9MX5pzjNRvjo/105TDE2LMp8rxKsrAAwc4Dh/yQFg==", null, false, "c49041f3-3a22-452a-b3c2-bbcc18d51781", false, "NewUser" }
                });

            migrationBuilder.InsertData(
                table: "Pokemons",
                columns: new[] { "Id", "ATK", "ATKEV", "CaptureRate", "Classification", "DEF", "DEFEV", "DexEntry", "GrowthRate", "HP", "HPEV", "Height", "Name", "PokedexEntry", "SPATK", "SPATKEV", "SPD", "SPDEF", "SPDEFEV", "SPDEV", "Type1", "Type2", "Weight" },
                values: new object[] { 5, 64.0, 64.0, 45.0, "Flame Pokemon", 58.0, 58.0, 5, 1059860.0, 58.0, 58.0, 1.1000000000000001, "Charmeleon", "When it swings its burning tail, it elevates the temperature to unbearably high levels.", 65.0, 65.0, 80.0, 65.0, 65.0, 80.0, "Fire", "", 19.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c589edb-69c5-4d6c-9604-2f7e52210ea1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5ad1afe-ac28-43c0-86b6-2b237893fe3c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5eec3216-3bfe-42e9-8086-86e2e76f93e8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "63eb3132-6f5e-4802-a08d-fffa7ed68368");

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8dfd4bb2-52e0-4004-a7a4-1be27ce9a726", "aec62267-a49a-400e-b4cc-305a6f08a6f2", "Admin", "ADMIN" },
                    { "ea63ea47-b366-4982-bde3-06f0492d345a", "b0c191f3-d89d-462e-8e7b-63afeffab947", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0f7e793e-b909-4ccb-b2f0-04452b49e25a", 0, "11dc594d-364f-41b7-b594-13702fcc18fb", "reall.admin@admin.eal", true, false, null, "REALL.ADMIN@ADMIN.EAL", "REALADMIN", "AQAAAAEAACcQAAAAECB/+o448AU5IIFcCRY3zS4TONAqem2LTyezhBXOcUPu/FIgL4itYZmtRiUbxT4kgg==", null, false, "195df285-5252-4b96-8524-bebd5b2efdde", false, "RealAdmin" },
                    { "7691cc83-38f2-4f6b-8223-035a39b93079", 0, "11f375b7-5163-4cbe-9e62-b8d3f0c698ef", "new.user@newUser.com", true, false, null, "NEW.USER@NEWUSER.COM", "NEWUSER", "AQAAAAEAACcQAAAAEDwVLvLsPe2ydTBJ4DS5w+fMM9MX5pzjNRvjo/105TDE2LMp8rxKsrAAwc4Dh/yQFg==", null, false, "ffcacdf8-b68c-47b2-b198-33150efc1dca", false, "NewUser" }
                });
        }
    }
}
