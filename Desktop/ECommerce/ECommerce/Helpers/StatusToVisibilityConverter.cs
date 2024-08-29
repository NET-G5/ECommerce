using ECommerce.Models;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ECommerce.Helpers
{
    public class StatusToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (OrderStatus)value;
            if (status is OrderStatus.Refunded || status is OrderStatus.Canceled)
            {
                return Visibility.Collapsed;    
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
