using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ferrari.Models;
using Ferrari.WindowsStore.Contracts;
using SQLite;

namespace Ferrari.Repositories
{
   public class VideosRepository : IVideosRepository
    {

       	private readonly SQLiteAsyncConnection _sqliteConnection;

        public VideosRepository()
		{
			_sqliteConnection = new SQLiteAsyncConnection("db.sqlite");
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
    }
}
