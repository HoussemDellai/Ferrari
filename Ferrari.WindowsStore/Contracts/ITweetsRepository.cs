using System.Collections.Generic;
using System.Threading.Tasks;
using Ferrari.Models;

namespace Ferrari.Contracts
{
  public  interface ITweetsRepository
  {

      Task<bool> SaveTweetsCollectionAsync(List<Tweet> tweets);

      Task<List<Tweet>> GetTweetsCollectionAsync();
  }
}
