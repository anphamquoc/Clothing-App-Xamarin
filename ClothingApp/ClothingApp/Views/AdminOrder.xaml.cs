using ClothingApp.Helpers;
using ClothingApp.Interfaces;
using ClothingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClothingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminOrder : ContentPage
    {
        private readonly CommonInterface CommonInterface = new CommonInterface();
        List<OrderVM> orderVMs;
        public ICommand DeleteOrderCommand => new Command(DeleteOrder);
        async void DeleteOrder(object o)
        {
            OrderVM orderVM = o as OrderVM;
            bool check = await DisplayAlert("Thông báo", "Bạn có muốn xóa đơn hàng này không", "Có", "Không");
            if (check)
            {
                ApiResponse apiResponse = await CommonInterface._orderRepository.DeleteOrder(new Model.DeleteOrderModel
                {
                    OrderId = orderVM.id
                });

                if (apiResponse.success)
                {
                    orderVMs.Remove(orderVM);
                    listItems.ItemsSource = null;
                    listItems.ItemsSource = orderVMs;
                    return;
                }
            }
        }

        public AdminOrder()
        {
            InitializeComponent();
            BindingContext = new
            {
                DeleteOrderCommand
            };
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ApiResponse apiResponse = await CommonInterface._orderRepository.GetAllOrders();
            if (apiResponse.success == false)
            {
                await DisplayAlert("Thông báo", apiResponse.message, "OK");
                return;
            }

            orderVMs = new ConvertObject<OrderVM>().ConvertObjectToListData(apiResponse.data);
            listItems.ItemsSource = orderVMs;
        }

        private async void listItems_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            OrderVM orderVM = listItems.SelectedItem as OrderVM;
            await Shell.Current.GoToAsync($"//AdminOrderDetail?OrderId={orderVM.id}");
        }
    }
}