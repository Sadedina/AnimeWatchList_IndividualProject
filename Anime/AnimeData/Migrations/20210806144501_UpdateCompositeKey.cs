using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeData.Migrations
{
    public partial class UpdateCompositeKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Watchlist__Anime__5441852A",
                table: "Watchlists");

            migrationBuilder.DropForeignKey(
                name: "FK__Watchlist__Perso__534D60F1",
                table: "Watchlists");

            migrationBuilder.DropIndex(
                name: "IX_Watchlists_PersonID",
                table: "Watchlists");

            migrationBuilder.AlterColumn<string>(
                name: "PersonID",
                table: "Watchlists",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnimeID",
                table: "Watchlists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Watchlis__10D7DA958DB11BF3",
                table: "Watchlists",
                columns: new[] { "PersonID", "AnimeID" });

            migrationBuilder.AddForeignKey(
                name: "FK__Watchlist__Anime__5BE2A6F2",
                table: "Watchlists",
                column: "AnimeID",
                principalTable: "Animes",
                principalColumn: "AnimeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Watchlist__Perso__5CD6CB2B",
                table: "Watchlists",
                column: "PersonID",
                principalTable: "Profiles",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Watchlist__Anime__5BE2A6F2",
                table: "Watchlists");

            migrationBuilder.DropForeignKey(
                name: "FK__Watchlist__Perso__5CD6CB2B",
                table: "Watchlists");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Watchlis__10D7DA958DB11BF3",
                table: "Watchlists");

            migrationBuilder.AlterColumn<int>(
                name: "AnimeID",
                table: "Watchlists",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PersonID",
                table: "Watchlists",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255);

            migrationBuilder.CreateIndex(
                name: "IX_Watchlists_PersonID",
                table: "Watchlists",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK__Watchlist__Anime__5441852A",
                table: "Watchlists",
                column: "AnimeID",
                principalTable: "Animes",
                principalColumn: "AnimeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Watchlist__Perso__534D60F1",
                table: "Watchlists",
                column: "PersonID",
                principalTable: "Profiles",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
