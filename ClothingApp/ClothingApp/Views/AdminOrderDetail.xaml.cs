using ClothingApp.Helpers;
using ClothingApp.Interfaces;
using ClothingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClothingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminOrderDetail : ContentPage, IQueryAttributable
    {
        private readonly CommonInterface commonInterface = new CommonInterface();
        public string OrderId;
        public OrderVM orderVM = new OrderVM();
        public AdminOrderDetail()
        {
            InitializeComponent();
        }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            OrderId = query["OrderId"];
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

            orderVM = new ConvertObject<OrderVM>().ConvertObjectToData(apiResponse.data);

            listItems.ItemsSource = orderVM.OrderDetails;
            fullName.Text = orderVM.FullName;
            address.Text = orderVM.Address;
            phoneNumber.Text = orderVM.PhoneNumber;
            email.Text = orderVM.Email;
            total.Text = new ConvertToCurrencyFormat(orderVM.Total.ToString()).Result;            Status.Text = orderVM.Status;
            Status.TextColor = orderVM.Status != "Đang giao hàng" ? Color.FromHex("#22bb33") : Color.FromHex("#FF3535");
            ChangeStatus.IsEnabled = orderVM.Status == "Đang giao hàng";
        }

        private async void GoBack_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Admin//AdminOrder");
        }

        private async void ChangeStatus_Clicked(object sender, EventArgs e)
        {
            bool check = await DisplayAlert("Thông báo", "Bạn có muốn thay đổi tình trạng đơn hàng này", "Có", "Không");
            if (check)
            {
                ApiResponse apiResponse = await commonInterface._orderRepository.UpdateStatus(new Model.UpdateStatusOrderModel
                {
                    OrderId = orderVM.id,
                    Status = "Đã giao hàng"
                });

                if (apiResponse.success == false)
                {
                    await DisplayAlert("Thông báo", apiResponse.message, "OK");
                    return;
                }

                await DisplayAlert("Thông báo", apiResponse.message, "OK");
                orderVM.Status = "Đã giao hàng";
                Status.Text = orderVM.Status;
                Status.TextColor = orderVM.Status != "Đang giao hàng" ? Color.FromHex("#22bb33") : Color.FromHex("#FF3535");
                ChangeStatus.IsEnabled = orderVM.Status == "Đang giao hàng";
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Admin//AdminOrder");
        }
    }
}