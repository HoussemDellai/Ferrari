
using Ferrari.Contracts;
using Ferrari.DesignTimeData;
using Ferrari.Repositories;
using Ferrari.Services;
using Ferrari.ViewModels;
using Ferrari.WindowsStore.Contracts;
using Ferrari.WindowsStore.DAL;
using Ferrari.WindowsStore.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Ferrari.Configurations
{
    public class ViewModelFactory
    {
        /// <summary>
        ///     Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        static ViewModelFactory()
        {
            // code with unity container

            var container = new UnityContainer();

            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));

            container.RegisterInstance(typeof (IUnityContainer), container);

            container.RegisterType<IItemsService, ItemsService>();

            container.RegisterType<IPageNavigationService, PageNavigationService>();

            container.RegisterType<IFlickrService, FlickrService>();

            container.RegisterType<ITweetsService, TweetsService>();

            container.RegisterType<IVideosService, VideosService>();

            container.RegisterType<ISettingsService, SettingsService>();

            container.RegisterType<IItemsRepository, ItemsRepository>();

            container.RegisterType<IImagesRepository, ImagesRepository>();

            container.RegisterType<IVideosRepository, VideosRepository>();

            container.RegisterType<ITweetsRepository, TweetsRepository>();

            container.RegisterType<ILockScreenService, LockScreenService>();

            container.RegisterType<IContactsService, ContactsService>();

#if WINDOWS_PHONE
            if (System.ComponentModel.DesignerProperties.IsInDesignTool)
            {
                container.RegisterType<ILiveTileService, LiveTileServiceDesignTimeData>();
            }
            else
            {
                container.RegisterType<ILiveTileService, LiveTileService>();
            }
#else
            container.RegisterType<ILiveTileService, LiveTileService>();
#endif

            container.RegisterType<ISharingService, SharingService>();

            //Singleton
            container.RegisterType<MainPageViewModel>(new ContainerControlledLifetimeManager());

            //container.RegisterType<ItemDetailViewModel>(new ContainerControlledLifetimeManager());

            //ServiceLocator.Current.GetInstance<ItemDetailViewModel>();

#if WINDOWS_PHONE || SILVERLIGHT
            if (System.ComponentModel.DesignerProperties.IsInDesignTool)
#endif

#if NETFX_CORE
            // if (DesignMode.DesignModeEnabled)
#endif
            {
                RegisterInstancesForDesignMode(container);
            }
        }

        public MainPageViewModel MainPage
        {
            get { return ServiceLocator.Current.GetInstance<MainPageViewModel>(); }
        }

        public ItemDetailsPageViewModel ItemDetailsPage
        {
            get { return ServiceLocator.Current.GetInstance<ItemDetailsPageViewModel>(); }
        }

        public VideosCollectionPageViewModel VideosCollectionPage
        {
            get { return ServiceLocator.Current.GetInstance<VideosCollectionPageViewModel>(); }
        }

        public AlbumPhotosPageViewModel AlbumPhotosPage
        {
            get { return ServiceLocator.Current.GetInstance<AlbumPhotosPageViewModel>(); }
        }

        public SplashScreenPageViewModel SplashScreenPage
        {
            get { return ServiceLocator.Current.GetInstance<SplashScreenPageViewModel>(); }
        }

        public AboutUsViewModel AboutUsPage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AboutUsViewModel>();
            }
        }

        private static void RegisterInstancesForDesignMode(IUnityContainer container)
        {
            container.RegisterInstance(ItemDesignTimeData.ItemsCollectionDesign);
            container.RegisterInstance(ItemDesignTimeData.ItemDesign);
            container.RegisterInstance(ItemDesignTimeData.FlickrImagesCollectionDesign);
            container.RegisterInstance(ItemDesignTimeData.Videos);
        }
    }
}