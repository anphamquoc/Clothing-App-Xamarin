using ClothingApp.Helpers;
using ClothingApp.Interfaces;
using ClothingApp.Model;
using ClothingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClothingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductInformation : ContentPage, IQueryAttributable
    {
        readonly CommonInterface CommonInterface = new CommonInterface();
        public string ProductId { get; set; }
        public ProductInformation()
        {
            InitializeComponent();
        }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            this.ProductId = query["productId"];
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Yield();
            ApiResponse apiResponse = await CommonInterface._productRepository.GetProductById(this.ProductId);

            if (!apiResponse.success)
            {
                await DisplayAlert("Thông báo", apiResponse.message, "OK");
                await Shell.Current.GoToAsync("//Home");
            }

            ProductVM productVM = new ConvertObject<ProductVM>().ConvertObjectToData(apiResponse.data);

            titlePage.Text = productVM.Name;
            name.Text = productVM.Name;
            description.Text = productVM.Description;
            image.Source = productVM.ImgUrl;
            price.Text = new ConvertToCurrencyFormat(productVM.Price.ToString()).Result;

        }

        

        private async void BackToHome_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Home");
        }

        private async void AddToCart_btn_Clicked(object sender, EventArgs e)
        {
            string cartId = ((App)App.Current).CartId;
            AddToCartModel addToCartModel = new AddToCartModel
            {
                CartId = cartId,
                ProductId = ProductId
            };

            ApiResponse apiResponse = await CommonInterface._cartDetailRepository.AddProductToCart(addToCartModel);

            if (!apiResponse.success)
            {
                await DisplayAlert("Thông báo", apiResponse.message, "OK");
            }

            else await DisplayAlert("Thông báo", "Thêm vào giỏ hàng thành công", "OK");

            return;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Shopping");
        }
    }
}