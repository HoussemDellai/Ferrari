using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Ferrari.Models;

namespace Ferrari.WindowsStore
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        private double _pageWidth;
        private double _pageHeight;

        public MainPage()
        {

            InitializeComponent();

            SizeChanged += OnSizeChanged;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs sizeChangedEventArgs)
        {
            _pageWidth = sizeChangedEventArgs.NewSize.Width;
            _pageHeight = sizeChangedEventArgs.NewSize.Height;

            if (_pageWidth <= 620)
            {
                FullScreenGrid.Visibility = Visibility.Collapsed;
                SnappedGrid.Visibility = Visibility.Visible;
            }
            else
            {
                FullScreenGrid.Visibility = Visibility.Visible;
                SnappedGrid.Visibility = Visibility.Collapsed;
            }
        }

        private async void GridViewItemZoomedOut_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainSemanticZoom.IsZoomedInViewActive = true;

            await Task.Delay(200);

            var sectionName = string.Empty;

            var textBlock = e.OriginalSource as TextBlock;
            if (textBlock != null)
            {
                sectionName = textBlock.Text;
            }
            else
            {
                var grid = e.OriginalSource as Grid;
                if (grid != null)
                {
                    sectionName = grid.DataContext as String;
                }
            }

            if (sectionName == "")
                return;

            switch (sectionName)
            {
                case "Featured":
                    MainHub.ScrollToSection(MainHub.Sections[0]);
                    break;
                case "Cars":
                    MainHub.ScrollToSection(MainHub.Sections[1]);
                    break;
                case "News":
                    MainHub.ScrollToSection(MainHub.Sections[2]);
                    break;
                case "Formula 1":
                    MainHub.ScrollToSection(MainHub.Sections[3]);
                    break;
                case "Racing":
                    MainHub.ScrollToSection(MainHub.Sections[4]);
                    break;
                case "Videos":
                    MainHub.ScrollToSection(MainHub.Sections[5]);
                    break;
                case "Tweets":
                    MainHub.ScrollToSection(MainHub.Sections[6]);
                    break;
            }
        }

        private void Image_OnLoaded(object sender, RoutedEventArgs e)
        {
            var featuredImage = sender as Image;

            if (featuredImage == null)
                return;

            var flickrImage = featuredImage.DataContext as FlickrImage;

            if (flickrImage == null)
                return;

            if (flickrImage.LargeImageWidth != null
                && flickrImage.LargeImageHeight != null)
            {
                featuredImage.Width = (double) (_pageHeight * flickrImage.LargeImageWidth / flickrImage.LargeImageHeight);
            }
            else
            {
                featuredImage.Width = _pageHeight * 4 / 3;
            }
        }
    }
}
