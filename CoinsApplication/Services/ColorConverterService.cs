using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CoinsApplication.Services
{
    public class ColorConverterService : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal number)
            {
                return number > 0 ? Brushes.Green : Brushes.Red;
            }
            return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
