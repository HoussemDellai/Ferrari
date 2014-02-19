using System.Collections.Generic;
using System.Threading.Tasks;
using Ferrari.Models;

namespace Ferrari.Contracts
{
	public interface IItemsService
	{

		Task<List<Item>> GetItemsAsync(string link);
	}
}
