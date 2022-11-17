using ClothingApp.Helpers;
using ClothingApp.Interfaces;
using ClothingApp.Model;
using ClothingApp.ViewModels;
using Newtonsoft.Json;
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
    public partial class Checkout : ContentPage, IQueryAttributable
    {
        private readonly CommonInterface CommonInterface = new CommonInterface();
        public string Total;
        public Checkout()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Yield();
            string userId = ((App)App.Current).UserId;
            ApiResponse apiResponse = await CommonInterface._userRepository.GetUserById(userId);
            if (apiResponse.success == false)
            {
                await DisplayAlert("Thông báo", apiResponse.message, "OK");
                return;
            }

            UserVM userVM = new ConvertObject<UserVM>().ConvertObjectToData(apiResponse.data);
            name.Text = userVM.FullName;
            address.Text = userVM.Address;
            email.Text = userVM.Email;
            phoneNumber.Text = userVM.PhoneNumber;
            productCost.Text = new ConvertToCurrencyFormat(Total).Result;
            total.Text = new ConvertToCurrencyFormat((long.Parse(Total) + 50000).ToString()).Result; 


        }

        private async void Checkout_Btn_Clicked(object sender, EventArgs e)
        {
            ApiResponse apiResponse = await CommonInterface._orderRepository.CreateOrder(new CreateOrderModel
            {
                Address = address.Text,
                FullName = name.Text,
                Email = email.Text,
                PhoneNumber = phoneNumber.Text,
                Total = long.Parse(Total),
                UserId = ((App)App.Current).UserId,
            });

            Console.WriteLine(apiResponse.data);

            if (apiResponse.success == false)
            {
                await DisplayAlert("Thông báo", apiResponse.message, "OK");
                return;
            }

            OrderVM orderVM = new ConvertObject<OrderVM>().ConvertObjectToData(apiResponse.data);

            apiResponse = await CommonInterface._cartDetailRepository.GetAllProductByCartId(((App)App.Current).CartId);

            List<CartDetailVM> cartDetailVMs = new ConvertObject<CartDetailVM>().ConvertObjectToListData(apiResponse.data);


            foreach (var item in cartDetailVMs)
            {
                _ = await CommonInterface._orderDetailRepository.AddProductToOrder(new AddProductToOrderModel
                {
                    OrderId = orderVM.id,
                    ProductId = item.Product.id,
                    Quantity = item.Quantity,
                });

                _ = await CommonInterface._cartDetailRepository.DeleteProductFromCart(new DeleteProductModel
                {
                    CartId = ((App)App.Current).CartId,
                    ProductId = item.Product.id
                });

            }

            await Shell.Current.GoToAsync($"//CheckoutSuccess?OrderId={orderVM.id}");
        }

        private async void BackToHome_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Cart");
        }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            this.Total = query["Total"];
         }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Cart");
        }
    }
}