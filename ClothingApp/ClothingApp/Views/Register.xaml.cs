using ClothingApp.Helpers;
using ClothingApp.Interfaces;
using ClothingApp.Model;
using ClothingApp.Services;
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
    public partial class Register : ContentPage
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Shell.Current.GoToAsync("//Login"));
        CommonInterface CommonInterface = new CommonInterface();
        public Register()
        {
            InitializeComponent();
            this.BindingContext = this;
            username.Text = "";
            password.Text = "";
            rePassword.Text = "";
        }

        private async void Register_btn_Clicked(object sender, EventArgs e)
        {
            string usernameString = username.Text;
            string passwordString = password.Text;
            string rePasswordString = rePassword.Text;

            Console.WriteLine(passwordString, rePasswordString);

            if (!string.Equals(passwordString, rePasswordString))
            {
                await DisplayAlert("Thông báo", "Mật khẩu và nhập lại mật khẩu phải trùng với nhau", "OK");
                return;
            }

            ApiResponse apiResponse = await CommonInterface._userRepository.Register(new UserRegisterModel
            {
                Username = usernameString,
                Password = passwordString
            });

            UserVM userVM = new ConvertObject<UserVM>().ConvertObjectToData(apiResponse.data);

            if (!apiResponse.success)
            {
                await DisplayAlert("Thông báo", apiResponse.message, "OK");
                return;
            }

            ((App)App.Current).UserId = userVM.id.ToString();
            ((App)App.Current).Role = userVM.Role;
            apiResponse = await CommonInterface._cartRepository.CreateCart(((App)App.Current).UserId);
            CartVM cartVM = new ConvertObject<CartVM>().ConvertObjectToData(apiResponse.data);
            ((App)App.Current).CartId = cartVM.id;
            await DisplayAlert("Thông báo", "Đăng ký thành công", "OK");

            await Shell.Current.GoToAsync("//Home");
        }
    }
}