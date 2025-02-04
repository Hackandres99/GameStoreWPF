using GameStoreWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStoreWPF.Context
{
	public partial class GameStoreContext : DbContext
	{
		public GameStoreContext()
		{
		}

		public GameStoreContext(DbContextOptions<GameStoreContext> options)
			: base(options)
		{
		}

		public virtual DbSet<ConsoleVideoGame> ConsoleVideoGames { get; set; }

		public virtual DbSet<PublicationYear> PublicationYears { get; set; }

		public virtual DbSet<VideoGame> VideoGames { get; set; }

		public virtual DbSet<VideoGameAge> VideoGameAges { get; set; }

		public virtual DbSet<VideoGameType> VideoGameTypes { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseSqlServer("Server=DESKTOP-88NKHV0\\MSSQLSERVER1; Database=gameStore; Integrated Security=true; TrustServerCertificate=true");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ConsoleVideoGame>(entity =>
			{
				entity.HasKey(e => e.Id).HasName("PK__consoleV__3214EC0793F4E642");

				entity.ToTable("consoleVideoGame");

				entity.Property(e => e.Name)
					.HasMaxLength(25)
					.IsFixedLength()
					.HasColumnName("name");
			});

			modelBuilder.Entity<PublicationYear>(entity =>
			{
				entity.HasKey(e => e.Id).HasName("PK__publicat__3214EC072AE4262D");

				entity.ToTable("publicationYear");

				entity.Property(e => e.Year).HasColumnName("year");
			});

			modelBuilder.Entity<VideoGame>(entity =>
			{
				entity.HasKey(e => e.Id).HasName("PK__videoGam__3214EC07F7D4C6AC");

				entity.ToTable("videoGame");

				entity.Property(e => e.Console).HasColumnName("console");
				entity.Property(e => e.Name)
					.HasMaxLength(25)
					.HasColumnName("name");
				entity.Property(e => e.PublicationYear).HasColumnName("publicationYear");
				entity.Property(e => e.VideoGameAge).HasColumnName("videoGameAge");
				entity.Property(e => e.VideoGameType).HasColumnName("videoGameType");

				entity.HasOne(d => d.ConsoleNavigation).WithMany(p => p.VideoGames)
					.HasForeignKey(d => d.Console)
					.HasConstraintName("FK_videoGame_ToConsole");

				entity.HasOne(d => d.PublicationYearNavigation).WithMany(p => p.VideoGames)
					.HasForeignKey(d => d.PublicationYear)
					.HasConstraintName("FK_videoGame_ToYear");

				entity.HasOne(d => d.VideoGameAgeNavigation).WithMany(p => p.VideoGames)
					.HasForeignKey(d => d.VideoGameAge)
					.HasConstraintName("FK_videoGame_ToAge");

				entity.HasOne(d => d.VideoGameTypeNavigation).WithMany(p => p.VideoGames)
					.HasForeignKey(d => d.VideoGameType)
					.HasConstraintName("FK_videoGame_ToType");
			});

			modelBuilder.Entity<VideoGameAge>(entity =>
			{
				entity.HasKey(e => e.Id).HasName("PK__videoGam__3214EC07E858C920");

				entity.ToTable("videoGameAge");

				entity.Property(e => e.Age).HasColumnName("age");
			});

			modelBuilder.Entity<VideoGameType>(entity =>
			{
				entity.HasKey(e => e.Id).HasName("PK__videoGam__3214EC07CBB01108");

				entity.ToTable("videoGameType");

				entity.Property(e => e.Type)
					.HasMaxLength(25)
					.HasColumnName("type");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}

}

