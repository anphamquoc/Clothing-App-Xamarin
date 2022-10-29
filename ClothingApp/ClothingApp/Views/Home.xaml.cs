using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ClothingApp.Model;
using System.Windows.Input;

namespace ClothingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Shell.Current.GoToAsync("//Cart"));
        public ICommand FilterItem => new Command<string>(async (url) => await Shell.Current.GoToAsync("//Cart"));
        public List<HomeItem> homeItems;
        public Home()
        {
            InitializeComponent();

            homeItems = new List<HomeItem> {
                new HomeItem("dress_icon.png", "Dress"),
                new HomeItem("long_sleeve_shirt_icon.png", "Shirt"),
                new HomeItem("pant_icon.png", "Pants"),
                new HomeItem("shirt_icon.png", "T-Shirt")
            };

            this.BindingContext = this;

            navigationCarousel.ItemsSource = homeItems;
        }

        private async void navigationCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(1);
            await Shell.Current.GoToAsync("//Favourite");
        }

        private async void navigationCarousel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await Shell.Current.GoToAsync("//ProductInformation");
        }
    }
}