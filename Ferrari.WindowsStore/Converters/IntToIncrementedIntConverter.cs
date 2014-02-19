using System;
using Windows.UI.Xaml.Data;

namespace Ferrari.Converters
{
	public class IntToIncrementedIntConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			int number;
			if (!(value is int)) return 0;

			number = (int) value;

			return number + 1;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
