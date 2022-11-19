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
    public partial class AdminProductInformation : ContentPage, IQueryAttributable
    {
        readonly CommonInterface CommonInterface = new CommonInterface();
        public string ProductId { get; set; }
        public AdminProductInformation()
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
                return;
            }

            ProductVM productVM = new ConvertObject<ProductVM>().ConvertObjectToData(apiResponse.data);

            name.Text = productVM.Name;
            description.Text = productVM.Description;
            image.Source = productVM.ImgUrl;
            price.Text = new ConvertToCurrencyFormat(productVM.Price.ToString()).Result;
            titlePage.Text = productVM.Name;

        }

        

        private async void BackToHome_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Admin//AdminProduct");
        }

        private async void EditProduct_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//EditProduct?productId={ProductId}");
        }

        private async void DeleteProduct_Clicked(object sender, EventArgs e)
        {
            bool check = await DisplayAlert("Thông báo", "Bạn có muốn xóa sản phẩm này?", "Có", "Không");
            if (check)
            {
                ApiResponse apiResponse = await CommonInterface._productRepository.DeleteProduct(ProductId);
                if (apiResponse.success)
                {
                    await DisplayAlert("Thông báo", apiResponse.message, "OK");
                    await Shell.Current.GoToAsync("//Admin//AdminProduct");
                    return;
                }
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Admin//AdminProduct");
        }
    }
}