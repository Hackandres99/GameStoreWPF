using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStoreWPF.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "consoleVideoGame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nchar(25)", fixedLength: true, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__consoleV__3214EC0793F4E642", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "publicationYear",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__publicat__3214EC072AE4262D", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "videoGameAge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    age = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__videoGam__3214EC07E858C920", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "videoGameType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__videoGam__3214EC07CBB01108", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "videoGame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    console = table.Column<int>(type: "int", nullable: true),
                    publicationYear = table.Column<int>(type: "int", nullable: true),
                    videoGameAge = table.Column<int>(type: "int", nullable: true),
                    videoGameType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__videoGam__3214EC07F7D4C6AC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_videoGame_ToAge",
                        column: x => x.videoGameAge,
                        principalTable: "videoGameAge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_videoGame_ToConsole",
                        column: x => x.console,
                        principalTable: "consoleVideoGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_videoGame_ToType",
                        column: x => x.videoGameType,
                        principalTable: "videoGameType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_videoGame_ToYear",
                        column: x => x.publicationYear,
                        principalTable: "publicationYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_videoGame_console",
                table: "videoGame",
                column: "console");

            migrationBuilder.CreateIndex(
                name: "IX_videoGame_publicationYear",
                table: "videoGame",
                column: "publicationYear");

            migrationBuilder.CreateIndex(
                name: "IX_videoGame_videoGameAge",
                table: "videoGame",
                column: "videoGameAge");

            migrationBuilder.CreateIndex(
                name: "IX_videoGame_videoGameType",
                table: "videoGame",
                column: "videoGameType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "videoGame");

            migrationBuilder.DropTable(
                name: "videoGameAge");

            migrationBuilder.DropTable(
                name: "consoleVideoGame");

            migrationBuilder.DropTable(
                name: "videoGameType");

            migrationBuilder.DropTable(
                name: "publicationYear");
        }
    }
}
