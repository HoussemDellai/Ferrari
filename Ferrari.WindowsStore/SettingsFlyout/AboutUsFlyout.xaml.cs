// The Settings Flyout item template is documented at http://go.microsoft.com/fwlink/?LinkId=273769

using System;
using Windows.System;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace Ferrari.WindowsStore.SettingsFlyouts
{
	public sealed partial class AboutUsFlyout
	{
		public AboutUsFlyout()
		{
			InitializeComponent();
		}

		private void AboutUsFlyout_OnBackClick(object sender, BackClickEventArgs e)
		{
			if (Parent is Popup)
				(Parent as Popup).IsOpen = false;

			SettingsPane.Show();
		}

		private void Link_OnClick(object sender, RoutedEventArgs e)
		{
			Launcher.LaunchUriAsync(new Uri("http://houssemdellai.net"));
		}
	}
}
