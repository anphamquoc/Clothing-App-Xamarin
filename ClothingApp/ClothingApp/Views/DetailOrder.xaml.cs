using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ClothingApp.Model;
using ClothingApp.ViewModels;
using ClothingApp.Interfaces;
using ClothingApp.Helpers;

namespace ClothingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailOrder : ContentPage, IQueryAttributable
    {
        private readonly CommonInterface commonInterface = new CommonInterface();
        public string OrderId;
        public long Total;
        public OrderVM OrderVM;
        public DetailOrder()
        {
            InitializeComponent();

            //listItems.ItemsSource = homeItems;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Yield();

            ApiResponse apiResponse = await commonInterface._orderRepository.GetAllProductByOrderId(OrderId);

            if (apiResponse.success == false)
            {
                await DisplayAlert("Thông báo", apiResponse.message, "OK");
                return;
            }

            OrderVM = new ConvertObject<OrderVM>().ConvertObjectToData(apiResponse.data);
            listItems.ItemsSource = OrderVM.OrderDetails;
            total.Text = new ConvertToCurrencyFormat(OrderVM.Total.ToString()).Result;
            fullName.Text = OrderVM.FullName;
            address.Text = OrderVM.Address;
            phoneNumber.Text = OrderVM.PhoneNumber;
            email.Text = OrderVM.Email;
            Status.Text = OrderVM.Status;
            Status.TextColor = OrderVM.Status != "Đang giao hàng" ? Color.FromHex("#22bb33") : Color.FromHex("#FF3535");
        }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            OrderId = query["OrderId"];
        }

        private async void GoBack_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Order");
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Order");
        }
    }
}