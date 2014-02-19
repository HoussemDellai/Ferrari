using System.Collections.Generic;
using System.Threading.Tasks;
using Ferrari.Models;
using Ferrari.WindowsStore.Models;

namespace Ferrari.WindowsStore.Contracts
{
	public interface IOfflineService
	{

		Task<bool> SaveItemsCollectionAsync(List<Item> items);

		Task<List<Item>> GetItemsCollectionByCategoryAsync(string itemCategory);

		Task<bool> SaveVideosCollectionAsync(List<YoutubeVideo> videos);

		Task<List<YoutubeVideo>> GetVideosCollectionAsync();

		Task<bool> SaveTweetsCollectionAsync(List<Tweet> tweets);

		Task<List<Tweet>> GetTweetsCollectionAsync();

		Task<bool> SaveFlickrImagesCollectionAsync(List<FlickrImage> flickrImagesCollection);

		Task<List<FlickrImage>> GetFlickrImagesCollectionAsync();
	}
}
