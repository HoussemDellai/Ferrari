using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ferrari.Models;
using Ferrari.WindowsStore.Contracts;
using Ferrari.WPhone8.SqlCeDataContext;

namespace Ferrari.Repositories
{
    public class VideosRepository : IVideosRepository
    {


        public Task<List<YoutubeVideo>> GetVideosCollectionAsync()
        {
            try
            {
                List<YoutubeVideo> videos;

                using (var context = new FerrariDataContext())
                {
                    IQueryable<YoutubeVideo> vdeos = from itms
                                                       in context.GetTable<YoutubeVideo>()
                                                       select itms;

                    videos = vdeos.ToList();
                }

                return Task.FromResult<List<YoutubeVideo>>(videos);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<bool> SaveVideosCollectionAsync(List<YoutubeVideo> videos)
        {

            if (videos == null || videos.Count == 0)
                return Task.FromResult<bool>(false);

            try
            {
                //Adding data to the local database 
                using (var context = new FerrariDataContext())
                {
                    var oldVideos = context.GetTable<YoutubeVideo>();
                    context.GetTable<YoutubeVideo>().DeleteAllOnSubmit(oldVideos);
                    context.SubmitChanges();

                    foreach (var video in videos)
                    {
                        context.GetTable<YoutubeVideo>().InsertOnSubmit(video);
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
