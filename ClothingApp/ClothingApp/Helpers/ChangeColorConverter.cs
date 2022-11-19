using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ClothingApp.Helpers
{
    class ChangeColorConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            return (value as string) == "Đã giao hàng" ? Color.FromHex("#22bb33") : Color.FromHex("#FF3535");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value as string;
        }
    }
}
