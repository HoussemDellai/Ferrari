using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace Ferrari.WindowsStore.Converters
{
	public class StringToImageUrlConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var str = value as string;

            var imageUrl = "ms-appx://" + str;	// Images/CarsManifacturers/BMW.png

			return imageUrl;

				//return string.Format("{0}" + str + "{1}", "Images/CarsManifacturers/", ".png");	// Images/CarsManifacturers/BMW.png
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
