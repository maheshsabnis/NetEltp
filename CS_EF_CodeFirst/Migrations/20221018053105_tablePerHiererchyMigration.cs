using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CS_EF_CodeFirst.Migrations
{
    public partial class tablePerHiererchyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayDuration = table.Column<int>(type: "int", nullable: true),
                    BoxOfficeCollection = table.Column<double>(type: "float", nullable: true),
                    Seasons = table.Column<int>(type: "int", nullable: true),
                    EpisodPerSeason = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionUnits", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProductionUnits",
                columns: new[] { "Id", "BoxOfficeCollection", "Category", "Discriminator", "Name", "PlayDuration", "ReleaseYear" },
                values: new object[,]
                {
                    { 1, 12222.0, "Spy", "Movies", "Dr.No", 150, 1963 },
                    { 2, 122.0, "Comedy", "Movies", "Golmal", 180, 1976 }
                });

            migrationBuilder.InsertData(
                table: "ProductionUnits",
                columns: new[] { "Id", "Discriminator", "EpisodPerSeason", "Name", "ReleaseYear", "Seasons" },
                values: new object[,]
                {
                    { 3, "WebSeries", 100, "Ramayan", 1986, 2 },
                    { 4, "WebSeries", 50, "House of Cards", 2005, 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionUnits");
        }
    }
}
