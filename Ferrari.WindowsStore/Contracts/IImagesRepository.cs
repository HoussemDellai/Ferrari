using System.Collections.Generic;
using System.Threading.Tasks;
using Ferrari.Models;

namespace Ferrari.Contracts
{
   public interface IImagesRepository
   {

       Task<bool> SaveFlickrImagesCollectionAsync(List<FlickrImage> flickrImagesCollection);

       Task<List<FlickrImage>> GetFlickrImagesCollectionAsync();
   }
}
