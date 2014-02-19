using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Ferrari.WindowsStore.Converters
{
	public class BooleanToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (! (value is bool)) return false;

			var isTrue = (bool) value;

			if (isTrue)
			{
				return Visibility.Visible;
			}
			
			return Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
