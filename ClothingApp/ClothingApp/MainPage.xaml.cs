using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ClothingApp.Model;

namespace ClothingApp
{
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<Object, string>(this, "sendRole", (sender, args) =>
            {
                adminPage.IsVisible = args == "admin";
            });
        }
    }
}
