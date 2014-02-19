using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ferrari.Models;
using Ferrari.WindowsStore.Contracts;
using Ferrari.WindowsStore.Models;
using SQLite;

namespace Ferrari.WindowsStore.OfflineServices
{
	public class OfflineService : IOfflineService
	{

		private readonly SQLiteAsyncConnection _sqliteConnection;

		public OfflineService()
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

		public async Task<bool> SaveVideosCollectionAsync(List<YoutubeVideo> videos)
		{
			try
			{
				//await _sqliteConnection.DropTableAsync<YoutubeVideo>();
				await _sqliteConnection.CreateTableAsync<YoutubeVideo>();

				if (videos == null)
					return false;

				// Remove old existing items
				var existingItems = await _sqliteConnection.Table<YoutubeVideo>().ToListAsync();

				foreach (var item in existingItems)
				{
					await _sqliteConnection.DeleteAsync(item);
				}

				await _sqliteConnection.CreateTableAsync<YoutubeVideo>();

				await _sqliteConnection.InsertAllAsync(videos);

				return true;
			}
			catch (Exception exc)
			{
				return false;
			}
		}

		public async Task<List<YoutubeVideo>> GetVideosCollectionAsync()
		{
			try
			{
				return await _sqliteConnection.Table<YoutubeVideo>().ToListAsync();
			}
			catch (Exception)
			{
				return null;
			}
		}

		public async Task<bool> SaveTweetsCollectionAsync(List<Tweet> tweets)
		{
			try
			{
				//await _sqliteConnection.DropTableAsync<Tweet>();
				await _sqliteConnection.CreateTableAsync<Tweet>();

				if (tweets == null)
					return false;

				// Remove old existing items
				var existingItems = await _sqliteConnection.Table<Tweet>().ToListAsync();

				foreach (var item in existingItems)
				{
					await _sqliteConnection.DeleteAsync(item);
				}

				await _sqliteConnection.CreateTableAsync<Tweet>();

				await _sqliteConnection.InsertAllAsync(tweets);

				return true;
			}
			catch (Exception exc)
			{
				return false;
			}
		}

		public async Task<List<Tweet>> GetTweetsCollectionAsync()
		{
			try
			{
				return await _sqliteConnection.Table<Tweet>().ToListAsync();
			}
			catch (Exception)
			{
				return null;
			}
		}

		public async Task<bool> SaveFlickrImagesCollectionAsync(List<FlickrImage> flickrImagesCollection)
		{
			try
			{
				//await _sqliteConnection.DropTableAsync<FlickrImage>();
				await _sqliteConnection.CreateTableAsync<FlickrImage>();

				if (flickrImagesCollection == null)
					return false;

				// Remove old existing items
				var existingItems = await _sqliteConnection.Table<FlickrImage>().ToListAsync();
				foreach (var item in existingItems)
				{
					await _sqliteConnection.DeleteAsync(item);
				}

				//await _sqliteConnection.CreateTableAsync<FlickrImage>();

				await _sqliteConnection.InsertAllAsync(flickrImagesCollection);

				return true;
			}
			catch (Exception exc)
			{
				return false;
			}
		}

		public async Task<List<FlickrImage>> GetFlickrImagesCollectionAsync()
		{
			try
			{
				return await _sqliteConnection.Table<FlickrImage>().ToListAsync();
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
