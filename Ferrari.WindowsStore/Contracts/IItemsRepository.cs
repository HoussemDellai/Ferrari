using System.Collections.Generic;
using System.Threading.Tasks;
using Ferrari.Models;

namespace Ferrari.Contracts
{
   public interface IItemsRepository
   {

       Task<bool> SaveItemsCollectionAsync(List<Item> items);

       Task<List<Item>> GetItemsCollectionByCategoryAsync(string itemCategory);
   }
}
