using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ferrari.Contracts;
using Ferrari.Models;
using Ferrari.WindowsStore.Contracts;
using SQLite;

namespace Ferrari.Repositories
{
    public class ImagesRepository : IImagesRepository
    {
        private readonly SQLiteAsyncConnection _sqliteConnection;

        public ImagesRepository()
		{
			_sqliteConnection = new SQLiteAsyncConnection("db.sqlite");
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
