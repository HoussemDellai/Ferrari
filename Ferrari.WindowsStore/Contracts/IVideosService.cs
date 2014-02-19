using System.Collections.Generic;
using System.Threading.Tasks;
using Ferrari.Models;

namespace Ferrari.Contracts
{
	public interface IVideosService
	{

		Task<List<YoutubeVideo>> GetYoutubeVideosAsync(string youtubeChannel, int numberOfVideos);
	}
}
