using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ferrari.Contracts;
using Ferrari.Models;
using SQLite;

namespace Ferrari.Repositories
{
    /// <summary>
    /// Repository that uses SQLite to access data.
    /// </summary>
    public class TweetsRepository : ITweetsRepository
    {
        	private readonly SQLiteAsyncConnection _sqliteConnection;

            public TweetsRepository()
		{
			_sqliteConnection = new SQLiteAsyncConnection("db.sqlite");
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
    }
}
