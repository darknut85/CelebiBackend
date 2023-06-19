using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class isTm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19d2e3ee-3284-4e62-b69f-f05aa7e3876d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de8219f8-72ff-4938-bc0f-c93b9ceaf7bb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2086059c-d2c6-46ff-b053-535692cbafb1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dfb9c2f7-618b-4c4a-b8a4-59612987d086");

            migrationBuilder.AddColumn<bool>(
                name: "IsTm",
                table: "LevelupMoves",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "86e05890-9202-4aef-adf8-039eb86d2307", "b0c191f3-d89d-462e-8e7b-63afeffab947", "User", "USER" },
                    { "b657d041-3c9d-4e7a-a13c-eeed7a88e014", "aec62267-a49a-400e-b4cc-305a6f08a6f2", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "76de0a9e-e58a-41cb-b549-ccbe9cedd8da", 0, "ee39a898-e5fc-4a29-9763-4f5da8b35dfb", "new.user@newUser.com", true, false, null, "NEW.USER@NEWUSER.COM", "NEWUSER", "AQAAAAEAACcQAAAAEDwVLvLsPe2ydTBJ4DS5w+fMM9MX5pzjNRvjo/105TDE2LMp8rxKsrAAwc4Dh/yQFg==", null, false, "5c8abf3a-1f68-41b5-bd65-07efe88359f8", false, "NewUser" },
                    { "fb99f814-6741-4982-b941-340d77d44530", 0, "517eb55a-b972-4375-a7a4-c529e50e24ae", "reall.admin@admin.eal", true, false, null, "REALL.ADMIN@ADMIN.EAL", "REALADMIN", "AQAAAAEAACcQAAAAECB/+o448AU5IIFcCRY3zS4TONAqem2LTyezhBXOcUPu/FIgL4itYZmtRiUbxT4kgg==", null, false, "0d77301a-dfb1-4ce6-8c9a-8274c55ef88f", false, "RealAdmin" }
                });

            migrationBuilder.UpdateData(
                table: "LevelupMoves",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsTm",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86e05890-9202-4aef-adf8-039eb86d2307");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b657d041-3c9d-4e7a-a13c-eeed7a88e014");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76de0a9e-e58a-41cb-b549-ccbe9cedd8da");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fb99f814-6741-4982-b941-340d77d44530");

            migrationBuilder.DropColumn(
                name: "IsTm",
                table: "LevelupMoves");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19d2e3ee-3284-4e62-b69f-f05aa7e3876d", "aec62267-a49a-400e-b4cc-305a6f08a6f2", "Admin", "ADMIN" },
                    { "de8219f8-72ff-4938-bc0f-c93b9ceaf7bb", "b0c191f3-d89d-462e-8e7b-63afeffab947", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2086059c-d2c6-46ff-b053-535692cbafb1", 0, "fc93037a-df67-4665-8757-0d662a54153b", "new.user@newUser.com", true, false, null, "NEW.USER@NEWUSER.COM", "NEWUSER", "AQAAAAEAACcQAAAAEDwVLvLsPe2ydTBJ4DS5w+fMM9MX5pzjNRvjo/105TDE2LMp8rxKsrAAwc4Dh/yQFg==", null, false, "7021c047-66b5-4ca5-8d0c-75e6fb3d65cd", false, "NewUser" },
                    { "dfb9c2f7-618b-4c4a-b8a4-59612987d086", 0, "f1d9c279-247c-4ce2-8752-979975b797d8", "reall.admin@admin.eal", true, false, null, "REALL.ADMIN@ADMIN.EAL", "REALADMIN", "AQAAAAEAACcQAAAAECB/+o448AU5IIFcCRY3zS4TONAqem2LTyezhBXOcUPu/FIgL4itYZmtRiUbxT4kgg==", null, false, "6eb3a2aa-2cc9-4b7e-9b1a-3b099dab3142", false, "RealAdmin" }
                });
        }
    }
}
