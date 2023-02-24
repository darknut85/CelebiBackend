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
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DexEntry = table.Column<int>(type: "integer", nullable: false),
                    Classification = table.Column<string>(type: "text", nullable: true),
                    Type1 = table.Column<string>(type: "text", nullable: true),
                    Type2 = table.Column<string>(type: "text", nullable: false),
                    Height = table.Column<double>(type: "double precision", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    PokedexEntry = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pokemons",
                columns: new[] { "Id", "Classification", "DexEntry", "Height", "Name", "PokedexEntry", "Type1", "Type2", "Weight" },
                values: new object[,]
                {
                    { 1, "Seed Pokemon", 1, 0.69999999999999996, "Bulbasaur", "A strange seed was planted on its back at birth. The plant sprouts and grows with this Pokémon.", "Grass", "Poison", 6.9000000000000004 },
                    { 2, "Seed Pokemon", 2, 1.0, "Ivysaur", "When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs.", "Grass", "Poison", 13.0 },
                    { 3, "Seed Pokemon", 3, 2.0, "Venusaur", "The plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight.", "Grass", "Poison", 100.0 },
                    { 4, "Lizard Pokemon", 4, 0.59999999999999998, "Charmander", "Obviously prefers hot places. When it rains, steam is said to spout from the tip of its tail.", "Fire", "", 8.5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemons");
        }
    }
}
