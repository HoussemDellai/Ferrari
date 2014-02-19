using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace Ferrari.WPhone8
{
    public partial class MainPage
    {

        //public static readonly DependencyProperty NumberOfItemsSourceProperty = DependencyProperty.RegisterAttached(
        //   "NumberOfItemsSource", typeof(int), typeof(LongListSelector), new PropertyMetadata(default(int)));

        //public int NumberOfItemsSource
        //{
        //    get
        //    {
        //        return (int) GetValue(NumberOfItemsSourceProperty);
        //    }
        //    set
        //    {
        //        SetValue(NumberOfItemsSourceProperty, value);
        //    }
        //}

        // Constructor
        public MainPage()
        {
#if DEBUG
            var memory = Microsoft.Phone.Info.DeviceStatus.ApplicationCurrentMemoryUsage / (1024 * 1024);
            var limit = Microsoft.Phone.Info.DeviceStatus.ApplicationMemoryUsageLimit / (1024 * 1024);
            var peak = Microsoft.Phone.Info.DeviceStatus.ApplicationPeakMemoryUsage / (1024 * 1024);
#endif

            InitializeComponent();

#if DEBUG
            var memory1 = Microsoft.Phone.Info.DeviceStatus.ApplicationCurrentMemoryUsage / (1024 * 1024);
            var limit1 = Microsoft.Phone.Info.DeviceStatus.ApplicationMemoryUsageLimit / (1024 * 1024);
            var peak1 = Microsoft.Phone.Info.DeviceStatus.ApplicationPeakMemoryUsage / (1024 * 1024);
#endif

            MainPanorama.SelectionChanged += MainPanoramaOnSelectionChanged;
        }



        private void MainPanoramaOnSelectionChanged(object sender,
            SelectionChangedEventArgs selectionChangedEventArgs)
        {
            if (MainPanorama.SelectedItem == VideosPanoramaItem)
            {
                VideosTextBlock.Visibility = Visibility.Visible;
                VideosTitleTextBlock.Visibility = Visibility.Collapsed;
            }
            else
            {
                VideosTextBlock.Visibility = Visibility.Collapsed;
                VideosTitleTextBlock.Visibility = Visibility.Visible;
            }


            //if (MainPanorama.SelectedItem == TweetsPanoramaItem)
            //{
            //    FeaturedPanoramaItem.Margin = new Thickness(0, -40, 0, 0);
            //}
            //else if (MainPanorama.SelectedItem == FeaturedPanoramaItem)
            //{
            //    FeaturedPanoramaItem.Margin = new Thickness(-12, -40, 0, 0);
            //}
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void GoToCarsSection_Tap(object sender,
            GestureEventArgs e)
        {
            MainPanorama.DefaultItem = MainPanorama.Items[MainPanorama.Items.IndexOf(CarsPanoramaItem)];
        }

        private void GoToVideosSection_Tap(object sender,
            GestureEventArgs e)
        {
            MainPanorama.DefaultItem = MainPanorama.Items[MainPanorama.Items.IndexOf(VideosPanoramaItem)];
        }

        private void GoToRacingSection_Tap(object sender,
            GestureEventArgs e)
        {
            MainPanorama.DefaultItem = MainPanorama.Items[MainPanorama.Items.IndexOf(RacingPanoramaItem)];
        }

        private void GoToFormulaOneSection_Tap(object sender,
            GestureEventArgs e)
        {
            MainPanorama.DefaultItem = MainPanorama.Items[MainPanorama.Items.IndexOf(FormulaOnePanoramaItem)];
        }

        private void GoToNewsSection_Tap(object sender,
            GestureEventArgs e)
        {
            MainPanorama.DefaultItem = MainPanorama.Items[MainPanorama.Items.IndexOf(NewsPanoramaItem)];
        }

        private void GoToTweetsSection_Tap(object sender,
            GestureEventArgs e)
        {
            MainPanorama.DefaultItem = MainPanorama.Items[MainPanorama.Items.IndexOf(TweetsPanoramaItem)];
        }
    }
}