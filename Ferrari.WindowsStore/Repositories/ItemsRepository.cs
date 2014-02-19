using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ferrari.Contracts;
using Ferrari.Models;
using Ferrari.WindowsStore.Contracts;
using SQLite;

namespace Ferrari.Repositories
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly SQLiteAsyncConnection _sqliteConnection;

        public ItemsRepository()
		{
			_sqliteConnection = new SQLiteAsyncConnection("db.sqlite");
		}

		public async Task<bool> SaveItemsCollectionAsync(List<Item> items)
		{
			try
			{
				// var i = await _sqliteConnection.DropTableAsync<Item>();

				// Create table if not exist
				await _sqliteConnection.CreateTableAsync<Item>();

				if (items == null)
					return false;

				// Remove old existing items
				var allExistingItems = await _sqliteConnection.Table<Item>().ToListAsync();
				var existingItems = allExistingItems.Where(item => item.Category == items[0].Category);
				//var existingItems = await _sqliteConnection.Table<Item>().Where(item => item.Category == items[0].Category).ToListAsync();

				foreach (var item in existingItems)
				{
					await _sqliteConnection.DeleteAsync(item);
				}

				// Save items
				await _sqliteConnection.InsertAllAsync(items);

				return true;
			}
			catch (Exception exc)
			{
				return false;
			}
		}

		public async Task<List<Item>> GetItemsCollectionByCategoryAsync(string itemCategory)
		{
			try
			{
				return await _sqliteConnection.Table<Item>().Where(item => item.Category == itemCategory).ToListAsync();
			}
			catch (Exception)
			{
				return null;
			}
		}
    }
}
