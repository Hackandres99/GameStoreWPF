using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStoreWPF.Migrations
{
    public partial class InsertInitialData : Migration
    {
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			// Insertar datos en las tablas relacionadas primero
			migrationBuilder.Sql("INSERT INTO [dbo].[consoleVideoGame] ([name]) VALUES (N'ps5')");
			migrationBuilder.Sql("INSERT INTO [dbo].[consoleVideoGame] ([name]) VALUES (N'ps4')");
			migrationBuilder.Sql("INSERT INTO [dbo].[consoleVideoGame] ([name]) VALUES (N'xbox')");
			migrationBuilder.Sql("INSERT INTO [dbo].[consoleVideoGame] ([name]) VALUES (N'pc')");
			migrationBuilder.Sql("INSERT INTO [dbo].[consoleVideoGame] ([name]) VALUES (N'nintendo')");
			migrationBuilder.Sql("INSERT INTO [dbo].[consoleVideoGame] ([name]) VALUES (N'snes clasic')");

			migrationBuilder.Sql("INSERT INTO [dbo].[publicationYear] ([year]) VALUES (2024)");
			migrationBuilder.Sql("INSERT INTO [dbo].[publicationYear] ([year]) VALUES (2023)");
			migrationBuilder.Sql("INSERT INTO [dbo].[publicationYear] ([year]) VALUES (2022)");
			migrationBuilder.Sql("INSERT INTO [dbo].[publicationYear] ([year]) VALUES (2021)");

			migrationBuilder.Sql("INSERT INTO [dbo].[videoGameAge] ([age]) VALUES (18)");
			migrationBuilder.Sql("INSERT INTO [dbo].[videoGameAge] ([age]) VALUES (16)");
			migrationBuilder.Sql("INSERT INTO [dbo].[videoGameAge] ([age]) VALUES (14)");
			migrationBuilder.Sql("INSERT INTO [dbo].[videoGameAge] ([age]) VALUES (12)");

			migrationBuilder.Sql("INSERT INTO [dbo].[videoGameType] ([type]) VALUES (N'adventure')");
			migrationBuilder.Sql("INSERT INTO [dbo].[videoGameType] ([type]) VALUES (N'sport')");
			migrationBuilder.Sql("INSERT INTO [dbo].[videoGameType] ([type]) VALUES (N'shooter')");
			migrationBuilder.Sql("INSERT INTO [dbo].[videoGameType] ([type]) VALUES (N'rol')");

		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
	
		}

	}
}
