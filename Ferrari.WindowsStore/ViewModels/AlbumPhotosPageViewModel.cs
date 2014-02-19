using System.Collections.Generic;
using System.Windows.Input;
using Ferrari.Contracts;
using Ferrari.Models;
using Ferrari.Utilities;
using Microsoft.Practices.Unity;

namespace Ferrari.ViewModels
{
    public class AlbumPhotosPageViewModel : BaseViewModel
    {
        private readonly ISharingService _sharingService;
        private List<FlickrImage> _flickrImagesCollection;
        private FlickrImage _selectedFlickrImage;
        private readonly ILiveTileService _liveTileService;
        private readonly ILockScreenService _lockScreenService;
        private ICommand _goBackPhotoCommand;
        private ICommand _goNextPhotoCommand;
        private ICommand _trySetImageAsLockScreenBackgroundCommand;

        public List<FlickrImage> FlickrImagesCollection
        {
            get
            {
                return _flickrImagesCollection;
            }
            set
            {
                _flickrImagesCollection = value;
                OnPropertyChanged();
            }
        }

        public FlickrImage SelectedFlickrImage
        {
            get
            {
                return _selectedFlickrImage;
            }
            set
            {
                _selectedFlickrImage = value;
                _sharingService.RegisterForShare(_selectedFlickrImage.Title, "", _selectedFlickrImage.LargeImageUrl);
                _liveTileService.TryUpdateLiveTileAsync(_selectedFlickrImage.Title, _selectedFlickrImage.MediumImageUrl);
                OnPropertyChanged();
            }
        }

        public ICommand TrySetImageAsLockScreenBackgroundCommand
        {
            get
            {
                if (_trySetImageAsLockScreenBackgroundCommand == null)
                {
                    _trySetImageAsLockScreenBackgroundCommand = new RelayCommand(() => _lockScreenService.TrySetImageAsLockScreenBackground(SelectedFlickrImage.LargeImageUrl));
                }
                return _trySetImageAsLockScreenBackgroundCommand;
            }
        }

        public ICommand GoNextPhotoCommand
        {
            get
            {
                if (_goNextPhotoCommand == null)
                {
                    _goNextPhotoCommand = new RelayCommand(() =>
                    {
                        SelectedFlickrImage = PreviousAndNextFromListUtilities<FlickrImage>.GetNextObjectFromCollection(SelectedFlickrImage,
                            FlickrImagesCollection);
                    });
                }

                return _goNextPhotoCommand;
            }
        }

        public ICommand GoBackPhotoCommand
        {
            get
            {
                if (_goBackPhotoCommand == null)
                {
                    _goBackPhotoCommand = new RelayCommand(() =>
                    {
                        SelectedFlickrImage =
                            PreviousAndNextFromListUtilities<FlickrImage>.GetPreviousObjectFromCollection(SelectedFlickrImage,
                                FlickrImagesCollection);
                    });
                }

                return _goBackPhotoCommand;
            }
        }

        public AlbumPhotosPageViewModel(
            IPageNavigationService pageNavigationService,
            List<FlickrImage> flickrImages,
            ISharingService sharingService,
            ILiveTileService liveTileService,
            ILockScreenService lockScreenService,
            IUnityContainer unityContainer)
            : base(sharingService, pageNavigationService, unityContainer)
        {
            _sharingService = sharingService;
            _liveTileService = liveTileService;
            _lockScreenService = lockScreenService;

            FlickrImagesCollection = flickrImages;
            SelectedFlickrImage = FlickrImagesCollection[0];
        }
    }
}
