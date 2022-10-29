using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ClothingApp.Model;

namespace ClothingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Order : ContentPage
    {
        public Order()
        {
            InitializeComponent();

            List<OrderItem> orderItems = new List<OrderItem> {
                new OrderItem("Order 001", "28/07/2001", 2000, "Đang giao hàng"),
                new OrderItem("Order 001", "28/07/2001", 2000, "Đang giao hàng"),
                new OrderItem("Order 001", "28/07/2001", 2000, "Đang giao hàng"),
                new OrderItem("Order 001", "28/07/2001", 2000, "Đang giao hàng")
            };

            listItems.ItemsSource = orderItems;
        }

        private async void listItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Shell.Current.GoToAsync("//DetailOrder");
        }
    }
}