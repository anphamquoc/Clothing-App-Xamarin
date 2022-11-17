using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ClothingApp.Model;
using System.Net.Http;
using Newtonsoft.Json;
using ClothingApp.Interfaces;
using ClothingApp.Helpers;
using ClothingApp.Services;
using ClothingApp.ViewModels;

namespace ClothingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Shell.Current.GoToAsync("//Register"));
        //public MySqlConnection sqlConnection;
        private readonly CommonInterface CommonInterface = new CommonInterface();
        public Login()
        {
            InitializeComponent();
            this.BindingContext = this;
            username.Text = "";
            password.Text = "";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string Username = username.Text;
            string Password = password.Text;

            ApiResponse apiResponse = await CommonInterface._userRepository.Login(new UserLoginModel
            {
                Username = Username,
                Password = Password
            });

            if (apiResponse.success== false)
            {
                await DisplayAlert("Thông báo", apiResponse.message, "OK");
                return;
            }

            UserVM user = JsonConvert.DeserializeObject<UserVM>(apiResponse.data.ToString());
            apiResponse = await CommonInterface._cartRepository.GetCartByUserId(user.id.ToString());

            if (apiResponse.success == false) {
                await DisplayAlert("Thông báo", apiResponse.message, "OK");
                return;
            }

            CartVM cartVM = new ConvertObject<CartVM>().ConvertObjectToData(apiResponse.data);

            ((App)App.Current).UserId = user.id.ToString();
            ((App)App.Current).CartId = cartVM.id;
            ((App)App.Current).Role = user.Role;

            MessagingCenter.Send<Object, string>(this, "sendRole", user.Role);

            await DisplayAlert("Thông báo", "Đăng nhập thành công", "OK");
            
            await Shell.Current.GoToAsync("//Home");
        }
    }
}