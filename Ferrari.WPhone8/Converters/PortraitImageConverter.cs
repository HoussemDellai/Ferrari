using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Ferrari.Models;

namespace Ferrari.Converters
{
	public class PortraitImageConverter : IValueConverter
	{
		public object Convert(object value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			var imagesCollection = value as List<FlickrImage>;

			if (imagesCollection == null) return null;

			return imagesCollection.FirstOrDefault(image => image.LargeImageWidth < image.LargeImageHeight).LargeImageUrl;
		}

		public object ConvertBack(object value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
