using ClothingApp.Helpers;
using ClothingApp.Interfaces;
using ClothingApp.Model;
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
    public partial class AdminEditProduct : ContentPage, IQueryAttributable
    {
        private readonly CommonInterface commonInterface = new CommonInterface();
        public string ProductId;
        public AdminEditProduct()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Yield();

            if (ProductId == null)
            {
                Name.Text = "";
                Description.Text = "";
                Price.Text = "";
                ImgUrl.Text = "";
                titlePage.Text = "Thêm sản phẩm";
                return;
            }

            titlePage.Text = "Sửa sản phẩm";
            ApiResponse apiResponse = await commonInterface._productRepository.GetProductById(ProductId);
            if (apiResponse.success == false)
            {
                await DisplayAlert("Thông báo", apiResponse.message, "OK");
                return;
            }

            ProductVM productVM = new ConvertObject<ProductVM>().ConvertObjectToData(apiResponse.data);

            Name.Text = productVM.Name;
            Description.Text = productVM.Description;
            Price.Text = productVM.Price.ToString();
            ImgUrl.Text = productVM.ImgUrl;
        }

        private async void Confirm_Clicked(object sender, EventArgs e)
        {
            string name = Name.Text;
            string description = Description.Text;
            string imgUrl = ImgUrl.Text;
            string price = Price.Text;

            if (ProductId == null)
            {
                ApiResponse apiReponse = await commonInterface._productRepository.AddNewProduct(new AddProductModel
                {
                    Name = name,
                    Description = description,
                    ImgUrl = imgUrl,
                    Price = long.Parse(price),
                });

                if (apiReponse.success == false)
                {
                    await DisplayAlert("Thông báo", apiReponse.message, "OK");
                    return;
                }

                await DisplayAlert("Thông báo", "Thêm thành công", "OK");
                await Shell.Current.GoToAsync("//Admin//AdminProduct");
                return;
            }

            ApiResponse apiResponse = await commonInterface._productRepository.UpdateProduct(ProductId, new UpdateProductModel { 
                Name = name,
                Description = description,
                ImgUrl = imgUrl,
                Price = long.Parse(price)
            });

            if (apiResponse.success == false)
            {
                await DisplayAlert("Thông báo", apiResponse.message, "OK");
                return;
            }

            await DisplayAlert("Thông báo", apiResponse.message, "OK");
            await Shell.Current.GoToAsync($"//AdminProductInformation?productId={ProductId}");
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            if (ProductId == null)
            {
                await Shell.Current.GoToAsync("//Admin//AdminProduct");
                return;
            }
            await Shell.Current.GoToAsync($"//AdminProductInformation?productId={ProductId}");
        }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            ProductId = query.ContainsKey("productId") ? query["productId"] : null;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (ProductId == null)
            {
                await Shell.Current.GoToAsync("//Admin//AdminProduct");
                return;
            }
            await Shell.Current.GoToAsync($"//AdminProductInformation?productId={ProductId}");
        }
    }
}