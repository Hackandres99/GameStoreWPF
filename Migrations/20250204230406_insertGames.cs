using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStoreWPF.Migrations
{
    public partial class insertGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("INSERT INTO [dbo].[videoGame] ([name], [console], [publicationYear], [videoGameAge], [videoGameType]) VALUES (N'God of War', 1, 1, 1, 1)");
			migrationBuilder.Sql("INSERT INTO [dbo].[videoGame] ([name], [console], [publicationYear], [videoGameAge], [videoGameType]) VALUES (N'Prince of Persia', 4, 4, 2, 1)");
			migrationBuilder.Sql("INSERT INTO [dbo].[videoGame] ([name], [console], [publicationYear], [videoGameAge], [videoGameType]) VALUES (N'FiFa 2023', 2, 2, 4, 2)");
			migrationBuilder.Sql("INSERT INTO [dbo].[videoGame] ([name], [console], [publicationYear], [videoGameAge], [videoGameType]) VALUES (N'Call of Duty', 4, 2, 2, 3)");
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
