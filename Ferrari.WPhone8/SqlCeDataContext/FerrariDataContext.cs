using System.Data.Linq;
using Ferrari.Models;

namespace Ferrari.WPhone8.SqlCeDataContext
{
    /// <summary>
    /// This class provides access to the SQLCE database in Windows Phone.
    /// </summary>
    public class FerrariDataContext : DataContext
    {

        private const string ConnectionString = @"isostore:/Items.sdf";

        /// <summary>
        /// The constructor will create the database if not exist.
        /// </summary>
        public FerrariDataContext()
               : base(ConnectionString)
        {
            if (!DatabaseExists())
            {
                // Delete and create the database if any modification in schema
                DeleteDatabase();
                CreateDatabase();
            }
        }

        // the tables

        public Table<Item> Items;

        public Table<FlickrImage> Images;

        public Table<YoutubeVideo> Videos;

        public Table<Tweet> Tweets;
    }
}
