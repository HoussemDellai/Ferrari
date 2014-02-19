using System;
using SQLite;

namespace Ferrari.Models
{
	public class Tweet
	{

		[PrimaryKey, AutoIncrement]
		public int TweetId { get; set; }

		public string Text { get; set; }

		public string UserName { get; set; }

		public DateTime PublishDate { get; set; }

		public string ImageUrl { get; set; }

		public string ScreenName { get; set; }
	}
}
