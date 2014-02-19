using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ferrari.Contracts;
using Ferrari.Models;
using Ferrari.WindowsStore.Contracts;
using Ferrari.WPhone8.SqlCeDataContext;

namespace Ferrari.Repositories
{
    public class ImagesRepository : IImagesRepository
    {

        public Task<List<FlickrImage>> GetFlickrImagesCollectionAsync()
        {
            try
            {
                List<FlickrImage> images;

                using (var context = new FerrariDataContext())
                {
                    IQueryable<FlickrImage> itemsCollection = from itms
                        in context.GetTable<FlickrImage>()
                        select itms;

                    images = itemsCollection.ToList();
                }

                return Task.FromResult<List<FlickrImage>>(images);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<bool> SaveFlickrImagesCollectionAsync(List<FlickrImage> images)
        {
            if (images == null || images.Count == 0)
                return Task.FromResult<bool>(false);

            try
            {
                //Adding data to the local database 
                using (var context = new FerrariDataContext())
                {
                    var oldImages = context.Images;
                    context.Images.DeleteAllOnSubmit(oldImages);
                    context.SubmitChanges();

                    foreach (FlickrImage item in images)
                    {
                        context.GetTable<FlickrImage>().InsertOnSubmit(item);
                    }
                    context.SubmitChanges();
                }

                return Task.FromResult<bool>(true);
            }
            catch (Exception exc)
            {
                return Task.FromResult<bool>(false);
            }
        }
    }
}
