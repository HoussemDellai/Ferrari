using System.Collections.Generic;

namespace Ferrari.Configurations
{
	public class Constants
	{

		public static string NewsLink
		{
			get { return "http://houssemdellai-services.azurewebsites.net/api/ferrari/feed/news/20"; }
		}

		public static string FormulaOneLink
		{
			get { return "http://houssemdellai-services.azurewebsites.net/api/ferrari/feed/FormulaOne/20"; }
		}

		public static string CarsLink
		{
			get { return "http://houssemdellai-services.azurewebsites.net/api/ferrari/feed/Cars/20"; }
		}

		public static string RacingLink
		{
			get { return "http://houssemdellai-services.azurewebsites.net/api/ferrari/feed/Racing/20"; }
		}

		public static string TweetsLink
		{
			get { return "http://houssemdellai-services.azurewebsites.net/api/tweets/FerrariMagazine/Ferrari/20"; }
		}

		public static string YoutubeChannelLink
		{
			get { return "http://houssemdellai-services.azurewebsites.net/api/youtube/ferrariworld/20"; }
		}

		public static string FlickrLink
		{
			get { return "http://houssemdellai-services.azurewebsites.net/api/flickr/62461882@N04/20"; }
		}



		/// <summary>
		/// "Featured",
		/// "Cars",
		/// "News",
		/// "Formula 1",
		/// "Racing",
		/// "Videos",
		/// "Tweets",
		/// </summary>
		public static List<string> SectionNames
		{
			get
			{
				return new List<string>
				{
					"Featured",
					"Cars",
					"News",
					"Formula 1",
					"Racing",
					"Videos",
					"Tweets",
				};
			}
		}
	}
}
