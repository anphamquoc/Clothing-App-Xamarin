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
    public partial class ProductInformation : ContentPage
    {
        public ProductInformation()
        {
            InitializeComponent();
        }

        private async void BackToHome_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Home");
        }
    }
}