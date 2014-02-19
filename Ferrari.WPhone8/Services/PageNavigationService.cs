using System;
using System.Windows;
using System.Windows.Navigation;
using Ferrari.Contracts;
using Microsoft.Phone.Controls;

namespace Ferrari.WindowsStore.Services
{
	public class PageNavigationService : IPageNavigationService
	{

        private PhoneApplicationFrame _mainFrame;
        public event NavigatingCancelEventHandler Navigating;

	    public void GoBack()
	    {
	        throw new NotImplementedException();
	    }

	    public void NavigateToItemDetailPage()
	    {
            if (EnsureMainFrame())
            {
                _mainFrame.Navigate(new Uri("/Views/ItemDetailsPage.xaml", UriKind.Relative));
            }
	    }

	    public void NavigateToMainPage()
	    {
	        throw new NotImplementedException();
	    }

	    public void NavigateToVideoPlayerPage()
	    {
            if (EnsureMainFrame())
            {
                _mainFrame.Navigate(new Uri("/Views/VideoPlayerPage.xaml", UriKind.Relative));
            }
	    }

        public void NavigateToVideosCollectionPage()
        {
            if (EnsureMainFrame())
            {
                _mainFrame.Navigate(new Uri("/Views/VideosCollectionPage.xaml", UriKind.Relative));
            }
        }

	    public void NavigateToAlbumPhotosPage()
	    {
            if (EnsureMainFrame())
            {
                _mainFrame.Navigate(new Uri("/Views/AlbumPhotosPage.xaml", UriKind.Relative));
            }
	    }

	    public void NavigateToAboutUsPage()
	    {
            if (EnsureMainFrame())
            {
                _mainFrame.Navigate(new Uri("/Views/AboutUsPage.xaml", UriKind.Relative));
            }
	    }

	    private bool EnsureMainFrame()
        {
            if (_mainFrame != null)
            {
                return true;
            }

            _mainFrame = Application.Current.RootVisual as PhoneApplicationFrame;

            if (_mainFrame != null)
            {
                // Could be null if the app runs inside a design tool
                _mainFrame.Navigating += (s, e) =>
                {
                    if (Navigating != null)
                    {
                        Navigating(s, e);
                    }
                };

                return true;
            }

            return false;
        }
	}
}
