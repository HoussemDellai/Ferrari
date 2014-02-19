using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Ferrari.Contracts;
using Ferrari.Models;
using Ferrari.Configurations;
using Newtonsoft.Json;

namespace Ferrari.WindowsStore.DAL
{
	public class VideosService : IVideosService
	{
		public async Task<List<YoutubeVideo>> GetYoutubeVideosAsync(string youtubeChannel, int numberOfVideos)
		{
			var client = new HttpClient();

			try
			{
				var youtubeVideosJson = await client.GetStringAsync(Constants.YoutubeChannelLink);

				return await JsonConvert.DeserializeObjectAsync<List<YoutubeVideo>>(youtubeVideosJson);
			}
			catch (Exception exc)
			{
				return null;
			}
		}
	}
}
