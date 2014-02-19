using System.Collections.Generic;
using System.Threading.Tasks;
using Ferrari.Models;

namespace Ferrari.Contracts
{
	public interface ITweetsService
	{

		Task<List<Tweet>> GetTweetsAsync(string twitterAccount, string twitterHashTag, int numberOfTweets);
	}
}
