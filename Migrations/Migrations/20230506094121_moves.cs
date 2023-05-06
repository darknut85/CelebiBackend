using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class moves : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Move",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    PowerPoints = table.Column<double>(type: "double precision", nullable: false),
                    BasePower = table.Column<double>(type: "double precision", nullable: false),
                    Accuracy = table.Column<double>(type: "double precision", nullable: false),
                    BattleEffect = table.Column<string>(type: "text", nullable: false),
                    EffectRate = table.Column<double>(type: "double precision", nullable: false),
                    Priority = table.Column<double>(type: "double precision", nullable: false),
                    Target = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Move", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0fe5232a-1bda-4244-a539-e5ac13079380", "aec62267-a49a-400e-b4cc-305a6f08a6f2", "Admin", "ADMIN" },
                    { "4337351d-c0b0-44cd-96e6-299fd4a3a5de", "b0c191f3-d89d-462e-8e7b-63afeffab947", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "69b6a67d-073e-42d9-9500-b32ad236d0e3", 0, "0503a58e-b1a3-41f5-a043-45d732954176", "reall.admin@admin.eal", true, false, null, "REALL.ADMIN@ADMIN.EAL", "REALADMIN", "AQAAAAEAACcQAAAAECB/+o448AU5IIFcCRY3zS4TONAqem2LTyezhBXOcUPu/FIgL4itYZmtRiUbxT4kgg==", null, false, "857e74f3-4e9c-4806-9346-84fcea3d1487", false, "RealAdmin" },
                    { "d4bd13c8-be03-48d7-af2a-e6c0578285a9", 0, "0583a9a9-9d62-479a-a960-082b4efd3ab9", "new.user@newUser.com", true, false, null, "NEW.USER@NEWUSER.COM", "NEWUSER", "AQAAAAEAACcQAAAAEDwVLvLsPe2ydTBJ4DS5w+fMM9MX5pzjNRvjo/105TDE2LMp8rxKsrAAwc4Dh/yQFg==", null, false, "e3c5156d-92e9-4e80-a625-03fa27bd2ddb", false, "NewUser" }
                });

            migrationBuilder.InsertData(
                table: "Move",
                columns: new[] { "Id", "Accuracy", "BasePower", "BattleEffect", "EffectRate", "Name", "PowerPoints", "Priority", "Target", "Type" },
                values: new object[,]
                {
                    { 1, 95.0, 35.0, "A NORMAL-type attack. Many Pokémon know this attack right from the start.", 0.0, "Tackle", 35.0, 0.0, "selected target", "Normal" },
                    { 2, 100.0, 35.0, "A NORMAL-type attack. Sharp claws are used to inflict damage on the target.", 0.0, "Scratch", 40.0, 0.0, "selected target", "Normal" },
                    { 3, 100.0, 0.0, "A technique that lowers the target's ATTACK power. Can normally be used up to six times.", 0.0, "Growl", 40.0, 0.0, "All opponent Pokémon in range", "Normal" },
                    { 4, 100.0, 0.0, "A technique that lowers the target's DEFENSE. Useful against tough, armored Pokémon.", 0.0, "Tail Whip", 30.0, 0.0, "All opponent Pokémon in range", "Normal" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Move");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0fe5232a-1bda-4244-a539-e5ac13079380");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4337351d-c0b0-44cd-96e6-299fd4a3a5de");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69b6a67d-073e-42d9-9500-b32ad236d0e3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d4bd13c8-be03-48d7-af2a-e6c0578285a9");

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
        }
    }
}
