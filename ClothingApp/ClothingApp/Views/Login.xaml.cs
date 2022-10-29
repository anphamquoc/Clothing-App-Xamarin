using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ClothingApp.Model;

namespace ClothingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Shell.Current.GoToAsync("//Register"));
        public Login()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string Username = username.Text;
            string Password = password.Text;

            Connect connect = new Connect();
            SqlConnection sqlConnection = connect.Connection;

            sqlConnection.Open();

            string queryString = $"select * from dbo.users where username='{Username}' and password='{Password}'";

            SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            int Count = 0;

            while(sqlDataReader.Read())
            {
                Count += 1;
            }

            if(Count == 0)
            {
                await DisplayAlert("Thông báo", "Tài khoản hoặc mật khẩu sai", "OK");
                return;
            }

            await Shell.Current.GoToAsync("//Home");
        }
    }
}