using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Data;
using Ferrari.Models;

namespace Ferrari.WindowsStore.Converters
{
    public class CollectionToLastCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                var collection = (List<Item>) value;
                var numberOfItems = int.Parse((string) parameter);

                return collection.Take(numberOfItems);
            }
            catch (Exception)
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
