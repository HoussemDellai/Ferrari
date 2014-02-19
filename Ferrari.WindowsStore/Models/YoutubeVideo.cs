using System;
using SQLite;

namespace Ferrari.Models
{
	public class YoutubeVideo
	{
		[PrimaryKey, AutoIncrement]
		public int YoutubeVideoId { get; set; }

		public String Id { get; set; }

		public String Title { get; set; }

		public DateTime PubDate { get; set; }

		public String YoutubeLink { get; set; }

		public String VideoLink { get; set; }

		public String Thumbnail { get; set; }
	}
}
