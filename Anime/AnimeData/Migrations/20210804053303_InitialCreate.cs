using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeData.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    AnimeID = table.Column<int>(type: "int", nullable: false),
                    animeName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    genre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    type = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    episode = table.Column<int>(type: "int", nullable: true),
                    releaseYear = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    language = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    restriction = table.Column<int>(type: "int", nullable: true),
                    rank = table.Column<int>(type: "int", nullable: true),
                    summary = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.AnimeID);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    PersonID = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    username = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    firstName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    lastName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    age = table.Column<int>(type: "int", nullable: true),
                    country = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Profiles__AA2FFB855DD7F05B", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "Watchlists",
                columns: table => new
                {
                    PersonID = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    AnimeID = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: true),
                    watching = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Watchlis__10D7DA9557DB0008", x => new { x.PersonID, x.AnimeID });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animes");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Watchlists");
        }
    }
}
