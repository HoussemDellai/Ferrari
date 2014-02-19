
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

namespace Ferrari.WindowsStore.UserControls
{
	public sealed partial class AnimatedImageUserControl
	{
		public static readonly DependencyProperty AnimatedImageSourceProperty = 
			DependencyProperty.RegisterAttached(
			"AnimatedImageSource", 
			typeof(string), 
			typeof(AnimatedImageUserControl),
			new PropertyMetadata("ms-appx:///Assets/Images/Novitec-Rosso-Ferrari-10.jpg", PropertyChangedCallback));

		private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			var animatedImageUserControl = dependencyObject as AnimatedImageUserControl;

			if (animatedImageUserControl == null) return;

			//animatedImageUserControl.DataContext = new BitmapImage(new Uri(dependencyPropertyChangedEventArgs.NewValue.ToString()));
			animatedImageUserControl.BackgroundImage.Source = new BitmapImage(new Uri(dependencyPropertyChangedEventArgs.NewValue.ToString()));
		}

		public AnimatedImageUserControl()
		{
			InitializeComponent();

			BackgroundImage.Source = new BitmapImage(new Uri(AnimatedImageSource));
		}

		/// <summary>
		/// Customized dependency property created to get and set the background image of the user control.
		/// </summary>
		public string AnimatedImageSource
		{
			get { return (string) GetValue(AnimatedImageSourceProperty); }
			set
			{
				SetValue(AnimatedImageSourceProperty, value);
				BackgroundImage.Source = new BitmapImage(new Uri(value));
			}
		}
	}
}
