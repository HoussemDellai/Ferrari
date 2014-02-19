// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

using System;
using Windows.UI.Xaml;

namespace Ferrari.WindowsStore.Views
{
	/// <summary>
	/// A basic page that provides characteristics common to most applications.
	/// </summary>
	public sealed partial class AlbumPhotosPage
	{
		public AlbumPhotosPage()
		{
			InitializeComponent();

			var dispatcherTimer = new DispatcherTimer
			{
				Interval = new TimeSpan(0, 0, 3)
			};
			dispatcherTimer.Tick += ShowNextFlipViewItem_OnTick;
			dispatcherTimer.Start();
		}

		private void ShowNextFlipViewItem_OnTick(object sender, object o)
		{
			if (MainFlipView.Items == null)
				return;

			if (MainFlipView.SelectedIndex == MainFlipView.Items.Count - 1)
			{
				MainFlipView.SelectedItem = MainFlipView.Items[0];
			}
			else if (MainFlipView.SelectedIndex < MainFlipView.Items.Count - 1)
			{
				MainFlipView.SelectedItem = MainFlipView.Items[MainFlipView.SelectedIndex + 1];
			}
		}
	}
}
