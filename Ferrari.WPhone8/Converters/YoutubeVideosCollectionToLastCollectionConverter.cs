using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Ferrari.Models;

namespace Ferrari.Converters
{
    /// <summary>
    /// This converter will get a list of items and return a sublist of a specified number.
    /// </summary>
    public class YoutubeVideosCollectionToLastCollectionConverter : IValueConverter
    {
        public object Convert(object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            //return value;

            try
            {
                var collection = (List<YoutubeVideo>) value;
                var numberOfItems = int.Parse((string) parameter);

                //var result = collection[0];
                var result = collection.Take(numberOfItems).ToList();

                return result;
            }
            catch (Exception)
            {
                return value;
            }


            //if (value == null || parameter == null)
            //    return value;

            //var collection = value as List<YoutubeVideo>;

            //if (collection == null || collection.Count == 0)
            //    return value;

            //if (!(parameter is string))
            //    return value;

            //var numberOfItems = int.Parse((string) parameter);

            //var result = collection.Take(numberOfItems);

            //return result;
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
