using Microsoft.EntityFrameworkCore.Migrations;

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
            migrationBuilder.DropPrimaryKey(
                name: "PK_Move",
                table: "Move");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3609bc32-f4ee-4ef0-a046-fabb9bdffd5a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4312670e-56fc-416d-9388-61fc59f56819");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb98d311-f669-4ae4-9dbd-d32f36ef5f61");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c1021c51-7ee0-4aa0-9b71-2bb8b27f8e4f");

            migrationBuilder.RenameTable(
                name: "Move",
                newName: "Moves");

            migrationBuilder.AddColumn<int>(
                name: "MoveId",
                table: "LevelupMoves",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Moves",
                table: "Moves",
                column: "Id");

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

            migrationBuilder.UpdateData(
                table: "LevelupMoves",
                keyColumn: "Id",
                keyValue: 1,
                column: "MoveId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_LevelupMoves_MoveId",
                table: "LevelupMoves",
                column: "MoveId");

            migrationBuilder.AddForeignKey(
                name: "FK_LevelupMoves_Moves_MoveId",
                table: "LevelupMoves",
                column: "MoveId",
                principalTable: "Moves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LevelupMoves_Moves_MoveId",
                table: "LevelupMoves");

            migrationBuilder.DropIndex(
                name: "IX_LevelupMoves_MoveId",
                table: "LevelupMoves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Moves",
                table: "Moves");

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

            migrationBuilder.DropColumn(
                name: "MoveId",
                table: "LevelupMoves");

            migrationBuilder.RenameTable(
                name: "Moves",
                newName: "Move");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Move",
                table: "Move",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3609bc32-f4ee-4ef0-a046-fabb9bdffd5a", "b0c191f3-d89d-462e-8e7b-63afeffab947", "User", "USER" },
                    { "4312670e-56fc-416d-9388-61fc59f56819", "aec62267-a49a-400e-b4cc-305a6f08a6f2", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "bb98d311-f669-4ae4-9dbd-d32f36ef5f61", 0, "886c288f-6f69-4237-b870-b5cc20aa399c", "new.user@newUser.com", true, false, null, "NEW.USER@NEWUSER.COM", "NEWUSER", "AQAAAAEAACcQAAAAEDwVLvLsPe2ydTBJ4DS5w+fMM9MX5pzjNRvjo/105TDE2LMp8rxKsrAAwc4Dh/yQFg==", null, false, "dfdf546b-dd14-4d58-9fa4-264500573b40", false, "NewUser" },
                    { "c1021c51-7ee0-4aa0-9b71-2bb8b27f8e4f", 0, "323f22ff-d4d5-4023-a6ba-715e64cba0b9", "reall.admin@admin.eal", true, false, null, "REALL.ADMIN@ADMIN.EAL", "REALADMIN", "AQAAAAEAACcQAAAAECB/+o448AU5IIFcCRY3zS4TONAqem2LTyezhBXOcUPu/FIgL4itYZmtRiUbxT4kgg==", null, false, "1ca86d8a-916e-4113-8902-d0c913920c78", false, "RealAdmin" }
                });
        }
    }
}
