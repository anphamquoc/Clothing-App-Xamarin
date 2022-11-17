using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ClothingApp.Model;
using System.Windows.Input;
using ClothingApp.Helpers;
using ClothingApp.Interfaces;
using ClothingApp.Services;
using ClothingApp.ViewModels;
using Newtonsoft.Json;

namespace ClothingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Shell.Current.GoToAsync("//Shopping"));
        public ICommand FilterItem => new Command<string>(async (url) => await Shell.Current.GoToAsync("//Cart"));
        private readonly IProductRepository _productRepository = new ProductService();
        public Home()
        {
            InitializeComponent();

            this.BindingContext = this;
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();
            ApiResponse apiResponse = await _productRepository.GetAllProducts();
            if (apiResponse.success == false)
            {
                await DisplayAlert("Thông báo", apiResponse.message, "OK");
                return;
            }
            List<ProductVM> productVMs = new ConvertObject<ProductVM>().ConvertObjectToListData(apiResponse.data);

            navigationCarousel.ItemsSource = productVMs.GetRange(0, productVMs.Count > 4 ? 4 : productVMs.Count);    
        }

        private async void navigationCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await Shell.Current.GoToAsync("//Favourite");
        }

        private async void navigationCarousel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductVM productVM = navigationCarousel.SelectedItem as ProductVM;
            await Shell.Current.GoToAsync($"//ProductInformation?productId={productVM.id}");
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Shopping");
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Cart");
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Order");
        }

        private async void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//User");
        }
    }
}