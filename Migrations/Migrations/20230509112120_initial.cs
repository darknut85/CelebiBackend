using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DexEntry = table.Column<int>(type: "integer", nullable: false),
                    Classification = table.Column<string>(type: "text", nullable: false),
                    Type1 = table.Column<string>(type: "text", nullable: false),
                    Type2 = table.Column<string>(type: "text", nullable: false),
                    Height = table.Column<double>(type: "double precision", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    PokedexEntry = table.Column<string>(type: "text", nullable: false),
                    GrowthRate = table.Column<double>(type: "double precision", nullable: false),
                    CaptureRate = table.Column<double>(type: "double precision", nullable: false),
                    HP = table.Column<double>(type: "double precision", nullable: false),
                    ATK = table.Column<double>(type: "double precision", nullable: false),
                    DEF = table.Column<double>(type: "double precision", nullable: false),
                    SPATK = table.Column<double>(type: "double precision", nullable: false),
                    SPDEF = table.Column<double>(type: "double precision", nullable: false),
                    SPD = table.Column<double>(type: "double precision", nullable: false),
                    HPEV = table.Column<double>(type: "double precision", nullable: false),
                    ATKEV = table.Column<double>(type: "double precision", nullable: false),
                    DEFEV = table.Column<double>(type: "double precision", nullable: false),
                    SPATKEV = table.Column<double>(type: "double precision", nullable: false),
                    SPDEFEV = table.Column<double>(type: "double precision", nullable: false),
                    SPDEV = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LevelupMoves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    PokemonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelupMoves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelupMoves_Pokemons_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Pokemons",
                columns: new[] { "Id", "ATK", "ATKEV", "CaptureRate", "Classification", "DEF", "DEFEV", "DexEntry", "GrowthRate", "HP", "HPEV", "Height", "Name", "PokedexEntry", "SPATK", "SPATKEV", "SPD", "SPDEF", "SPDEFEV", "SPDEV", "Type1", "Type2", "Weight" },
                values: new object[,]
                {
                    { 1, 49.0, 49.0, 45.0, "Seed Pokemon", 49.0, 49.0, 1, 1059860.0, 45.0, 45.0, 0.69999999999999996, "Bulbasaur", "A strange seed was planted on its back at birth. The plant sprouts and grows with this Pokémon.", 65.0, 65.0, 45.0, 65.0, 65.0, 45.0, "Grass", "Poison", 6.9000000000000004 },
                    { 2, 62.0, 62.0, 45.0, "Seed Pokemon", 63.0, 63.0, 2, 1059860.0, 60.0, 60.0, 1.0, "Ivysaur", "When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs.", 80.0, 80.0, 60.0, 80.0, 80.0, 60.0, "Grass", "Poison", 13.0 },
                    { 3, 82.0, 82.0, 45.0, "Seed Pokemon", 83.0, 83.0, 3, 1059860.0, 80.0, 80.0, 2.0, "Venusaur", "The plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight.", 100.0, 100.0, 80.0, 100.0, 100.0, 80.0, "Grass", "Poison", 100.0 },
                    { 4, 52.0, 52.0, 45.0, "Lizard Pokemon", 42.0, 42.0, 4, 1059860.0, 39.0, 39.0, 0.59999999999999998, "Charmander", "Obviously prefers hot places. When it rains, steam is said to spout from the tip of its tail.", 50.0, 50.0, 65.0, 50.0, 50.0, 65.0, "Fire", "", 8.5 },
                    { 5, 64.0, 64.0, 45.0, "Flame Pokemon", 58.0, 58.0, 5, 1059860.0, 58.0, 58.0, 1.1000000000000001, "Charmeleon", "When it swings its burning tail, it elevates the temperature to unbearably high levels.", 65.0, 65.0, 80.0, 65.0, 65.0, 80.0, "Fire", "", 19.0 }
                });

            migrationBuilder.InsertData(
                table: "LevelupMoves",
                columns: new[] { "Id", "Level", "PokemonId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LevelupMoves_PokemonId",
                table: "LevelupMoves",
                column: "PokemonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "LevelupMoves");

            migrationBuilder.DropTable(
                name: "Move");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Pokemons");
        }
    }
}
