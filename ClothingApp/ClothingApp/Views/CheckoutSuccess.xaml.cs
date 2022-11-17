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
    public partial class CheckoutSuccess : ContentPage, IQueryAttributable
    {
        IDictionary<string, string> query;
        public CheckoutSuccess()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Yield();
        }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            this.query = query;
        }

        private async void BackToHome_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Home");
        }

        private async void OrderDetail_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//DetailOrder?OrderId={query["OrderId"]}");
        }
    }
}