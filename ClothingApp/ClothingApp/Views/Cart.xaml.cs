using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ClothingApp.Model;
using ClothingApp.Interfaces;
using ClothingApp.Helpers;
using ClothingApp.ViewModels;
using System.Windows.Input;
using Newtonsoft.Json;
using System.Net.Http;

namespace ClothingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cart : ContentPage
    {
        List<CartDetailVM> cartDetailVMs;
        private readonly CommonInterface CommonInterface = new CommonInterface();
        public long Total;
        public ICommand IncreaseQuantityCommand => new Command(IncreaseQuantity);
        public void CalculateTotal()
        {
            long Total = 0;
            foreach (var item in cartDetailVMs)
            {
                Total += item.Quantity * item.Product.Price;
            }

            this.Total = Total;
            total.Text = new ConvertToCurrencyFormat(Total.ToString()).Result;

        }
        async void IncreaseQuantity(object o) {
            CartDetailVM cartDetailVM = o as CartDetailVM;

            string productId = cartDetailVM.Product.id;
            string cartId = ((App)App.Current).CartId;
            int quantity = cartDetailVM.Quantity + 1;

            UpdateProductQuantityModel updateProductQuantityModel = new UpdateProductQuantityModel
            {
                CartId = cartId,
                ProductId = productId,
                Quantity = quantity
            };

            ApiResponse apiResponse = await CommonInterface._cartDetailRepository.UpdateQuantityProductFromCart(updateProductQuantityModel);
            if (apiResponse.success == false)
            {
                await DisplayAlert("Thông báo", apiResponse.message, "OK");
                return;
            }


            for (int i = 0; i < cartDetailVMs.Count; i++)
            {
                if (cartDetailVMs[i].Product.id == productId)
                {
                    cartDetailVMs[i].Quantity = quantity;
                }
            }

            CalculateTotal();
            listItems.ItemsSource = null;
            listItems.ItemsSource = cartDetailVMs;

        }
        public ICommand DecreaseQuantityCommand => new Command(DecreaseQuantity);
        async void DecreaseQuantity(object o)
        {
            CartDetailVM cartDetailVM = o as CartDetailVM;
            Console.WriteLine(cartDetailVM.Quantity);

            string productId = cartDetailVM.Product.id;
            string cartId = ((App)App.Current).CartId;
            int quantity = cartDetailVM.Quantity - 1 > 0 ? cartDetailVM.Quantity - 1 : 1;

            UpdateProductQuantityModel updateProductQuantityModel = new UpdateProductQuantityModel
            {
                CartId = cartId,
                ProductId = productId,
                Quantity = quantity,
            };

            ApiResponse apiResponse = await CommonInterface._cartDetailRepository.UpdateQuantityProductFromCart(updateProductQuantityModel);
            if (apiResponse.success == false)
            {
                await DisplayAlert("Thông báo", apiResponse.message, "OK");
                return;
            }


            for (int i = 0; i < cartDetailVMs.Count; i++)
            {
                if (cartDetailVMs[i].Product.id == productId)
                {
                    cartDetailVMs[i].Quantity = quantity;
                }
            }

            CalculateTotal();
            listItems.ItemsSource = null;
            listItems.ItemsSource = cartDetailVMs;
        }

        public ICommand DeleteProductFromCartCommand => new Command(DeleteProductFromCart);
        async void DeleteProductFromCart(object o)
        {
            bool check = await DisplayAlert("Thông báo", "Bạn có muốn xóa sản phẩm này không?", "Có", "Không");
            if (!check)
            {
                return;
            }
            CartDetailVM cartDetailVM = o as CartDetailVM;
            DeleteProductModel deleteProductModel = new DeleteProductModel
            {
                CartId = ((App)App.Current).CartId,
                ProductId = cartDetailVM.Product.id
            };

            ApiResponse apiResponse = await CommonInterface._cartDetailRepository.DeleteProductFromCart(deleteProductModel);
            if (apiResponse.success == false)
            {
                await DisplayAlert("Thông báo", apiResponse.message, "OK");
                return;
            }

            cartDetailVMs.Remove(cartDetailVM);
            CalculateTotal();
            listItems.ItemsSource = null;
            listItems.ItemsSource = cartDetailVMs;

        }

        public Cart()
        {
            InitializeComponent();
            this.BindingContext = new
            {
                IncreaseQuantityCommand,
                DecreaseQuantityCommand,
                DeleteProductFromCartCommand
            };

            //listItems.ItemsSource = homeItems;

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            string cartId = ((App)App.Current).CartId;
            ApiResponse apiResponse = await CommonInterface._cartDetailRepository.GetAllProductByCartId(cartId);
            Console.WriteLine(apiResponse.ToString());
            if (!apiResponse.success)
            {
                await DisplayAlert("Thông báo", apiResponse.message, "OK");
                return;
            }

            cartDetailVMs = new ConvertObject<CartDetailVM>().ConvertObjectToListData(apiResponse.data);
            CalculateTotal();
            listItems.ItemsSource = cartDetailVMs;
        }

        private async void Checkout_Btn_Clicked(object sender, EventArgs e)
        {
            if (cartDetailVMs.Count == 0)
            {
                await DisplayAlert("Thông báo", "Phải có ít nhất một sản phẩm để thanh toán", "OK");
                return;
            }
            await Shell.Current.GoToAsync($"//Checkout?Total={this.Total}");
        }
    }
}