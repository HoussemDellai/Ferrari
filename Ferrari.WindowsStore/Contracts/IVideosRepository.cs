using System.Collections.Generic;
using System.Threading.Tasks;
using Ferrari.Models;

namespace Ferrari.WindowsStore.Contracts
{
   public interface IVideosRepository
   {

       Task<bool> SaveVideosCollectionAsync(List<YoutubeVideo> videos);

       Task<List<YoutubeVideo>> GetVideosCollectionAsync();
   }
}
