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
using MySqlConnector;
using MySql;

namespace ClothingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Shell.Current.GoToAsync("//Register"));
        public SqlConnection sqlConnection;
        //public MySqlConnection sqlConnection;
        public Login()
        {
            InitializeComponent();
            this.BindingContext = this;
            string srvrname = "172.20.8.183";
            string srvrdbname = "clothingDB";
            string srvrusername = "sa";
            string srvrpassword = "helloanhan";

            string sqlconn = @"Data Source=LAPTOP-8OLD4A8I\SQLEXPRESS;Initial Catalog=clothingDB;User ID=sa;Password=helloanhan";
            sqlConnection = new SqlConnection(sqlconn);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string srvrname = "127.0.0.1";
            string srvrdbname = "clothingDB";
            string srvrusername = "sa";
            string srvrpassword = "helloanhan";
            string Username = username.Text;
            string Password = password.Text;


                //sqlConnection = new MySqlConnection();
                //sqlConnection.ConnectionString = "Server=127.0.0.1;Database=clothingdb;Uid=root;";
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source=.;Initial Catalog=clothingDB;User ID=sa;Password=helloanhan;";
            sqlConnection.Open();
                //sqlConnection.Open();
            

            string queryString = $"select * from users where username='{Username}' and password='{Password}'";

            //MySqlCommand sqlCommand = new MySqlCommand(queryString, sqlConnection);
            //SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);
            //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            //int Count = 0;

            //while (sqlDataReader.Read())
            //{
            //    Count += 1;
            //}

            //if (Count == 0)
            //{
            //    await DisplayAlert("Thông báo", "Tài khoản hoặc mật khẩu sai", "OK");
            //    return;
            //}

            //sqlConnection.Close();

            await Shell.Current.GoToAsync("//Home");
        }
    }
}