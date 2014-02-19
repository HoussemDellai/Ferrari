// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Ferrari.WindowsStore.Views
{
	/// <summary>
	///     An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class ItemDetailsPage
	{
		public ItemDetailsPage()
		{
			InitializeComponent();

			SizeChanged += OnSizeChanged;
		}

		private void OnSizeChanged(object sender, SizeChangedEventArgs sizeChangedEventArgs)
		{
			var pageWidth = sizeChangedEventArgs.NewSize.Width;

			if (pageWidth <= 800)
			{
				FullScreenGrid.Visibility = Visibility.Collapsed;
				SnappedGrid.Visibility = Visibility.Visible;

				MainFlipView.Width = pageWidth;
				SnappedGrid.Width = pageWidth;
			}
			else
			{
				FullScreenGrid.Visibility = Visibility.Visible;
				SnappedGrid.Visibility = Visibility.Collapsed;

				if (pageWidth < 1024)
				{
					FullScreenGrid.Margin = new Thickness(0, 60, 0, 0);
				}
			}
		}
	}
}