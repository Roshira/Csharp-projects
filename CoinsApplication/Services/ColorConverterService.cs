using System;
using System.Globalization;
using System.Windows.Data;

namespace CoinsApplication.Services
{
    public class ColorConverterService : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double number)
            {
                return number > 0 ? "Positive" : "Negative";
            }
            return "Neutral";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
