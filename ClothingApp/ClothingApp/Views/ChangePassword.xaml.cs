using ClothingApp.Helpers;
using ClothingApp.Interfaces;
using ClothingApp.Model;
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
    public partial class ChangePassword : ContentPage
    {
        public CommonInterface CommonInterface = new CommonInterface();
        public ChangePassword()
        {
            InitializeComponent();
        }

        private async void Confirm_Clicked(object sender, EventArgs e)
        {
            string Password = password.Text;
            string NewPassword = newPassword.Text;
            string ReNewPassword = reNewPassword.Text;

            if (NewPassword != ReNewPassword)
            {
                await DisplayAlert("Thông báo", "Mật khẩu mới không khớp với trường nhập lại mật khẩu mới", "OK");
                return;
            }

            ChangeUserPasswordModel changeUserPasswordModel = new ChangeUserPasswordModel
            {
                Password = Password,
                NewPassword = NewPassword
            };

            ApiResponse apiResponse = await CommonInterface._userRepository.ChangeUserPassword(((App)App.Current).UserId, changeUserPasswordModel);

            if (apiResponse.success == false)
            {
                await DisplayAlert("Thông báo", apiResponse.message, "OK");
                return;
            }

            await DisplayAlert("Thông báo", "Đổi mật khẩu thành công", "OK");
            await Shell.Current.GoToAsync("//User");
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//User");
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//User");
        }
    }
}