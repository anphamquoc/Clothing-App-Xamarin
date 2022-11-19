using ClothingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ClothingApp.Helpers
{
    class TotalPriceConverter: IValueConverter
    {
        public OrderDetailVM orderDetailVM;
        public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            OrderDetailVM orderDetailVM = value as OrderDetailVM;
            this.orderDetailVM = orderDetailVM;
            return orderDetailVM.Quantity * orderDetailVM.Product.Price;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return orderDetailVM;
        }
    }
}
