using System;
using System.Data.Linq.Mapping;

namespace Ferrari.Models
{
    [Table]
    public class YoutubeVideo
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int YoutubeVideoId
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public string Id
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public string Title
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public DateTime PubDate
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public string YoutubeLink
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public string VideoLink
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public string Thumbnail
        {
            get;
            set;
        }
    }
}
