using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ClothingApp.Model;
using ClothingApp.Helpers;
using ClothingApp.Interfaces;
using ClothingApp.Services;
using ClothingApp.ViewModels;

namespace ClothingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Shopping : ContentPage
    {
        private readonly IProductRepository _productRepository = new ProductService();
        List<ProductVM> productVMs;
        List<ProductVM> searchProduct;
        public Shopping()
        {
            InitializeComponent();

        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();
            ApiResponse apiResponse = await _productRepository.GetAllProducts();

            if (apiResponse.success == false) {
                await DisplayAlert("Thông báo", apiResponse.message, "OK");
                return;

            }

            productVMs = new ConvertObject<ProductVM>().ConvertObjectToListData(apiResponse.data);

            navigationCollection.ItemsSource = productVMs;
        }

        private async void navigationCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductVM productVM = navigationCollection.SelectedItem as ProductVM;
            await Shell.Current.GoToAsync($"//ProductInformation?productId={productVM.id}");
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchBarText = SearchBar.Text;
            searchProduct = new List<ProductVM>();
            foreach(var item in productVMs)
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
    }
}