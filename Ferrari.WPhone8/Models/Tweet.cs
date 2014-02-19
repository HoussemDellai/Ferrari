using System;
using System.Data.Linq.Mapping;

namespace Ferrari.Models
{
    [Table]
    public class Tweet
    {

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int TweetId
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public string Text
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public string UserName
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public DateTime PublishDate
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public string ImageUrl
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public string ScreenName
        {
            get;
            set;
        }
    }
}
