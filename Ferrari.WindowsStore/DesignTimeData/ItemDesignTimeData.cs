using System;
using System.Collections.Generic;
using Ferrari.Models;

namespace Ferrari.DesignTimeData
{
    public static class ItemDesignTimeData
    {

        public static FlickrImage FlickrImage
        {
            get
            {
                return new FlickrImage
                {
                    LargeImageUrl = "http://farm6.staticflickr.com/5336/8855565568_66a457ca96_h.jpg", 
                                        //"ms-appx:///DesignTimeData/Ferrari-LaFerrari-2014-4.jpg",
                    Title = "1000 miglia race"
                };
            }
        }

        public static List<FlickrImage> FlickrImagesCollectionDesign
        {
            get
            {
                return new List<FlickrImage>
				{
					FlickrImage, FlickrImage, FlickrImage, FlickrImage, 
				};
            }
        }

        public static Item ItemDesign
        {
            get
            {
                return new Item
                {
                    Title = "Even more astonishing figures for classic Ferraris",
                    Description =
                        "Maranello – What’s worth more, a Picasso painting or a Ferrari car? When one is talking of masterpieces, it’s hard to give a precise answer."
                    ,
                    TextNews =
                        "What’s worth more, a Picasso painting or a Ferrari car? When one is talking of masterpieces, it’s hard to give a precise answer. However, it’s a fact that recent prices reached by classic Ferraris in auctions around the world are truly amazing. There was further confirmation of that yesterday, when a 1964 250 LM went for US$14.3 million at the “Art of the Automobile” auction organised by RM Auction in collaboration with Sotheby’s in New York. &lt;BR>&lt;BR>Back in August, at the Pebble Beach auction, a 275 GTB/4 S NART Spider went for 27.5 million dollars and a 250 LM was also the object of a fierce bidding war between several buyers. However, the price of 52 million dollars that were paid for a 250 GTO is still unbeaten as the highest price ever paid, not just for a Maranello car, but any road car. &lt;BR>&lt;BR>The 250 LM that went under the hammer yesterday in New York was initially destined for road use, but when, in 1968, it was bought by two Ecuadorians, Guillermo Ortega and Fausto Merello, who were part of the Raceco team, it was transformed into a race car. The South American duo used the car in the most important endurance race on the American continent, taking the class win and eighth overall in the 1969 Daytona 24 Hours." +
                        "What’s worth more, a Picasso painting or a Ferrari car? When one is talking of masterpieces, it’s hard to give a precise answer. However, it’s a fact that recent prices reached by classic Ferraris in auctions around the world are truly amazing. There was further confirmation of that yesterday, when a 1964 250 LM went for US$14.3 million at the “Art of the Automobile” auction organised by RM Auction in collaboration with Sotheby’s in New York. &lt;BR>&lt;BR>Back in August,"
                    ,
                    ImageUrl = "http://www.ferrari.com/Site_Collection_Image_260x200/131122_newsGT_130164car_260x200.jpg",
                    PublishDate = new DateTime(2014, 2, 4, 4, 0 , 0)//"Mon, 05 Mar 2012 10:00:00 GMT",
                };
            }
        }



        public static List<Item> ItemsCollectionDesign
        {
            get
            {
                return new List<Item>
				{
					ItemDesign, ItemDesign, ItemDesign, ItemDesign, ItemDesign, ItemDesign
				};
            }
        }

        public static YoutubeVideo Video
        {
            get
            {
                return new YoutubeVideo
                {
                    Title = "Giochi Olimpici Invernali Sochi 2014 - Intervista a Carlo Mornati",
                    Thumbnail = "http://img.youtube.com/vi/5ZIX8WGHXl4/maxresdefault.jpg",
                    PubDate = new DateTime(2014, 2, 5),
                };
            }
        }

        public static List<YoutubeVideo> Videos
        {
            get
            {
            return new List<YoutubeVideo>
            {
                Video, Video, Video, Video,
                Video, Video, Video, Video,
                Video, Video, Video, Video,
                Video, Video, Video, Video,
            };
            }
        }
    }
}
