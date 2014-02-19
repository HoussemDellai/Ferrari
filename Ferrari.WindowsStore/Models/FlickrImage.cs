using System;
using SQLite;

namespace Ferrari.Models
{
	public class FlickrImage
	{
		[PrimaryKey, AutoIncrement]
		public int FlickrImageId { get; set; }

		public String Title { get; set; }

		public String LargeImageUrl { get; set; }

		public int? LargeImageWidth { get; set; }

		public int? LargeImageHeight { get; set; }

		public string MediumImageUrl { get; set; }

		public int? MediumImageWidth { get; set; }

		public int? MediumImageHeight { get; set; }
	}
}
