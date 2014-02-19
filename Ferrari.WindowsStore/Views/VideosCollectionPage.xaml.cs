using Windows.UI.Xaml;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Ferrari.WindowsStore.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class VideosCollectionPage
	{
		public VideosCollectionPage()
		{
			InitializeComponent();
			SizeChanged += OnSizeChanged;
		}

		private void OnSizeChanged(object sender, SizeChangedEventArgs sizeChangedEventArgs)
		{
			var pageWidth = sizeChangedEventArgs.NewSize.Width;

			if (pageWidth <= 1020)
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

        private void MediaPlayer_OnIsFullScreenChanged(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            if (MediaGrid.Margin.Left > 0)
            {
                MediaGrid.Margin = new Thickness(0);
            }
            else
            {
                MediaGrid.Margin = new Thickness(120, 140, 500, 100);
            }
        }
	}
}
