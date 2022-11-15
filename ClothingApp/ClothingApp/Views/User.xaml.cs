using ClothingApp.Helpers;
using ClothingApp.Interfaces;
using ClothingApp.Model;
using ClothingApp.Services;
using Newtonsoft.Json;
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
        private readonly IUserRepository _userRepository = new UserService();
        public UserVM user;
        public User()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();
            ApiResponse apiResponse = await _userRepository.GetUserById(((App)App.Current).UserId);
            if (apiResponse.success == false)
            {
                await DisplayAlert("Thông báo", apiResponse.message, "OK");
                return;
            }

            //user = JsonConvert.DeserializeObject<UserVM>(apiResponse.data.ToString());
            user = new ConvertObject<UserVM>().ConvertObjectToData(apiResponse.data);

            address.Text = user.Address;
            phoneNumber.Text = user.PhoneNumber;
            email.Text = user.Email;
            fullName.Text = user.FullName;
            titleName.Text = user.FullName;
            titleEmail.Text = user.Email;

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