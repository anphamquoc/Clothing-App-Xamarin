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
    public partial class Checkout : ContentPage
    {
        public Checkout()
        {
            InitializeComponent();
        }

        private async void Checkout_Btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//CheckoutSuccess");
        }

        private async void BackToHome_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Cart");
        }
    }
}