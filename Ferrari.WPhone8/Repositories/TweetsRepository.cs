using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;
using Ferrari.Contracts;
using Ferrari.Models;
using Ferrari.WPhone8.SqlCeDataContext;

namespace Ferrari.Repositories
{
    /// <summary>
    ///     Repository that uses SQLite to access data.
    /// </summary>
    public class TweetsRepository : ITweetsRepository
    {
        #region ITweetsRepository Members

        public Task<List<Tweet>> GetTweetsCollectionAsync()
        {
            try
            {
                List<Tweet> tweets;

                using (var context = new FerrariDataContext())
                {
                    IQueryable<Tweet> itemsCollection = from itms
                        in context.GetTable<Tweet>()
                        select itms;

                    tweets = itemsCollection.ToList();
                }

                return Task.FromResult(tweets);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<bool> SaveTweetsCollectionAsync(List<Tweet> tweets)
        {
            if (tweets == null || tweets.Count == 0)
                return Task.FromResult(false);

            try
            {
                //Adding data to the local database 
                using (var context = new FerrariDataContext())
                {
                    Table<Tweet> oldTweets = context.GetTable<Tweet>();
                    context.GetTable<Tweet>().DeleteAllOnSubmit(oldTweets);
                    context.SubmitChanges();

                    foreach (Tweet tweet in tweets)
                    {
                        context.GetTable<Tweet>().InsertOnSubmit(tweet);
                    }
                    context.SubmitChanges();
                }

                return Task.FromResult(true);
            }
            catch (Exception exc)
            {
                return Task.FromResult(false);
            }
        }

        #endregion
    }
}