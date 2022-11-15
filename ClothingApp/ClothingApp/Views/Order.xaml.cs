using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ClothingApp.Model;
using ClothingApp.Interfaces;
using ClothingApp.ViewModels;
using ClothingApp.Helpers;

namespace ClothingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Order : ContentPage
    {
        CommonInterface CommonInterface = new CommonInterface();
        public Order()
        {
            InitializeComponent();

            //listItems.ItemsSource = orderItems;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ApiResponse apiResponse = await CommonInterface._orderRepository.GetAllOrderByUserId(((App)App.Current).UserId);
            if (apiResponse.success == false)
            {
                await DisplayAlert("Thông báo", apiResponse.message, "OK");
                return;
            }

            List<OrderVM> orderVMs = new ConvertObject<OrderVM>().ConvertObjectToListData(apiResponse.data);
            listItems.ItemsSource = orderVMs;
        }

        private async void listItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            OrderVM orderVM = listItems.SelectedItem as OrderVM;
            await Shell.Current.GoToAsync($"//DetailOrder?OrderId={orderVM.id}");
        }
    }
}