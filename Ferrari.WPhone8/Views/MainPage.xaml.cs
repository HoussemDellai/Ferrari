using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace Ferrari.WPhone8
{
	public partial class MainPage
	{


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

		}

		private void GoToCarsSection_Tap(object sender,
			GestureEventArgs e)
		{
			MainPanorama.DefaultItem = MainPanorama.Items[MainPanorama.Items.IndexOf(CarsPanoramaItem)];
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