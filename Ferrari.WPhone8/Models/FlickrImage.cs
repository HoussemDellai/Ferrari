using System;
using System.Data.Linq.Mapping;

namespace Ferrari.Models
{
    [Table]
    public class FlickrImage
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int FlickrImageId { get; set; }

        [Column(CanBeNull = true)]
        public String Title { get; set; }

        [Column(CanBeNull = true)]
        public String LargeImageUrl { get; set; }

        [Column(CanBeNull = true)]
        public int? LargeImageWidth { get; set; }

        [Column(CanBeNull = true)]
        public int? LargeImageHeight { get; set; }

        [Column(CanBeNull = true)]
        public string MediumImageUrl { get; set; }

        [Column(CanBeNull = true)]
        public int? MediumImageWidth { get; set; }

        [Column(CanBeNull = true)]
        public int? MediumImageHeight { get; set; }
    }
}