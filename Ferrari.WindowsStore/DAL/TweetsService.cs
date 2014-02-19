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
	public class TweetsService : ITweetsService
	{

		public async Task<List<Tweet>> GetTweetsAsync(string twitterAccount, string twitterHashTag, int numberOfTweets)
		{
			var client = new HttpClient();

			try
			{
				var tweetsJson = await client.GetStringAsync(Constants.TweetsLink);

				return await JsonConvert.DeserializeObjectAsync<List<Tweet>>(tweetsJson);
			}
			catch(Exception exc)
			{
				return null;
			}
		}
	}
}
