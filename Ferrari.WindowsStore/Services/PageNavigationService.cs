using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Ferrari.Contracts;
using Ferrari.Utilities;
using Ferrari.ViewModels;
using Ferrari.WindowsStore.Views;
using Ferrari.Utilities;

namespace Ferrari.WindowsStore.Services
{
	public class PageNavigationService : IPageNavigationService
	{

		public RelayCommand GoBackCommand { get; set; }

		public PageNavigationService()
		{
			GoBackCommand = new RelayCommand(GoBack);
		}

		public int BackStackDepth
		{
			get
			{
				var frame = ((Frame) Window.Current.Content);
				return frame.BackStackDepth;
			}
		}

		public String CurrentPageType
		{
			get
			{
				var frame = ((Frame) Window.Current.Content);
				return frame.CurrentSourcePageType.Name;
			}
		}

		public bool CanGoBack
		{
			get
			{
				var frame = ((Frame) Window.Current.Content);
				return frame.CanGoBack;
			}
		}

		public void GoBack()
		{
			var frame = (Frame) Window.Current.Content;

			if (frame.CanGoBack)
			{
				frame.GoBack();
			}
		}

		public void GoForward()
		{
			var frame = ((Frame) Window.Current.Content);

			if (frame.CanGoForward)
			{
				frame.GoForward();
			}
		}

		public void Navigate(Type sourcePageType)
		{
			((Frame) Window.Current.Content).Navigate(sourcePageType);
		}

		public void Navigate(Type sourcePageType, object parameter)
		{
			var frame = (Frame) Window.Current.Content;
			if (frame == null)
			{
				frame = new Frame();
			}
			frame.Navigate(sourcePageType, parameter);
		}

		public void GoHome()
		{
			var frame = ((Frame) Window.Current.Content);

			while (frame.CanGoBack)
			{
				frame.GoBack();
			}
		}

		public void Navigate(string pageKey)
		{
			Navigate(pageKey, null);
		}

		public void NavigateToItemDetailPage()
		{

			Navigate(typeof(ItemDetailsPage));
		}

		public void NavigateToMainPage()
		{
			Navigate(typeof(MainPage));
		}

		//public void NavigateToSectionItemDetailsPage()
		//{
		//	Navigate(typeof(SectionItemDetailsPage));
		//}

		//public void NavigateToMapAgenciesPage()
		//{
		//	Navigate(typeof(MapAgenciesPage));
		//}

		public void Navigate(string pageKey, object parameter)
		{
			switch (pageKey)
			{
				case "ItemDetailsPage":
					Navigate(typeof(ItemDetailsPage), parameter);
					break;

				case "MainPage":
					Navigate(typeof(MainPage), parameter);
					break;

				//case "SectionItemDetailsPage":
				//	Navigate(typeof(SectionItemDetailsPage), parameter);
				//	break;

				//case "MapAgenciesPage":
				//	Navigate(typeof(MapAgenciesPage), parameter);
				//	break;
			}
		}

		public void NavigateToAlbumPhotosPage()
		{
			Navigate(typeof(AlbumPhotosPage));
		}

	    public void NavigateToAboutUsPage()
	    {
            Navigate(typeof(AboutUsPage));
	    }

        public void NavigateToVideoPlayerPage()
        {
            Navigate(typeof(VideosCollectionPage));
        }

        public void NavigateToVideosCollectionPage()
        {
            Navigate(typeof(VideosCollectionPage));
        }

		public void NavigateToCarSpecificationPage()
		{
			//Navigate(typeof(VideosCollectionPage));
		}
	}
}
