using System;
using System.Globalization;
using System.Windows.Data;

namespace Ferrari.Converters
{
    public class IntToIncrementedIntConverter : IValueConverter
    {
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            int number;
            if (!(value is int))
                return 0;

            number = (int) value;

            return number + 1;
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
