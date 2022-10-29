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
    public partial class User : ContentPage
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Shell.Current.GoToAsync("//ChangePassword"));
        public User()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//EditUser");
        }

        private async void Logout_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Login");
        }
    }
}