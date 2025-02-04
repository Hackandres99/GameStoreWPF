namespace GameStoreWPF.Models
{
	public partial class VideoGame
	{
		public int Id { get; set; }

		public string? Name { get; set; }

		public int? Console { get; set; }

		public int? PublicationYear { get; set; }

		public int? VideoGameAge { get; set; }

		public int? VideoGameType { get; set; }

		public virtual ConsoleVideoGame? ConsoleNavigation { get; set; }

		public virtual PublicationYear? PublicationYearNavigation { get; set; }

		public virtual VideoGameAge? VideoGameAgeNavigation { get; set; }

		public virtual VideoGameType? VideoGameTypeNavigation { get; set; }
	}

}

