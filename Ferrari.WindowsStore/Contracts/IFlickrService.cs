using System.Collections.Generic;
using System.Threading.Tasks;
using Ferrari.Models;

namespace Ferrari.Contracts
{
	public interface IFlickrService
	{

		Task<List<FlickrImage>> GetFlickrImagesAsync(string serviceLink);
	}
}
