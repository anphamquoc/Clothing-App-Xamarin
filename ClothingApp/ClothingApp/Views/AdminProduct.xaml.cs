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
    public partial class AdminProduct : ContentPage
    {
        private readonly CommonInterface commonInterface = new CommonInterface();
        List<ProductVM> productVMs;
        List<ProductVM> searchProduct;
        public ICommand TapCommand => new Command(async () =>
        {
            await Shell.Current.GoToAsync("//EditProduct");
        });
        public AdminProduct()
        {
            InitializeComponent();
            BindingContext = new
            {
                TapCommand
            };
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ApiResponse apiResponse = await commonInterface._productRepository.GetAllProducts();
            if (apiResponse.success == false)
            {
                await DisplayAlert("Thông báo", apiResponse.message, "OK");
                return;
            }
            productVMs = new ConvertObject<ProductVM>().ConvertObjectToListData(apiResponse.data);
            navigationCollection.ItemsSource = productVMs;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchBarText = SearchBar.Text;
            searchProduct = new List<ProductVM>();
            foreach (var item in productVMs)
            {
                if (item.Name.ToLower().Contains(searchBarText.ToLower()))
                {
                    searchProduct.Add(item);
                }
            }
            if (searchBarText.Length == 0)
            {
                searchResult.Text = "Tất cả sản phẩm";
            }
            else searchResult.Text = $"Tìm thấy {searchProduct.Count} kết quả";
            navigationCollection.ItemsSource = null;
            navigationCollection.ItemsSource = searchProduct;
        }

        private async void navigationCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductVM productVM = navigationCollection.SelectedItem as ProductVM;

            await Shell.Current.GoToAsync($"//AdminProductInformation?productId={productVM.id}");
        }
    }
}