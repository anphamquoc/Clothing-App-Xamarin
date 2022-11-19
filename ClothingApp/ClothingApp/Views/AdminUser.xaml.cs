using ClothingApp.Helpers;
using ClothingApp.Interfaces;
using ClothingApp.Model;
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
    public partial class AdminUser : ContentPage
    {
        private readonly CommonInterface commonInterface = new CommonInterface();
        public ICommand DeleteUserCommand => new Command(DeleteUser);
        List<UserVM> userVMs;
        List<UserVM> searchUserVMs;
        async void DeleteUser(object o)
        {
            UserVM userVM = o as UserVM;
            bool check = await DisplayAlert("Thông báo", "Bạn có muốn xóa người dùng này", "Có", "Không");
            if (check == true)
            {
                ApiResponse apiResponse = await commonInterface._userRepository.DeleteUser(userVM.id.ToString());
                if (apiResponse.success)
                {
                    userVMs.Remove(userVM);
                    listItems.ItemsSource = null;
                    listItems.ItemsSource = userVMs;
                }
                else
                {
                    await DisplayAlert("Thông báo", apiResponse.message, "OK");
                    return;
                }
            }
        }
        public AdminUser()
        {
            InitializeComponent();
            BindingContext = new
            {
                DeleteUserCommand,
            };
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ApiResponse apiResponse = await commonInterface._userRepository.GetAllUsers();
            if (apiResponse.success == false)
            {
                await DisplayAlert("Thông báo", apiResponse.message, "OK");
                return;
            }

            userVMs = new ConvertObject<UserVM>().ConvertObjectToListData(apiResponse.data);

            listItems.ItemsSource = userVMs;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchUserVMs = new List<UserVM>();
            string query = SearchBar.Text;
            foreach(var item in userVMs)
            {
                if (item.Username.ToLower().Contains(query.ToLower()))
                {
                    searchUserVMs.Add(item);
                }
            }

            if (query.Length == 0)
            {
                searchResult.Text = "Tất cả người dùng";
            }
            else searchResult.Text = $"Tìm thấy {searchUserVMs.Count} kết quả";

            listItems.ItemsSource = null;
            listItems.ItemsSource = searchUserVMs;
        }
    }
}