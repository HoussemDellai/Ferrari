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
        public String Id
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public String Title
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
        public String YoutubeLink
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public String VideoLink
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public String Thumbnail
        {
            get;
            set;
        }
    }
}
