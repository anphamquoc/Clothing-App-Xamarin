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
    public partial class EditUser : ContentPage
    {
        CommonInterface CommonInterface = new CommonInterface();
        public EditUser()
        {
            InitializeComponent();
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();
            ApiResponse apiResponse = await CommonInterface._userRepository.GetUserById(((App)App.Current).UserId);

            if (apiResponse.success == false)
            {
                await DisplayAlert("Thông báo", apiResponse.message, "OK");
                return;
            }

            UserVM userVM = new ConvertObject<UserVM>().ConvertObjectToData(apiResponse.data);
            fullName.Text = userVM.FullName;
            address.Text = userVM.Address;
            email.Text = userVM.Email;
            phoneNumber.Text = userVM.PhoneNumber;
        }

        async private void Confirm_Clicked(object sender, EventArgs e)
        {
            string FullName = fullName.Text;
            string Address = address.Text;
            string Email = email.Text;
            string PhoneNumber = phoneNumber.Text;

            UpdateUserModel updateUserModel = new UpdateUserModel
            {
                PhoneNumber = PhoneNumber,
                Address = Address,
                Email = Email,
                FullName = FullName
            };

            ApiResponse apiResponse = await CommonInterface._userRepository.UpdateUser(((App)App.Current).UserId, updateUserModel);

            if (!apiResponse.success)
            {
                await DisplayAlert("Thông báo", apiResponse.message, "OK");
                return;
            }

            await DisplayAlert("Thông báo", apiResponse.message, "OK");
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