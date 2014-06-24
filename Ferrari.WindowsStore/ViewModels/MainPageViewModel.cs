using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel;
using Ferrari.Contracts;
using Ferrari.Models;
using Ferrari.Utilities;
using Ferrari.Configurations;
using Ferrari.WindowsStore.Contracts;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.Unity;
using System.ComponentModel;

namespace Ferrari.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Private fields

        private readonly IItemsService _dataService;
        private readonly IFlickrService _flickrService;
        private readonly IImagesRepository _imagesRepository;
        private readonly IItemsRepository _itemsRepository;
        private readonly IPageNavigationService _pageNavigationService;
        private readonly ITweetsRepository _tweetsRepository;
        private readonly ITweetsService _tweetsService;
        private readonly IUnityContainer _unityContainer;
        private readonly IVideosRepository _videosRepository;
        private readonly IVideosService _youtubeChannelService;
        private List<Item> _carsCollection;
        private List<FlickrImage> _flickrImagesCollection;
        private List<Item> _formulaOneCollection;
        private bool _isLoadingData;
        private RelayCommand _navigateToAlbumPhotosPageCommand;
        private RelayCommand _navigateToCarsPageCommand;
        private RelayCommandGeneric<Item> _navigateToDetailsPageCommand;
        private RelayCommand _navigateToFormula1PageCommand;
        private RelayCommand _navigateToNewsPageCommand;
        private RelayCommand _navigateToRacingPageCommand;
        private ICommand _navigateToVideoPlayerPageCommand;
        private RelayCommandGeneric<YoutubeVideo> _navigateToVideosCollectionPageCommand;
        private ICommand _navigateToCarSpecificationPageCommand;
        private List<Item> _newsCollection;
        private List<Item> _racingCollection;
        private RelayCommand _refreshDataCommand;
        private List<Tweet> _tweetsCollection;
        private List<YoutubeVideo> _youtubeVideosCollection;
        private ICarsRepository _carsRepository;
        private List<Car> _carModelsCollection;

        #endregion

        #region Public Properties

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

        public List<YoutubeVideo> YoutubeVideosCollection
        {
            get
            {
                return _youtubeVideosCollection;
            }
            set
            {
                _youtubeVideosCollection = value;
                OnPropertyChanged();
            }
        }

        public List<Tweet> TweetsCollection
        {
            get
            {
                return _tweetsCollection;
            }
            set
            {
                _tweetsCollection = value;
                OnPropertyChanged();
            }
        }

        public List<Item> NewsCollection
        {
            get
            {
                return _newsCollection;
            }
            set
            {
                _newsCollection = value;
                OnPropertyChanged();
            }
        }

        public List<Item> FormulaOneCollection
        {
            get
            {
                return _formulaOneCollection;
            }
            set
            {
                _formulaOneCollection = value;
                OnPropertyChanged();
            }
        }

        public List<Item> CarsCollection
        {
            get
            {
                return _carsCollection;
            }
            set
            {
                _carsCollection = value;
                OnPropertyChanged();
            }
        }

        public List<Item> RacingCollection
        {
            get
            {
                return _racingCollection;
            }
            set
            {
                _racingCollection = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoadingData
        {
            get
            {
                return _isLoadingData;
            }
            set
            {
                _isLoadingData = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public RelayCommand NavigateToCarsPageCommand
        {
            get
            {
                if (_navigateToCarsPageCommand == null)
                {
                    _navigateToCarsPageCommand = new RelayCommand(() =>
                    {
                        _unityContainer.RegisterInstance(RacingCollection);
                        _pageNavigationService.NavigateToItemDetailPage();
                    });
                }
                return _navigateToCarsPageCommand;
            }
        }

        public RelayCommand NavigateToRacingPageCommand
        {
            get
            {
                if (_navigateToRacingPageCommand == null)
                {
                    _navigateToRacingPageCommand = new RelayCommand(() =>
                    {
                        _unityContainer.RegisterInstance(RacingCollection);
                        _pageNavigationService.NavigateToItemDetailPage();
                    });
                }
                return _navigateToRacingPageCommand;
            }
        }

        public RelayCommand NavigateToNewsPageCommand
        {
            get
            {
                if (_navigateToNewsPageCommand == null)
                {
                    _navigateToNewsPageCommand = new RelayCommand(() =>
                    {
                        _unityContainer.RegisterInstance(NewsCollection);
                        _pageNavigationService.NavigateToItemDetailPage();
                    });
                }
                return _navigateToNewsPageCommand;
            }
        }

        public RelayCommand NavigateToFormula1PageCommand
        {
            get
            {
                if (_navigateToFormula1PageCommand == null)
                {
                    _navigateToFormula1PageCommand = new RelayCommand(() =>
                    {
                        _unityContainer.RegisterInstance(FormulaOneCollection);
                        _pageNavigationService.NavigateToItemDetailPage();
                    });
                }
                return _navigateToFormula1PageCommand;
            }
        }

        public ICommand NavigateToCarSpecificationPageCommand
        {
            get
            {
                if (_navigateToCarSpecificationPageCommand == null)
                {
                    _navigateToCarSpecificationPageCommand = new RelayCommandGeneric<Car>(car =>
                    {
                        if (car != null)
                        {
                            _unityContainer.RegisterInstance(car);
                            _pageNavigationService.NavigateToCarSpecificationPage();
                        }
                    });
                }
                return _navigateToCarSpecificationPageCommand;
            }
        }

        public RelayCommand NavigateToAlbumPhotosPageCommand
        {
            get
            {
                if (_navigateToAlbumPhotosPageCommand == null)
                {
                    _navigateToAlbumPhotosPageCommand = new RelayCommand(() =>
                    {
                        if (FlickrImagesCollection != null)
                        {
                            _unityContainer.RegisterInstance(FlickrImagesCollection);
                            _pageNavigationService.NavigateToAlbumPhotosPage();
                        }
                    });
                }
                return _navigateToAlbumPhotosPageCommand;
            }
        }

        public RelayCommandGeneric<YoutubeVideo> NavigateToVideosCollectionPageCommand
        {
            get
            {
                if (_navigateToVideosCollectionPageCommand == null)
                {
                    _navigateToVideosCollectionPageCommand = new RelayCommandGeneric<YoutubeVideo>(NavigateToVideosCollectionPage);
                }
                return _navigateToVideosCollectionPageCommand;
            }
        }

        public ICommand NavigateToVideoPlayerPageCommand
        {
            get
            {
                if (_navigateToVideoPlayerPageCommand == null)
                {
                    _navigateToVideoPlayerPageCommand = new RelayCommandGeneric<YoutubeVideo>(video =>
                    {
                        if (video == null)
                            return;

                        _unityContainer.RegisterInstance(video);
                        _unityContainer.RegisterInstance(YoutubeVideosCollection);
                        _pageNavigationService.NavigateToVideoPlayerPage();
                    });
                }
                return _navigateToVideoPlayerPageCommand;
            }
        }

        public RelayCommandGeneric<Item> NavigateToDetailsPageCommand
        {
            get
            {
                if (_navigateToDetailsPageCommand == null)
                {
                    _navigateToDetailsPageCommand = new RelayCommandGeneric<Item>(NavigateToDetailsPage);
                }
                return _navigateToDetailsPageCommand;
            }
        }

        public RelayCommand RefreshDataCommand
        {
            get
            {
                if (_refreshDataCommand == null)
                {
                    _refreshDataCommand = new RelayCommand(async () =>
                    {
                        await InitializeAllDataAsync();
                    });
                }
                return _refreshDataCommand;
            }
        }

        public List<Car> CarModelsCollection
        {
            get
            { return _carModelsCollection; }
            set
            {
                _carModelsCollection = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructor

        public MainPageViewModel(
            IPageNavigationService pageNavigationService,
            IItemsService dataService,
            ITweetsService tweetsService,
            IVideosService youtubeChannelService,
            ISettingsService settingsService,
            IUnityContainer unityContainer,
            IItemsRepository itemsRepository,
            ITweetsRepository tweetsRepository,
            IImagesRepository imagesRepository,
            IVideosRepository videosRepository,
            ICarsRepository carsRepository,
            IFlickrService flickrService,
            ISharingService sharingService)
            : base(
                sharingService,
                pageNavigationService,
                unityContainer)
        {
            _pageNavigationService = pageNavigationService;
            _dataService = dataService;
            _tweetsService = tweetsService;
            _youtubeChannelService = youtubeChannelService;
            _unityContainer = unityContainer;
            _itemsRepository = itemsRepository;
            _tweetsRepository = tweetsRepository;
            _imagesRepository = imagesRepository;
            _videosRepository = videosRepository;
            _flickrService = flickrService;
            _carsRepository = carsRepository;

            //CarModelsCollection = carsRepository.GetAll();

#if WINDOWS_PHONE
            if (DesignerProperties.IsInDesignTool)
#else // !WINDOWS_PHONE
			if (DesignMode.DesignModeEnabled)
#endif
            {
                //InitializeDataForDesignMode();
                InitializeDataFromOnlineAsync();
            }
        }

        #endregion

        public async Task InitializeAllDataAsync()
        {
            IsLoadingData = true;

            try
            {
                await StartInitializeDataAsync();
                await ContinueInitializeDataAsync();
            }
            catch (Exception)
            {
            }
            finally
            {
                IsLoadingData = false;
            }
        }

        /// <summary>
        ///     Will start downloading minimum data required to show content.
        /// </summary>
        /// <returns></returns>
        public async Task StartInitializeDataAsync()
        {

            //#if WINDOWS_PHONE
            //           //await InitializeDataFromOfflineAsync();
            //           //await InitializeDataFromOnlineAsync();
            //#else

            SendLoadedDataPercentageMessageToSplashScreen(10);

            FlickrImagesCollection = await _flickrService.GetFlickrImagesAsync(Constants.FlickrLink);

            if (FlickrImagesCollection == null || FlickrImagesCollection.Count == 0)
            {
                FlickrImagesCollection = await _imagesRepository.GetFlickrImagesCollectionAsync();
            }
            else //if (FlickrImagesCollection != null)
            {
                await _imagesRepository.SaveFlickrImagesCollectionAsync(FlickrImagesCollection);
            }

            SendLoadedDataPercentageMessageToSplashScreen(20);

            CarModelsCollection = _carsRepository.GetAll();

            SendLoadedDataPercentageMessageToSplashScreen(30);

            CarsCollection = await _dataService.GetItemsAsync(Constants.CarsLink);

            if (CarsCollection == null || CarsCollection.Count == 0)
            {
                CarsCollection = await _itemsRepository.GetItemsCollectionByCategoryAsync(Constants.SectionNames[1]);
            }
            else //if (CarsCollection != null)
            {
                await _itemsRepository.SaveItemsCollectionAsync(CarsCollection);
            }

            SendLoadedDataPercentageMessageToSplashScreen(50);

            NewsCollection = await _dataService.GetItemsAsync(Constants.NewsLink);

            if (NewsCollection == null || NewsCollection.Count == 0)
            {
                NewsCollection = await _itemsRepository.GetItemsCollectionByCategoryAsync(Constants.SectionNames[2]);
            }
            else
            {
                await _itemsRepository.SaveItemsCollectionAsync(NewsCollection);
            }

            SendLoadedDataPercentageMessageToSplashScreen(80);

#if DEBUG
#if WINDOWS_PHONE || SILVERLIGHT
            var memory = Microsoft.Phone.Info.DeviceStatus.ApplicationCurrentMemoryUsage / (1024 * 1024);
            var limit = Microsoft.Phone.Info.DeviceStatus.ApplicationMemoryUsageLimit / (1024 * 1024);
            var peak = Microsoft.Phone.Info.DeviceStatus.ApplicationPeakMemoryUsage / (1024 * 1024);
#endif
#endif

            ContinueInitializeDataAsync();
            //#endif
        }

        /// <summary>
        ///     Will continue downloading the rest of the data.
        /// </summary>
        /// <returns></returns>
        public async Task ContinueInitializeDataAsync()
        {
            IsLoadingData = true;

            FormulaOneCollection = await _dataService.GetItemsAsync(Constants.FormulaOneLink);

            if (FormulaOneCollection == null || FormulaOneCollection.Count == 0)
            {
                FormulaOneCollection =
                    await _itemsRepository.GetItemsCollectionByCategoryAsync(Constants.SectionNames[3]);
            }
            else
            {
                await _itemsRepository.SaveItemsCollectionAsync(FormulaOneCollection);
            }

            RacingCollection = await _dataService.GetItemsAsync(Constants.RacingLink);

            if (RacingCollection == null || RacingCollection.Count == 0)
            {
                RacingCollection = await _itemsRepository.GetItemsCollectionByCategoryAsync(Constants.SectionNames[4]);
            }
            else
            {
                await _itemsRepository.SaveItemsCollectionAsync(RacingCollection);
            }

            YoutubeVideosCollection = await _youtubeChannelService.GetYoutubeVideosAsync("", 20);

            if (YoutubeVideosCollection == null || YoutubeVideosCollection.Count == 0)
            {
                YoutubeVideosCollection = await _videosRepository.GetVideosCollectionAsync();
            }
            else
            {
                await _videosRepository.SaveVideosCollectionAsync(YoutubeVideosCollection);
            }

            TweetsCollection = await _tweetsService.GetTweetsAsync("@FerrariMagazine", "Ferrari", 20);

            if (TweetsCollection == null || TweetsCollection.Count == 0)
            {
                TweetsCollection = await _tweetsRepository.GetTweetsCollectionAsync();
            }
            else
            {
                await _tweetsRepository.SaveTweetsCollectionAsync(TweetsCollection);
            }

            IsLoadingData = false;

#if DEBUG
#if WINDOWS_PHONE
            var memory = Microsoft.Phone.Info.DeviceStatus.ApplicationCurrentMemoryUsage / (1024 * 1024);
            var limit = Microsoft.Phone.Info.DeviceStatus.ApplicationMemoryUsageLimit / (1024 * 1024);
            var peak = Microsoft.Phone.Info.DeviceStatus.ApplicationPeakMemoryUsage / (1024 * 1024);
#endif
#endif
        }

        /// <summary>
        /// Used only for design time data.
        /// </summary>
        /// <returns></returns>
        private async Task InitializeDataFromOnlineAsync()
        {
            FlickrImagesCollection = await _flickrService.GetFlickrImagesAsync(Constants.FlickrLink);

            CarModelsCollection = _carsRepository.GetAll();

            CarsCollection = await _dataService.GetItemsAsync(Constants.CarsLink);

            FormulaOneCollection = await _dataService.GetItemsAsync(Constants.FormulaOneLink);

            NewsCollection = await _dataService.GetItemsAsync(Constants.NewsLink);

            RacingCollection = await _dataService.GetItemsAsync(Constants.RacingLink);

            TweetsCollection = await _tweetsService.GetTweetsAsync("@FerrariMagazine", "Ferrari", 20);

            YoutubeVideosCollection = await _youtubeChannelService.GetYoutubeVideosAsync("", 20);
        }

        private void NavigateToVideosCollectionPage(YoutubeVideo youtubeVideo)
        {

            if (youtubeVideo == null)
                return;

            _unityContainer.RegisterInstance(youtubeVideo);
            _unityContainer.RegisterInstance(YoutubeVideosCollection);

            _pageNavigationService.NavigateToVideosCollectionPage();
        }

        private void NavigateToDetailsPage(Item item)
        {

            if (item == null)
                return;

            var items = new List<Item>();

            if (FormulaOneCollection != null && FormulaOneCollection.Contains(item))
            {
                items = FormulaOneCollection;
            }
            else if (NewsCollection != null && NewsCollection.Contains(item))
            {
                items = NewsCollection;
            }
            else if (RacingCollection != null && RacingCollection.Contains(item))
            {
                items = RacingCollection;
            }
            else if (CarsCollection != null && CarsCollection.Contains(item))
            {
                items = CarsCollection;
            }

            if (items == null)
                return;

            _unityContainer.RegisterInstance(item);
            _unityContainer.RegisterInstance(items);

            _pageNavigationService.NavigateToItemDetailPage();
        }

        private void InitializeDataForDesignMode()
        {
            var itemDesign = new Item
            {
                Title = "Even more astonishing figures for classic Ferraris",
                Description =
                    "Maranello – What’s worth more, a Picasso painting or a Ferrari car? When one is talking of masterpieces, it’s hard to give a precise answer.",
                TextNews =
                    "What’s worth more, a Picasso painting or a Ferrari car? When one is talking of masterpieces, it’s hard to give a precise answer. However, it’s a fact that recent prices reached by classic Ferraris in auctions around the world are truly amazing. There was further confirmation of that yesterday, when a 1964 250 LM went for US$14.3 million at the “Art of the Automobile” auction organised by RM Auction in collaboration with Sotheby’s in New York. &lt;BR>&lt;BR>Back in August, at the Pebble Beach auction, a 275 GTB/4 S NART Spider went for 27.5 million dollars and a 250 LM was also the object of a fierce bidding war between several buyers. However, the price of 52 million dollars that were paid for a 250 GTO is still unbeaten as the highest price ever paid, not just for a Maranello car, but any road car. &lt;BR>&lt;BR>The 250 LM that went under the hammer yesterday in New York was initially destined for road use, but when, in 1968, it was bought by two Ecuadorians, Guillermo Ortega and Fausto Merello, who were part of the Raceco team, it was transformed into a race car. The South American duo used the car in the most important endurance race on the American continent, taking the class win and eighth overall in the 1969 Daytona 24 Hours.",
                //ImageUrl = "http://www.ferrari.com/Site_Collection_Image_260x200/131122_newsGT_130164car_260x200.jpg",
                ImageUrl = "ms-appx:///Assets/Images/small.png"
            };

            var items = new List<Item>
			{
				itemDesign,
				itemDesign,
				itemDesign,
				itemDesign,
				itemDesign,
				itemDesign
			};

            CarModelsCollection = _carsRepository.GetAll();

            FlickrImagesCollection = new List<FlickrImage>
			{
				new FlickrImage
				{
					Title = "Ferrari 100 millia",
					LargeImageUrl = "http://farm8.staticflickr.com/7401/8855562948_2104e9d9c0_b.jpg",
				},
			};

            NewsCollection = items;
            NewsCollection = items;
            RacingCollection = items;
            FormulaOneCollection = items;
        }

        public async Task InitializeDataFromOfflineAsync()
        {
            FlickrImagesCollection = await _imagesRepository.GetFlickrImagesCollectionAsync();

            CarModelsCollection = _carsRepository.GetAll();

            FormulaOneCollection = await _itemsRepository.GetItemsCollectionByCategoryAsync(Constants.SectionNames[3]);

            NewsCollection = await _itemsRepository.GetItemsCollectionByCategoryAsync(Constants.SectionNames[2]);

            RacingCollection = await _itemsRepository.GetItemsCollectionByCategoryAsync(Constants.SectionNames[4]);

            CarsCollection = await _itemsRepository.GetItemsCollectionByCategoryAsync(Constants.SectionNames[1]);

            TweetsCollection = await _tweetsRepository.GetTweetsCollectionAsync();

            YoutubeVideosCollection = await _videosRepository.GetVideosCollectionAsync();
        }

        private void SendLoadedDataPercentageMessageToSplashScreen(int percentage)
        {
            Messenger.Default.Send(percentage);
        }
    }
}