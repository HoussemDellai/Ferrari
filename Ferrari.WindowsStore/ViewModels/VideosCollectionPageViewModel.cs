using System.Collections.Generic;
using System.Windows.Input;
using Ferrari.Contracts;
using Ferrari.Models;
using Ferrari.Utilities;
using Microsoft.Practices.Unity;

namespace Ferrari.ViewModels
{
    public class VideosCollectionPageViewModel : BaseViewModel
    {
        private readonly IPageNavigationService _pageNavigationService;
        private readonly ISharingService _sharingService;
        private readonly IUnityContainer _unityContainer;
        private YoutubeVideo _selectedVideo;
        private ICommand _navigateToVideoPlayerPageCommand;
      

        public VideosCollectionPageViewModel(IUnityContainer unityContainer,
            IPageNavigationService pageNavigationService,
            ISharingService sharingService)
            : base(sharingService, pageNavigationService, unityContainer)
        {
            _unityContainer = unityContainer;
            _pageNavigationService = pageNavigationService;
            _sharingService = sharingService;

            InitializeData();
        }

        public YoutubeVideo SelectedVideo
        {
            get
            {
                return _selectedVideo;
            }
            set
            {
                _selectedVideo = value;
                _sharingService.RegisterForShare(_selectedVideo.Title, _selectedVideo.YoutubeLink,
                    _selectedVideo.Thumbnail);
                OnPropertyChanged();
            }
        }

        public List<YoutubeVideo> YoutubeVideosCollection
        {
            get;
            set;
        }
      

        private void InitializeData()
        {
            SelectedVideo = _unityContainer.Resolve<YoutubeVideo>();
            YoutubeVideosCollection = _unityContainer.Resolve<List<YoutubeVideo>>();

            //#if !WINDOWS_PHONE
            //            if (DesignMode.DesignModeEnabled)
            //            {
            //                YoutubeVideosCollection = new List<YoutubeVideo>
            //                {
            //                    new YoutubeVideo(),
            //                    new YoutubeVideo(),
            //                    new YoutubeVideo(),
            //                    new YoutubeVideo(),
            //                    new YoutubeVideo(),
            //                    new YoutubeVideo(),
            //                    new YoutubeVideo(),
            //                    new YoutubeVideo(),
            //                    new YoutubeVideo(),
            //                    new YoutubeVideo(),
            //                    new YoutubeVideo(),
            //                    new YoutubeVideo()
            //                };
            //            }
            //            else
            //#endif
        }
    }
}